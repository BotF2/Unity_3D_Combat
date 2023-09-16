using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BOTF3D_GalaxyMap;
using Assets.Script;
using BOTF3D_Combat;
using DG.Tweening.Core.Easing;
using TMPro.Examples;

namespace BOTF3D_Core
{
    public class ZoomCamera : MonoBehaviour

    {
        public Camera _shipCamera;
        public CameraMultiTarget cameraMultiTarget;
        public Camera _cameraGalactica;
        //public GameManager _gameManager;
        bool _startZoomerUpdate = false;
        bool _doneWithWideAngle = false;
        bool _startGalacticZoomerUpdate = false;
        bool _doneWithGalacticWideAngele = false;
        float _startTimer = 0;
        float _startGalacticTimer = 0;

        //private void Start()
        //{
        //    //_gameManager = GameManager.Instance;
        //}
        void Update()
        {
            if (_startZoomerUpdate)
            {
                if (!_doneWithWideAngle && _shipCamera.fieldOfView > 24)
                    _shipCamera.fieldOfView = _shipCamera.fieldOfView - (Time.time - _startTimer) / 5;
                if (!_doneWithWideAngle && _shipCamera.fieldOfView <= 24)
                    _doneWithWideAngle = true;

                if (_doneWithWideAngle) // && cameraMultiTarget._rotateAroundTarget)
                {
                    if (Input.mouseScrollDelta == Vector2.zero)
                        return;
                    else//GameManager.Instance._statePassedCombatInit)
                    {
                        bool turnOffNormalize = false;
                        if (cameraMultiTarget._normalizeFieldOfView)
                        {
                            cameraMultiTarget._normalizeFieldOfView = false;
                            turnOffNormalize = true;
                        }
                        if (Input.mouseScrollDelta.y > 0 && _shipCamera.fieldOfView > 10) //GetAxis("Mouse ScrollWheel") 
                        {
                            _shipCamera.fieldOfView--;
                        }
                        if (Input.mouseScrollDelta.y < 0 && _shipCamera.fieldOfView < 30) //.GetAxis("Mouse ScrollWheel") < 0 
                        {
                            _shipCamera.fieldOfView++;
                        }
                        if (turnOffNormalize)
                        {
                            cameraMultiTarget._normalizeFieldOfView = true;
                            turnOffNormalize = false;
                        }

                    }
                }
            }
            //if (_startGalacticZoomerUpdate)
            //{
            //    if (!_doneWithGalacticWideAngele && _cameraGalactica.fieldOfView > 24)
            //        _cameraGalactica.fieldOfView = _cameraGalactica.fieldOfView - (Time.time - _startGalacticTimer) / 5;
            //    if (!_doneWithGalacticWideAngele && _cameraGalactica.fieldOfView <= 24)
            //        _doneWithGalacticWideAngele = true;

            //    if (_doneWithGalacticWideAngele) // && cameraMultiTarget._rotateAroundTarget)
            //    {
            //        if (Input.mouseScrollDelta == Vector2.zero)
            //            return;
            //    }
            //}
        }
        public void ZoomIn()
        {
            _doneWithWideAngle = false;
            _startZoomerUpdate = true;
            _shipCamera.fieldOfView = 60;
            _startTimer = Time.time;
        }
        public void TurnOfZoomerUpdate()
        {
            _startZoomerUpdate = false;
            _doneWithWideAngle = false;
        }
        //public void GalacticZoomIn()
        //{
        //    _doneWithGalacticWideAngele = false;
        //    _startGalacticZoomerUpdate = true;
        //    _cameraGalactica.fieldOfView = 60;
        //    _startGalacticTimer = Time.time;
        //}
        //public void TurnOfGalacticZoomUpdate()
        //{
        //    _startGalacticZoomerUpdate = false;
        //    _doneWithGalacticWideAngele = false;
        //}
      
    }
}
