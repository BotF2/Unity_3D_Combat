using Assets.Core;
using System.Collections.Generic;
using UnityEngine;

namespace GalaxyMap
{
    [CreateAssetMenu(menuName = "Galaxy/StarSystemSO")]
    public class StarSystemSO : ScriptableObject // ToDo move StarSystemSO in MonoBehavior to this
    {
        public int _sysInt;
        public int _x;//done currentPosition vetor and tranform move in MonoBehavior inheriting StarSystemSO attached to a GO?
        public int _y;
        public int _z;
        public string sysName;
        public Vector3 location;
        public StarSystemEnum _starSystemEnum;
        public CivEnum starSystemFirstOwner;
        public CivEnum starSystemCurrentOwner;
        public StarType starSystemType;
        //public Civilization civOwnerEnum;
        public float _sysCredits = 10f;
        public int _systemPopLimit;
        public int _currentSysPop;
        public string _originalOwnerName;
        public string _currentOwnerName;

        [HideInInspector]
        public Sprite starSprit;
        public Sprite _civOwnerSprite; // asigned in inspector just like SolarSystemView
        public Sprite _ownerInsignia;
        public float _currentSysFactories;
        private string originalCivOwnerName;
        public string currentCivOwnerName;
        public bool _homeColony;
        public GameObject myObject;
        public string _text;
        public static Dictionary<StarSystemEnum, StarSystemSO> StarSystemDictionary =
            new Dictionary<StarSystemEnum, StarSystemSO>();


        //public StarSystemSO(int sysID)
        //{
        //    StarSystemSO theSystemData = StarSystemSO.StarSystemDictionary[(StarSystemEnum)sysID];
        //    _civOwnerSprite = theSystemData._ownerCivSprite;
        //    civInsignia = theSystemData._ownerInsigniaSprite;
        //    currentCivOwnerName = theSystemData._currentOwnerName;
        //}

        //public void UpdateActiveSystemData(int sysID) // update StarSystemSO so correct image and name shows in viewed system
        //{
        //    StarSystemManager theSystemData = StarSystemSO.StarSystemDictionary[(StarSystemEnum)sysID];
        //    this.civOwnerImage.sprite = theSystemData._ownerCivSprite;
        //    this.civInsignia.sprite = theSystemData._ownerInsigniaSprite;
        //    this.currentCivOwnerName = theSystemData._currentOwnerName;
        //    //originalCivOwnerName = theSystemData._originalOwnerName;
        //}

        //public static StarSystemSO InitializFleet(int systemInt)
        //{
        //    //ToDo make some uninhabited systems to colonize
        //    StarSystemSO daSystem = new StarSystemSO(systemInt);
        //    string[] sysStrings = GalaxyView.SystemDataDictionary[systemInt];
        //    daSystem._sysInt = systemInt;
        //    daSystem._x = int.Parse(sysStrings[1]);
        //    daSystem._y = int.Parse(sysStrings[2]);
        //    daSystem._z = int.Parse(sysStrings[3]);
        //    daSystem._sysEnum = (StarSystemEnum)systemInt;
        //    daSystem._sysName = sysStrings[4];
        //    StarType star;
        //    //if (Enum.TryParse(sysStrings[7], out star))
        //    //    daSystem._starType = star;
        //    //daSystem._ownerCiv = CivData.CivilizationDictionary[(CivEnum)systemInt];
        //    daSystem._sysCredits = 10f;
        //    daSystem._systemPopLimit = int.Parse(sysStrings[33]);
        //    daSystem._currentSysPop = int.Parse(sysStrings[6]);
        //    daSystem._originalOwnerName = sysStrings[5];
        //    daSystem._currentOwnerName = sysStrings[5];
        //    daSystem._ownerInsigniaSprite = Resources.Load<Sprite>("Insignias/" + daSystem._originalOwnerName);
        //    daSystem._ownerCivSprite = Resources.Load<Sprite>("Civilizations/" + daSystem._originalOwnerName.ToLower());
        //    daSystem._currentSysFactories = float.Parse(sysStrings[32]);
        //    //_civInsignia leave for CivData to do
        //    //daSystem._systemPopulation = int.Parse(sysStrings[6]);
        //    if (sysStrings[5] != "UNINHABITED")
        //        daSystem._homeColony = true;
        //    else daSystem._homeColony = false;
        //    daSystem._text = "blah, blah, blah";
        //    //SetSystemOwner(daSystem);
        //    //civOwnerSprite = daSystem._ownerCivSprite;
        //    //civOwnerName = daSystem._ownerName;

