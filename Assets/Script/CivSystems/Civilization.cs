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
//using static UnityEngine.ParticleSystem;
using UnityEngine.Rendering;
using BOTF3D_GalaxyMap;

namespace BOTF3D_Core
{
    [System.Serializable]
    public class Civilization
    {
        #region Fields

        //ToDo: add 2 Traits for a civ
        public int _civID;
        public CivEnum _civEnum;
        public string _shortName;
        public string _longName;
        //public Race race -- try to leave this off, too complicated
        public StarSystem _homeSystem;
        public bool _weAreMajorCiv;
        //public Traits _traitOne;
        //public Traits _traitTwo;
        public Sprite _civImage;
        public Sprite _insignia;
        public List<Fleet> civFleetList;
        public List<float> _sysTradeAllocation = new List<float> { 100f, };
        //public RelationshipManager _relationshipManager;
        //public int[,] relationshipScoresArray; // index of player and other civ, holds int relationship score value
        //public RelationshipInfo relationshipInfo; // has property of relationship score -100 to +100
        public Dictionary<CivEnum, DiplomaticEnum> _relationshipDictionary = new Dictionary<CivEnum, DiplomaticEnum>() { { (CivEnum)111, (DiplomaticEnum)(-3) } }; // key is other civ (111 is Placeholder) and DiplomaticEnum -3 is unknown 
        public List<float> _relationshipScores = new List<float>();
        //public float _civPopulation; // credits per game time
        //public List<Bonus> _globalBonuses;
        //public readonly CivilizationMapData _mapData;
        //public readonly ResearchPool _research;
        //public readonly ResourcePool _resources;
        //public readonly List<SitRepEntry> _sitRepEntries;
        //public int _totalPopulation;
        //public readonly Meter _totalValue;
        public float _civTechPoints;
        public TechLevel _civTechLevel;
        public float _civTaxRate;
        public float _cviGrowthRate; // currently using public float techPopGrowthRate = 0.01f in CivilizationData
        //public float _intel;
        public float _civCredits;
        //public readonly Treasury _treasury;
        //public int _maintenanceCostLastTurn;
        //public int _rankCredits;
        //public List<CivHistory> _civHist_List = new List<CivHistory>();
        public List<Civilization> _contactList; //**** who we have met
        //public Dictionary<int, DiplomaticRelation>
       // public StarSystem _homeColony;
        public List<StarSystem> _ownedSystem;
        public List<Ship> _fleet;
        //public List<int> _IntelIDs;
        //public MapLocation? _homeColonyLocation;
        //public int _seatOfGovernmentId = -1;
        //public readonly Meter _totalIntelligenceAttackingAccumulated;
        //public readonly Meter _totalIntelligenceDefenseAccumulated;
        public string _civInfoText;
        //public int _rankMaint;
        //public int _rankResearch;
        //public int _rankIntelAttack;
        //public readonly string newline = Environment.NewLine;
        //public readonly IPlayer _localPlayer;
        //public readonly AppContext _appContext

        #endregion Fields

        //public void Start()
        //{
        //    deltaRelation = new Dictionary<int, int>() { {0,0} }; // initialize deltaRelation Dictionary;         
        //}
        // helper method when you want to work with relationships.
        //public int GetRelationshipInt(Civilization otherCivilization)
        //{
        //    return RelationshipManager.GetRelationshipScore(this, otherCivilization);
        //}
        //public RelationshipInfo GetRelationshipInfoWith(Civilization otherCivilization)
        //{
        //    return RelationshipManager.GetRelationshipInfo(this, otherCivilization);
        //}
        // ... other faction code
        public Civilization(int sysCivInt)
        {
            this._civID = sysCivInt;
            //this._civEnum
        }
    }
}
