using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BOTF3D_Core;
using BOTF3D_Combat;
using Assets.Script;
using UnityEngine.Rendering;


namespace BOTF3D_GalaxyMap
{
    public class DragTargetPointer: MonoBehaviour
    {
        private Vector3 mOffset;
        //public GameObject targetPointer;
        private float targetPointerZ;
        public Camera galaxyCamera;

        private void OnMouseDown()
        {
            targetPointerZ = galaxyCamera.WorldToScreenPoint(gameObject.transform.position).y;
            // Store offset = gameobject world pos - mouse world pos
            mOffset = gameObject.transform.position - GetMouseWorldPos(); //- GetMouseWorldPos();
           // mOffset.z = 0f;
        }
        private Vector3 GetMouseWorldPos()
        {
            // screen pixel coordinates (x,y)
            Vector3 mousePointer = Input.mousePosition;
            // z coordiaten of game object TargetPointer on screen
            mousePointer.z = targetPointerZ;
            Vector3 myVetor = galaxyCamera.ScreenToViewportPoint(mousePointer);
            return myVetor; //galaxyCamera.ScreenToViewportPoint(mousePointer);
        }
        void OnMouseDrag()
        {
            //Vector3 scaleOffset = new Vector3((mOffset.x * 10f), (mOffset.y * 10f), mOffset.z);
            transform.position = GetMouseWorldPos() + mOffset;
        }
    }
}
