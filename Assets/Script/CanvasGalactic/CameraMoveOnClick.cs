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
    public class CameraMoveOnClick : MonoBehaviour
    {
        public CameraManagerGalactica cameraManagerGalactica;
        public Camera cam;
        public bool cameraZoomed = false; // this checks to see if the camera was zoomed
        private string colliderName;
        private Quaternion _initRotation;
        float _initFieldOfView;

        private void Start()
        {
            _initRotation = transform.rotation;
            _initFieldOfView = cam.fieldOfView;
        }

        void Update()
        {
            // Right Mouse Click 
            if (Input.GetMouseButtonDown(1))
            {
                if (!cameraZoomed )
                { 
                //Create variables to cast a ray on object
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit)) 
                    {
                        colliderName = hit.collider.name;

                        //Detect if ray hit system 
                        if (colliderName.Contains("System")) 
                        {
                            // zoom and rotate to clicked object
                            _initRotation = cam.transform.rotation;
                            float deep = hit.collider.transform.position.y;

                            float newZoom = (deep + 15000f) / 200f;
                            cam.fieldOfView = 85 - newZoom;
                            cam.transform.rotation = Quaternion.LookRotation(hit.collider.transform.position - cam.transform.position);                                                                                                               
                            cameraZoomed = true;
                            cameraManagerGalactica.SetZoomedStatus();
                        }
                    }                   
                }
                else 
                {
                    cam.fieldOfView = _initFieldOfView;
                    cam.transform.rotation = _initRotation;
                    cameraZoomed = false;
                    cameraManagerGalactica.SetZoomedStatus();
                }
            }
        }
        //public bool AreWeZoomed()
        //{
        //    return cameraZoomed;
        //}
    }
}
