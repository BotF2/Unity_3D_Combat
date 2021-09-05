using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class MouseLook : MonoBehaviour
    {
        public GameManager gameManager;
        public float mouseSensitivity = 1f;
        private float xRotation = 0f;
        private float yRotation = 0f;

        public float YRotation { get { return yRotation; } }
        public float XRotation { get { return xRotation; } }

        void Start()
        {
            if (gameManager.StatePassedInit == true)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (gameManager.StatePassedInit == true)
            {
                float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -35, 35);
                yRotation -= mouseX;
                yRotation = Mathf.Clamp(yRotation, -35, 35);
                transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);              
               // moveCombatObject.Rotate(Vector3.up * mouseX);
            }


        }
    }
}
