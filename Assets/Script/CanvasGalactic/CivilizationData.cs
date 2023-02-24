using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Assets.Script;
using BOTF3D_Core;
using BOTF3D_Combat;
using System.Runtime.CompilerServices;

namespace BOTF3D_GalaxyMap
{
    public class CivilizationData : MonoBehaviour
    {
        #region Fields
        public GameManager gameManager;
        public StarSystemData starSystemData;
        public PanelCommand panelCommand;
        [SerializeField]
        public static Dictionary<int, string[]> CivDataDictionary; // incoming data
        [SerializeField]
        public static Dictionary<CivEnum, Civilization> CivilizationDictionary = new Dictionary<CivEnum, Civilization>(); // { { CivEnum.PLACEHOLDER, new Civilization(111) } };
        private float TechPopRate = 0.001f;
        private float TaxRate = 0.05f;
        private float payDef = 1f;
        private float payResearch = 1f;
        private float paySpy = 1f;
        private float payIndustry = 1f;
        private int numStars;
        [SerializeField]
        public ProductionSliders proSliders;
        #endregion
        public void Awake()
        {
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
        public static Civilization Create(int systemInt)
        {
            Civilization daCiv = new Civilization(systemInt);
            var sysStrings = CivilizationData.CivDataDictionary[systemInt];
            daCiv._civEnum = (CivEnum)systemInt;
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
            GameObject goTwo = GameObject.CreatePrimitive(PrimitiveType.Plane);
            var rendTwo = goTwo.GetComponent<Renderer>();
            rendTwo.material.mainTexture = Resources.Load(pathCiv) as Texture;
            daCiv._civImage = Sprite.Create((Texture2D)rendTwo.material.mainTexture, new Rect(0, 0, rendTwo.material.mainTexture.width, rendTwo.material.mainTexture.height), new Vector2(0.5f, 0.5f));
            goTwo.gameObject.SetActive(false);
            daCiv._civPopulation = int.Parse(sysStrings[9]);
            daCiv._civCredits = int.Parse(sysStrings[10]);
            daCiv._civTechLevel = int.Parse(sysStrings[11]);
            daCiv._homeSystem = StarSystemData.StarSystemDictionary[(StarSystemEnum)systemInt];
            List<StarSystem> ownedSystemStarterList = new List<StarSystem>() { daCiv._homeSystem };
            daCiv._ownedSystem = ownedSystemStarterList;
            //sysIndexList = gameManager
            return daCiv;
        }

        public void LoadDictionaryOfCivs(int[] ints) // only call once on loading galaxy 
        {
            for (int i = 0; i < ints.Length; i++)
            {
                Civilization aCiv = CivilizationData.Create(ints[i]); 
                starSystemData.UpdateSystemOwner(aCiv, aCiv._homeSystem); // Star Systems instantiated first so go back now, set Civ for owner of system
                CivilizationData.CivilizationDictionary.Add((CivEnum)ints[i], aCiv);
            }
            numStars = gameManager._galaxyStarCount.Length;
        }
        public void AddPopulation()
        {
            //var numStars = gameManager._galaxyStarCount.Length;
            for (int i = 0; i < numStars; i++)
            {
                var civIndex = gameManager._galaxyStarCount[i];
                Civilization civ = CivilizationDictionary[(CivEnum)civIndex];
                List<StarSystem> sysList = civ._ownedSystem;
                float currentPopulation = 0.01f;

                foreach (var starSys in sysList)
                {
                    float currentSysLimit = (starSys._systemPopLimit + civ._civTechLevel); // _systemPopulation is fixed, update game value by tech level (_civResearch) and civ
                    if (starSys._currentSysPop < currentSysLimit)
                    {
                        starSys._currentSysPop += starSys._currentSysPop* TechPopRate;
                        currentPopulation += starSys._currentSysPop;
                    }
                }
                civ._civPopulation = currentPopulation;                
            }
        }
        public void AddPopCredits()
        // ship qualtiy = civTech * research points
        // time to produce ship = population(Credits)/civTech, a drain on credits
        // total credits/time = population, (maintenance + production, the drains on credits)
        // Population = [population + (100/ research points)]/ population
        // total Credits is population (popCredits),+ population to credits over time
        {
            //var numStars = gameManager._galaxyStarCount.Length;
            for (int i = 0; i < numStars; i++)
            {
                Civilization civ = CivilizationDictionary[(CivEnum)i];
                //if (civ._civCredits < 0.01)
                //    civ._civCredits = 0.01f;
                civ._civCredits += TaxRate * civ._civPopulation;
            }
        }
        public void AddTech()
        {
            for (int i = 0; i < 6; i++)
            {
                Civilization civ = CivilizationDictionary[(CivEnum)i];
               // civ._civResearch += civ._breakThroughs; // ToDo: generate breakThroughs from UI Research per turn slider
            }
        }
        public void AddSpy()
        {
            for (int i = 0; i < numStars; i++)
            {
                Civilization civ = CivilizationDictionary[(CivEnum)i];
                //float intel
                //civ._civTechLevel
                // ToDo: generate intel from UI Spy per turn slider
                // civ.UI_Data (what we can see of other civs) += civ._intel;
            }
        }
        public void DoCivProduction()
        {
            //loop all civs, Civ's Credits * sliderRatioDefence for civ = Denfense budget?
            // ship qualtiy = civTech * research points

            var numStars = gameManager._galaxyStarCount.Length;
            for (int i = 0; i < numStars; i++)
            {
                int civIndex = gameManager._galaxyStarCount[i];
                Civilization civ = CivilizationDictionary[(CivEnum)civIndex];
                payDef = proSliders.sliderRateDef * civ._civCredits;
                civ._defBudget += payDef;
                civ._civCredits -= payDef;
                payResearch = proSliders.sliderRateTech * civ._civCredits; 
                civ._techBudget += payResearch;
                civ._civCredits -= payResearch;
                paySpy = proSliders.sliderRateSpy * civ._civCredits;
                civ._spyBudget += paySpy;
                civ._civCredits -= paySpy;
                payIndustry = proSliders.sliderRateIndustry * civ._civCredits;
                civ._industryBudget += payIndustry;
                civ._civCredits -= payIndustry;
                float[] budget = new float[4] { civ._defBudget, civ._techBudget, civ._spyBudget, civ._industryBudget };
                panelCommand.BalanceTheBudget(budget);
                if (civ._civEnum == gameManager._localPlayer)
                    panelCommand.DisplayBudget(budget);

            }

        }
        //void BalanceTheBudget(float[] _budget)
        //{

        //}
    }
}
