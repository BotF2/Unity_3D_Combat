using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Script;
using BOTF3D_Core;
using BOTF3D_Combat;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using DG.Tweening;
using Unity.VisualScripting.Dependencies.NCalc;
//using System.Numerics;

namespace BOTF3D_GalaxyMap
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

        //[SerializeField]
        //[Tooltip("Camera zooming in/out by 'Mouse Scroll Wheel' is active")]
        //private bool _enableTranslation = true;

        //[SerializeField]
        //[Tooltip("Velocity of camera zooming in/out")]
        //private float _translationSpeed = 55f;

        [Space]

        [SerializeField]
        [Tooltip("Camera movement by 'W','A','S','D','Q','E','Z','C' keys is active")]
        private bool _enableMovement = true;

        [SerializeField]
        [Tooltip("Camera movement speed")]
        private float _movementSpeed = 20f;

        [SerializeField]
        [Tooltip("Speed of the quick camera movement when holding the 'Left Shift' key")]
        private float _boostedSpeed = 4f;

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
        private float _speedFactor = 2f;

        [Space]

        [SerializeField]
        [Tooltip("This keypress will move the camera to initialization position")]
        private KeyCode _initPositonButton = KeyCode.R;

        #endregion UI

        // In Galaxy Map X is right left, Y is in out and zLine is negative up down
     
        [Header("Camera Positioning")]
        private Vector2 cameraOffset = new Vector2(10f, 14f);
        public float lookAtOffset = 400f;
        public float _rotateSpeed = 20f;
        public float maxRotation;
        public float minRotation;
        [Header("Move Bounds")]
        public Vector3 minBounds, maxBounds;
        [Header("Zoom Controls")]
        [SerializeField]
       //private float scrollSpeed = 40f;

        private bool zoomed = false;
        private Vector3 currentRotation;
        float frameRotate = 1f;
        Camera camGalactica;
        public GameObject telescopeHolder; 
        //public Camera telescope;
        public GameObject combatStopGalacticPlay;
        public GameObject returnToGalaxyFromSystemView;
        public GameObject buttonFleets;
        public GameObject buttonResetView;
        //public GameObject backgroundImageObject;
        public GameObject _targetPointer;
        public ClickSolarSystem clickSolarSystem;
        private float _currentIncrease = 0.1f; // active control of camera movement rate
        private Vector3 _initPosition;
        private Vector3 _initRotation;
        private Vector3 _initRotationCam;
        float _initFieldOfView;
        public Camera _publicCameraGalactica; //this camera cameraGalactica is assinged in Unity Hierarchy and works for raycast
        //public bool cameraZoomed = false; // this checks to see if the camera was zoomed
        //private string colliderName;


        private void Awake()
        {
            minBounds = new Vector3(-500f, -450f, -1000f);
            maxBounds = new Vector3(300f, 400f, 1000f);

            maxRotation = _initRotation.z + 10f;
            minRotation = _initRotation.z - 10f;

            camGalactica = GetComponentInChildren<Camera>();

            camGalactica.transform.LookAt(transform.position + Vector3.forward * lookAtOffset);

            _initRotationCam = _publicCameraGalactica.transform.eulerAngles;
            _initFieldOfView = _publicCameraGalactica.fieldOfView;
        }
        private void Start()
        {
            this.transform.Rotate(-1f, 1f, -1f); // enables / activates the camera but not sure why
            this.transform.Rotate(1f, -1f, 1f);
            _initPosition = transform.position;
            _initRotation = transform.eulerAngles;
            currentRotation = this.transform.localEulerAngles;
            
            //telescope.transform.position = camGalactica.transform.position;
            //telescope.transform.rotation = camGalactica.transform.rotation;
            //FleetManagerEmpty = gameObject.transform.Find("FleetManagerEmpty").gameObject;
        }

        private void Update()
        {
            LockPositionInBounds();

            // Movement
            if (_enableMovement)
            {
                if (zoomed)
                {
                    _currentIncrease = 0.01f;
                }
                else
                {
                    _currentIncrease = 0.1f;
                }
                Vector3 deltaPosition = Vector3.zero;
                float currentSpeed = _movementSpeed;

                if (Input.GetKey(KeyCode.LeftShift))
                    currentSpeed = _boostedSpeed * _movementSpeed;
                if (Input.GetKey(KeyCode.RightShift))
                    currentSpeed = _boostedSpeed * _movementSpeed;

                if (Input.GetKey(KeyCode.W))
                    deltaPosition += transform.up * _speedFactor;

                if (Input.GetKey(KeyCode.S))
                    deltaPosition -= transform.up * _speedFactor;

                if (Input.GetKey(KeyCode.D))
                    deltaPosition += transform.right *_speedFactor;

                //if (Input.GetKey(KeyCode.RightArrow))
                //    deltaPosition += transform.right;

                if (Input.GetKey(KeyCode.A))
                    deltaPosition -= transform.right * _speedFactor;

                //if(Input.GetKey(KeyCode.LeftArrow))
                //    deltaPosition -= transform.right;

                if (Input.GetKey(KeyCode.Q))
                    deltaPosition += transform.forward * _speedFactor;

                //if (Input.GetKey(KeyCode.UpArrow))
                //    deltaPosition += transform.forward;

                if (Input.GetKey(KeyCode.E))
                    deltaPosition -= transform.forward * _speedFactor;

                //if (Input.GetKey(KeyCode.DownArrow))
                //    deltaPosition -= transform.forward;

                if (Input.GetKey(KeyCode.Z))
                {
                    transform.Rotate(Vector3.forward, frameRotate * Time.deltaTime * _rotateSpeed);
                }

                if (Input.GetKey(KeyCode.C))
                {
                    transform.Rotate(Vector3.back, frameRotate * Time.deltaTime * _rotateSpeed);
                }

                //if (Input.GetKey(_moveUp))
                //    deltaPosition += transform.up;

                //if (Input.GetKey(_moveDown))
                //    deltaPosition -= transform.up;

                // Calc acceleration
                // CalculateCurrentIncrease(deltaPosition != Vector3.zero);

                //amGalactica.fieldOfView -= Input.GetAxisRaw("Mouse ScrollWheel")  * scrollSpeed;

                transform.position += deltaPosition * currentSpeed * _currentIncrease;

            }
            // Return to init position, R
            if (Input.GetKeyDown(_initPositonButton)) // r key
            {
                transform.position = _initPosition;
                transform.eulerAngles = _initRotation;
                _publicCameraGalactica.fieldOfView = _initFieldOfView;
                _publicCameraGalactica.transform.eulerAngles = _initRotationCam;
                //_cameraMoveOnClick.cam.fieldOfView = _zoomLevel;
            }
            //zoom camera with scroll wheel when it is not pressed or down
            if (!Input.GetMouseButtonDown(2) && !Input.GetMouseButton(2)) // scroll wheel not pressed or held
            {
                if (Input.mouseScrollDelta.y != 0)
                {
                    float deltaFieldOfView = Input.mouseScrollDelta.y / 2f;
                    float newFieldOfView = Math.Clamp(_publicCameraGalactica.fieldOfView - deltaFieldOfView, 15f, _initFieldOfView +3f);
                    _publicCameraGalactica.fieldOfView = newFieldOfView;
                }
               
            }
            //Right Mouse Click
            //if (Input.GetMouseButtonDown(1)) // right mouse button
            //{
            //    if (!cameraZoomed)
            //    {
            //        //Create variables to cast a ray on object
            //        int layerMask = 1 << 8; // in raycast below, we are only going to hit in layer 8 GalacticUI,
            //                                // the background image of galaxy
            //        Ray ray = _publicCameraGalactica.ScreenPointToRay(Input.mousePosition);

            //        if (Physics.Raycast(ray, out RaycastHit hit, 10000f,layerMask)) 
            //        {
            //            Collider collider = backgroundImageObject.GetComponent<Collider>();

            //            //Detect if ray hit background image 
            //            if (hit.collider == collider) 
            //            {
            //                float deep = hit.collider.transform.position.y;

            //                float newZoom = (deep + 15000f) / 200f;
            //                _publicCameraGalactica.fieldOfView = 90 - newZoom;

            //                _publicCameraGalactica.transform.rotation =
            //                    Quaternion.LookRotation(hit.point - _publicCameraGalactica.transform.position, Vector3.up);
            //                cameraZoomed = true;
            //                //this.SetZoomedStatus();
            //            }

            //        }
            //    }
            //    else 
            //    {
            //        _publicCameraGalactica.fieldOfView = _initFieldOfView;
            //        _publicCameraGalactica.transform.eulerAngles = _initRotationCam;

            //        cameraZoomed = false;
            //        //this.SetZoomedStatus();
            //    }
            //}

        }
        void LateUpdate()
        {
            this.transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y,
                 ClampAngles(transform.rotation.eulerAngles.z, minRotation, maxRotation));
        }
        public void ResetGalacticCamera()
        {
            //if (!clickSolarSystem.BlockedByUI)
            //{
                transform.position = _initPosition;
                transform.eulerAngles = _initRotation;
                _publicCameraGalactica.fieldOfView = _initFieldOfView;
                _publicCameraGalactica.transform.eulerAngles = _initRotationCam;
            //}
        }

        public void ActivateCombatStopGalacticPlay(bool turnOn)
        {
            if (turnOn)
            {
                combatStopGalacticPlay.SetActive(true);
                telescopeHolder.SetActive(true);
            }
            else
            {
                combatStopGalacticPlay.SetActive(false);
                telescopeHolder.SetActive(false);
            }
        }
        public void ActivateReturnToGalaxyViewFromSystem(bool turnOn)
        {
            if (turnOn)
            {
                returnToGalaxyFromSystemView.SetActive(true);
            }
            else
            {
                returnToGalaxyFromSystemView.SetActive(false);
            }
        }

        public void ActivateButtonFleets(bool turnOn)
        {
            if (turnOn)
            {
                buttonFleets.SetActive(true);
            }
            else
            {
                buttonFleets.SetActive(false);
            }
        }
        public void ActivateRestViewButton(bool turnOn)
        {
            if (turnOn)
            {
                buttonResetView.SetActive(true);
            }
            else
            {
                buttonResetView.SetActive(false);
            }
        }

        public void ResetGalacticCamLocation()
        {
            //_cameraMoveOnClick.ResetCameraMoveOnClick();
            transform.position = _initPosition;
            transform.eulerAngles = _initRotation;

        }

        private void LockPositionInBounds()
        {
            transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x),
            Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y),
            Mathf.Clamp(transform.position.z, minBounds.z, maxBounds.z));
            //transform.position.zLine);
        }
        public float ClampAngles(float angle, float min, float max)
        {
            if (angle < 90 || angle > 270) // if we are in a critical range of jumping to 0 or 360...
            {
                if (angle > 180) angle -= 360; // convert anlges to -180..+180
                if (max > 180) max -= 360;
                if (min > 180) min -= 360;
            }
            angle = Mathf.Clamp(angle, min, max);
            if (angle < 0) angle += 360; // if negative convert to 0..360;
            return angle;
        }
        //public void SetZoomedStatus()
        //{
        //        if (zoomed == false)
        //            zoomed = true;
        //        else zoomed = false;
        //}
    }
}
