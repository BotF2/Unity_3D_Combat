using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GalaxyMap;
using UnityEngine.UI;

namespace Assets.Core
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
        int moveCounter = 5;

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
                if (moveCounter < 1)
                {
                    for (int i = 0; i < GalaxyView._movingGalaxyObjects.Count; i++)
                    {
                        MoveGalacticObjects myMoveGalactic = GalaxyView._movingGalaxyObjects[i].GetComponent<MoveGalacticObjects>();
                        myMoveGalactic.ThrustVector(); // move galaxy objects
                       // myMoveGalactic.MovePlanePoint(); // move objects plane endpoints
                    }
                    moveCounter = 5;
                }
                else moveCounter--;
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
