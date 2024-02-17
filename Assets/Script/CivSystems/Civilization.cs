using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Assets.Core;
using GalaxyMap;

namespace Assets.Core
{
    [System.Serializable]
    public class Civilization // has what is unique to a civ
    {
        #region Fields

        //ToDo: add 2 Traits for a civ
        public int _civID;
        public CivEnum _civEnum;
        public string _shortName;
        public string _longName;
        public StarSystemEnum _homeSystemEnum;
        public static Civilization FED;
        public static Civilization ROM;
        public static Civilization KLING;
        public static Civilization CARD;
        public static Civilization DOM;
        public static Civilization BORG;
        public static Civilization TERRAN;
        //public Race race -- try to leave this off, too complicated
        //public StarSystem _homeSystem;
        public bool _weAreMajorCiv;
        //public Traits _traitOne;
        //public Traits _traitTwo;
        public Sprite _civImage;
        public Sprite _insignia;
        public List<FleetData> civFleetList;
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

        public List<StarSystemEnum> _ownedSystemEnums;
        public List<Ship> _listCombatShips;
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

        public void Awake() 
        {
            FED = new Civilization(0);
            ROM = new Civilization(1);
            KLING = new Civilization(2);
            CARD = new Civilization(3);
            DOM = new Civilization(4);
            BORG = new Civilization(5);
            TERRAN = new Civilization(300);
        }

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
