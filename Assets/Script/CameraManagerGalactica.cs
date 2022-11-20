using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;
using BOTF3D_GalaxyMap;
using BOTF3D_Combat;
using DG.Tweening;
using Unity.VisualScripting.Dependencies.NCalc;

namespace BOTF3D_Core
{

    public class CameraManagerGalactica : MonoBehaviour
    {
        #region UI

        [Space]

        [SerializeField]
        [Tooltip("The script is currently active")]
        private bool _active = true;

        [Space]

        //[SerializeField]
        //[Tooltip("Camera rotation by mouse movement is active")]
        //private bool _enableRotation = true;

        [SerializeField]
        [Tooltip("Sensitivity of mouse rotation")]
        private float _mouseSense = 1.8f;

        [Space]

        [SerializeField]
        [Tooltip("Camera zooming in/out by 'Mouse Scroll Wheel' is active")]
        private bool _enableTranslation = true;

        [SerializeField]
        [Tooltip("Velocity of camera zooming in/out")]
        private float _translationSpeed = 55f;

        [Space]

        [SerializeField]
        [Tooltip("Camera movement by 'W','A','S','D','Q','E' keys is active")]
        private bool _enableMovement = true;

        [SerializeField]
        [Tooltip("Camera movement speed")]
        private float _movementSpeed = 10f;

        //[SerializeField]
        //[Tooltip("Speed of the quick camera movement when holding the 'Left Shift' key")]
        //private float _boostedSpeed = 50f;

        //[SerializeField]
        //[Tooltip("Boost speed")]
        //private KeyCode _boostSpeed = KeyCode.LeftShift;

        //[SerializeField]
        //[Tooltip("Move up")]
        //private KeyCode _moveUp = KeyCode.E;

        //[SerializeField]
        //[Tooltip("Move down")]
        //private KeyCode _moveDown = KeyCode.Q;

        //[Space]

        //[SerializeField]
        //[Tooltip("Acceleration at camera movement is active")]
        //private bool _enableSpeedAcceleration = true;

        [SerializeField]
        [Tooltip("Rate which is applied during camera movement")]
        private float _speedAccelerationFactor = 1.5f;

        [Space]

        [SerializeField]
        [Tooltip("This keypress will move the camera to initialization position")]
        private KeyCode _initPositonButton = KeyCode.R;

        #endregion UI
        // In Galaxy Map X is right left, Y is in out and z is negative up down
        [Header("Camera Positioning")]
        public Vector2 cameraOffset = new Vector2(10f, 14f);
        public float lookAtOffset = 2f;
        //[Header("Move Controls")]
        //public float inOutSpeed = 100f;
        //public float lateralSpeed = 100f;
        //public float upDownSpeed = 10f;
       // private Vector3 mousePos;
        public float rotateSpeed = 20f;
        public float maxRotation = 20f;
        public float minRotation = -20f;
        [Header("Move Bounds")]
        public Vector2 minBounds, maxBounds;
        [Header("Zoom Controls")]
        //public float zoomSpeed = 400f;
        //public float nearZoomLimit = 2f;
        //public float farZoomLimit = 30f;
        //public float startingZoom = 20f;

        //IZoomStrategy zoomStrategy;
        //Vector3 frameMove;
        private Vector3 currentRotation;
        float frameRotate = 1f;
        //float frameZoom;
        Camera cam;

        private float _currentIncrease = 0.1f; // active control of camera movement rate
        //private float _currentIncreaseMem = 0;

        private Vector3 _initPosition;
        private Vector3 _initRotation;

