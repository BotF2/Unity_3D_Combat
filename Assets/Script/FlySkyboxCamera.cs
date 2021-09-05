using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class FlySkyboxCamera : MonoBehaviour
    {
        public GameManager gameManager;
       // public MouseLook mouseLook;
        public float mouseSensitivity = 1f;
        public float skyboxFactor = 40;
        private float xRotation = 0f;
        private float yRotation = 0f;

        private void Start()
        {

        }
        void Update()
        {
            if (gameManager._statePassedInit == true)
            {
                float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
                xRotation += mouseY;
                xRotation = Mathf.Clamp(xRotation, -35 * skyboxFactor, 35 *skyboxFactor);
                yRotation += mouseX;
                yRotation = Mathf.Clamp(yRotation, -35 *skyboxFactor, 35 * skyboxFactor);
                transform.localRotation = Quaternion.Euler(xRotation * skyboxFactor, yRotation * skyboxFactor, 0f);
                         
                //yRotation = mouseLook.YRotation;
                //xRotation = mouseLook.XRotation;
                //gameObject.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
                //Quaternion rot = Quaternion.Euler( xRotation, yRotation, 0f); 
                //Matrix4x4 m = Matrix4x4.TRS(Vector3.zero, rot, new Vector3(1, 1, 1));
                // targetMaterial.SetMatrix("_Rotation", m);
                // List<float> rotationFloats = new List<float>() { yRotation, xRotation, 0 };
                //RenderSettings.skybox.SetFloat("_Rotation", yRotation);
                // RenderSettings.skybox.SetFloatArray("_Rotation", rotationFloats);
                // RenderSettings.skybox.SetMatrix("Rotation Axis", m);
            }
        }
    }
}

