using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Assets.Script;
using BOTF3D_GalaxyMap;
using BOTF3D_Combat;
using UnityEngine.UI;

namespace BOTF3D_Core
{ 
    public class TimeManager : MonoBehaviour
    {
        public static Action OnMinuteChanged;
        public static Action OnStardateChanged;
        public static int gameMinute { get; private set; }
        public static int stardate { get; private set; }

        private float minuteToRealTime = 2f;
        private float timer;
        private bool showTime = false;

        public void StartClock()
        {
            gameMinute = 0;
            stardate = 1010;
            timer = minuteToRealTime;
            showTime= true;
        }


        void Update()
        {
            if (showTime)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    gameMinute++;
                    OnMinuteChanged?.Invoke();
                    if (gameMinute >= 99)
                    {
                        stardate++;
                        gameMinute = 0;
                        OnStardateChanged?.Invoke();
                    }
                    timer = minuteToRealTime;
                }
            }
        }
    }
}