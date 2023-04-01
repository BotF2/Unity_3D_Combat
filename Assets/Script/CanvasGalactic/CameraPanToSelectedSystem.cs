using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;
using BOTF3D_Core;
using BOTF3D_Combat;
using DG.Tweening;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine.UIElements;

namespace BOTF3D_GalaxyMap
{
    public class CameraPanToSelectedSystem : MonoBehaviour
    {
        public CameraManagerGalactica cameraManagerGalactica;
        Vector3 groundCamOffset;
        Vector3 camTarget;
        Vector3 camSmoothDampV;
        //GameObject cam;
        public Camera cam;
        //public GameObject[] hotspots;
        Ray ray;
        RaycastHit hit;
        public float panspeed = 20f;
        public string colliderName;
        public bool clicked = false;
        public Vector3 tempCamTarget;
        public Vector3 tempCamPosition;
        private bool Panned;
        private Vector3 _initPosition;
        private Vector3 _initRotation;
        //private float _maxDistance = 10000000000f;
        //int _layerMask; // = 1<<6; // Galactic layer

        void Start()
        {
           // //cam = GetComponent<Camera>(); // we do this in inspector
           // Vector3 groundPos = GetWorldPosAtViewportPoint(0.5f, 0.5f);
           //// Debug.Log("groundPos: " + groundPos);
           // groundCamOffset = cam.transform.position - groundPos;
           // camTarget = cam.transform.position;
            Panned = false;
            _initPosition = transform.position;
            _initRotation = transform.eulerAngles;

        }

        void Update()
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Input.GetMouseButtonDown(1) && Panned == false)
            {
                if (Physics.Raycast(ray, out hit)) //, _maxDistance, 1<<6))
                {
                    colliderName = hit.collider.name;
                }
            }
            //else if (Input.GetMouseButtonDown(1) && Panned)
            //{
            //    //transform.position = _initPosition;
            //    //transform.eulerAngles = _initRotation;
            //   //cameraManagerGalactica.ResetGalacticCamLocation();

            //    Panned = true;
            //}


            if (Input.GetMouseButtonDown(1) && colliderName.Contains("System") && clicked == false)
            {
                // Center whatever position is clicked
                SetGroundPlane();
                float mouseX = Input.mousePosition.x / cam.pixelWidth;
                float mouseY = Input.mousePosition.y / cam.pixelHeight;
                Vector3 clickPt = GetWorldPosAtViewportPoint(mouseX, mouseY);
                camTarget = clickPt + groundCamOffset;
                clicked = true;

                //tempCamPosition.x = float.Parse(camTarget.x.ToString("0.##"));
                //tempCamPosition.y = float.Parse(camTarget.y.ToString("0.##"));
                //tempCamPosition.z = float.Parse(camTarget.z.ToString("0.##"));
                cam.transform.position = camTarget; //tempCamPosition;

            }

            // Move the camera smoothly to the target position
            //if (tempCamPosition != tempCamTarget && clicked == true)
            //{
            //    _initPosition = transform.position;
            //    _initRotation = transform.eulerAngles;
            //    Panned = true;
            //    cam.transform.position = Vector3.SmoothDamp(cam.transform.position, camTarget, ref camSmoothDampV, panspeed);
            //    tempCamPosition.x = float.Parse(cam.transform.position.x.ToString("0.##"));
            //    tempCamPosition.y = float.Parse(cam.transform.position.y.ToString("0.##"));
            //    tempCamPosition.z = float.Parse(cam.transform.position.z.ToString("0.##"));
            //}
            //else if (tempCamPosition == tempCamTarget)
            //{
            //    clicked = false;
            //    colliderName = "";
            //}
            //if (zoomed && Input.GetKey(KeyCode.Escape))
            //{
            //    zoomed = false;
            //    cameraManagerGalactica.ResetGalacticCamLocation();
            //}

        }
        private Vector3 GetWorldPosAtViewportPoint(float vx, float vy)
        {
            Ray worldRay = cam.ViewportPointToRay(new Vector3(vx, vy, 0));
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float distanceToGround;
            groundPlane.Raycast(worldRay, out distanceToGround);
           // Debug.Log("distance to ground:" + distanceToGround);
            return worldRay.GetPoint(distanceToGround);
        }
        private void SetGroundPlane()
        {
            Vector3 groundPos = GetWorldPosAtViewportPoint(0.5f, 0.5f);
            groundCamOffset = cam.transform.position - groundPos;
            //camTarget = cam.transform.position;
            //Panned = false;
            _initPosition = transform.position;
            _initRotation = transform.eulerAngles;
        }
        void camSmoothDamp()
        {

        }
    }
}
