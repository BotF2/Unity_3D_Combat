using Assets.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivData : MonoBehaviour // has list of civsInGame, starSytemData and civs data dictionaries?
{
    #region Fields
    public int CivInt;
    public CivEnum CivEnum;
    public string CivShortName;
    public string CivLongName;
    public string CivHomeSystem;
    public string TraitOne;
    public string TraitTwo;
    public string CivImage;
    public string Insignia;
    public int Population;
    public int Credits;
    public int TechPoints;
    // end of SOs
    public int _civID;

    //public List<StarSystemController> _controllerSysList;
    //public List<FleetController> _controllerFleetList;
    //public Dictionary<StarSystemEnum, StarSystemSO> starSystemsDictionary = new Dictionary<StarSystemEnum, StarSystemSO>();
    //public Dictionary<int, FleetController> fleetsDictionary = new Dictionary<int, FleetController>();

    public string _descriptionString; 
    //public StarSystemEnum _homeSysEnum;
    public bool _weAreMajorCiv;
    public float _civTechPoints;
   // public TechLevel _civTechLevel;
    public float _civTaxRate;
    public float _cviGrowthRate; // currently using public float techPopGrowthRate = 0.01f in CivilizationData
    //public float _intel;
    public float _civCredits;
    public float _sysTradeAllocation;
    public List<CivData> _contactList; //**** who we have met
    //public List<StarSystemEnum> _ownedSystemEnums;
    //private Canvas _canvasGalactic;
    //public static List<Civilization> civsInGame = new List<Civilization>(); // should this be in GameManager
    //public StarSystemSO starSysData;
 
    public static Canvas canvasGalactic;
    //public PanelCommand panelCommand;
    //public List<Fleet> civFleetList;
    //[SerializeField]
    //public static Dictionary<int, string[]> CivStringsDictionary; // incoming data
   
    //public static Dictionary<CivEnum, CivData> CivilizationDictionary = new Dictionary<CivEnum, CivData>(); // { { CivEnum.PLACEHOLDER, new Civilization(111) } };
    private float techPopGrowthRate = 0.01f;
    //private float factoryMaint = 0.05f;
    //private float labMaint = 0.05f;
    //private float intelMaint = 0.05f;
    //private float defMaint = 0.05f;
    private int numStars;
    //public List<StarSystemManager> _sysList;

    //public ProductionSliders proSliders;
    //private int count = 0;
    #endregion
}

