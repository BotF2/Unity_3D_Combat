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

namespace BOTF3D_GalaxyMap
{
    public class HoverTipManager : MonoBehaviour
    {
        public TextMeshProUGUI tipText;
        public RectTransform tipWindow;
        private Vector3 theLocation;

        public static Action<string> OnMouseHover;
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
        private void ShowTip(string tip) //, Vector2 mousePosition);
        {
            tipText.text = tip;
            //tipWindow.sizeDelta= new Vector2(tipText.preferredWidth > 200 ? 200 : tipText.preferredWidth, tipText.preferredHeight);
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
