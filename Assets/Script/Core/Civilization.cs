using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Assets.Script;
using BOTF3D_Combat;
using UnityEngine.XR;
using static UnityEngine.ParticleSystem;
using UnityEngine.Rendering;
using BOTF3D_GalaxyMap;

namespace BOTF3D_Core
{
    [System.Serializable]
    public class Civilization
    {
        #region Fields

        //ToDo: add 2 Traints for a civ
        public int _civID;
        public CivEnum _civEnum;
        public string _shortName;
        public string _longName;
        //public Race race -- try to leave this off, too complicated
        public StarSystem _homeSystem;
        //public Traits _traitOne;
        //public Traits _traitTwo;
        public Sprite _civImage;
        public Sprite _insignia;
        //private readonly int _civId;
        public float _credits;
        //private List<Bonus> _globalBonuses;
        //private readonly CivilizationMapData _mapData;
        //private readonly ResearchPool _research;
        //private readonly ResourcePool _resources;
        //private readonly List<SitRepEntry> _sitRepEntries;
        //public int _totalPopulation;
        //private readonly Meter _totalValue;
        public float _civResearch;
        public float _civCredits;
        //private readonly Treasury _treasury;
        //private int _maintenanceCostLastTurn;
        //private int _rankCredits;
        //public List<CivHistory> _civHist_List = new List<CivHistory>();
        public List<Civilization> _contactList;
       // public StarSystem _homeColony;
        public List<StarSystem> _ownedSystem;
        //private List<int> _IntelIDs;
        //private MapLocation? _homeColonyLocation;
        //private int _seatOfGovernmentId = -1;
        //private readonly Meter _totalIntelligenceAttackingAccumulated;
        //private readonly Meter _totalIntelligenceDefenseAccumulated;
        public string _text;
        //private int _rankMaint;
        //private int _rankResearch;
        //private int _rankIntelAttack;
        //private readonly string newline = Environment.NewLine;
        //private readonly IPlayer _localPlayer;
        //private readonly AppContext _appContext;

        #endregion Fields

        public Civilization(int sysCivInt)
        {
            this._civID = sysCivInt;
        }
    }
}
