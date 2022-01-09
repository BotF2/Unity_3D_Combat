using Assets.Script;
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
		public float PaddingUp = 200f;
		public float PaddingDown = 200f;
		public float MoveSmoothTime = 0.19f;
		private Camera _camera;
		public GameObject _cameraHolder;
		private GameObject[] _targets = new GameObject[0];
		private DebugProjection _debugProjection;

		#region added to cameraMuliTararget
		private bool _didNotGetTargetYet = true;
		private Vector3 _cameraOffSet;
		public float _targetTimer = 0.5f;
		private float _autoTimer = 7f;
		public GameObject _cameraTarget;
		public bool _lookAtTarget = true;
		public bool _rotateAroundTarget = true;
		public float _mouseRotationSpeed = 5.0f;
		public bool turningPositiveX = true;
		public bool turningPositiveY = true;
		public float RotateSmoothTime = 0.1f;
		private float AngularVelocity = 0.0f;
		#endregion

		enum DebugProjection { DISABLE, IDENTITY, ROTATED }
		enum ProjectionEdgeHits { TOP_BOTTOM, LEFT_RIGHT }

        public void SetTargets(GameObject[] targets)
        {
            _targets = targets; // 2 empty dummy gameObjects as targets located where 3D ships warp in.
        }

        private void Awake()
		{
			_camera = Camera.main;
			
            //_camera = gameObject.GetComponent<Camera>(); // not working
            _debugProjection = DebugProjection.ROTATED;
			//_targetTimer = 0.5f; // now set as a field above and not part of cameraMultiTarget
			//_cameraTarget = 
		}

		private void LateUpdate()
		{
            // ToDo: get a combat updater to reset _targets GameObject Array as ships are distroyed!!!
            if (_targets.Length == 0)
            {
                return;
            }

            var targetPositionAndRotation = TargetPositionAndRotation(_targets); // *** see new location for these lines code in below region
			Vector3 velocity = Vector3.zero;
			
			if (Input.GetKey("space")) // use GetKey for holding key down, GetKeyDown() is for one frame of pressed
			{
				Quaternion cameraTurnAngleX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * _mouseRotationSpeed, Vector3.up);
				_cameraOffSet = cameraTurnAngleX * _cameraOffSet;
				Vector3 newPositionX = _cameraTarget.transform.position + _cameraOffSet;
				gameObject.transform.position = Vector3.Slerp(gameObject.transform.position, newPositionX, MoveSmoothTime);
				Quaternion cameraTurnAngleY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * _mouseRotationSpeed, Vector3.right);
				_cameraOffSet = cameraTurnAngleY * _cameraOffSet;
				Vector3 newPositionY = _cameraTarget.transform.position + _cameraOffSet;
				gameObject.transform.position = Vector3.Slerp(gameObject.transform.position, newPositionY, MoveSmoothTime);
				gameObject.transform.LookAt(_cameraTarget.transform);

				// ToDo: get a value for _cameraTarget.transform.position.z based on the number of ship columns deep into screen

			}
			else
			{
				gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPositionAndRotation.Position, ref velocity, MoveSmoothTime);

				var target_rot = Quaternion.LookRotation(_cameraTarget.transform.position - gameObject.transform.position); 
				var delta = Quaternion.Angle(gameObject.transform.rotation, target_rot);
				if (delta > 0.0f)
                {
					var t = Mathf.SmoothDampAngle(delta, 0.0f, ref AngularVelocity, RotateSmoothTime);
					t = 1.0f - t / delta;
					gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, target_rot, t);
                }
			}	


			//_camera.transform.position = gameObject.transform.position;
			//_camera.transform.rotation = gameObject.transform.rotation;

            #region RotateAroundTarget Also added to cameraMultiTarget



            //       if (true) // ( GameManager.Instance._statePassedCombatInit) //_targetTimer < 0f)
            //       {
            //           _rotateAroundTarget = true; //  do we need this??
            //           if (_didNotGetTargetYet)
            //           {
            //Quaternion targetRotation = gameObject.transform.rotation;
			//Vector3 meanVector = _cameraTarget.transform.position;// new Vector3(150, 110, 50);//Vector3.zero;
                                                           //foreach (GameObject target in _targets)
                                                           //{
                                                           //    meanVector += target.transform.position;
                                                           //}
                                                           //meanVector = (meanVector / _targets.Count()); // average location for center point
            //_cameraTarget = (GameObject)Instantiate(new GameObject(), meanVector, targetRotation);
            //_didNotGetTargetYet = false;
           // _cameraOffSet = gameObject.transform.position - _cameraTarget.transform.position;
            //           }

   //         if (Input.GetKey("space")) // use GetKey for holding key down, GetKeyDown() is for one frame of pressed
   //         {
   //             Quaternion cameraTurnAngleX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * _mouseRotationSpeed, Vector3.up);
   //             _cameraOffSet = cameraTurnAngleX * _cameraOffSet;
   //             Vector3 newPositionX = _cameraTarget.transform.position + _cameraOffSet;
   //             gameObject.transform.position = Vector3.Slerp(gameObject.transform.position, newPositionX, MoveSmoothTime);
   //             Quaternion cameraTurnAngleY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * _mouseRotationSpeed, Vector3.right);
   //             _cameraOffSet = cameraTurnAngleY * _cameraOffSet;
   //             Vector3 newPositionY = _cameraTarget.transform.position + _cameraOffSet;
   //             gameObject.transform.position = Vector3.Slerp(gameObject.transform.position, newPositionY, MoveSmoothTime);
			//	gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPositionAndRotation.Position, ref velocity, MoveSmoothTime);
			//}
   //         else
   //         {
                //float xRotation = 0.01f;
                //float yRotation = 0.005f;

                //if (turningPositiveX)
                //{
                //    if (_autoTimer <= 0)
                //    {
                //        turningPositiveX = false;
                //        _autoTimer = 14;

                //    }
                //    AutoRotation(xRotation, Vector3.up);
                //    AutoRotation(yRotation, Vector3.right);
                //}
                //else if (!turningPositiveX)
                //{
                //    if (_autoTimer <= 0)
                //    {
                //        turningPositiveX = true;
                //        _autoTimer = 14;
                //    }
                //    AutoRotation(-xRotation, Vector3.up);
                //    AutoRotation(-yRotation, Vector3.right);
                //}
                //_autoTimer -= Time.deltaTime;

            //}

            //           if (_lookAtTarget || _rotateAroundTarget)
            //           {
           // gameObject.transform.LookAt(_cameraTarget.transform);
            //           }

            //       }
            //       else if (GameManager.Instance._statePassedCombatInit && _targetTimer > 0f)
            //       {
            //           _targetTimer -= Time.deltaTime;
            //           //var targetPositionAndRotation = TargetPositionAndRotation(_targets);
            //           //Vector3 velocity = Vector3.zero;
            //gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPositionAndRotation.Position, ref velocity, MoveSmoothTime);
            //           //gameObject.transform.rotation = targetPositionAndRotation.Rotation;
            //       }
            //       else
            //           return;
            _camera.transform.position = gameObject.transform.position;
			_camera.transform.rotation = gameObject.transform.rotation;
			_targetTimer -= Time.deltaTime;
			#endregion
		}

        // Added method for from Rotation around target
        #region Auto Rotation around average target
        private void AutoRotation(float xRotating, Vector3 direction)
        {
            Quaternion cameraTurnAngleX = Quaternion.AngleAxis(xRotating * _mouseRotationSpeed, direction);
            _cameraOffSet = cameraTurnAngleX * _cameraOffSet;
            Vector3 newPositionX = _cameraTarget.transform.position + _cameraOffSet;
			gameObject.transform.position = Vector3.Slerp(gameObject.transform.position, newPositionX, MoveSmoothTime);
        }
        #endregion
        PositionAndRotation TargetPositionAndRotation(GameObject[] targets)
		{
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
	}
}


