using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using BOTF3D_Core;
using Assets.Script;
using BOTF3D_Combat;
using UnityEngine.EventSystems;


namespace BOTF3D_GalaxyMap
{
    public class NextSolarSystem : MonoBehaviour
    {
        public GameObject solarSystemView;
        public GameObject hideSystemButton;
        public HideSystemButton hide;
        public SolarSystemView view;

        private void Awake()
        {
            solarSystemView = GameObject.Find("SolarSystemView");
            view = solarSystemView.GetComponent<SolarSystemView>();
            hideSystemButton = GameObject.Find("HideSystemButton");
            hide = hideSystemButton.GetComponent<HideSystemButton>();
        }
        ////public void ShowThisSolarSystemView(int buttonSystemID)
        ////{
        ////    if (hide.weAreHidding == false)
        ////    {
        ////        view.ShowNextSolarSystemView(buttonSystemID);
        ////    }

        ////}
    }
}
