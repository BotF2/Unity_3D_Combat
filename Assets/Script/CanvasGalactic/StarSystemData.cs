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
using UnityEngine.UI;
using UnityEngine.Rendering.VirtualTexturing;

namespace BOTF3D_GalaxyMap
{
    public class StarSystemData : MonoBehaviour
    {
        private Sprite _civOwnerImage;
        //public GameObject myImage;
        [SerializeField]
        public static Dictionary<StarSystemEnum, StarSystem> StarSystemDictionary = new Dictionary<StarSystemEnum, StarSystem>(); // { { StarSystemEnum.PLACEHOLDER, new StarSystem(900) } };
        private void Start()
        {
            //myImage.AddComponent(typeof(Sprite));
        }
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
            daSystem._name = sysStrings[4];
            StarType star;
            if (Enum.TryParse(sysStrings[7], out star))
                daSystem._starType = star;
            //daSystem._ownerCiv = CivilizationData.CivilizationDictionary[(CivEnum)systemInt];
            daSystem._sysCredits = 10f;
            daSystem._systemPopLimit = int.Parse(sysStrings[33]);
            daSystem._currentSysPop = int.Parse(sysStrings[6]);
            daSystem._ownerName = sysStrings[5];
            daSystem._ownerInsigniaSprite = Resources.Load<Sprite>("Insignia/" + daSystem._ownerName);
           //daSystem._ownerCiv = do this in CivilizationData
            daSystem._currentSysFactories = float.Parse(sysStrings[32]);
            //_civInsignia leave for CivilizationData to do
            //daSystem._systemPopulation = int.Parse(sysStrings[6]);
            if (sysStrings[5] != "UNINHABITED")
                daSystem._homeColony = true;
            else daSystem._homeColony = false;
            daSystem._text = "blah, blah, blah";
            

            return daSystem;
        }

        public void LoadSystemDictionary(int[] starArray)
        {
            for (int i = 0; i < starArray.Length; i++)
            {
                var sys = StarSystemData.Create(starArray[i]);
                
                StarSystemDictionary.Add(sys._sysEnum, sys);
            }
        }
        public void AddFleet(StarSystemEnum sysEnum, GameObject fleet)
        {
            StarSystem theSystem = StarSystemData.StarSystemDictionary[sysEnum];
            theSystem._fleetsInSystem.Add(fleet.gameObject);
        }
        public void RemoveFleet(StarSystemEnum sysEnum, GameObject fleet)
        {
            StarSystem theSystem = StarSystemData.StarSystemDictionary[sysEnum];
            theSystem._fleetsInSystem.Remove(fleet.gameObject);
        }
        public void UpdateSystemOwner(Civilization civ, StarSystem sys)
        {
            StarSystem theSystem = StarSystemData.StarSystemDictionary[sys._sysEnum];
            theSystem._ownerCiv = civ;
            theSystem._ownerName = civ._shortName;
            theSystem._ownerInsigniaSprite = Resources.Load<Sprite>("Insignia/" + sys._name.ToUpper());
            theSystem._ownerCivSprite = Resources.Load<Sprite>("Civilizations/" + sys._name.ToLower());
            if (civ._shortName.ToUpper() == sys._name.ToUpper())
            {
                theSystem._homeColony = true;
            }
            else theSystem._homeColony = false;

        }
        public StarSystem GetSystem(StarSystemEnum sysEnum)
        {
            return StarSystemDictionary[sysEnum];
        }
    }
}
