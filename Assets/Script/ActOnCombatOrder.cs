using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Script
{
    public class ActOnCombatOrder : MonoBehaviour
    {
        public static Dictionary<int, GameObject> FriendShips = new Dictionary<int, GameObject>();  // updated to current combat
        public static Dictionary<int, GameObject> EnemyShips = new Dictionary<int, GameObject>();
        public static Dictionary<int, GameObject> CombatObjects = new Dictionary<int, GameObject>();

        public void CombatOrderAction(Orders order, Dictionary<int, GameObject> daFriends, Dictionary<int, GameObject> daEnemies) // GameManager Orders updated by toggle in CombatmMenu through CombatOrderSeleciton.cs
        {
            FriendShips = daFriends;
            EnemyShips = daEnemies;
            foreach (var item in daEnemies)
            {
                CombatObjects.Add(item.Key, item.Value);
            }
            foreach (var item in daFriends)
            {
                CombatObjects.Add(item.Key, item.Value);
            }

            switch (order)
            {
                case Orders.Engage:
                    EngageOrder();
                    //GameManager.Instance.instantiateCombatShips.order = Orders.Engage;
                    // currently using InstantiateCombatShips to setup ship entry by order then this section will be for during combat running
                    break;
                case Orders.Rush:
                    RushOrder();
                    //GameManager.Instance.instantiateCombatShips.order = Orders.Rush;
                    break;
                case Orders.Formation:
                    FormationOrder();
                    //GameManager.Instance.instantiateCombatShips.order = Orders.Formation;
                    break;
                case Orders.Retreat:
                    RetreatOrder();
                    //GameManager.Instance.instantiateCombatShips.order = Orders.Retreat;
                    break;
                case Orders.ProtectTransports:
                    ProtectTransportsOrder();
                    //GameManager.Instance.instantiateCombatShips.order = Orders.ProtectTransports;
                    break;
                case Orders.TargetTransports:
                    TargetTransportsOrder();
                    //GameManager.Instance.instantiateCombatShips.order = Orders.TargetTransports;
                    break;
                default:
                    break;
            }
        }
        private void EngageOrder()
        {            
            // instantiation locations set in InstantiateCombatShips based on CombatOrderSelection.cs / UI
        }
        private void RushOrder() { }
        private void RetreatOrder() { }
        private void FormationOrder() { }
        private void ProtectTransportsOrder() { }
        private void TargetTransportsOrder() { }
    }
}
