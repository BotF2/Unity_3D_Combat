using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using JetBrains.Annotations;
using UnityEngine.UI;
using UnityEngine.Rendering.VirtualTexturing;
using Assets.Core;
using System.Collections.Generic;

namespace GalaxyMap
{
    public class StarSystemData : MonoBehaviour
    {
        public Image civOwnerImage;
        public Image civInsignia;
        private string originalCivOwnerName;
        public string currentCivOwnerName;
        private string sysDataName;
        public StarSystemSO starSystemData;
        public int _sysInt;
        public int _x;//done currentPosition vetor and tranform move in MonoBehavior inheriting StarSystemSO attached to a GO?
        public int _y;
        public int _z;
        public StarSystemEnum _sysEnum;
        public string _sysName;
        public StarType _starType;
        public CivData _ownerCiv;
        public string _originalOwnerName;
        public string _currentOwnerName;
        public Sprite _ownerInsigniaSprite;
        public Sprite _ownerCivSprite;
        public float _sysCredits;
        //public float _sysTaxRate; Set it at civ level
        public float _systemPopLimit;
        public float _currentSysPop;
        //public float _systemFactoryLimit; Do it all with pop limit??
        public float _currentSysFactories;
        //public float _production;
        //private int _maintenanceCostLastTurn;
        //private int _rankCredits;
        //public List<CivHistory> _civHist_List = new List<CivHistory>();
        public bool _homeColony;
        public string _text;
        public GameObject _systemSphere;
        //public List<GameObject> _fleetsInSystem;
        public Text nameText;
        public Image artworkImage;
        public static Dictionary<StarSystemEnum, StarSystemSO> starSysDataDictionary = new Dictionary<StarSystemEnum, StarSystemSO>();
        //public List<ShipYardData> shipYardDataList;
        //[SerializeField]
        //public static Dictionary<StarSystemEnum, StarSystemManager> StarSystemDictionary = new Dictionary<StarSystemEnum, StarSystemManager>();

        //public StarSystemSO(int sysID)
        //{
        //    StarSystemManager theSystem = StarSystemSO.StarSystemDictionary[(StarSystemEnum)sysID];
        //    civOwnerImage.sprite = theSystem._ownerCivSprite;
        //    civInsignia.sprite = theSystem._ownerInsigniaSprite;
        //    currentCivOwnerName = theSystem._currentOwnerName;
        //}
        //public void UpdateActiveSystemData(int sysID) // update StarSystemSO so correct image and name shows in viewed system
        //{
        //    StarSystemManager theSystem = StarSystemSO.StarSystemDictionary[(StarSystemEnum)sysID];
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
        //    daSystem._systemPopLimit = int.Parse(sysStrings[33]);
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
        //        StarSystemDictionary.Add(sys._sysEnum, sys);
        //    }
        //}
        //public void AddFleet(StarSystemEnum sysEnum, GameObject fleet)
        //{
        //    StarSystemManager theSystem = StarSystemSO.StarSystemDictionary[sysEnum];
        //    theSystem._fleetsInSystem.Add(fleet.gameObject);
        //}
        //public void RemoveFleet(StarSystemEnum sysEnum, GameObject fleet)
        //{
        //    StarSystemManager theSystem = StarSystemSO.StarSystemDictionary[sysEnum];
        //    theSystem._fleetsInSystem.Remove(fleet.gameObject);
        //}
        //public void LoadSystemOwner(Civilization civ, StarSystemEnum sys) // Now CivilizationData can provide civ data for system
        //{
        //    StarSystemManager theSystem = StarSystemSO.StarSystemDictionary[sys];
        //    theSystem._ownerCiv = civ;
        //    theSystem._currentOwnerName = civ._shortNameString;
        //    theSystem._ownerInsigniaSprite = civ._insignia; // Resources.Load<Sprite>("Insignia/" + sys._sysName.ToUpper());
        //    theSystem._ownerCivSprite = civ._civImage; //Resources.Load<Sprite>("Civilizations/" + sys._sysName.ToLower());
        //    theSystem._homeColony = true;
        //    //civOwnerImage.sprite = theSystem._ownerCivSprite;
        //    //civInsignia.sprite = theSystem._ownerInsigniaSprite;
        //    //originalCivOwnerName = theSystem._originalOwnerName;
        //}
        //public void UpdateSystemOwner(StarSystemManager sys, Civilization civ) // change civ owner in StarSystemDictionary
        //{
        //    // code here for getting sprite by civ
        //    StarSystemManager theSystem = StarSystemSO.StarSystemDictionary[sys._sysEnum];
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
        //    if (StarSystemDictionary.ContainsKey(sysEnum))
        //        return StarSystemDictionary[sysEnum];
        //    else return null;
        //}
        //public Sprite GetSystemOwnerSprite(StarSystemEnum sysEnum)
        //{
        //    return StarSystemDictionary[sysEnum]._ownerInsigniaSprite;
        //}
        //public string GetSystemOwenerName(StarSystemEnum sysEnum)
        //{
        //    return StarSystemDictionary[sysEnum]._originalOwnerName;
        //}
    }
}

