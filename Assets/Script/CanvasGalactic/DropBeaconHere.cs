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

namespace BOTF3D_GalaxyMap
{
    public class DropBeaconHere : MonoBehaviour
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

        private void Start()
        {
            float x = this.transform.localPosition.x;
            float y = this.transform.localPosition.y;

            //GalaxyDropLine targetLine = Instantiate(targetDropLine, new Vector3(0, 0, 0), Quaternion.identity);
            //targetLine.name = this.name + "_targetLine";
            ////targetLine.gameObject.layer = 1;
            //_targetPlaneGObj = Instantiate(_targetLineEndpointPrefab,
            //    new Vector3(x, y, 600f), Quaternion.identity);
            //_targetPlaneGObj.name = "_targetPlanePoint";
            //_targetPlaneGObj.transform.SetParent(canvasGalactic.transform, false);
            //_targetPlaneGObj.layer = 7; // noSeeEm

            //Transform[] endFleetPoints = new Transform[2] // transform array for line drawing
            //    { this.transform, _targetPlaneGObj.transform };
            //targetLine.SetUpLine(endFleetPoints);
        }
    }
}
