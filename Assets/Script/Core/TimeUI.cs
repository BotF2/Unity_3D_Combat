using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;
using BOTF3D_GalaxyMap;
using BOTF3D_Combat;
using UnityEngine.UI;
using DG.Tweening.Core.Easing;
using TMPro;

namespace BOTF3D_Core
{ 
    public class TimeUI : MonoBehaviour
    {
        [SerializeField]
        public TextMeshProUGUI timeText;
        private void OnEnable()
        {
            TimeManager.OnMinuteChanged += UpdateTime; // on invoked add method, not call method
            TimeManager.OnStardateChanged += UpdateTime;
        }
        private void OnDisable()
        {
            TimeManager.OnMinuteChanged -= UpdateTime;
            TimeManager.OnStardateChanged -= UpdateTime;
        }
        private void UpdateTime()
        {
            timeText.text = $"Stardate: {TimeManager.stardate:0000}.{TimeManager.gameMinute:00}";
        }
    }
}
