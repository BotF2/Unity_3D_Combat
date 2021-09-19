using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class ZoomCamera : MonoBehaviour
    {
        //public GameManager gameManager;
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
        }
    }
}
