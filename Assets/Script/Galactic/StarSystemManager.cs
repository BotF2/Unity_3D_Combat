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
        public GameObject starSystemPrefab;
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
        #endregion Fields



        private void Start()
        {
            //if (starSystemData == null)
            //{
            //    //nameText.text = starSystemData.name;
            //    //descriptionText.text = starSystemData.description;
            //    artworkImage.sprite = starSystemData.starSprit;
            //    starSystemData.location = transform.position;
            //}
        }
        public static StarSystemSO Create(int systemInt)
        {
            //ToDo make some uninhabited systems to colonize
            StarSystemSO mySystemData = ScriptableObject.CreateInstance<StarSystemSO>();
            //StarSystemSO mySystemData = new StarSystemSO(systemInt);
            string[] sysStrings = GalaxyView.SystemDataDictionary[systemInt];
            mySystemData._sysInt = systemInt;
            mySystemData._x = int.Parse(sysStrings[1]);
            mySystemData._y = int.Parse(sysStrings[2]);
            mySystemData._z = int.Parse(sysStrings[3]);
            mySystemData._starSystemEnum = (StarSystemEnum)systemInt;
            mySystemData.sysName = sysStrings[4];
            StarType star = (StarType)int.Parse(sysStrings[7]);
            //if (Enum.TryParse(sysStrings[7], out star))
            //    mySystemData._starType = star;
            //mySystemData._ownerCiv = CivilizationData.CivilizationDictionary[(CivEnum)systemInt];
            mySystemData._sysCredits = 10f;
            mySystemData._systemPopLimit = int.Parse(sysStrings[33]);
            mySystemData._currentSysPop = int.Parse(sysStrings[6]);
            mySystemData._originalOwnerName = sysStrings[5];
            mySystemData._currentOwnerName = sysStrings[5];
            mySystemData._ownerInsignia = Resources.Load<Sprite>("Insignias/" + mySystemData._originalOwnerName);
            mySystemData._civOwnerSprite = Resources.Load<Sprite>("Civilizations/" + mySystemData._originalOwnerName.ToLower());
            mySystemData._currentSysFactories = float.Parse(sysStrings[32]);
            //_civInsignia leave for CivilizationData to do
            //mySystemData._systemPopulation = int.Parse(sysStrings[6]);
            if (sysStrings[5] != "UNINHABITED")
                mySystemData._homeColony = true;
            else mySystemData._homeColony = false;
            mySystemData._text = "blah, blah, blah";
            //SetSystemOwner(mySystemData);
            //civOwnerSprite = mySystemData._ownerCivSprite;
            //civOwnerName = mySystemData._ownerName;
            starSysDataDictionary.Add(mySystemData._starSystemEnum, mySystemData);
            return mySystemData;
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
            //    StarSystemDictionary.Add(sys._sysEnum, sys);
            //}
        }
        public void UpdateSystemOwner(StarSystemSO theSystemData, CivData newCivDataOnwer) // change newCivDataOnwer owner in StarSystemDictionary
        {
            // code here for getting sprite by newCivDataOnwer
            //StarSystemSO theSystemData = newCivDataOnwer.starSysDataDictionary[sysData._starSystemEnum];

            theSystemData.starSystemCurrentOwner = newCivDataOnwer._civEnum;
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
        //    starSystemData.ResetData();
        //}
    }
}