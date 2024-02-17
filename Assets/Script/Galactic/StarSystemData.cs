using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Core;

namespace GalaxyMap
{
    [CreateAssetMenu(menuName = "Galaxy/SystemData")]
    public class StarSystemData : ScriptableObject // ToDo move StarSystemData in MonoBehavior to this
    {
        public string systemName;
        public string description;  
        public string thisSystem;
        public Vector3 location;
        [SerializeField]
        public int sysIn;
        public Civilization civOwnerEnum;
        [HideInInspector]
        public Sprite starSprit;
        public Sprite civOwnerImage; // asigned in inspector just like SolarSystemView
        public Sprite civInsigniaImage;
        private string originalCivOwnerName;
        public string currentCivOwnerName;
        //private string sysDataName;
        public GameObject myObject;
        public static Dictionary<StarSystemEnum, StarSystem> StarSystemDictionary =
            new Dictionary<StarSystemEnum, StarSystem>();


        public StarSystemData(int sysID)
        {
            StarSystem theSystem = StarSystemData.StarSystemDictionary[(StarSystemEnum)sysID];
            civOwnerImage = theSystem._ownerCivSprite;
            civInsigniaImage = theSystem._ownerInsigniaSprite;
            currentCivOwnerName = theSystem._currentOwnerName;
        }

        //public void UpdateActiveSystemData(int sysID) // update StarSystemData so correct image and name shows in viewed system
        //{
        //    StarSystem theSystem = StarSystemData.StarSystemDictionary[(StarSystemEnum)sysID];
        //    this.civOwnerImage.sprite = theSystem._ownerCivSprite;
        //    this.civInsigniaImage.sprite = theSystem._ownerInsigniaSprite;
        //    this.currentCivOwnerName = theSystem._currentOwnerName;
        //    //originalCivOwnerName = theSystem._originalOwnerName;
        //}

        public static StarSystem Create(int systemInt)
        {
            //ToDo make some uninhabited systems to colonize
            StarSystem daSystem = new StarSystem(systemInt);
            string[] sysStrings = GalaxyView.SystemDataDictionary[systemInt];
            daSystem._sysInt = systemInt;
            daSystem._x = int.Parse(sysStrings[1]);
            daSystem._y = int.Parse(sysStrings[2]);
            daSystem._z = int.Parse(sysStrings[3]);
            daSystem._sysEnum = (StarSystemEnum)systemInt;
            daSystem._sysName = sysStrings[4];
            StarType star;
            //if (Enum.TryParse(sysStrings[7], out star))
            //    daSystem._starType = star;
            //daSystem._ownerCiv = CivilizationData.CivilizationDictionary[(CivEnum)systemInt];
            daSystem._sysCredits = 10f;
            daSystem._systemPopLimit = int.Parse(sysStrings[33]);
            daSystem._currentSysPop = int.Parse(sysStrings[6]);
            daSystem._originalOwnerName = sysStrings[5];
            daSystem._currentOwnerName = sysStrings[5];
            daSystem._ownerInsigniaSprite = Resources.Load<Sprite>("Insignias/" + daSystem._originalOwnerName);
            daSystem._ownerCivSprite = Resources.Load<Sprite>("Civilizations/" + daSystem._originalOwnerName.ToLower());
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

        public void LoadSystemData(int[] starArray)
        {
            for (int i = 0; i < starArray.Length; i++)
            {
                var sys = StarSystemData.Create(starArray[i]);
                this.civOwnerImage = sys._ownerCivSprite;
                this.civInsigniaImage = sys._ownerInsigniaSprite;
                this.currentCivOwnerName = sys._currentOwnerName;
                this.originalCivOwnerName = sys._originalOwnerName;
                this.systemName = sys._sysName;
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
        public void LoadSystemOwner(Civilization civ, StarSystemEnum sys) // Now CivilizationData can provide civ data for system
        {
            StarSystem theSystem = StarSystemData.StarSystemDictionary[sys];
            theSystem._ownerCiv = civ;
            theSystem._currentOwnerName = civ._shortName;
            theSystem._ownerInsigniaSprite = civ._insignia; // Resources.Load<Sprite>("Insignia/" + sys._sysName.ToUpper());
            theSystem._ownerCivSprite = civ._civImage; //Resources.Load<Sprite>("Civilizations/" + sys._sysName.ToLower());
            theSystem._homeColony = true;
            //civOwnerImage.sprite = theSystem._ownerCivSprite;
            //civInsigniaImage.sprite = theSystem._ownerInsigniaSprite;
            //originalCivOwnerName = theSystem._originalOwnerName;
        }
        public void UpdateSystemOwner(StarSystem sys, Civilization civ) // change civ owner in StarSystemDictionary
        {
            // code here for getting sprite by civ
            StarSystem theSystem = StarSystemData.StarSystemDictionary[sys._sysEnum];
            theSystem._ownerCiv = civ;
            theSystem._currentOwnerName = civ._shortName;
            theSystem._ownerInsigniaSprite = civ._insignia; // Resources.Load<Sprite>("Insignia/" + sys._sysName.ToUpper());
            theSystem._ownerCivSprite = civ._civImage; //Resources.Load<Sprite>("Civilizations/" + sys._sysName.ToLower());
            if (civ._shortName.ToUpper() == sys._originalOwnerName.ToUpper())
            {
                theSystem._homeColony = true;
            }
            else theSystem._homeColony = false;
            //civOwnerImage.sprite = theSystem._ownerCivSprite;
            //civInsigniaImage.sprite = theSystem._ownerInsigniaSprite;
            //originalCivOwnerName = theSystem._originalOwnerName;

        }
        public StarSystem GetSystem(StarSystemEnum sysEnum)
        {
            if (StarSystemDictionary.ContainsKey(sysEnum))
                return StarSystemDictionary[sysEnum];
            else return null;
        }
        public Sprite GetSystemOwnerSprite(StarSystemEnum sysEnum)
        {
            return StarSystemDictionary[sysEnum]._ownerInsigniaSprite;
        }
        public string GetSystemOwenerName(StarSystemEnum sysEnum)
        {
            return StarSystemDictionary[sysEnum]._originalOwnerName;
        }
        public void ResetData()
        {
            myObject = null;
            location = Vector3.zero;
        }

    }
}

