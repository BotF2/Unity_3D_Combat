using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class MouseLook : MonoBehaviour
    {
        //public GameManager gameManager;
        public bool turningPositiveX;
        public bool turningPositiveY;
        public float mouseSensitivity = 0.05f;
        public float xRotation = 0f;
        public float yRotation = 0f;

        public float YRotation { get { return yRotation; } }
        public float XRotation { get { return xRotation; } }

        void Start()
        {
            if (GameManager.Instance._statePasedInit == true)
            {
                //Cursor.lockState = CursorLockMode.Locked;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance._statePasedInit)
            {
                if (Input.GetKey("space")) // use GetKey for holding key down, GetKeyDown() is for one frame of pressed
                {
                    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                    float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
                    xRotation -= mouseY;
                    xRotation = Mathf.Clamp(xRotation, -45, 45);
                    yRotation -= mouseX;
                    yRotation = Mathf.Clamp(yRotation, -45, 45);
                    transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
                    if (xRotation <= 0)
                        turningPositiveX = true;
                    else
                        turningPositiveX = false;
                    if (yRotation <= 0)
                        turningPositiveY = true;
                    else
                        turningPositiveY = false;
                }
                else
                {
                    float autoY = 0.02f;
                    float autoX = 0.02f;

                    if (turningPositiveX)
                    {
                        xRotation += autoX;
                        if (xRotation > 45f)
                            turningPositiveX = false;
                    }
                    else if (!turningPositiveX)
                    { 
                        xRotation -= autoX;
                        if (xRotation < -45f)
                            turningPositiveX = true;
                    }
                    if (turningPositiveY)
                    {
                        yRotation += autoY;
                        if (yRotation > 45f)
                            turningPositiveY = false;
                    }
                    else if (!turningPositiveY)
                    {
                        yRotation -= autoY;
                        if (yRotation < -45)
                            turningPositiveY = true;
                    }

                    transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
                }
            }
        }
    }
}
