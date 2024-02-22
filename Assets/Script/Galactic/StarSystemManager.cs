using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Core;
using UnityEngine.XR;
using JetBrains.Annotations;
using System.IO;
using System.Linq;
using Unity.VisualScripting;


namespace GalaxyMap
{
    public class StarSystemManager : MonoBehaviour
    {
        #region Fields
        public GameObject starSysPrefab;
        public List<StarSystemController> fleetControllers;
        public StarSystemSO starSysSO;// asign in inspector
        public StarSystemController starSysController;
        //public static Dictionary<StarSystemEnum, StarSystemSO> starSysDataDictionary = new Dictionary<StarSystemEnum, StarSystemSO>();
        #endregion Fields

        private void Start()
        {
            //if (starSysData == null)
            //{
            //    //nameText.text = starSysData.name;
            //    //descriptionText.text = starSysData.description;
            //    artworkImage.sprite = starSysData.starSprit;
            //    starSysData.location = transform.position;
            //}
        }
        public StarSystemController InitializStarSystem(int systemInt, StarSystemSO myStarSysSO)
        {
            //ToDo make some uninhabited systems to colonize
            GameObject starSystemGO = Instantiate(starSysPrefab);
            InitizeStarSystemController(starSystemGO.GetComponent<StarSystemController>(), starSysSO);
            string[] sysStrings = GalaxyView.SystemDataDictionary[systemInt];
            starSysController.starSystemData._sysInt = systemInt;
            starSysController.starSystemData._x = int.Parse(sysStrings[1]);
            starSysController.starSystemData._y = int.Parse(sysStrings[2]);
            starSysController.starSystemData._z = int.Parse(sysStrings[3]);
            starSysController.starSystemData._sysEnum = (StarSystemEnum)systemInt;
            starSysController.starSystemData._sysName = sysStrings[4];
            StarType star = (StarType)int.Parse(sysStrings[7]);
            //if (Enum.TryParse(sysStrings[7], out star))
            //    starSysController.starSysData._starType = star;
            //starSysController.starSysData._ownerCiv = CivilizationData.CivilizationDictionary[(CivEnum)systemInt];
            starSysController.starSystemData._sysCredits = 10f;
            starSysController.starSystemData._systemPopLimit = int.Parse(sysStrings[33]);
            starSysController.starSystemData._currentSysPop = int.Parse(sysStrings[6]);
            starSysController.starSystemData._originalOwnerName = sysStrings[5];
            starSysController.starSystemData._currentOwnerName = sysStrings[5];
            starSysController.starSystemData._ownerInsigniaSprite = Resources.Load<Sprite>("Insignias/" + starSysController.starSystemData._originalOwnerName);
            starSysController.starSystemData._ownerCivSprite = Resources.Load<Sprite>("Civilizations/" + starSysController.starSystemData._originalOwnerName.ToLower());
            starSysController.starSystemData._currentSysFactories = float.Parse(sysStrings[32]);
            //_civInsignia leave for CivilizationData to do
            //starSysController.starSysData._systemPopulation = int.Parse(sysStrings[6]);
            if (sysStrings[5] != "UNINHABITED")
                starSysController.starSystemData._homeColony = true;
            else starSysController.starSystemData._homeColony = false;
            starSysController.starSystemData._text = "blah, blah, blah";
            //SetSystemOwner(starSysController.starSysData);
            //civOwnerSprite = starSysController.starSysData._ownerCivSprite;
            //civOwnerName = starSysController.starSysData._ownerName;
            fleetControllers.Add(starSysController);
            //starSysDataDictionary.Add(starSysController.starSystemData._sysEnum, starSysSO);
            return starSysController;
        }
        public void InitizeStarSystemController(StarSystemController starSysController, StarSystemSO starSysSO)
        {
            this.starSysController.starSystemData.name = starSysSO.name;
        }
        public void LoadSystemData(int[] starArray) // do we need this anymore? done above?
        {
            //for (int i = 0; i < starArray.Length; i++)
            //{
            //    var sys = StarSystemManager.InitializFleet(starArray[i]);
            //    this.civOwnerImage = sys._ownerCivSprite;
            //    this.civInsigniaImage = sys._ownerInsigniaSprite;
            //    this.currentCivOwnerName = sys._currentOwnerName;
            //    this.originalCivOwnerName = sys._originalOwnerName;
            //    this.systemName = sys._sysName;
            //    StarSysDictionary.Add(sys._sysEnum, sys);
            //}
        }
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
        public void UpdateSystemOwner(StarSystemSO theSystemData, CivData newCivDataOnwer) // change newCivDataOnwer owner in StarSysDictionary
        {
            // code here for getting sprite by newCivDataOnwer
            //StarSystemSO theSystemData = newCivDataOnwer.starSysDataDictionary[sysData._starSysEnum];

            theSystemData.currentOwner = newCivDataOnwer._civEnum;
            theSystemData._civOwnerSprite = newCivDataOnwer._civInsign; // Resources.Load<Sprite>("Insignia/" + sysData._sysName.ToUpper());
            theSystemData._ownerInsignia = newCivDataOnwer._civImage; //Resources.Load<Sprite>("Civilizations/" + sysData._sysName.ToLower());
            if (newCivDataOnwer._civEnum.ToString() == theSystemData.starSystemFirstOwner.ToString())
            {
                theSystemData._homeColony = true;
            }
            else theSystemData._homeColony = false;
            theSystemData.currentCivOwnerName = newCivDataOnwer.name;

        }
        public StarSystemSO GetSystem(StarSystemEnum sysEnum)
        {
            if (starSysDataDictionary.ContainsKey(sysEnum))
                return starSysDataDictionary[sysEnum];
            else return null;
        }
        public Sprite GetSystemOwnerSprite(StarSystemEnum sysEnum)
        {
            return starSysDataDictionary[sysEnum]._ownerInsignia;
        }
        public string GetSystemOwenerName(StarSystemEnum sysEnum)
        {
            return starSysDataDictionary[sysEnum]._originalOwnerName;
        }

        public StarSystemManager(int sysInt)
        {
            // to do, check that system is still owned if we are past create Galaxy phase
            this._sysInt = sysInt;
        }
        private void OnEnable()
        {
            if (starSystemData != null)
            {
                starSystemData.location = transform.position;
            }
        }

        //private void OnDisable()
        //{
        //    starSysData.ResetData();
        //}
    }
}