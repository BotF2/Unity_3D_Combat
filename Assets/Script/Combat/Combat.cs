using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BOTF3D_GalaxyMap;
using BOTF3D_Core;
using Assets.Script;
using System;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using Assets.Script;
using BOTF3D_GalaxyMap;
using BOTF3D_Combat;

namespace BOTF3D_Combat
{

    public class Combat : MonoBehaviour
    {
        //ToDo: get a list of combatants form galaxy map / diplomacy
        // call diplomayc WhoFigthsWithMe(Civilization civ) with civs from galaxy map
        // call WhoIsAtWar(Civilization civ) with civs and build a list of FriendShips on left and EnemyShips on right.
        // Hard coded for now
        public List<GameObject> _friendCombatans; // for now be get the combatant gameObjects as they are instantiated in InstantiatCombatShips
        public List<GameObject> _enemyCombatans;

        public List<CivEnum> _friendCivs = new List<CivEnum>() { CivEnum.FED };
        public List<CivEnum> _enemyCivs = new List<CivEnum>() { CivEnum.KLING, CivEnum.ROM, CivEnum.CARD };

        public void AddCombatant(GameObject combatant)
        {
            string[] nameArray = new string[3] { "civilization", "shipType", "era" };
            if (combatant.name != "Ship")
            {
                nameArray = combatant.name.Split('_');
            }
            string civName = nameArray[0];
            CivEnum daCiv;
            switch (civName.ToUpper())
            {
                case "FED":
                    daCiv = CivEnum.FED;
                    break;
                //case "TERRAN":
                //    daCiv = Civilization.TERRAN;
                //    break;
                case "ROM":
                    daCiv = CivEnum.ROM;
                    break;
                case "KLING":
                    daCiv = CivEnum.KLING;
                    break;
                case "CARD":
                    daCiv = CivEnum.CARD;
                    break;
                case "DOM":
                    daCiv = CivEnum.DOM;
                    break;
                case "BORG":
                    daCiv = CivEnum.BORG;
                    break;
                default:
                    daCiv = CivEnum.FED;
                    break;
            }
            if (_friendCivs.Contains(daCiv))
            {
                _friendCivs.Add(daCiv);
            }
            else if (_enemyCivs.Contains(daCiv))
            {
                _enemyCivs.Add(daCiv);
            }
        }

        public List<GameObject> UpdateFriendCombatants()
        {
            return _friendCombatans;
        }
        public List<GameObject> UpdateEnemyCombatants()
        {
            return _enemyCombatans;
        }
        public List<CivEnum> FriendCivCombatants()
        {
            return _friendCivs;
        }
        public List<CivEnum> EnemyCivCombatants()
        {
            return _enemyCivs;
        }
        // do something
        /*   string[] _friendNameArray = new string[] { "FED_CRUISER_II", "FED_CRUISER_III", "FED_DESTROYER_II", "FED_DESTROYER_II",
                "FED_DESTROYER_I", "FED_SCOUT_II", "FED_SCOUT_IV" , "FED_COLONYSHIP_I" };
        FriendNameArray = _friendNameArray;
            string[] _enemyNameArray = new string[] {"KLING_DESTROYER_I", "KLING_DESTROYER_I", "KLING_CRUISER_II", "KLING_SCOUT_II", "KLING_COLONYSHIP_I","CARD_SCOUT_I",
                "ROM_CRUISER_III", "ROM_CRUISER_II", "ROM_SCOUT_III"} */
    }
}
