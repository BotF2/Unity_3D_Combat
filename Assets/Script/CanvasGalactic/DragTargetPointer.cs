using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;
using BOTF3D_Core;
using BOTF3D_Combat;
using UnityEngine.InputSystem;
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
        //private void MoveTargetPlaneEmpty()
        //{
        //    float x = this.transform.localPosition.x;
        //    float y = this.transform.localPosition.y;
        //    _targetPlaneGObj.transform.localPosition = new Vector3(x, y, 600f);
        //}
        private Vector3 GetMousePosition()
        {
            return galaxyCamera.WorldToScreenPoint(transform.position);
            //return lastPosition;
        }

        private void OnMouseDown()
        {
            Vector3 tempPosition = Input.mousePosition - GetMousePosition();
            thePosition = tempPosition;
            //MoveTargetPlaneEmpty();
        }
        private void OnMouseDrag()
        {
            var tempPosition = galaxyCamera.ScreenToWorldPoint(Input.mousePosition - thePosition);
            tempPosition.x = Mathf.Clamp(tempPosition.x, -595f, 550f);
            tempPosition.z = Mathf.Clamp(tempPosition.z, (-157f), (340f));

            Vector3 forGalaxyPosition = new Vector3(tempPosition.x, (-tempPosition.z * 2.3f), 0f);

            transform.position = forGalaxyPosition;
            _targetPlaneGObj.transform.position = new Vector3(transform.position.x,
                transform.position.y, _backgoundGalaxyImage.transform.position.z);
        }
    }
}
