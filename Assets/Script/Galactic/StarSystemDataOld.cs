using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Assets.Core;

using UnityEngine.XR;
using JetBrains.Annotations;
using UnityEngine.UI;
using UnityEngine.Rendering.VirtualTexturing;

namespace GalaxyMap
{
    //[System.Serializable]
    public class StarSystemDataOld: MonoBehaviour
    {
        //public Image civOwnerImage; // asigned in inspector just like SolarSystemView
        //public Image civInsignia;
        //private string originalCivOwnerName;
        //public string currentCivOwnerName;
        //private string sysDataName;
        // public List<ShipYardData> shipYardDataList;
        //[SerializeField]
        //public static Dictionary<StarSystemEnum, StarSystemManager> StarSysDictionary = new Dictionary<StarSystemEnum, StarSystemManager>();

        //public StarSystemSO(int sysID)
        //{
        //    StarSystemManager theSystem = StarSystemSO.StarSysDictionary[(StarSystemEnum)sysID];
        //    civOwnerImage.sprite = theSystem._ownerCivSprite;
        //    civInsignia.sprite = theSystem._ownerInsigniaSprite;
        //    currentCivOwnerName = theSystem._currentOwnerName;
        //}
        //public void UpdateActiveSystemData(int sysID) // update StarSystemSO so correct image and name shows in viewed system
        //{
        //    StarSystemManager theSystem = StarSystemSO.StarSysDictionary[(StarSystemEnum)sysID];
        //    this.civOwnerImage.sprite = theSystem._ownerCivSprite;
        //    this.civInsignia.sprite = theSystem._ownerInsigniaSprite;
        //    this.currentCivOwnerName = theSystem._currentOwnerName;
        //    //originalCivOwnerName = theSystem._originalOwnerName;
        //}
        //public static StarSystemManager InitializFleet(int systemInt)
        //{
        //    //ToDo make some uninhabited systems to colonize
        //    StarSystemManager daSystem = new StarSystemManager(systemInt);
        //    string[] sysStrings = GalaxyView.SystemDataDictionary[systemInt];
        //    daSystem._sysInt = systemInt;
        //    daSystem._x = int.Parse(sysStrings[1]);
        //    daSystem._y = int.Parse(sysStrings[2]);
        //    daSystem._z = int.Parse(sysStrings[3]);
        //    daSystem._sysEnum = (StarSystemEnum)systemInt;
        //    daSystem._sysName = sysStrings[4];
        //    StarType star;
        //    if (Enum.TryParse(sysStrings[7], out star))
        //        daSystem._starType = star;
        //    //daSystem._ownerCiv = CivilizationData.CivilizationDictionary[(CivEnum)systemInt];
        //    daSystem._sysCredits = 10f;
        //    daSystem._maxSysPop = int.Parse(sysStrings[33]);
        //    daSystem._currentSysPop = int.Parse(sysStrings[6]);
        //    daSystem._originalOwnerName = sysStrings[5];
        //    daSystem._currentOwnerName = sysStrings[5];
        //    daSystem._ownerInsigniaSprite = Resources.Load<Sprite>("Insignias/" + daSystem._originalOwnerName);
        //    daSystem._ownerCivSprite = Resources.Load<Sprite>("Civilizations/" + daSystem._originalOwnerName.ToLower());
        //    daSystem._currentSysFactories = float.Parse(sysStrings[32]);
        //    //_civInsignia leave for CivilizationData to do
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
        //private void SetSystemOwner(StarSystemManager theSystem)
        //{
        //    civOwnerSprite = theSystem._ownerCivSprite;
        //    civOwnerName = theSystem._ownerName;
        //}
        //public void LoadSystemData(int[] starArray)
        //{
        //    for (int i = 0; i < starArray.Length; i++)
        //    {
        //        var sys = StarSystemSO.InitializFleet(starArray[i]);
        //        this.civOwnerImage.sprite = sys._ownerCivSprite;
        //        this.civInsignia.sprite = sys._ownerInsigniaSprite;
        //        this.currentCivOwnerName = sys._currentOwnerName;
        //        this.originalCivOwnerName = sys._originalOwnerName;
        //        this.sysDataName = sys._sysName;
        //        StarSysDictionary.Add(sys._sysEnum, sys);
        //    }
        //}
        //public void AddFleet(StarSystemEnum sysEnum, GameObject fleet)
        //{
        //    StarSystemManager theSystem = StarSystemSO.StarSysDictionary[sysEnum];
        //    theSystem._fleetsInSystem.Add(fleet.gameObject);
        //}
        //public void RemoveFleet(StarSystemEnum sysEnum, GameObject fleet)
        //{
        //    StarSystemManager theSystem = StarSystemSO.StarSysDictionary[sysEnum];
        //    theSystem._fleetsInSystem.Remove(fleet.gameObject);
        //}
        //public void LoadSystemOwner(Civilization civ, StarSystemEnum sys) // Now CivilizationData can provide civ data for system
        //{
        //    StarSystemManager theSystem = StarSystemSO.StarSysDictionary[sys];
        //    theSystem._ownerCiv = civ;
        //    theSystem._currentOwnerName = civ._shortNameString;
        //    theSystem._ownerInsigniaSprite = civ._insignia; // Resources.Load<Sprite>("Insignia/" + sys._sysName.ToUpper());
        //    theSystem._ownerCivSprite = civ._civImage; //Resources.Load<Sprite>("Civilizations/" + sys._sysName.ToLower());
        //    theSystem._homeColony = true;
        //    //civOwnerImage.sprite = theSystem._ownerCivSprite;
        //    //civInsignia.sprite = theSystem._ownerInsigniaSprite;
        //    //originalCivOwnerName = theSystem._originalOwnerName;
        //}
        //public void UpdateSystemOwner(StarSystemManager sys, Civilization civ) // change civ owner in StarSysDictionary
        //{
        //    // code here for getting sprite by civ
        //    StarSystemManager theSystem = StarSystemSO.StarSysDictionary[sys._sysEnum];
        //    theSystem._ownerCiv = civ;
        //    theSystem._currentOwnerName = civ._shortNameString;
        //    theSystem._ownerInsigniaSprite = civ._insignia; // Resources.Load<Sprite>("Insignia/" + sys._sysName.ToUpper());
        //    theSystem._ownerCivSprite = civ._civImage; //Resources.Load<Sprite>("Civilizations/" + sys._sysName.ToLower());
        //    if (civ._shortNameString.ToUpper() == sys._originalOwnerName.ToUpper())
        //    {
        //        theSystem._homeColony = true;
        //    }
        //    else theSystem._homeColony = false;
        //    //civOwnerImage.sprite = theSystem._ownerCivSprite;
        //    //civInsignia.sprite = theSystem._ownerInsigniaSprite;
        //    //originalCivOwnerName = theSystem._originalOwnerName;

        //}
        //public StarSystemManager GetSystem(StarSystemEnum sysEnum)
        //{
        //    if (StarSysDictionary.ContainsKey(sysEnum))
        //        return StarSysDictionary[sysEnum];
        //    else return null;
        //}
        //public Sprite GetSystemOwnerSprite(StarSystemEnum sysEnum)
        //{
        //    return StarSysDictionary[sysEnum]._ownerInsigniaSprite;
        //}
        //public string GetSystemOwenerName(StarSystemEnum sysEnum)
        //{
        //    return StarSysDictionary[sysEnum]._originalOwnerName;
        //}

    }
}
