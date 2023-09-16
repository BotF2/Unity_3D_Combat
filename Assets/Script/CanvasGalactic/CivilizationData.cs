using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Assets.Script;
using BOTF3D_Core;
using BOTF3D_Combat;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

namespace BOTF3D_GalaxyMap
{
    //[System.Serializable]
    public class CivilizationData : MonoBehaviour
    {
        #region Fields
        public GameManager gameManager;
        public static List<Civilization> civsInGame = new List<Civilization>();
        public StarSystemData starSystemData;
        [SerializeField]
        public static Canvas canvasGalactic;
        public PanelCommand panelCommand;
        //public List<Fleet> civFleetList;
        [SerializeField]
        public static Dictionary<int, string[]> CivDataDictionary; // incoming data
        [SerializeField]
        public static Dictionary<CivEnum, Civilization> CivilizationDictionary = new Dictionary<CivEnum, Civilization>(); // { { CivEnum.PLACEHOLDER, new Civilization(111) } };
        private float techPopGrowthRate = 0.01f;
        //private float factoryMaint = 0.05f;
        //private float labMaint = 0.05f;
        //private float intelMaint = 0.05f;
        //private float defMaint = 0.05f;
        private int numStars;
        //public List<StarSystem> _sysList;
        [SerializeField]
        public ProductionSliders proSliders;
        #endregion
        public void Awake()
        {
            //GameObject tempObject = GameObject.Find("CanvasGalactic");
            //if (tempObject != null)
            //{
            //    canvasGalactic = tempObject.GetComponent<Canvas>();
            //}
            #region Read Civilization Data.txt 
            char separator = ',';
            Dictionary<int, string[]> _civDataDictionary = new Dictionary<int, string[]>();
            var file = new FileStream(Environment.CurrentDirectory + "\\Assets\\" + "Civilizations.txt", FileMode.Open, FileAccess.Read);

            var _dataPoints = new List<string>();
            using (var reader = new StreamReader(file))
            {

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();
                    if (line == null)
                        continue;
                    _dataPoints.Add(line.Trim());

                    if (line.Length > 0)
                    {
                        var civDataStringArray = line.Split(separator);

                        _civDataDictionary.Add(int.Parse(civDataStringArray[0]), civDataStringArray);
                    }
                }

                reader.Close();
                CivDataDictionary = _civDataDictionary;

            }
            #endregion          
        }
        public static CivilizationData Instance { get; private set; }
        public static Civilization Create(int systemInt)
        {
            Civilization daCiv = new Civilization(systemInt);
            var sysStrings = CivilizationData.CivDataDictionary[systemInt];
            daCiv._civEnum = (CivEnum)systemInt;
            if (systemInt <= 5) // update on adding more playable major civs
                daCiv._weAreMajorCiv = true;
            else daCiv._weAreMajorCiv = false;
            daCiv._shortName = sysStrings[2];
            daCiv._longName = sysStrings[3];

            //GetImage(systemInt, 8, "Insignias/", daCiv); // 8 is insignia
            string holdInsigniaName = CivDataDictionary[systemInt][8];
            string pathInsignia = "Insignias/" + holdInsigniaName.ToUpper();
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Plane); // (nameInsginia);
            var rend = go.GetComponent<Renderer>();
            rend.material.mainTexture = Resources.Load(pathInsignia) as Texture;
            daCiv._insignia = Sprite.Create((Texture2D)rend.material.mainTexture, new Rect(0, 0, rend.material.mainTexture.width, rend.material.mainTexture.height), new Vector2(0.5f, 0.5f));
            go.gameObject.SetActive(false);

            //GetImage(systemInt, 7, "Civilizations/", daCiv); // 7 is Civ
            string holdCivName = CivDataDictionary[systemInt][7];
            string pathCiv = "Civilizations/" + holdCivName.ToLower();
            GameObject buildImage = GameObject.CreatePrimitive(PrimitiveType.Plane);
            var rendTwo = buildImage.GetComponent<Renderer>();
            rendTwo.material.mainTexture = Resources.Load(pathCiv) as Texture;
            daCiv._civImage = Sprite.Create((Texture2D)rendTwo.material.mainTexture, new Rect(0, 0, rendTwo.material.mainTexture.width, rendTwo.material.mainTexture.height), new Vector2(0.5f, 0.5f));
            buildImage.gameObject.SetActive(false);
           // daCiv._civPopulation = int.Parse(sysStrings[9]);
            daCiv._civCredits = int.Parse(sysStrings[10]);
            daCiv._civTechPoints = int.Parse(sysStrings[11]);
            //daCiv._civTechLevel = TechLevel.EARLY; ToDo: set this by enough tech points to get new ship images
            daCiv._homeSystem = StarSystemData.StarSystemDictionary[(StarSystemEnum)systemInt];
            daCiv._homeSystem._ownerCiv = daCiv;
            List<Civilization> civsWeKnow = new List<Civilization>() { daCiv }; // instantiate list with knowing our self
            daCiv._contactList = civsWeKnow;
            List<StarSystem> ownedSystemStarterList = new List<StarSystem>() { daCiv._homeSystem };
            daCiv._ownedSystem = ownedSystemStarterList;
            //daCiv._relationshipDictionary = new Dictionary<int, int>();
            civsInGame.Add(daCiv);
            //for (int i = 0; i < systemInt; i++)
            //{