        private void Awake()
        {
            minBounds = new Vector2(-145f, -1000f);
            maxBounds = new Vector2(2f, -300f);
            // ToDo: Camera Zoom is not working here in galactic view, see zoomStrategy and OrthographicZoomStrategy.cs
            //var camArray = this.transform.GetComponentsInChildren<Camera>();
            //cam = camArray[1];
            cam = GetComponentInChildren<Camera>();
            //cam.transform.localPosition = new Vector3(0f, Mathf.Abs(cameraOffset.y), -Mathf.Abs(cameraOffset.x));
            //zoomStrategy = new OrthographicZoomStrategy(cam, startingZoom);
            cam.transform.LookAt(transform.position + Vector3.forward * lookAtOffset);
        }
        private void Start()
        {
            this.transform.Rotate(-1f, 1f, -1f); // enables / activates the camera but not sure why
            this.transform.Rotate(1f, -1f, 1f);
            _initPosition = transform.position;
            _initRotation = transform.eulerAngles;
            currentRotation = this.transform.localEulerAngles;
            //localTrans = transform;
            //localTrans = GetComponent<Transform>();
        }

        private void Update()
        {
            LockPositionInBounds();
            //LockRotationInBounds();
            if (_enableTranslation)
            {
                transform.Translate(Vector3.forward * Input.mouseScrollDelta.y * Time.deltaTime * _translationSpeed);
            }

            // Movement
            if (_enableMovement)
            {
                Vector3 deltaPosition = Vector3.zero;
                float currentSpeed = _movementSpeed;

                //if (Input.GetKey(_boostSpeed))
                //    currentSpeed = _boostedSpeed;

                if (Input.GetKey(KeyCode.W))
                    deltaPosition += transform.up;

                if (Input.GetKey(KeyCode.S))
                    deltaPosition -= transform.up;

                if (Input.GetKey(KeyCode.A))
                    deltaPosition -= transform.right;

                if (Input.GetKey(KeyCode.D))
                    deltaPosition += transform.right;

                if (Input.GetKey(KeyCode.Q))
                {
                    transform.Rotate(Vector3.forward, frameRotate * Time.deltaTime * rotateSpeed);
                }

                if (Input.GetKey(KeyCode.E))
                {
                    transform.Rotate(Vector3.back, frameRotate * Time.deltaTime * rotateSpeed);
                }
    
                //if (Input.GetKey(_moveUp))
                //    deltaPosition += transform.up;

                //if (Input.GetKey(_moveDown))
                //    deltaPosition -= transform.up;

                // Calc acceleration
                // CalculateCurrentIncrease(deltaPosition != Vector3.zero);

                transform.position += deltaPosition * currentSpeed * _currentIncrease;
 
                //Quaternion targetRot = Quaternion.LookRotation();
                //localTrans.rotation = Quaternion.Slerp(localTrans.rotation, targetRot, RotateSpeed * Time.deltaTime);
            }
            // Return to init position
            if (Input.GetKeyDown(_initPositonButton))
            {
                transform.position = _initPosition;
                transform.eulerAngles = _initRotation;
            }
        }
        //void LateUpdate()
        //{
        //    //currentRotation.z = Mathf.Clamp(currentRotation.z, minRotation, maxRotation);
        //    //this.transform.localEulerAngles = currentRotation;
        //    this.transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y,
        //         Mathf.Clamp(transform.rotation.eulerAngles.z, minRotation, maxRotation));
        //    //transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(_initRotation), maxRotation);
        //}
        public void ResetGalacticCamLocation()
        {
            transform.position = _initPosition;
            transform.eulerAngles = _initRotation;
        }

        private void LockPositionInBounds()
        {
            transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x),
            Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y),
            transform.position.z);
        }
        //private void LockRotationInBounds()
        //{
        //    Vector3 cameraEulerAngle = localTrans.rotation.eulerAngles;
        //    cameraEulerAngle.z = (cameraEulerAngle.z >180) ? cameraEulerAngle.z -360: -cameraEulerAngle.z;
        //    cameraEulerAngle.z = Mathf.Clamp(cameraEulerAngle.z, minRotation, maxRotation);

        //    localTrans.rotation = Quaternion.Euler(cameraEulerAngle);
        //}
    }
}
