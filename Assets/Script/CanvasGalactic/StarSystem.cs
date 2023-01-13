using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Assets.Script;
using BOTF3D_Core;
using BOTF3D_Combat;
using UnityEngine.XR;
using JetBrains.Annotations;

namespace BOTF3D_GalaxyMap
{
    [System.Serializable]
	public class StarSystem
	{
        #region Fields

        public int _systemInt;
        public int _x;
        public int _y;
        public int _z;
        public StarSystemEnum _sysEnum;
        public string _sysName;
        public StarType _starType;
        //public Civ _civEnum;
       // public Sprite _civInsignia;// do we get it from Civ and not system??
        public Civilization _ownerCiv;
       // public string _ownerName;
        public int _systemPopulation;
        //public float _systemResearch;
        //private readonly Treasury _treasury;
        //private int _maintenanceCostLastTurn;
        //private int _rankCredits;
        //public List<CivHistory> _civHist_List = new List<CivHistory>();
        public bool _homeColony;
        public string _text;
        #endregion Fields

        public StarSystem(int sysInt)
        {
            this._systemInt = sysInt;           
        }
        //public static StarSystem Create(int systemInt, string[] stings)
        //{
        //    StarSystem daSystem = StarSystemDictionary[systemInt];
        //    daSystem._systemInt = systemInt;
        //    daSystem._sysEnum = (StarSystemEnum)systemInt;
        //    daSystem._sysName = stings[4];
        //    StarType star;
        //    if (Enum.TryParse(stings[7], out star))
        //        daSystem._starType = star;
        //    daSystem._ownerCiv = Civilization.Create(systemInt);
        //    //daSystem._ownerName = daSystem._ownerCiv.name;
        //    //_civInsignia leave for StarSystemDataBase to do
        //    //    _systemPopulation = 2;
        //    //    _systemResearch = 2;
        //    //    _homeColony = true;
        //    //    _text = "blah, blah, blah";
        //    return daSystem;
        //}
    }
}
