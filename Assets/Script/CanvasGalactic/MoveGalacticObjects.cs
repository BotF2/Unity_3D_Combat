using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;
using BOTF3D_Combat;
using BOTF3D_Core;

namespace BOTF3D_GalaxyMap
{
    public class MoveGalacticObjects : MonoBehaviour
    {
        //[SerializeField]
        public CivilizationData civilizationData;
        //[SerializeField]
        public GameManager gameManager;


        //public 
        private void OnEnable()
        {
            TimeManager.OnMinuteChanged += TimeCheck;
        }
        private void OnDisable()
        {
            TimeManager.OnMinuteChanged -= TimeCheck;
        }
        private void TimeCheck()
        {
            civilizationData.MoveGalacticThings();
        }

    }
}
