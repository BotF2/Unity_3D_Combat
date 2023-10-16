using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Script;
using BOTF3D_Core;
using BOTF3D_Combat;

namespace BOTF3D_GalaxyMap
{
    public class BlockUIclick : MonoBehaviour, IPointerClickHandler
    {
        //public Camera cam; // galactic camera
        //Vector3 offset;

        //public void BlockSystemClick()
        //{
        //    clickedSolarSystem.BlockedByUI = true;
        //}
        //private void Start()
        //{
        //    offset = cam.transform.position - transform.position;
        //}
        //void Update()
        //{
        //    transform.position = transform.position + offset;//Camera.main.transform.forward * distance * Time.deltaTime;
        //}
        public void OnPointerClick(PointerEventData data)
        {
            // This will only execute if the objects collider was the first hit by the click's raycast
            //if (clickedSolarSystem != null)
            //clickedSolarSystem.BlockedByUI = true;
        }
    }
}
