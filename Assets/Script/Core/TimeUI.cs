using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GalaxyMap;

using UnityEngine.UI;
using DG.Tweening.Core.Easing;
using TMPro;

namespace Assets.Core
{ 
    public class TimeUI : MonoBehaviour
    {
        [SerializeField]
        MoveGalacticObjects moveGalacticObjects;
        //[SerializeField]
        //GalaxyView galaxyView;
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
