using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
//using BOTF3D_Core;
//using BOTF3D_Combat;
using Assets.Core;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

namespace GalaxyMap
{
    public class HideSystemButton : MonoBehaviour
    {
        public GameObject panelFleetManager;
        public Canvas canvasGalactica;
        public bool weAreHidding = false;
        private void Awake()
        {
            var cameraManagerGalactic = canvasGalactica.transform.Find("CameraManagerGalactica").gameObject;
            panelFleetManager = cameraManagerGalactic.transform.Find("PanelFleetManager").gameObject;
        }
        private void Update()
        {
            if(panelFleetManager.activeSelf == true)
            {
                weAreHidding = true;
            }
            else weAreHidding=false;
        }
    }
}
