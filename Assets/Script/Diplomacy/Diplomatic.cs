using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BOTF3D_GalaxyMap;
using BOTF3D_Core;
using BOTF3D_Combat;

namespace Assets.Script
{
    public class Diplomatic: MonoBehaviour
    {
        public enum DiplomaticRelations
        {
            AtWar,
            Hostile,
            Neutral,
            AtPease,
            WillTrade,
            WillFightAlongSide
        }
        public List<Civ> FightWithFed = new List<Civ>() { Civ.FED };
        //public List<Civilization> FightWithTerran;
        public List<Civ> FightWithRom = new List<Civ>() { Civ.ROM, Civ.KLING, Civ.CARD };
        public List<Civ> FightWithKling = new List<Civ>() { Civ.ROM, Civ.KLING, Civ.CARD };
        public List<Civ> FightWithCard = new List<Civ>() { Civ.ROM, Civ.KLING, Civ.CARD };
        public List<Civ> FightWithDom;
        public List<Civ> FightWithBorg;

        public List<Civ> FightFed = new List<Civ>() { Civ.ROM, Civ.KLING, Civ.CARD };
       // public List<Civilization> FightTerran;
        public List<Civ> FightRom = new List<Civ>() { Civ.FED };
        public List<Civ> FightKling = new List<Civ>() { Civ.FED };
        public List<Civ> FightCard = new List<Civ>() { Civ.FED };
        public List<Civ> FightDom;
        public List<Civ> FightBorg;

        public void Start()
        {

        }
        void Update()
        {
            // update diplomacy here
        }

        public Civ[] WhoFigthsWithMe(Civ civ)
        {
            switch (civ)
            {
                case Civ.FED:
                    return FightWithFed.ToArray();
                    break;
                //case Civilization.TERRAN:
                //    return FightWithTerran.ToArray();
                //    break;
                case Civ.ROM:
                    return FightWithRom.ToArray();
                    break;
                case Civ.KLING:
                    return FightWithKling.ToArray();
                    break;
                case Civ.CARD:
                    return FightWithCard.ToArray();
                    break;
                case Civ.DOM:
                    return FightWithDom.ToArray();
                    break;
                case Civ.BORG:
                    return FightWithBorg.ToArray();
                    break;
                default:
                    return FightWithFed.ToArray();
                    break;
            }
        }
        public Civ[] WhoIsAtWar(Civ civ)
        {
            switch (civ)
            {
                case Civ.FED:
                    return FightFed.ToArray();
                    break;
                //case Civilization.TERRAN:
                //    return FightTerran.ToArray();
                //    break;
                case Civ.ROM:
                    return FightRom.ToArray();
                    break;
                case Civ.KLING:
                    return FightKling.ToArray();
                    break;
                case Civ.CARD:
                    return FightCard.ToArray();
                    break;
                case Civ.DOM:
                    return FightDom.ToArray();
                    break;
                case Civ.BORG:
                    return FightBorg.ToArray();
                    break;
                default:
                    return FightWithFed.ToArray();
                    break;
            }
        }

    }
}
