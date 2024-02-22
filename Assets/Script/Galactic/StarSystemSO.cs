using Assets.Core;
using System.Collections.Generic;
using UnityEngine;

namespace GalaxyMap
{
    [CreateAssetMenu(menuName = "Galaxy/StarSystemSO")]
    public class StarSystemSO : ScriptableObject // ToDo move StarSystemSO in MonoBehavior to this
    {
        [SerializeField] int _sysInt;
        [SerializeField] int _x;//done currentPosition vetor and tranform move in MonoBehavior inheriting StarSystemSO attached to a GO?
        [SerializeField] int _y;
        [SerializeField] int _z;
        [SerializeField] string sysName;
        [SerializeField] StarSystemEnum _starSysEnum;
        [SerializeField] Vector3 location;
        [SerializeField] CivEnum originalOwner;
        [HideInInspector] public CivEnum currentOwner;
        [HideInInspector] public Civilization currentCivOwner;
        [HideInInspector] public string currentCivOwnerName;
        [HideInInspector] public Sprite _civOwnerSprite;
        [HideInInspector] StarType starType;
        [SerializeField] Sprite starSprit;
        [HideInInspector] public float _sysCredits = 10f;
        [HideInInspector] public int _systemPopLimit;
        [HideInInspector] int _currentSysPop;      
        [HideInInspector] public Sprite _ownerInsignia;
        [HideInInspector] public float _currentSysFactories;
        [HideInInspector] public bool _homeColony;
        [HideInInspector] public string _description;
        [HideInInspector] public static Dictionary<StarSystemEnum, StarSystemSO> StarSysDictionary =
            new Dictionary<StarSystemEnum, StarSystemSO>();
        [HideInInspector] public GameObject myObject;


        //public StarSystemSO(int sysID)
        //{
        //    StarSystemSO theSystemData = StarSystemSO.StarSysDictionary[(StarSystemEnum)sysID];
        //    _civOwnerSprite = theSystemData._ownerCivSprite;
        //    civInsignia = theSystemData._ownerInsigniaSprite;
        //    currentCivOwnerName = theSystemData._currentOwnerName;
        //}

        //public void UpdateActiveSystemData(int sysID) // update StarSystemSO so correct image and name shows in viewed system
        //{
        //    StarSystemManager theSystemData = StarSystemSO.StarSysDictionary[(StarSystemEnum)sysID];
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
        //        StarSysDictionary.Add(sysData._sysEnum, sysData);
        //    }
        //}

        public void LoadSystemOwner(CivData civData, StarSystemSO sysData) // Now CivData can provide newCivDataOnwer data for system
        { // Do we need this anymore?
            //StarSystemSO theSystemData = StarSystemManager.StarSysDictionary[sysData];
            //theSystemData._ownerCiv = civData;
            //theSystemData._currentOwnerName = civData._shortNameText.ToString();
            //theSystemData._ownerInsigniaSprite = civData._insignia; // Resources.Load<Sprite>("Insignia/" + sysData._sysName.ToUpper());
            //theSystemData._ownerCivSprite = civData._civImage; //Resources.Load<Sprite>("Civilizations/" + sysData._sysName.ToLower());
            //theSystemData._homeColony = true;
            //civOwnerImage.sprite = theSystemData._ownerCivSprite;
            //civInsignia.sprite = theSystemData._ownerInsigniaSprite;
            //originalCivOwnerName = theSystemData._originalOwnerName;
        }
        //public void UpdateSystemOwner(StarSystemSO theSystemData, CivData newCivDataOnwer) // change newCivDataOnwer owner in StarSysDictionary
        //{
        //    // code here for getting sprite by newCivDataOnwer
        //    //StarSystemSO theSystemData = newCivDataOnwer.starSysDataDictionary[sysData._starSysEnum];
      
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
        //    if (StarSysDictionary.ContainsKey(sysEnum))
        //        return StarSysDictionary[sysEnum];
        //    else return null;
        //}
        //public Sprite GetSystemOwnerSprite(StarSystemEnum sysEnum)
        //{
        //    return StarSysDictionary[sysEnum]._ownerInsignia;
        //}
        //public string GetSystemOwenerName(StarSystemEnum sysEnum)
        //{
        //    return StarSysDictionary[sysEnum]._originalOwnerName;
        //}
        public void ResetData()
        {
            myObject = null;
        }
    }
}

