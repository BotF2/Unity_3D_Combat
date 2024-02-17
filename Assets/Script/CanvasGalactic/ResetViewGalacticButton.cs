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
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;

namespace GalaxyMap
{

    public class ResetViewGalacticButton : MonoBehaviour
    {
        UIDocument buttonDoc;
        Button uiGalaxyResetViewButton;
        public CameraManagerGalactica cameraManagerGalactica;
        //public GameManager gameManager;
        private void OnEnable()
        {
            buttonDoc = this.GetComponent<UIDocument>();
            if (buttonDoc == null )
            { Debug.LogError("No Button Document found"); }
            uiGalaxyResetViewButton = buttonDoc.rootVisualElement.Q("ResetView") as Button;
            if (uiGalaxyResetViewButton != null)
            {
                Debug.Log("Reset View button found");
            }
            uiGalaxyResetViewButton.RegisterCallback<ClickEvent>(OnResetViewClicked);
        }

        public void OnResetViewClicked(ClickEvent evt)
        {
            cameraManagerGalactica.ResetGalacticCamera();
        }
    }
}
