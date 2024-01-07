using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;
using BOTF3D_Core;
using BOTF3D_Combat;
using UnityEngine.InputSystem;
using static UnityEditor.PlayerSettings;
using UnityEngine.UIElements;
//using UnityEngine.Windows;


namespace BOTF3D_GalaxyMap
{

    public class DragTargetPointer : MonoBehaviour
    {
        Vector3 thePosition;
        public Camera galaxyCamera;
        public GalaxyDropLine targetDropLine;
        public GameObject _targetLineEndpointPrefab;
        private GameObject _targetPlaneGObj;
        public Canvas canvasGalactic;
        public GameObject _backgoundGalaxyImage;
        private float z = 0f;
        private bool _rayHit = false; 

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
            _targetPlaneGObj.layer = 7;

            Transform[] endFleetPoints = new Transform[2]
                { this.transform, _targetPlaneGObj.transform };
            targetLine.SetUpLine(endFleetPoints);
        }
        void Update()
        {
            // if raycast hits TargetPointer
            if (Input.GetMouseButtonDown(2))
            {
                int layerMask = 1 << 6; // in raycast below, we are only going to hit in layer 6 Galactic,

                Ray ray = galaxyCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, 10000f, layerMask))
                {
                    Collider collider = this.GetComponent<Collider>();

                    //Detect if ray hit background image 
                    if (hit.collider == collider)
                    {
                        _rayHit = true;
                        Vector3 updatePosition = Input.mousePosition - GetTargetPosition();
                        thePosition = updatePosition;
                    }
                }
            }
            if (_rayHit)
            {           
                //Detect if the middle mouse button (scroll wheel) is held down in frame
                if (Input.GetMouseButton(2))
                {
                    Vector3 tempPosition = galaxyCamera.ScreenToWorldPoint(Input.mousePosition - thePosition);
                    tempPosition.x = Mathf.Clamp(tempPosition.x, -595f, 550f);
                    tempPosition.z = Mathf.Clamp(tempPosition.z, (-157f), (340f));

                    if (Input.mouseScrollDelta.y != 0)
                    {
                        z += Input.mouseScrollDelta.y * 10f;
                        z = Mathf.Clamp(z, -100f, (_backgoundGalaxyImage.transform.position.z - 10f));
                    }
                    Vector3 forGalaxyPosition = new Vector3(tempPosition.x, (-tempPosition.z * 2.3f), z);
                    transform.position = forGalaxyPosition;
                    _targetPlaneGObj.transform.position = new Vector3(transform.position.x,
                        transform.position.y, _backgoundGalaxyImage.transform.position.z);
                }
                else
                {
                    _rayHit = false;
                }
     
            }
        }
        private Vector3 GetTargetPosition()
        {
            return galaxyCamera.WorldToScreenPoint(transform.position);

        }

        //private void OnMouseDown() // for left mouse button
        //{
        //    Vector3 tempPosition = Input.mousePosition - GetTargetPosition();
        //    thePosition = tempPosition;
        //    //MoveTargetPlaneEmpty();
        //}
        //private void OnMouseDrag() // for left mouse button drag
        //{

        //    Vector3 tempPosition = galaxyCamera.ScreenToWorldPoint(Input.mousePosition - thePosition);
        //    tempPosition.x = Mathf.Clamp(tempPosition.x, -595f, 550f);
        //    tempPosition.z = Mathf.Clamp(tempPosition.z, (-157f), (340f));
            
        //    Vector3 forGalaxyPosition = new Vector3(tempPosition.x, (-tempPosition.z * 2.3f), 0f);
        //    //forGalaxyPosition.z += Input.mouseScrollDelta.y * 0.1f;
        //    transform.position = forGalaxyPosition;
        //    //transform.Translate(Vector3.up * Input.GetAxis("Mouse ScrollWheel"));
        //    _targetPlaneGObj.transform.position = new Vector3(transform.position.x,
        //        transform.position.y, _backgoundGalaxyImage.transform.position.z);
        //}
    }
}
