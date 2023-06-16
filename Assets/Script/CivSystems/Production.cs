using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Assets.Script;
using BOTF3D_Combat;
using BOTF3D_GalaxyMap;
using DG.Tweening.Core.Easing;

namespace BOTF3D_Core
{
    public class Production : MonoBehaviour
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
            // Civilization Tech at production [shipyard] (TIME IS KEY, low tech civ produces ships faster but weaker [cardassian] vs high tech produced slower stronger [borg],
            // Fed 10, Rom 12, Kling 10, Card 5 Dom 15, Borg 20
            // in production the higher the civ tech the longer to build in shipyard
            // Tech Level driven by Research Points, RS(the era, Enterprise vs TOS vs TNG vs...) all civs at enterprise era stars at 10RS and at TOS ear 20 RS
            // and Population is credits for production (early tech fed, rom, kling, card systems start at 20 pop, Dom at 30, borg at 40)
            // total credits per time = population (20 for staring Fed, Kling, Rom system and + as more systems added and + over time)

            // ship equality = civTech * research points
            // time to produce ship = population(Credits)/civTech, a drain on credits
            // total credits = maintenance + production, the drains on credits
            // Population = [population + (100/ research points)]/ population
            // total Credits is population (popCredits),+ population to credits over time
            // Produce();
            civilizationData.DoSystemProduction();
            civilizationData.DoDiplomacy(); // ??not on time steps, just do it???
            //civilizationData.DoConsumption();
            //civilizationData.AddTech();
            //civilizationData.AddSpy();
            //civilizationData.DoCivProduction();         
        }
        private void Produce() //not in this class, do it in CivilizationData.DoCivProduction
        {

        }
    }
}
