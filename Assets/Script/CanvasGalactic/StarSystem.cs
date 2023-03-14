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
        public string _ownerName;
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
        #endregion Fields

        public StarSystem(int sysInt)
        {
            this._systemInt = sysInt;           
        }
    }
}