            //}
            //daCiv._relationshipScores ;
            //if (!daCiv.deltaRelation.ContainsKey(systemInt))
            //    daCiv.deltaRelation.Add(systemInt, 0);

            return daCiv;
        }

        public void LoadDictionaryOfCivs(int[] ints) // only call once on loading galaxy 
        {
            for (int i = 0; i < ints.Length; i++)
            {
                Civilization aCiv = CivilizationData.Create(ints[i]); 
                starSystemData.LoadSystemOwner(aCiv, aCiv._homeSystem); // Star Systems instantiated first so go back now, set Civ for owner of system
                CivilizationDictionary.Add((CivEnum)aCiv._civID, aCiv);
                List<float> ourRelationScores = new List<float>();
                for (int j = 0; j < ints.Length; j++)
                {
                    ourRelationScores.Add(-100F);
                }
                aCiv._relationshipScores = ourRelationScores;
            }
            numStars = gameManager._galaxyStarCount.Length;
            //gameManager.SetCivs();
        }

        public void LoadRelationshipDictionaryOfCivs(int[] intsArray)
        {
            //diplomacy.cs has the WhatIsOurDipomaticEnum methode
            for (int i = 0; i < intsArray.Length; i++)
            {
                CivilizationDictionary[(CivEnum)intsArray[i]]._relationshipDictionary.Add((CivEnum)intsArray[i], (DiplomaticEnum)(-3));
            }
        }

        public void UpdateCivContactListOnStartCivSelection(TechLevel ourStartTechLevel)
        {
            switch (ourStartTechLevel)
            {
                case TechLevel.EARLY:
                    {
                       // LoadOurStartingMinor();
                    }
                    break;
                case TechLevel.DEVELOPED:
                    {
                        LoadOurStartingMinor();
                    }
                    break;
                case TechLevel.ADVANCED:
                    {
                        LoadOurStartingMinor();
                        foreach (Civilization aCiv in civsInGame)
                        {
                            if (aCiv._civEnum == CivEnum.FED || aCiv._civEnum == CivEnum.ROM ||
                                aCiv._civEnum == CivEnum.KLING || aCiv._civEnum == CivEnum.CARD ||
                                aCiv._civEnum == CivEnum.DOM || aCiv._civEnum == CivEnum.BORG)
                            {
                                foreach (Civilization thisCiv in civsInGame)
                                {
                                    if(!thisCiv._contactList.Contains(aCiv))
                                    thisCiv._contactList.Add(aCiv);
                                }
                            }
                            
                        }
                    }
                    break;
                case TechLevel.SUPREME:
                    {
                        LoadOurStartingMinor();
                        foreach (Civilization aCiv in civsInGame)
                        {
                            aCiv._contactList = civsInGame;
                        }
                    }    
                    break;
                default:
                    break;
            }
        }
        public Civilization CivFromEnum(CivEnum civEnum)
        {
            if(civsInGame.Count > 0)
            foreach (Civilization aCiv in civsInGame)
            {
                if (aCiv._civEnum == civEnum)
                    return aCiv;
            }
            return null;
        }
        private void LoadOurStartingMinor()
        {
            foreach (Civilization aCiv in civsInGame)
            {
                switch (aCiv._civEnum)
                {
                    case CivEnum.FED:
                        {
                            Civilization minorCiv = CivFromEnum(CivEnum.VULCANS);
                            if (minorCiv != null)
                            {
                                aCiv._contactList.Add(minorCiv); //Vulcans #146);
                                minorCiv._contactList.Add(aCiv);
                            }
                        }
                        break;
                    case CivEnum.ROM:
                        {
                            Civilization minorCiv = CivFromEnum(CivEnum.ZAKDORN);
                            if (minorCiv != null)
                            {
                                aCiv._contactList.Add(minorCiv); //Zackdorn #155);
                                minorCiv._contactList.Add(aCiv);
                            }
                        }
                        break;

                    case CivEnum.KLING:
                        {
                            Civilization minorCiv = CivFromEnum(CivEnum.KRIOSIANS);
                            if (minorCiv != null)
                            {
                                aCiv._contactList.Add(minorCiv); //Kriosians);
                                minorCiv._contactList.Add(aCiv);
                            }
                        }
                        break;
                    case CivEnum.CARD:
                        {
                            Civilization minorCiv = CivFromEnum(CivEnum.BAJORANS);
                            if (minorCiv != null)
                            {
                                aCiv._contactList.Add(minorCiv); //Bajorans #23);
                                minorCiv._contactList.Add(aCiv);
                            }
                        }
                        break;
                    case CivEnum.DOM:
                        {
                            Civilization minorCiv = CivFromEnum(CivEnum.DOSI);
                            if (minorCiv != null)
                            {
                                aCiv._contactList.Add(minorCiv); //Dosi #50);
                                minorCiv._contactList.Add(aCiv);
                            }
                        }
                        break;
                    case CivEnum.BORG:
                        {
                            Civilization minorCiv = CivFromEnum(CivEnum.NECHANI);
                            if (minorCiv != null)
                            {
                                aCiv._contactList.Add(minorCiv); //Nechani #96);
                                minorCiv._contactList.Add(aCiv);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public void DoSystemProduction()
        {
            //var numStars = gameManager._galaxyStarCount.Length;
            
            for (int i = 0; i < numStars; i++)
            {
                var civIndex = gameManager._galaxyStarCount[i];
                Civilization civ = CivilizationDictionary[(CivEnum)civIndex];
                CalculateCivSysAllocation(civ);
                if (civ._ownedSystem.Count > 0)
                {
                    for (int j= 0; j< civ._ownedSystem.Count; j++)
                    {
                        StarSystem starSys = civ._ownedSystem[j];
                        float sysPopLimit = (starSys._systemPopLimit + civ._civTechPoints); // _systemPopulation is fixed, update game value by tech level (_civResearch) and civ
                        if (starSys._currentSysPop < sysPopLimit)
                        {
                            starSys._currentSysPop += starSys._currentSysPop * techPopGrowthRate;

                            if (civ._ownedSystem.Count > 1) // profit from trade 
                            {
                                civ._civCredits += 5f;
                            }
                        }
                        //ToDo: set factory output at each system by civ level allocation to factories and local factories by system population level

                        //float sysFactoryLimit = (starSys._systemFactoryLimit + civ._civTechLevel);
                        //if (starSys._currentSysFactories < sysFactoryLimit)
                        //{
                        //    starSys._currentSysFactories += starSys._currentSysFactories * techPopGrowthRate;
                        //}
                        starSys._sysCredits += starSys._currentSysPop * starSys._currentSysFactories * civ._civTechPoints * techPopGrowthRate;
                        // ToDo: set tax rate in slider
                        starSys._sysCredits -= starSys._sysCredits * civ._civTaxRate;
                        DoSysConsumption(starSys);
                    }
                    for (int k = 0; k < civ._ownedSystem.Count; k++) // apply trade income from civ credits
                    {
                        StarSystem starSys = civ._ownedSystem[k];
                        starSys._sysCredits += civ._civCredits * (civ._sysTradeAllocation[k] / 100f);
                    }
                }
                DoCivConsumption(civ);
            }
        }
        private void DoSysConsumption(StarSystem starSys)
        {
            // ToDo: build ships here with starSys._sysCredits
        }
        private void DoCivConsumption(Civilization civ)
        {
            // ToDo: ship maintenance and Research and Intel consumption here
            // us civ._civCredits
        }
        private void CalculateCivSysAllocation(Civilization civ)
        {
            // ToDo: get slider imput here for trade credit allocation
            civ._sysTradeAllocation.Clear();
            float allocation = 100f/ civ._ownedSystem.Count;
            for (int i = 0; i < civ._ownedSystem.Count; i++)
            {
                civ._sysTradeAllocation.Add(allocation);              
            }
            
        }
        //public void PopulateCivRelationshipInfo(List<Civilization> ourCivs)
        //{
        //    foreach (var civ in ourCivs)
        //    {
        //        //int[] ourInfo = new int[ourCivs.Count];
        //        //for (int i = 0; i < ourCivs.Count; i++)
        //        //{
        //        //    ourInfo[i] = -100;
        //        //}
        //        //RelationshipInfo[] temp = new RelationshipInfo[ourCivs.Count];
        //        for (int i = 0; i < ourCivs.Count; i++)
        //        {
        //            RelationshipInfo myInfo = new RelationshipInfo();
        //            myInfo.RelationshipScore = -100;
        //            civ._relationshipManager.relationshipInfos[i] = myInfo;
        //        }

        //        //relationshipInfos.AddRange(temp);
        //        //RelationshipManager theArrayofInfo = new RelationshipManager(ourInfo);
        //       // civ._relationshipManager.relationshipInfos.AddRange(temp);
        //    }
            
        //}
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
