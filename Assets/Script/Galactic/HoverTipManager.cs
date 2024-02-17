using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Core;
using UnityEngine.UIElements;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.UI;
using Unity.VisualScripting;

namespace GalaxyMap
{
    public class HoverTipManager : MonoBehaviour
    {
        public GameManager gameManager;
        public CivilizationData civilizationData;
        public TextMeshProUGUI tipText;
        public RectTransform tipWindow;

        private RawImage img;

        private Vector3 theLocation;
        private StarSystem theStarSystem;
        [SerializeField]
        public StarSystemData starSystemData;

        public static Action<StarSystemEnum> OnMouseHover;
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
            Vector3 where = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z - 5);
            theLocation = where;
        }
        public void WhatSystem( StarSystemEnum starSysEnum)
        {
            theStarSystem = StarSystemData.StarSystemDictionary[starSysEnum];
        }
        private bool DoWeKnowThem(Civilization civ)
        {
            bool weKnowThem= false;
            //if (GameManager.Instance._localPlayerCiv == null) 
               // GameManager.Instance.SetCivs();
            Civilization localPlayer = GameManager.Instance._localPlayerCiv;
            for (int i = 0; i < localPlayer._contactList.Count; i++)
            {
                if (localPlayer._contactList[i]._shortName == civ._shortName)
                    weKnowThem = true;
            }
            return weKnowThem;
        }
        private void ShowTip(StarSystemEnum starSystemEnum) //, Vector2 mousePosition);
        {
            StarSystem theSystem = StarSystemData.StarSystemDictionary[starSystemEnum];
            if (DoWeKnowThem(theSystem._ownerCiv))
            {
                tipText.text = theSystem._ownerCiv._shortName;
                tipWindow.localScale = new Vector3(1, 1, 1);
                if (theSystem._y > -1000)
                {
                    tipWindow.localScale *= 2f; // if deep into screen make it bigger
                }
                else if (theSystem._x > -4700)
                {
                    tipWindow.localScale *= 1.5f; // if deep into screen make it bigger
                }
                img = tipWindow.gameObject.GetComponent<RawImage>();
                img.texture = theSystem._ownerCiv._civImage.texture;

                tipWindow.gameObject.SetActive(true);
                tipWindow.transform.localPosition = theLocation; //new Vector3 (theLocation.x + 200, theLocation.inputY + 200, theLocation.zLine - 100);
            }
        }
        private void HideTip()
        {
            tipText.text = default;
            tipWindow.gameObject.SetActive(false);
        }
    }
}
