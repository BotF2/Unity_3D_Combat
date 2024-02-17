using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Core;
//using BOTF3D_Combat;
//using BOTF3D_Core;
using System;

namespace GalaxyMap
{
    [RequireComponent(typeof(MeshCollider))]
    public class Telescope : MonoBehaviour
    {
        private Vector3 myOffset;

        private float mZCoord;

        public Camera GalacticCamera;

        private void OnMouseDown()
        {
            mZCoord = GalacticCamera.WorldToScreenPoint(gameObject.transform.position).z;
            // store myOffset = telescope gameObject world position - mouse world postion
            myOffset = gameObject.transform.position - GetMouseWorldPos();
        }
        private Vector3 GetMouseWorldPos()
        {
            Vector3 mousePoint = Input.mousePosition;
            mousePoint.z = mZCoord;
            return GalacticCamera.ScreenToWorldPoint(mousePoint);
        }
        private void OnMouseDrag()
        {
            transform.position = GetMouseWorldPos() + myOffset;
        }
    }
}
