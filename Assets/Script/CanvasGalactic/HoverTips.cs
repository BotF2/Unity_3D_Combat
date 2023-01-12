using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Script;
using BOTF3D_Core;
using BOTF3D_Combat;
using UnityEngine.UIElements;
using UnityEngine.UI;

namespace BOTF3D_GalaxyMap
{
    public class HoverTips : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public string tipToShow;
        private float timeToHoverWait = 0.5f;
        public HoverTipManager hoverTipManager;
        public GameObject myParent;
        [SerializeField] 
        private StarSystemEnum _starSysEnum;

        public void OnPointerEnter(PointerEventData eventData)
        {
            StopAllCoroutines();
            hoverTipManager.WhereIsTheTip(gameObject.transform.position);
            hoverTipManager.WhatSystem(_starSysEnum);
            StartCoroutine(StartTimer());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            StopAllCoroutines();
            HoverTipManager.OnMouseLoseFocus();
        }
        private void ShowMessage()
        {
            HoverTipManager.OnMouseHover(tipToShow, _starSysEnum); //, Input.mousePosition);
        }
        private IEnumerator StartTimer()
        {
            yield return new WaitForSeconds(timeToHoverWait);
            ShowMessage();
        } 
    }
}
