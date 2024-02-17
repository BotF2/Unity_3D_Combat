using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Core;
//using BOTF3D_Core;
//using BOTF3D_Combat;
using UnityEngine.UIElements;
using UnityEngine.UI;

namespace GalaxyMap
{
    public class HoverTips : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public string tipToShow;
        private float timeToHoverWait = 0.5f;
        [SerializeField]
        public HoverTipManager _hoverTipManager;
        [SerializeField] 
        public StarSystemEnum _starSysEnum;
        public Vector3 _sysLocation;

        public void OnPointerEnter(PointerEventData eventData)
        {
            StopAllCoroutines();
            _hoverTipManager.WhereIsTheTip(_sysLocation);//gameObject.transform.position);
            _hoverTipManager.WhatSystem(_starSysEnum); // send the starsystem enum to the manager
            StartCoroutine(StartTimer());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            StopAllCoroutines();
            HoverTipManager.OnMouseLoseFocus();
        }
        private void ShowMessage()
        {
            HoverTipManager.OnMouseHover( _starSysEnum); //, Input.mousePosition);
        }
        private IEnumerator StartTimer()
        {
            yield return new WaitForSeconds(timeToHoverWait);
            ShowMessage();
        } 
    }
}
