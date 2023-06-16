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

        public Image civOwnerImage;

        public Sprite spriteForOwner;

        public string civOwnerName;

        [SerializeField]
        public static Dictionary<StarSystemEnum, StarSystem> StarSystemDictionary = new Dictionary<StarSystemEnum, StarSystem>(); 
        private void Start()
        {
            //GameObject imageObject = GameObject.FindGameObjectWithTag("SysOwnerCivImage");
            //if (imageObject != null)
            //{
            //    civOwnerImage = imageObject.GetComponent<Image>();
            //}
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
            daSystem._ownerCivSprite = Resources.Load<Sprite>("Civilizations/" + daSystem._ownerName.ToLower());
            daSystem._currentSysFactories = float.Parse(sysStrings[32]);
            //_civInsignia leave for CivilizationData to do
            //daSystem._systemPopulation = int.Parse(sysStrings[6]);
            if (sysStrings[5] != "UNINHABITED")
                daSystem._homeColony = true;
            else daSystem._homeColony = false;
            daSystem._text = "blah, blah, blah";
           //SetSystemOwner(daSystem);
            //civOwnerSprite = daSystem._ownerCivSprite;
            //civOwnerName = daSystem._ownerName;

            return daSystem;
        }
        //private void SetSystemOwner(StarSystem theSystem)
        //{
        //    civOwnerSprite = theSystem._ownerCivSprite;
        //    civOwnerName = theSystem._ownerName;
        //}
        public void LoadSystemDictionary(int[] starArray)
        {
            for (int i = 0; i < starArray.Length; i++)
            {
                var sys = StarSystemData.Create(starArray[i]);
                civOwnerImage.sprite = sys._ownerCivSprite;
                civOwnerName = sys._ownerName;
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
            civOwnerImage.sprite = theSystem._ownerCivSprite;
            civOwnerName = theSystem._ownerName;

        }
        //public void ownerImageSpriteChange(StarSystem sys, Civilization civ)
        //{
        //    // code here for getting sprite by civ
        //    civOwnerImage.sprite = spriteForOwner;
        //}
        public StarSystem GetSystem(StarSystemEnum sysEnum)
        {
            return StarSystemDictionary[sysEnum];
        }
        public Sprite GetSystemOwnerSprite(StarSystemEnum sysEnum)
        {
            return StarSystemDictionary[sysEnum]._ownerInsigniaSprite;
        }
        public string GetSystemOwenerName(StarSystemEnum sysEnum)
        {
            return StarSystemDictionary[sysEnum]._ownerName;
        }

    }
}
