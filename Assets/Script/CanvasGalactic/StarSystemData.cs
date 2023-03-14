using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Assets.Script;
using BOTF3D_Core;
using BOTF3D_Combat;
using UnityEngine.XR;
using JetBrains.Annotations;

namespace BOTF3D_GalaxyMap
{
    public class StarSystemData : MonoBehaviour
    {
        [SerializeField]
        public static Dictionary<StarSystemEnum, StarSystem> StarSystemDictionary = new Dictionary<StarSystemEnum, StarSystem>(); // { { StarSystemEnum.PLACEHOLDER, new StarSystem(900) } };

        public static StarSystem Create(int systemInt)
        {
            //ToDo make some uninhabited systems to colonize
            StarSystem daSystem = new StarSystem(systemInt);
            string[] sysStrings = GalaxyView.SystemDataDictionary[systemInt];
            daSystem._systemInt = systemInt;
            daSystem._x = int.Parse(sysStrings[1]);
            daSystem._y = int.Parse(sysStrings[2]);
            daSystem._z = int.Parse(sysStrings[3]);
            daSystem._sysEnum = (StarSystemEnum)systemInt;
            daSystem._sysName = sysStrings[4];
            StarType star;
            if (Enum.TryParse(sysStrings[7], out star))
                daSystem._starType = star;
            //daSystem._ownerCiv = CivilizationData.CivilizationDictionary[(CivEnum)systemInt];
            daSystem._sysCredits = 10f;
            daSystem._systemPopLimit = int.Parse(sysStrings[33]);
            daSystem._currentSysPop = int.Parse(sysStrings[6]);
            daSystem._ownerName = sysStrings[5];
            daSystem._currentSysFactories = float.Parse(sysStrings[32]);
            //_civInsignia leave for CivilizationData to do
            //daSystem._systemPopulation = int.Parse(sysStrings[6]);
            if (sysStrings[5] != "UNINHABITED")
                daSystem._homeColony = true;
            else daSystem._homeColony = false;
            daSystem._text = "blah, blah, blah";

            return daSystem;
        }
        //public StarSystem GetStarSystemByInt(int sysInt) // Use the Ditoinary
        //{
        //    return StarSystemData.Create(sysInt); // = sysInt;
        //    //return this;
        //}
        public void LoadSystemDictionary(int[] starArray)
        {
            for (int i = 0; i < starArray.Length; i++)
            {
                var sys = StarSystemData.Create(starArray[i]);
                
                StarSystemDictionary.Add(sys._sysEnum, sys);
            }
        }
        public void UpdateSystemOwner(Civilization civ, StarSystem sys)
        {
            StarSystem theSystem = StarSystemData.StarSystemDictionary[sys._sysEnum];
            theSystem._ownerCiv = civ;
        }
        //public void AddSysPopulation()
        //{
            
        //}
    }
}
