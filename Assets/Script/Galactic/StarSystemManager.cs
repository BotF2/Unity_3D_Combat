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
        public StarSystemController starSysController;
        public GameObject starSysPrefab;
        public List<StarSystemController> starSysControllers;
        public StarSystemSO starSysSO;
        

        private void OnEnable()
        {
            if (starSysController != null)
            {
               // starSysSO.myObject = starSysPrefab;
                //starSysController.starSysData.position = transform.position; // Really?????
            }
        }

        private void Start()
        {
            //if (starSysData == null)
            //{
            //    //nameText.text = starSysData.name;
            //    //descriptionText.text = starSysData.description;
            //    artworkImage.sprite = starSysData.starSprit;
            //    starSysData.position = transform.position;
            //}
        }
        public StarSystemController InitializSystem(int systemInt)
        {
            //ToDo make some uninhabited systems to colonize
            GameObject sysGO = Instantiate(starSysPrefab);
            InitializeSysController(sysGO.GetComponent<StarSystemController>(), starSysSO );
            string[] sysStrings = GalaxyView.SystemDataDictionary[systemInt];
            starSysController.starSysData._sysInt = systemInt;
            starSysController.starSysData._x = int.Parse(sysStrings[1]);
            starSysController.starSysData._y = int.Parse(sysStrings[2]);
            starSysController.starSysData._z = int.Parse(sysStrings[3]);
            starSysController.starSysData._sysEnum = (StarSystemEnum)systemInt;
            starSysController.starSysData._sysName = sysStrings[4];
            StarType star = (StarType)int.Parse(sysStrings[7]);
            //if (Enum.TryParse(sysStrings[7], out star))
            //    mySystemData._starType = star;
            //mySystemData._ownerCiv = CivilizationData.CivilizationDictionary[(CivEnum)systemInt];
            starSysController.starSysData._sysCredits = 10f;
            starSysController.starSysData._sysPopLimit = int.Parse(sysStrings[33]);
            starSysController.starSysData._currentSysPop = int.Parse(sysStrings[6]);
            starSysController.starSysData._originalOwnerName = sysStrings[5];
            starSysController.starSysData._currentOwnerName = sysStrings[5];
            starSysController.starSysData._ownerInsigniaSprite = Resources.Load<Sprite>("Insignias/" + starSysController.starSysData._originalOwnerName);
            starSysController.starSysData._ownerCivSprite = Resources.Load<Sprite>("Civilizations/" + starSysController.starSysData._originalOwnerName.ToLower());
            starSysController.starSysData._currentSysFactories = float.Parse(sysStrings[32]);
            //_civInsignia leave for CivilizationData to do
            //mySystemData._systemPopulation = int.Parse(sysStrings[6]);
            if (sysStrings[5] != "UNINHABITED")
                starSysController.starSysData._homeColony = true;
            else starSysController.starSysData._homeColony = false;
            starSysController.starSysData._text = "blah, blah, blah";
            starSysControllers.Add(starSysController);
            //SetSystemOwner(mySystemData);
            //civOwnerSprite = mySystemData._ownerCivSprite;
            //civOwnerName = mySystemData._ownerName;
            //starSysDataDictionary.Add(mySystemData._starSystemEnum, mySystemData);
            return starSysController;
        }
        public void InitializeSysController(StarSystemController starSystemController, StarSystemSO starSysSO)
        {

        }
        public void LoadSystemData(int[] stars) // do we need this anymore? done above?
        {
            for (int i = 0; i < stars.Length; i++)
            {
                starSysControllers.Add(InitializSystem(i));
                //var sys = StarSystemManager.InitializFleet(starArray[i]);
                //this.civOwnerImage = sys._ownerCivSprite;
                //this.civInsigniaImage = sys._ownerInsigniaSprite;
                //this.currentCivOwnerName = sys._currentOwnerName;
                //this.originalCivOwnerName = sys._originalOwnerName;
                //this.systemName = sys._sysName;
                //StarSystemDictionary.Add(sys._sysEnum, sys);
            }
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
        //    if (starSysDataDictionary.ContainsKey(sysEnum))
        //        return starSysDataDictionary[sysEnum];
        //    else return null;
        //}
        //public Sprite GetSystemOwnerSprite(StarSystemEnum sysEnum)
        //{
        //    return starSysDataDictionary[sysEnum]._ownerInsignia;
        //}
        //public string GetSystemOwenerName(StarSystemEnum sysEnum)
        //{
        //    return starSysDataDictionary[sysEnum]._originalOwnerName;
        //}

        //public StarSystemManager(int sysInt)
        //{
        //    // to do, check that system is still owned if we are past create Galaxy phase
        //    this._sysInt = sysInt;
        //}
        //private void OnEnable()
        //{
        //    if (starSysSO != null)
        //    {
        //        starSysSO.position = transform.position;
        //    }
        //}

        //private void OnDisable()
        //{
        //    starSysData.ResetData();
        //}
    }
}