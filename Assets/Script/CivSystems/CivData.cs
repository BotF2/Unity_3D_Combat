using GalaxyMap;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Core
{

    public class CivData : MonoBehaviour // has list of civsInGame, starSytemData and civs data dictionaries?
    {
        #region Fields
        public GameManager gameManager;
        public int _civID;
        public CivEnum _civEnum;
        public List<StarSystemController> _controllerSysList;
        public List<FleetController> _controllerFleetList;
        //public Dictionary<StarSystemEnum, StarSystemSO> starSystemsDictionary = new Dictionary<StarSystemEnum, StarSystemSO>();
        //public Dictionary<int, FleetController> fleetsDictionary = new Dictionary<int, FleetController>();
        public string _shortNameString;
        public string _longNameString;
        public string _descriptionString; // not in Civilization.txt
        public Sprite _civInsign;
        public Sprite _civImage;
        public StarSystemEnum _homeSysEnum;
        public bool _weAreMajorCiv;
        public float _civTechPoints;
        public TechLevel _civTechLevel;
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
        [SerializeField]
        public static Canvas canvasGalactic;
        public PanelCommand panelCommand;
        //public List<Fleet> civFleetList;
        //[SerializeField]
        //public static Dictionary<int, string[]> CivStringsDictionary; // incoming data
        [SerializeField]
        public static Dictionary<CivEnum, CivData> CivilizationDictionary = new Dictionary<CivEnum, CivData>(); // { { CivEnum.PLACEHOLDER, new Civilization(111) } };
        private float techPopGrowthRate = 0.01f;
        //private float factoryMaint = 0.05f;
        //private float labMaint = 0.05f;
        //private float intelMaint = 0.05f;
        //private float defMaint = 0.05f;
        private int numStars;
        //public List<StarSystemManager> _sysList;
        [SerializeField]
        public ProductionSliders proSliders;
        private int count = 0;
        #endregion


        public void Awake()
        {
            //GameObject tempObject = GameObject.Find("CanvasGalactic");
            //if (tempObject != null)
            //{
            //    _canvasGalactic = tempObject.GetComponent<Canvas>();
            //}
            //#region Read Civilization Data.txt 
            //char separator = ',';
            //Dictionary<int, string[]> _civDataDictionary = new Dictionary<int, string[]>();
            //var file = new FileStream(Environment.CurrentDirectory + "\\Assets\\" + "Civilizations.txt", FileMode.Open, FileAccess.Read);

            //var _dataPoints = new List<string>();
            //using (var reader = new StreamReader(file))
            //{

            //    while (!reader.EndOfStream)
            //    {

            //        var line = reader.ReadLine();
            //        if (line == null)
            //            continue;
            //        _dataPoints.Add(line.Trim());

            //        if (line.Length > 0)
            //        {
            //            var civDataStringArray = line.Split(separator);

            //            _civDataDictionary.Add(int.Parse(civDataStringArray[0]), civDataStringArray);
            //        }
            //    }

            //    reader.Close();
            //    CivStringsDictionary = _civDataDictionary;

            //}
            //#endregion          
        }

        public void DoSystemProduction()
        {
            //var numStars = gameManager._galaxyStarCount.Length;
            
            //for (int i = 0; i < numStars; i++)
            //{
            //    var civIndex = gameManager._galaxyStarCount[i];
            //    CivData civ = CivilizationDictionary[(CivEnum)civIndex];
            //    CalculateCivSysAllocation(civ);
            //    if (civ._ownedSystemEnums.Count > 0)
            //    {
            //        for (int j= 0; j< civ._ownedSystemEnums.Count; j++)
            //        {
            //            StarSystemEnum starSysEnum = civ._ownedSystemEnums[j];
            //            StarSystemSO starSysData = StarSystemSO.StarSystemDictionary[starSysEnum];
            //            float sysPopLimit = (starSysData._maxSysPop + civ._civTechPoints); // _systemPopulation is fixed, update game value by tech level (_civResearch) and civ
            //            if (starSysData._currentSysPop < sysPopLimit)
            //            {
            //                starSysData._currentSysPop += starSysData._currentSysPop * (int)techPopGrowthRate;

            //                if (civ._ownedSystemEnums.Count > 1) // profit from trade 
            //                {
            //                    civ._civCredits += 5f;
            //                }
            //            }
            //            //ToDo: set factory output at each system by civ level allocation to factories and local factories by system population level

            //            //float sysFactoryLimit = (starSysData._systemFactoryLimit + civ._civTechLevel);
            //            //if (starSysData._currentSysFactories < sysFactoryLimit)
            //            //{
            //            //    starSysData._currentSysFactories += starSysData._currentSysFactories * techPopGrowthRate;
            //            //}
            //            starSysData._sysCredits += starSysData._currentSysPop * starSysData._currentSysFactories * civ._civTechPoints * techPopGrowthRate;
            //            // ToDo: set tax rate in slider
            //            starSysData._sysCredits -= starSysData._sysCredits * civ._civTaxRate;
            //            DoSysConsumption(starSysData);
            //        }
            //        for (int k = 0; k < civ._ownedSystemEnums.Count; k++) // apply trade income from civ credits
            //        {
            //            //StarSystemSO starSys = StarSystemSO.StarSystemDictionary[(StarSystemEnum)k];
            //            //starSys._sysCredits += civ._civCredits * (civ._sysTradeAllocation[k] / 100f);
            //        }
            //    }
            //    DoCivConsumption(civ);
            //}
        }
        private void DoSysConsumption(StarSystemSO starSysData)
        {
            // ToDo: build ships here with starSysData._sysCredits
        }
        private void DoCivConsumption(CivData civ)
        {
            // ToDo: ship maintenance and Research and Intel consumption here
            // us civ._civCredits
        }
        private void CalculateCivSysAllocation(CivData civ)
        {
            // ToDo: get slider imput here for trade credit allocation
            //civ._sysTradeAllocation.Clear();
            //float allocation = 100f/ civ._ownedSysEnums.Count;
            //for (int i = 0; i < civ._ownedSysEnums.Count; i++)
            //{
            //    civ._sysTradeAllocation.Add(allocation);              
            //}
            
        }
 
        public void DoDiplomacy()
        {
            //for (int i = 0; i < civsInGame.Count; i++)
            //{
            //    for (int j = 0; j < civsInGame.Count; j++)
            //    {
            //        if (i != j)
            //        {
            //            // Do we need to time this or does it just happen
            //            // CivEnum[] civArray = (CivEnum[])Enum.GetValues(typeof(CivEnum));
                        
            //            Civilization civ1 = civsInGame[i];
            //            Civilization civ2 = civsInGame[j];
            //            RelationshipInfo relationshipInfo = RelationshipManager.GetRelationshipInfo(civ1, civ2);
            //            //relationshipInfo.RelationshipScore += civ1.deltaRelation[j];
            //            //civ1.deltaRelation[j] = 0;
            //        }
            //    }
            //}
        }
        //public void SendCivDataToFleet()
        //{
        //    fleet.GetCivData(this);
        //}
        //public void MoveGalacticThings()
        //{

        //}
            
        //}
        //public void AddSysCredits()
        //// ship quality = civTech * research points
        //// time to produce ship = population(Credits)/civTech, a drain on credits
        //// total credits/time = population, (maintenance + production, the drains on credits)
        //// Population = [population + (100/ research points)]/ population
        //// total Credits is population (popCredits),+ population to credits over time
        //{
        //    //var numStars = gameManager._galaxyStarCount.Length;
        //    for (int i = 0; i < numStars; i++)
        //    {
        //        Civilization civ = CivilizationDictionary[(CivEnum)i];
        //        //if (civ._civCredits < 0.01)
        //        //    civ._civCredits = 0.01f;
        //        //civ._civCredits += TaxRate * civ._civPopulation;
        //    }
        //}
        //public void AddTech()
        //{
        //    for (int i = 0; i < 6; i++)
        //    {
        //        Civilization civ = CivilizationDictionary[(CivEnum)i];
        //       // civ._civResearch += civ._breakThroughs; // ToDo: generate breakThroughs from UI Research per turn slider
        //    }
        //}
        //public void AddSpy()
        //{
        //    for (int i = 0; i < numStars; i++)
        //    {
        //        Civilization civ = CivilizationDictionary[(CivEnum)i];
        //        //float intel
        //        //civ._civTechLevel
        //        // ToDo: generate intel from UI Spy per turn slider
        //        // civ.UI_Data (what we can see of other civs) += civ._intel;
        //    }
        //}
        //public void DoCivProduction()
        //{
        //    //loop all civs, Civ's Credits * sliderRatioDefence for civ = Denfense budget?
        //    // ship qualtiy = civTech * research points

        //    var numStars = gameManager._galaxyStarCount.Length;
        //    for (int i = 0; i < numStars; i++)
        //    {
        //        int civIndex = gameManager._galaxyStarCount[i];
        //        Civilization civ = CivilizationDictionary[(CivEnum)civIndex];
        //        payDef = proSliders.sliderRateDef * civ._civCredits;
        //        //civ._defBudget += payDef;
        //        civ._civCredits -= payDef;
        //        payResearch = proSliders.sliderRateTech * civ._civCredits; 
        //        //civ._techBudget += payResearch;
        //        civ._civCredits -= payResearch;
        //        paySpy = proSliders.sliderRateSpy * civ._civCredits;
        //       // civ._spyBudget += paySpy;
        //        civ._civCredits -= paySpy;
        //        payIndustry = proSliders.sliderRateIndustry * civ._civCredits;
        //        //civ._industryBudget += payIndustry;
        //        civ._civCredits -= payIndustry;
        //        //float[] budget = new float[4] { civ._defBudget, civ._techBudget, civ._spyBudget, civ._industryBudget };
        //        //panelCommand.BalanceTheBudget(budget);
        //        //if (civ._civEnum == gameManager._localPlayer)
        //            //panelCommand.DisplayBudget(budget);

        //    }

        //}
        //void BalanceTheBudget(float[] _budget)
        //{

        //}
    }
}
