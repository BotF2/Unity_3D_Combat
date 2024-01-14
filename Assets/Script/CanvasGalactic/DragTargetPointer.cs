using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;
using BOTF3D_Core;
using BOTF3D_Combat;
using UnityEngine.InputSystem;
using static UnityEditor.PlayerSettings;
using UnityEngine.UIElements;
using DG.Tweening;
//using UnityEngine.Windows;


namespace BOTF3D_GalaxyMap
{

    public class DragTargetPointer : MonoBehaviour
    {
        Vector3 screenPosition;
        public Vector3 worldPosition;
        public Camera galaxyCamera;
        public GalaxyDropLine targetDropLine;
        public GameObject _targetLineEndpointPrefab;
        private GameObject _targetPlaneGObj;
        public Canvas canvasGalactic;
        public GameObject _backgoundGalaxyImage;
        private float zLine = 0f;
        private bool _rayHit = false; 
        //private Plane _targetPlane;

        private void Start()
        {
            float x = this.transform.localPosition.x;
            float y = this.transform.localPosition.y;

            GalaxyDropLine targetLine = Instantiate(targetDropLine, new Vector3(0, 0, 0), Quaternion.identity);
            targetLine.name = this.name + "_targetLine";
            //targetLine.gameObject.layer = 1;
            _targetPlaneGObj = Instantiate(_targetLineEndpointPrefab,
                new Vector3(x, y, 600f), Quaternion.identity);
            _targetPlaneGObj.name = "_targetPlanePoint";
            _targetPlaneGObj.transform.SetParent(canvasGalactic.transform, false);
            _targetPlaneGObj.layer = 7; // noSeeEm

            Transform[] endFleetPoints = new Transform[2] // transform array for line drawing
                { this.transform, _targetPlaneGObj.transform };
            targetLine.SetUpLine(endFleetPoints);
        }
        void Update()
        {
            //Detect scroll wheel click then if raycast hits TargetPointer
            if (Input.GetMouseButtonDown(2))
            {
                int layerMaskT = 1 << 6; // in raycast below, we are only going to hitT in layer 6 Galactic,

                Ray rayT = galaxyCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

                if (Physics.Raycast(rayT, out RaycastHit hitT, 100000f, layerMaskT))
                {
                    Collider colliderT = this.GetComponent<Collider>();

                    //Detect if rayT hitT background image 
                    if (hitT.collider == colliderT)
                    {
                        _rayHit = true;
                        screenPosition = Mouse.current.position.ReadValue();
                    }
                }
            }
            if (_rayHit)
            {
                //Detect if the middle mouse button (scroll wheel) is held down in frame
                if (Input.GetMouseButton(2))
                {
                    if (Input.mouseScrollDelta.y != 0)
                    {
                        zLine = transform.position.z;
                        zLine += Input.mouseScrollDelta.y * 10f;
                        zLine = Mathf.Clamp(zLine, -60f, (_backgoundGalaxyImage.transform.position.z - 10f));
                        int layerMaskT = 1 << 6; // in raycast below, we are only going to hitT in layer 6 Galactic,

                        Ray rayT = galaxyCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

                        if (Physics.Raycast(rayT, out RaycastHit hitT, 100000f, layerMaskT))
                        {
                            Collider colliderT = this.GetComponent<Collider>();

                            //Detect if rayT hitT background image 
                            if (hitT.collider == colliderT)
                            {
                                worldPosition = new Vector3(transform.position.x, transform.position.y, zLine);
                            }

                        }
                    }
                    Vector3 newV3 = Mouse.current.position.ReadValue();
                    if (newV3 != screenPosition)
                    {
                        if (Input.mouseScrollDelta.y != 0)
                        {
                            zLine = transform.position.z;
                            zLine += Input.mouseScrollDelta.y * 10f;
                            zLine = Mathf.Clamp(zLine, -60f, (_backgoundGalaxyImage.transform.position.z - 10f));
                        }
                        screenPosition = newV3;
                        int layerMaskB = 1 << 8; // in raycast below, we are only going to hitB in layer 8 GalacticUI,
                        Ray rayB = galaxyCamera.ScreenPointToRay(screenPosition);
                        if (Physics.Raycast(rayB, out RaycastHit hitB, 100000f, layerMaskB))
                        {
                            Collider colliderB = _backgoundGalaxyImage.GetComponent<Collider>();

                            if (hitB.collider == colliderB)
                            {
                                worldPosition = new Vector3(hitB.point.x, hitB.point.y, zLine);
                            }

                        }
                    }
                    transform.position = worldPosition;
                    _targetPlaneGObj.transform.position = new Vector3(transform.position.x,
                        transform.position.y, _backgoundGalaxyImage.transform.position.z);
                }
                else
                {
                    _rayHit = false;
                }

            }
        }
    }
}
