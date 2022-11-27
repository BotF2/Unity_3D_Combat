using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Assets.Script;
using BOTF3D_GalaxyMap;
using BOTF3D_Combat;
using UnityEngine.XR;

namespace BOTF3D_Core
{
	public class Civilization : MonoBehaviour
	{
        #region Fields
        public GameManager _gameManager;
        private Civ _civ;
        //private readonly int _civId;
        private float _credits;
        //private List<Bonus> _globalBonuses;
        //private readonly CivilizationMapData _mapData;
        //private readonly ResearchPool _research;
        //private readonly ResourcePool _resources;
        //private readonly List<SitRepEntry> _sitRepEntries;
        private int _totalPopulation;
        //private readonly Meter _totalValue;
        private float _totalResearch;
        //private readonly Treasury _treasury;
        //private int _maintenanceCostLastTurn;
        //private int _rankCredits;
        private List<Systems> _systems;
        //public List<CivHistory> _civHist_List = new List<CivHistory>();
        private List<Civilization> _contactList;
        private Systems _homeColony;
        private List<Systems> _systemList;
        //private List<int> _IntelIDs;
        //private MapLocation? _homeColonyLocation;
        //private int _seatOfGovernmentId = -1;
        //private readonly Meter _totalIntelligenceAttackingAccumulated;
        //private readonly Meter _totalIntelligenceDefenseAccumulated;
        private string _text;
        //private int _rankMaint;
        //private int _rankResearch;
        //private int _rankIntelAttack;
        //private readonly string newline = Environment.NewLine;
        //private readonly IPlayer _localPlayer;
        //private readonly AppContext _appContext;

        #endregion Fields
  //      public Civilization()
		//{
		//}
        public void Awake()
        {
            _gameManager = GameManager.Instance;
        }
        public void Star()
        {
        }
	}
}
