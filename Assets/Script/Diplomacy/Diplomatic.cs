using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BOTF3D_GalaxyMap;
using BOTF3D_Core;
using BOTF3D_Combat;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Assets.Script
{
    public class Diplomatic : MonoBehaviour
    {
        // see CivilizationData DoDiplomacy SEE RELATIONSHIPINFO RelationshipInfo.cs
        public GameManager gameManager;
        public CivilizationData civilizationData;


        //private List<DiplomaticRelation> diploRelationList;
        //public enum DiplomaticRelation
        //{
        //    UnKnow, // 500 RelationshipScore in RelationshipInfo.cs
        //    AtWar, // 0 RelationshipScore in RelationshipInfo.cs - down 5 point each stardate (negative converts to zero)
        //    Hostile, // <250 RelationshipScore in RelationshipInfo.cs
        //    Neutral, // 250 - 750 RelationshipScore in RelationshipInfo.cs - no change
        //    AtPease, // >750 RelationshipScore in RelationshipInfo.cs - up 3 point each stardate
        //    WillFightAlongSide // 500 RelationshipScore in RelationshipInfo.cs
        //}
        // public List<CivEnum> FightWithFed = new List<CivEnum>() { CivEnum.FED };
        // //public List<Civilization> FightWithTerran;
        // public List<CivEnum> FightWithRom = new List<CivEnum>() { CivEnum.ROM, CivEnum.KLING, CivEnum.CARD };
        // public List<CivEnum> FightWithKling = new List<CivEnum>() { CivEnum.ROM, CivEnum.KLING, CivEnum.CARD };
        // public List<CivEnum> FightWithCard = new List<CivEnum>() { CivEnum.ROM, CivEnum.KLING, CivEnum.CARD };
        // public List<CivEnum> FightWithDom;
        // public List<CivEnum> FightWithBorg;

        // public List<CivEnum> FightFed = new List<CivEnum>() { CivEnum.ROM, CivEnum.KLING, CivEnum.CARD };
        //// public List<Civilization> FightTerran;
        // public List<CivEnum> FightRom = new List<CivEnum>() { CivEnum.FED };
        // public List<CivEnum> FightKling = new List<CivEnum>() { CivEnum.FED };
        // public List<CivEnum> FightCard = new List<CivEnum>() { CivEnum.FED };
        // public List<CivEnum> FightDom;
        // public List<CivEnum> FightBorg;

        public void Start()
        {

        }
        void Update()
        {
            // update diplomacy here
        }
        public DiplomaticEnum WhatIsOurDiploicEnum(CivEnum civE)
        {
            return CivilizationData.CivilizationDictionary[civE]._relationshipDictionary[civE];
        }
        public void UpdateDiplomaticRelation(CivEnum civ1, CivEnum civ2, float delta)
        {
            // do math to change relationship, look up current relation and see when to change it
        }
    }

    
    //public bool WillFigthsWithMe(CivEnum civ)
    //{
    //    switch (civ)
    //    {
    //        case CivEnum.FED:
    //            return FightWithFed.ToArray();
    //            break;
    //        //case Civilization.TERRAN:
    //        //    return FightWithTerran.ToArray();
    //        //    break;
    //        case CivEnum.ROM:
    //            return FightWithRom.ToArray();
    //            break;
    //        case CivEnum.KLING:
    //            return FightWithKling.ToArray();
    //            break;
    //        case CivEnum.CARD:
    //            return FightWithCard.ToArray();
    //            break;
    //        case CivEnum.DOM:
    //            return FightWithDom.ToArray();
    //            break;
    //        case CivEnum.BORG:
    //            return FightWithBorg.ToArray();
    //            break;
    //        default:
    //            return FightWithFed.ToArray();
    //            break;
    //    }
    //}
    //public bool WhoIsAtWar(CivEnum civ)
    //{
    //    switch (civ)
    //    {
    //        case CivEnum.FED:
    //            return FightFed.ToArray();
    //            break;
    //        //case Civilization.TERRAN:
    //        //    return FightTerran.ToArray();
    //        //    break;
    //        case CivEnum.ROM:
    //            return FightRom.ToArray();
    //            break;
    //        case CivEnum.KLING:
    //            return FightKling.ToArray();
    //            break;
    //        case CivEnum.CARD:
    //            return FightCard.ToArray();
    //            break;
    //        case CivEnum.DOM:
    //            return FightDom.ToArray();
    //            break;
    //        case CivEnum.BORG:
    //            return FightBorg.ToArray();
    //            break;
    //        default:
    //            return FightWithFed.ToArray();
    //            break;
    //    }
    //}

}

