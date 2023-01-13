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
        public static Dictionary<StarSystemEnum, StarSystem> StarSystemDictionary = new Dictionary<StarSystemEnum, StarSystem>() { { StarSystemEnum.PLACEHOLDER, new StarSystem(900) } };

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
            daSystem._ownerCiv = CivilizationData.CivilizationDictionary[(CivEnum)systemInt];
            daSystem._systemPopulation = int.Parse(sysStrings[6]);
            daSystem._homeColony = true;
            //daSystem._ownerName = daSystem._ownerCiv.name;
            //_civInsignia leave for StarSystemDataBase to do
            //    _systemPopulation = 2;
            //    _systemResearch = 2;
            //    _homeColony = true;
            //    _text = "blah, blah, blah";
            StarSystemDictionary.Add(daSystem._sysEnum, daSystem);

            return daSystem;
        }
    }
}
