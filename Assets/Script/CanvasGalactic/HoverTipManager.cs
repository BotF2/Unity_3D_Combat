using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Script;
using BOTF3D_Core;
using BOTF3D_Combat;
using UnityEngine.UIElements;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.UI;

namespace BOTF3D_GalaxyMap
{
    public class HoverTipManager : MonoBehaviour
    {
        public TextMeshProUGUI tipText;
        public RectTransform tipWindow;
        //public GameObject tipWindowTwo;

        private RawImage img;
        //private RawImage imgTwo;
        private Vector3 theLocation;
        private StarSystemEnum starSystemEnum;
        private StarSystem theStarSystem;
        [SerializeField]
        public StarSystemData starSystemData;

        public static Action<string, StarSystemEnum> OnMouseHover;
        public static Action OnMouseLoseFocus;

        private void OnEnable()
        {
            OnMouseHover += ShowTip;
            OnMouseLoseFocus += HideTip;
        }
        private void OnDisable()
        {

            OnMouseHover -= ShowTip;
            OnMouseLoseFocus -= HideTip;
        }
        void Start()
        {
            HideTip();
        }
        public void WhereIsTheTip(Vector3 currentPosition)
        {
            Vector3 movedUp = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z - 5);
            theLocation = movedUp;
        }
        public void WhatSystem(StarSystemEnum starSysEneum)
        {
            theStarSystem = StarSystemData.StarSystemDictionary[starSysEneum];
        }
        private void ShowTip(string tip, StarSystemEnum starSystemEnum) //, Vector2 mousePosition);
        {
            var theSystem = StarSystemData.StarSystemDictionary[starSystemEnum];
            tipText.text = theSystem._ownerCiv._shortName;
            img = tipWindow.gameObject.GetComponent<RawImage>();
            img.texture = theSystem._ownerCiv._insignia.texture;

            tipWindow.gameObject.SetActive(true);
            tipWindow.transform.position = theLocation; //new Vector3 (theLocation.x + 200, theLocation.y + 200, theLocation.z - 100);
        }
        private void HideTip()
        {
            tipText.text = default;
            tipWindow.gameObject.SetActive(false);
        }
    }
}
