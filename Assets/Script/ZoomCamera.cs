using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class ZoomCamera : MonoBehaviour

    {
        float drift = 20f;
        //public GameManager gameManager;
        //private void Start()
        //{
        //    GetComponent<Camera>().fieldOfView = 17f;
        //}
        void Update()
        {
            if (GameManager.Instance._statePasedInit)
            {
                if (Input.GetAxis("Mouse ScrollWheel") > 0 && GetComponent<Camera>().fieldOfView > 12)
                {
                    GetComponent<Camera>().fieldOfView--;
                }
                if (Input.GetAxis("Mouse ScrollWheel") < 0 && GetComponent<Camera>().fieldOfView < 40)
                {
                    GetComponent<Camera>().fieldOfView++;
                }
            }
            //else
            //{
            //    bool backAndForth = true;
            //    if (backAndForth)
            //    {
            //        GetComponent<Camera>().fieldOfView += drift;
            //        backAndForth = false;
            //    }
            //    else
            //    {
            //        GetComponent<Camera>().fieldOfView -= drift;
            //        backAndForth = true;
            //    }

            //}
                
        }
    }
}
