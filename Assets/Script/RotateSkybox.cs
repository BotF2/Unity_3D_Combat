using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class RotateSkybox : MonoBehaviour
    {
        public GameManager gameManager;
        public MouseLook mouseLook;
        private float speed;

        private float xRotation = 0f;
        private float yRotation = 0f;

        private void Start()
        {         
            //speed = gameManager.viewCombatSpeed;
        }
        void Update()
        {
            if (gameManager._statePassedInit == true)
            {

                //yRotation = mouseLook.YRotation;
                //xRotation = mouseLook.XRotation;
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
