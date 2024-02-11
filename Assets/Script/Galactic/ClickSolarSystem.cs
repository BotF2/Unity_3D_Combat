using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Assets.Core;
using UnityEngine.EventSystems;


namespace GalaxyMap
{

    public class ClickSolarSystem : MonoBehaviour
    {
        public GameObject solarSystemView;
        public GameObject hideSystemButton;
        public CameraManagerGalactica cameraManagerGalactica;
        public HideSystemButton hide;
        public SolarSystemView view;
        //public bool BlockedByUI = false;

        private void Awake()
        {
            solarSystemView = GameObject.Find("SolarSystemView");
            view = solarSystemView.GetComponent<SolarSystemView>();
            //hideSystemButton = GameObject.Find("HideSystemButton");
            //hide = hideSystemButton.GetComponent<HideSystemButton>();
        }
        public void ShowThisSolarSystemView(int buttonSystemID)
        {
            //bool isOverUI = EventSystem.current.IsPointerOverGameObject();
            //if (hide.weAreHidding == false) 
            //{
                view.ShowNextSolarSystemView(buttonSystemID);
                
            //}
            //if (isOverUI)
            //{
            //    if (EventSystem.current.currentSelectedGameObject.name == "ResetViewButton")
            //        cameraManagerGalactica.ResetGalacticCamera();
            //}

        }
    }
}
