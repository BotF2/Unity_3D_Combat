using Assets.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GalaxyMap
{
    public class GalaxyObjectClick : MonoBehaviour, IPointerClickHandler
    {
        bool ClickUI = true;
        public CameraManagerGalactica cameraManagerGalactica;
        // Start is called before the first frame update
        //void Start()
        //{

        //}

        //// Update is called once per frame
        //void Update()
        //{

        //}
        public void OnPointerClick(PointerEventData eventData)
        {
            // could tell us what game object was clicked
            //    if (EventSystem.current.IsPointerOverGameObject())
            //    {
            //        if (EventSystem.current.currentSelectedGameObject.name == "ResetViewButton")
            //        {
            //            ClickUI = true;
            //        }
            //    }
            //eventData.selectedObject
            //ClickUI = false;
            //if (cameraManagerGalactica != null)
            //    cameraManagerGalactica.ClickUI = false;
        }
    }
}
