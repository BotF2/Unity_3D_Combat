using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BOTF3D_GalaxyMap;
using Assets.Script;
using BOTF3D_Combat;

namespace BOTF3D_Core 
{
    public class Billboard : MonoBehaviour
    {
        // use on torpedo sprit
        private Camera theCam;
        private float rotate = 1f;

        void Start()
        {
            theCam = Camera.main; // only find it once
        }

        // Update is called once per frame
        void LateUpdate()
        {
            rotate += 150;
            transform.LookAt(theCam.transform);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, rotate);
        }
    }
}