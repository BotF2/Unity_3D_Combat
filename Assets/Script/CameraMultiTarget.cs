﻿using Assets.Script;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
	public class CameraMultiTarget : MonoBehaviour
	{
		public float Pitch;
		public float Yaw;
		public float Roll;
		public float PaddingLeft = 210f;
		public float PaddingRight = 210f;
		public float PaddingUp = 210f;
		public float PaddingDown = 210f;
		public float MoveSmoothTime = 0.19f;
		private Camera _camera;
		public Camera _shipCamera;
		private float _shipCameraFieldOfView;
		public GameObject _cameraHolder;
		private GameObject[] _targets = new GameObject[0];
		private DebugProjection _debugProjection;

		#region added to cameraMuliTararget
		public F_Animator3 f_animator3;
		public E_Animator1 e_animator1;
		private Vector3 _cameraOffSet;
		public float _warpInTimer = 5f;
		private bool _warpingIn = true;
		private bool _spaceKey = false;
		private bool _alreadyAutoRotated = false;
		private bool _firstTimeMouseRotate = true;
		public bool _normalizeFieldOfView = false;
		private float _autoRotationTimer = 5f;
		private float _rotationDirectionTimer = 2f;
		public Vector3 _cameraTarget;
		public float _mouseRotationSpeed = 5.0f;
		public bool turningPositiveX = true;
		//public bool turningPositiveY = true;
		public float RotateSmoothTime = 0.1f;
		private float AngularVelocity = 0.0f;
		#endregion

		enum DebugProjection { DISABLE, IDENTITY, ROTATED }
		enum ProjectionEdgeHits { TOP_BOTTOM, LEFT_RIGHT }

        public void SetTargets(GameObject[] targets)
        {
			_targets = targets;
        }

        private void Awake()
		{
			_camera = Camera.main; // give gameObject(camera) and unity Camera.main the same position and rotation at end of LateUpdate
			
            //_camera = gameObject.GetComponent<Camera>(); // not working
            _debugProjection = DebugProjection.ROTATED;
			_shipCameraFieldOfView = _shipCamera.fieldOfView;
		}

		private void LateUpdate()
		{
            if (_targets.Length == 0)
            {
                return;
            }
			var targetPositionAndRotation = TargetPositionAndRotation(_targets);

			if (Input.GetKey("space") && !_warpingIn)
			{
				_spaceKey = true;
				_autoRotationTimer = 5.0f;
			}
			else if(!_warpingIn)
            {
				_spaceKey = false;

            }
			Vector3 velocity = Vector3.zero;
			if (_warpingIn || !_spaceKey)
			{
				if (_autoRotationTimer > 0)
				{
					if ( _autoRotationTimer < 4.5f)
					{
						if (_alreadyAutoRotated && _autoRotationTimer > 2.5f && !_normalizeFieldOfView) 
                        {
							_shipCamera.fieldOfView = _shipCamera.fieldOfView - 0.05f;
						}
						if (_autoRotationTimer < 2.5f)
							_normalizeFieldOfView = true;
                        if (_normalizeFieldOfView)
                        {
							// normalize shipcamera field of view
                            if (_shipCamera.fieldOfView <= _shipCameraFieldOfView + 0.5f)
                            {
                                _shipCamera.fieldOfView += 0.05f;
                            }
                            else if (_shipCamera.fieldOfView > _shipCameraFieldOfView - 0.5f)
                            {
                                _shipCamera.fieldOfView -= 0.05f;
                            }
							if (_autoRotationTimer < 1f)
								_normalizeFieldOfView = false;
                        }			
                    }
					
					_cameraOffSet = gameObject.transform.position - _cameraTarget;
					gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPositionAndRotation.Position, ref velocity, MoveSmoothTime);

					var target_rot = Quaternion.LookRotation(_cameraTarget - gameObject.transform.position); //_cameraTarget.transform.position
					var delta = Quaternion.Angle(gameObject.transform.rotation, target_rot);
					if (delta > 0.0f)
					{
						var t = Mathf.SmoothDampAngle(delta, 0.0f, ref AngularVelocity, RotateSmoothTime);
						t = 1f - t / delta;
						gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, target_rot, t);
					}
					if (_warpInTimer <= 0.0f)
						_warpingIn = false;
					else _warpInTimer -= Time.deltaTime;
					if (!_warpingIn && !_spaceKey)
					{
						_autoRotationTimer -= Time.deltaTime;
					}
				}
                else
                {
					// autoratation code
					_firstTimeMouseRotate = true;
					_alreadyAutoRotated = true;

					float xRotation = 0.05f;
					float yRotation = 0.1f;
					if (_rotationDirectionTimer < 2f)
					{
						_shipCamera.fieldOfView = _shipCamera.fieldOfView + 0.05f;
					}
                    if (_rotationDirectionTimer <= 0)
						{
							_rotationDirectionTimer = 2f;
							_autoRotationTimer = 5f;
						}
						AutoRotation(xRotation, Vector3.right);

					_rotationDirectionTimer -= Time.deltaTime;
					gameObject.transform.LookAt(_cameraTarget);					
				}
			}
			else
			{
				// this 'else' is spacebar key is down so rotate with mouse
				_normalizeFieldOfView = true;
				Quaternion cameraTurnAngleX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * _mouseRotationSpeed, Vector3.up);
				_cameraOffSet = cameraTurnAngleX * _cameraOffSet;
				Vector3 newPositionX = _cameraTarget + _cameraOffSet;
				gameObject.transform.position = Vector3.Slerp(gameObject.transform.position, newPositionX, MoveSmoothTime);
				Quaternion cameraTurnAngleY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * _mouseRotationSpeed, Vector3.right);
				_cameraOffSet = cameraTurnAngleY * _cameraOffSet;
				Vector3 newPositionY = _cameraTarget + _cameraOffSet;
				gameObject.transform.position = Vector3.Slerp(gameObject.transform.position, newPositionY, MoveSmoothTime);
				gameObject.transform.LookAt(_cameraTarget);
				if (_firstTimeMouseRotate)
				{
					_autoRotationTimer = 5f;
					_firstTimeMouseRotate = false;
                }
			}
			_camera.transform.position = gameObject.transform.position;
			_camera.transform.rotation = gameObject.transform.rotation;
		}

        // Added method for from Rotation around target
        #region Auto Rotation around average target
        private void AutoRotation(float xRotating, Vector3 direction)
        {
            Quaternion cameraTurnAngleX = Quaternion.AngleAxis(xRotating * _mouseRotationSpeed, direction);
            _cameraOffSet = cameraTurnAngleX * _cameraOffSet;
            Vector3 newPositionX = _cameraTarget + _cameraOffSet;
			gameObject.transform.position = Vector3.Slerp(gameObject.transform.position, newPositionX, MoveSmoothTime);
		}
        #endregion
        PositionAndRotation TargetPositionAndRotation(GameObject[] targets)
		{
			_cameraTarget = calculateCentroid(targets);
			float halfVerticalFovRad = (_camera.fieldOfView * Mathf.Deg2Rad) / 2f;
			float halfHorizontalFovRad = Mathf.Atan(Mathf.Tan(halfVerticalFovRad) * _camera.aspect);

			var rotation = Quaternion.Euler(Pitch, Yaw, Roll);
			var inverseRotation = Quaternion.Inverse(rotation);

			var targetsRotatedToCameraIdentity = targets.Select(target => inverseRotation * target.transform.position).ToArray();

			float furthestPointDistanceFromCamera = targetsRotatedToCameraIdentity.Max(target => target.z);
			float projectionPlaneZ = furthestPointDistanceFromCamera + 3f;

			ProjectionHits viewProjectionLeftAndRightEdgeHits =
				ViewProjectionEdgeHits(targetsRotatedToCameraIdentity, ProjectionEdgeHits.LEFT_RIGHT, projectionPlaneZ, halfHorizontalFovRad).AddPadding(PaddingRight, PaddingLeft);
			ProjectionHits viewProjectionTopAndBottomEdgeHits =
				ViewProjectionEdgeHits(targetsRotatedToCameraIdentity, ProjectionEdgeHits.TOP_BOTTOM, projectionPlaneZ, halfVerticalFovRad).AddPadding(PaddingUp, PaddingDown); 

			var requiredCameraPerpedicularDistanceFromProjectionPlane =
				Mathf.Max(
					RequiredCameraPerpedicularDistanceFromProjectionPlane(viewProjectionTopAndBottomEdgeHits, halfVerticalFovRad),
					RequiredCameraPerpedicularDistanceFromProjectionPlane(viewProjectionLeftAndRightEdgeHits, halfHorizontalFovRad)
			);

			Vector3 cameraPositionIdentity = new Vector3(
				(viewProjectionLeftAndRightEdgeHits.Max + viewProjectionLeftAndRightEdgeHits.Min) / 2f,
				(viewProjectionTopAndBottomEdgeHits.Max + viewProjectionTopAndBottomEdgeHits.Min) / 2f,
				projectionPlaneZ - requiredCameraPerpedicularDistanceFromProjectionPlane);

			DebugDrawProjectionRays(cameraPositionIdentity,
				viewProjectionLeftAndRightEdgeHits,
				viewProjectionTopAndBottomEdgeHits,
				requiredCameraPerpedicularDistanceFromProjectionPlane,
				targetsRotatedToCameraIdentity,
				projectionPlaneZ,
				halfHorizontalFovRad,
				halfVerticalFovRad);

			return new PositionAndRotation(rotation * cameraPositionIdentity, rotation);
		}

		private static float RequiredCameraPerpedicularDistanceFromProjectionPlane(ProjectionHits viewProjectionEdgeHits, float halfFovRad)
		{
			float distanceBetweenEdgeProjectionHits = viewProjectionEdgeHits.Max - viewProjectionEdgeHits.Min;
			return (distanceBetweenEdgeProjectionHits / 2f) / Mathf.Tan(halfFovRad);
		}

		private ProjectionHits ViewProjectionEdgeHits(IEnumerable<Vector3> targetsRotatedToCameraIdentity, ProjectionEdgeHits alongAxis, float projectionPlaneZ, float halfFovRad)
		{
			float[] projectionHits = targetsRotatedToCameraIdentity
				.SelectMany(target => TargetProjectionHits(target, alongAxis, projectionPlaneZ, halfFovRad))
				.ToArray();
			return new ProjectionHits(projectionHits.Max(), projectionHits.Min());
		}

		private float[] TargetProjectionHits(Vector3 target, ProjectionEdgeHits alongAxis, float projectionPlaneDistance, float halfFovRad)
		{
			float distanceFromProjectionPlane = projectionPlaneDistance - target.z;
			float projectionHalfSpan = Mathf.Tan(halfFovRad) * distanceFromProjectionPlane;

			if (alongAxis == ProjectionEdgeHits.LEFT_RIGHT)
			{
				return new[] {target.x + projectionHalfSpan, target.x - projectionHalfSpan};
			}
			else
			{
				return new[] {target.y + projectionHalfSpan, target.y - projectionHalfSpan};
			}

		}

		private void DebugDrawProjectionRays(Vector3 cameraPositionIdentity, ProjectionHits viewProjectionLeftAndRightEdgeHits,
			ProjectionHits viewProjectionTopAndBottomEdgeHits, float requiredCameraPerpedicularDistanceFromProjectionPlane,
			IEnumerable<Vector3> targetsRotatedToCameraIdentity, float projectionPlaneZ, float halfHorizontalFovRad,
			float halfVerticalFovRad)
		{

			if (_debugProjection == DebugProjection.DISABLE)
				return;

			DebugDrawProjectionRay(
				cameraPositionIdentity,
				new Vector3((viewProjectionLeftAndRightEdgeHits.Max - viewProjectionLeftAndRightEdgeHits.Min) / 2f,
					(viewProjectionTopAndBottomEdgeHits.Max - viewProjectionTopAndBottomEdgeHits.Min) / 2f,
					requiredCameraPerpedicularDistanceFromProjectionPlane), new Color32(31, 119, 180, 255));
			DebugDrawProjectionRay(
				cameraPositionIdentity,
				new Vector3((viewProjectionLeftAndRightEdgeHits.Max - viewProjectionLeftAndRightEdgeHits.Min) / 2f,
					-(viewProjectionTopAndBottomEdgeHits.Max - viewProjectionTopAndBottomEdgeHits.Min) / 2f,
					requiredCameraPerpedicularDistanceFromProjectionPlane), new Color32(31, 119, 180, 255));
			DebugDrawProjectionRay(
				cameraPositionIdentity,
				new Vector3(-(viewProjectionLeftAndRightEdgeHits.Max - viewProjectionLeftAndRightEdgeHits.Min) / 2f,
					(viewProjectionTopAndBottomEdgeHits.Max - viewProjectionTopAndBottomEdgeHits.Min) / 2f,
					requiredCameraPerpedicularDistanceFromProjectionPlane), new Color32(31, 119, 180, 255));
			DebugDrawProjectionRay(
				cameraPositionIdentity,
				new Vector3(-(viewProjectionLeftAndRightEdgeHits.Max - viewProjectionLeftAndRightEdgeHits.Min) / 2f,
					-(viewProjectionTopAndBottomEdgeHits.Max - viewProjectionTopAndBottomEdgeHits.Min) / 2f,
					requiredCameraPerpedicularDistanceFromProjectionPlane), new Color32(31, 119, 180, 255));

			foreach (var target in targetsRotatedToCameraIdentity)
			{
				float distanceFromProjectionPlane = projectionPlaneZ - target.z;
				float halfHorizontalProjectionVolumeCircumcircleDiameter = Mathf.Sin(Mathf.PI - ((Mathf.PI / 2f) + halfHorizontalFovRad)) / (distanceFromProjectionPlane);
				float projectionHalfHorizontalSpan = Mathf.Sin(halfHorizontalFovRad) / halfHorizontalProjectionVolumeCircumcircleDiameter;
				float halfVerticalProjectionVolumeCircumcircleDiameter = Mathf.Sin(Mathf.PI - ((Mathf.PI / 2f) + halfVerticalFovRad)) / (distanceFromProjectionPlane);
				float projectionHalfVerticalSpan = Mathf.Sin(halfVerticalFovRad) / halfVerticalProjectionVolumeCircumcircleDiameter;

				DebugDrawProjectionRay(target,
					new Vector3(projectionHalfHorizontalSpan, 0f, distanceFromProjectionPlane),
					new Color32(214, 39, 40, 255));
				DebugDrawProjectionRay(target,
					new Vector3(-projectionHalfHorizontalSpan, 0f, distanceFromProjectionPlane),
					new Color32(214, 39, 40, 255));
				DebugDrawProjectionRay(target,
					new Vector3(0f, projectionHalfVerticalSpan, distanceFromProjectionPlane),
					new Color32(214, 39, 40, 255));
				DebugDrawProjectionRay(target,
					new Vector3(0f, -projectionHalfVerticalSpan, distanceFromProjectionPlane),
					new Color32(214, 39, 40, 255));
			}
		}

		private void DebugDrawProjectionRay(Vector3 start, Vector3 direction, Color color)
		{
			Quaternion rotation = _debugProjection == DebugProjection.IDENTITY ? Quaternion.identity : gameObject.transform.rotation;
			Debug.DrawRay(rotation * start, rotation * direction, color);
		}

		public Vector3 calculateCentroid(GameObject[] centerPoints)
		{
			var centroid = new Vector3(0, 0, 0);
			var numPoints = centerPoints.Count();
			foreach (var point in centerPoints)
			{
				centroid += point.transform.position;
			}

			centroid /= numPoints;

			return centroid;
		}
	}
}


