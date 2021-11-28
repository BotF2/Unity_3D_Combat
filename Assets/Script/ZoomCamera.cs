using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class ZoomCamera : MonoBehaviour

    {
        public Camera _shipCamera;
        public CameraMultiTarget cameraMultiTarget;
        //public float defaultFOV = 18;
        //float drift = 20f;
        //public GameManager gameManager;
        //private void Start()
        //{
        //    GetComponent<Camera>().fieldOfView = 18f;
        //}

        void Update()
        {
            if (cameraMultiTarget._rotateAroundTarget)
            {
                if (Input.mouseScrollDelta == Vector2.zero)
                    return;
                else//GameManager.Instance._statePassedCombatInit)
                {

                    if (Input.mouseScrollDelta.y > 0 && _shipCamera.fieldOfView > 10) //GetAxis("Mouse ScrollWheel") 
                    {
                        _shipCamera.fieldOfView--;
                    }
                    if (Input.mouseScrollDelta.y < 0 && _shipCamera.fieldOfView < 30) //.GetAxis("Mouse ScrollWheel") < 0 
                    {
                        _shipCamera.fieldOfView++;
                    }
                }
            }
            //if (GameManager.Instance._statePassedCombatInit)
            //{
            //    if (Input.GetKeyDown("o"))  ///GetAxis("Mouse ScrollWheel") > 0 && camera.fieldOfView > 12)
            //    {
            //        camera.fieldOfView--;
            //    }
            //    if (Input.GetKeyDown("p"))//GetAxis("Mouse ScrollWheel") < 0 && camera.fieldOfView < 40)
            //    {
            //        camera.fieldOfView++;
            //    }
            //}
            //if (GameManager.Instance._statePassedCombatInit)
            //{
            //    if (Input.GetAxis("Mouse ScrollWheel") > 0 && GetComponent<Camera>().fieldOfView > 12)
            //    {
            //        GetComponent<Camera>().fieldOfView--;
            //    }
            //    if (Input.GetAxis("Mouse ScrollWheel") < 0 && GetComponent<Camera>().fieldOfView < 40)
            //    {
            //        GetComponent<Camera>().fieldOfView++;
            //    }
            //}   
        }
        
    }
}
