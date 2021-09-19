using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class FlySkyboxCamera : MonoBehaviour
    {
        //public GameManager gameManager;
        public MouseLook mouseLook;
        public float mouseSensitivity = 1f;
        public float skyboxFactor = 10f;
        private float xRotation = 0f;
        private float yRotation = 0f;
        private bool turningPositiveX;
        private bool turningPositiveY;

        private void Start()
        {
            if (GameManager.Instance._statePasedInit)
            {
               // Cursor.lockState = CursorLockMode.Locked;
            }
           // transform.eulerAngles = startEuler;
        }
        void Update()
        {
            if (GameManager.Instance._statePasedInit)
            {
                if (Input.GetKey("space"))
                  {
                    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                    float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
                    xRotation += mouseY;
                    xRotation = Mathf.Clamp(xRotation, -45 * skyboxFactor, 45 * skyboxFactor);
                    yRotation += mouseX;
                    yRotation = Mathf.Clamp(yRotation, -45 * skyboxFactor, 45 * skyboxFactor);
                    transform.localRotation = Quaternion.Euler(xRotation * skyboxFactor, yRotation * skyboxFactor, 0f);
                    if (xRotation <= 0)
                        turningPositiveX = false;
                    else
                        turningPositiveX = true;

                    if (yRotation <= 0)
                        turningPositiveY = false;
                    else
                        turningPositiveY = true;
                }
                else
                {
                    float autoY = 0.002f;
                    float autoX = 0.002f;

                    if (!mouseLook.turningPositiveX)
                    {
                        xRotation += autoX;
                    }
                    else if (mouseLook.turningPositiveX)
                    {
                        xRotation -= autoX;
                    }
                    if (!mouseLook.turningPositiveY)
                    {
                        yRotation += autoY;
                    }
                    else if (!turningPositiveY)
                    {
                        yRotation -= autoY;
                    }

                    transform.localRotation = Quaternion.Euler(xRotation * skyboxFactor, yRotation * skyboxFactor, 0f);
                }
            }
        }
    }
}

