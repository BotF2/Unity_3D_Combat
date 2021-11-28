using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Script
{
    public class ActOnCombatOrder : MonoBehaviour
    {
        public bool Animate = false;
        public GameObject animFriend1;
        public GameObject animFriend2;
        public GameObject animFriend3;
        public GameObject animEnemy1;
        public GameObject animEnemy2;
        public GameObject animEnemy3;
        //public Animator animEnemy;
        //public AudioSource warpAudioSource_0;
        //public Friend_Animator friendAnimator;
        //public Enemy_Animator enemyAnimator;
        int leftRightGap = 400;
        // GameObject[] objectPair = new GameObject[2];
        //List<GameObject, GameObject> listOfChildAndParent;
        //public static string[] FriendNameArray; // For current Combat ****
        //public static string[] EnemyNameArray;
        public int xFriend = -5500;
        public int xEnemy = 5500;
        public static Dictionary<int, GameObject> FriendShips = new Dictionary<int, GameObject>();  // updated to current combat
        public static Dictionary<int, GameObject> EnemyShips = new Dictionary<int, GameObject>();
        public static Dictionary<int, GameObject> CombatObjects = new Dictionary<int, GameObject>();

        void Start()
        {

        }


        //public GameObject[] _AnimationEmpties;
        ////public GameObject testAnimation;
        //// Engaqe Animation
        //public GameObject EngageFriendScout_Y0_Z0;
        //public GameObject EngageFriendDestroyer_Y0_Z1;
        //public GameObject EngageFriendCapital_Y0_Z2;
        //public GameObject EngageFriendColony_Y1_Z0;
        //public GameObject EngageFriend_Y1_Z1;
        //public GameObject EngageFriend_Y1_Z2;
        //public GameObject EngageEnemyScout_Y0_Z0;
        //public GameObject EngageEnemyDestroyer_Y0_Z1;
        //public GameObject EngageEnemyCapital_Y0_Z2;
        //public GameObject EngageEnemyColony_Y1_Z0;
        //public GameObject EngageEnemy_Y1_Z1;
        //public GameObject EngageEnemy_Y1_Z2;
        //// Formation Animation
        //public GameObject FormationFriendScout_Y0_Z0;
        //public GameObject FormationFriendDestroyer_Y0_Z1;
        //public GameObject FormationFriendCapital_Y0_Z2;
        //public GameObject FormationFriendColony_Y1_Z0;
        //public GameObject FormationFriend_Y1_Z1;
        //public GameObject FormationFriend_Y1_Z2;
        //public GameObject FormationEnemyScout_Y0_Z0;
        //public GameObject FormationEnemyDestroyer_Y0_Z1;
        //public GameObject FormationEnemyCapital_Y0_Z2;
        //public GameObject FormationEnemyColony_Y1_Z0;
        //public GameObject FormationEnemy_Y1_Z1;
        //public GameObject FormationEnemy_Y1_Z2;
        //private void Start()
        //{
        //    StartCoroutine(waiter());
        //}

        //// Update is called once per frame
        //void Update()
        //{

        //    StartCoroutine(waiter());

        //    //ExecuteAnimation();
        //    // ????? Do we Send update on target list to CombatMultiTarget.cs here or later !!!!!!!!!!!
        //}
        //private void AddPairToList(GameObject child, FriendOrFoe who)
        //{
        //    GameObject friendAnimation;
        //    if (who == FriendOrFoe.friend)
        //         { friendAnimation = Instantiate(testAnimation, new Vector3(xFriend, 0, 0), Quaternion.identity); }
        //    else
        //    {
        //        { friendAnimation = Instantiate(testAnimation, new Vector3(xFriend, 0, 0), Quaternion.identity); }
        //    }
        //    //AnimationObjectPair newPair = new AnimationObjectPair(child, friendAnimation);
        //    //if (newPair != null)
        //    listOfChildAndParent.Add(child, friendAnimation);
        //}
        //private void ParentThis()
        //{
        //    if (listOfChildAndParent != null)
        //    foreach (var item in listOfChildAndParent)
        //    {
        //        item._objectPair[0].transform.SetParent(item._objectPair[1].transform, true);
        //    }
        //}
        //IEnumerator waiter()
        //{
        //    int xCount = Random.Range(1, 2);
        //    yield return new WaitForSeconds(xCount);
        //    ParentThis();
        //   // StartCoroutine(waiter());
        //}
        //void ExecuteAnimation()
        //{
        //    Animate = true;
        //}
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
                    break;
                case Orders.Formation:
                    FormationOrder();
                    break;
                case Orders.Retreat:
                    RetreatOrder();
                    break;
                case Orders.ProtectTransports:
                    ProtectTransportsOrder();
                    break;
                case Orders.Rush:
                    RushOrder();
                    break;
                case Orders.AttackTransports:
                    AttackTransportsOrder();
                    break;
                default:
                    break;
            }
        }
        private void EngageOrder()
        {            

        }
        private void FormationOrder() { }
        private void RetreatOrder() { }
        private void ProtectTransportsOrder() { }
        private void RushOrder() { }
        private void AttackTransportsOrder() { }
        //private GameObject GetAnimatorEmpty(GameObject aShip, FriendOrFoe who)
        //{
        //    int shipTypeIncrement = 0;
        //    int enemyIncrement = 0;
        //    if (who == FriendOrFoe.enemy)
        //        enemyIncrement = 6;
        //    string readName = aShip.name.ToUpper();
        //    string[] _nameParts = readName.Split('_');
        //    string shipType = _nameParts[1];
        //    switch (shipType)
        //    {
        //        case "SCOUT":
        //            shipTypeIncrement = 0;
        //            break;
        //        case "DESTROYER":
        //            shipTypeIncrement = 1;
        //            break;
        //        case "CRUISER":
        //        case "LT-CRUISER":
        //        case "HVY-CRISER":
        //            shipTypeIncrement = 2;
        //            break;
        //        case "COLONY":
        //            shipTypeIncrement = 3;
        //            break;
        //        //case "more ship types here":
        //        //    shipIncrement = 0;
        //        //    break;
        //        default:
        //            break;
        //    }
        //    return _AnimationEmpties[shipTypeIncrement + enemyIncrement];
        //}
    }
}
