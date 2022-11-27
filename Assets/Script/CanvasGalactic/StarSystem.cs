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

namespace BOTF3D_GalaxyMap
{
	public class StarSystem : MonoBehaviour 
	{
        #region Fields
        public GameManager _gameManager;
        private Civ _owner;
        private int _systemPopulation;
        private float _systemResearch;
        //private readonly Treasury _treasury;
        //private int _maintenanceCostLastTurn;
        //private int _rankCredits;
        //public List<CivHistory> _civHist_List = new List<CivHistory>();
        private bool _homeColony;
        private string _text;

        #endregion Fields

        public void Awake()
        {
            _gameManager = GameManager.Instance;
        }
        public void Star()
        {
        }
	}
}