        //    return daSystem;
        //}

        //public void LoadSystemData(int[] starArray)
        //{
        //    for (int i = 0; i < starArray.Length; i++)
        //    {
        //        var sysData = StarSystemSO.InitializFleet(starArray[i]);
        //        this.civOwnerImage = sysData._ownerCivSprite;
        //        this.civInsignia = sysData._ownerInsigniaSprite;
        //        this.currentCivOwnerName = sysData._currentOwnerName;
        //        this.originalCivOwnerName = sysData._originalOwnerName;
        //        this.systemName = sysData._sysName;
        //        StarSystemDictionary.Add(sysData._sysEnum, sysData);
        //    }
        //}
        public void AddFleet(CivData civData, FleetController fleetData)
        {
            //if (!civData.fleetsDictionary.ContainsKey(fleetData.fleetNum))
            //    civData.fleetsDictionary.Add(fleetData.fleetNum,fleetData);
            //else do something
        }
        public void RemoveFleet(CivData civData, FleetController fleetData)
        {
            //if (civData.fleetsDictionary.ContainsKey(fleetData.fleetNum))
            //    civData.fleetsDictionary.Remove(fleetData.fleetNum);
        }
        public void LoadSystemOwner(CivData civData, StarSystemSO sysData) // Now CivData can provide newCivDataOnwer data for system
        { // Do we need this anymore?
            //StarSystemSO theSystemData = StarSystemManager.StarSystemDictionary[sysData];
            //theSystemData._ownerCiv = civData;
            //theSystemData._currentOwnerName = civData._shortNameText.ToString();
            //theSystemData._ownerInsigniaSprite = civData._insignia; // Resources.Load<Sprite>("Insignia/" + sysData._sysName.ToUpper());
            //theSystemData._ownerCivSprite = civData._civImage; //Resources.Load<Sprite>("Civilizations/" + sysData._sysName.ToLower());
            //theSystemData._homeColony = true;
            //civOwnerImage.sprite = theSystemData._ownerCivSprite;
            //civInsignia.sprite = theSystemData._ownerInsigniaSprite;
            //originalCivOwnerName = theSystemData._originalOwnerName;
        }
        //public void UpdateSystemOwner(StarSystemSO theSystemData, CivData newCivDataOnwer) // change newCivDataOnwer owner in StarSystemDictionary
        //{
        //    // code here for getting sprite by newCivDataOnwer
        //    //StarSystemSO theSystemData = newCivDataOnwer.starSysDataDictionary[sysData._starSystemEnum];
      
        //    theSystemData.starSystemCurrentOwner = newCivDataOnwer._civEnum;
        //    theSystemData._civOwnerSprite = newCivDataOnwer._civInsign; // Resources.Load<Sprite>("Insignia/" + sysData._sysName.ToUpper());
        //    theSystemData._ownerInsignia = newCivDataOnwer._civImage; //Resources.Load<Sprite>("Civilizations/" + sysData._sysName.ToLower());
        //    if (newCivDataOnwer._civEnum.ToString() == theSystemData.starSystemFirstOwner.ToString())
        //    {
        //        theSystemData._homeColony = true;
        //    }
        //    else theSystemData._homeColony = false;
        //    theSystemData.currentCivOwnerName = newCivDataOnwer.name;

        //}
        //public StarSystemSO GetSystem(StarSystemEnum sysEnum)
        //{
        //    if (StarSystemDictionary.ContainsKey(sysEnum))
        //        return StarSystemDictionary[sysEnum];
        //    else return null;
        //}
        //public Sprite GetSystemOwnerSprite(StarSystemEnum sysEnum)
        //{
        //    return StarSystemDictionary[sysEnum]._ownerInsignia;
        //}
        //public string GetSystemOwenerName(StarSystemEnum sysEnum)
        //{
        //    return StarSystemDictionary[sysEnum]._originalOwnerName;
        //}
        public void ResetData()
        {
            myObject = null;
            location = Vector3.zero;
        }

    }
}

