using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;
using System.Linq;

namespace Assets.Script
{
    public class InstantiateCombatShips : MonoBehaviour
    {
        public List<GameObject> combatShips;
        public int ySeparator = 100; // gap in grid between ships on y axis
        public int zSeparator = 100;
        public int offsetFriendLeft = -5500; // value of x axis for friend grid left side (start here), world location
       // public int offsetFriendRight = 5800; // value of x axis for friend grid right side, world location
        public int offsetEnemyRight = 5500; // start here
       // public int offsetEnemyLeft = -5800;

        // ****** Use a running count of ships by to for ship starting locaitons
        public int _friendScoutShips = 0;
        public int _friendDestroyerShips = 0;
        public int _friendCapitalShips = 0;
        public int _friendUtilityShips = 0;
        public int _enemyScoutShips = 0;
        public int _enemyDestroyerShips = 0;
        public int _enemyCapitalShips = 0;
        public int _enemyUtilityShips = 0;
        public GameObject cameraEmpty;
        public List<GameObject> cameraTargetList; // do not send directly to CameraMultiTarget, send to GameManager first

        //void Awake()
        //{

        //}

        //// Update is called once per frame
        //void Update()
        //{ 

        //}
        public void PreCombatSetup(string[] preCombatFriends, string[] preCombatEnemies) //, bool weAreFriend)
        // The preCombatFriends is the list of friend combatents that will come from galaxy screen incoming combat data

        {
            int yScout = 180; // ship types in roes going into screen
            int yCapital = 90;
            int yDestroyer = 0;
            float shipScale = 100f;

            List<string> preCombatShipNames = preCombatFriends.ToList(); // local list of ships for this combat instance
            foreach (var item in preCombatEnemies.ToList())
            {
                preCombatShipNames.Add(item);
            }
            var cameraTargets = new List<GameObject>();
            int xOffsetLeftRight;
            int xCameraEmpty= 0; // 0 for left side friends and 300 for right side enemies
            int xLocation = 0;
            int yLocation = 0;
            int zLocation = 0;
            GameObject emptyPrefab;
            int rotationOnY;
            bool isFriend;

            #region sort to get data for instantiating a ship
            List<GameObject> tempList = new List<GameObject>();
            for (int i = 0; i < preCombatShipNames.Count; i++)
            {
                string[] _nameArray = preCombatShipNames[i].Split('_');
                if (preCombatFriends.Contains(preCombatShipNames[i]))
                {
                    xOffsetLeftRight = offsetFriendLeft;
                    emptyPrefab = GameManager.Friend_0;
                    rotationOnY = 90;
                    isFriend = true;
                }
                else
                {
                    xOffsetLeftRight = offsetEnemyRight;
                    emptyPrefab = GameManager.Enemy_0;
                    rotationOnY = -90;
                    isFriend = false;
                }
                // need y and z location for each ship and x for camera empties set by left 0, right 300

                if (isFriend) //friendOrFoe == FriendOrFoe.friend)
                {
                    xCameraEmpty = 0;
                    switch (_nameArray[1].ToUpper())
                    {
                        case "SCOUT":
                            xLocation = xOffsetLeftRight;
                            yLocation = yScout;
                            if (_friendScoutShips % 2 == 0)
                                yLocation = yLocation + ySeparator;
                            int zScoutLocal = _friendScoutShips / 2;
                            zLocation = zSeparator * zScoutLocal;
                            SetShipCounts(_nameArray[1], isFriend);
                            break;
                        case "DESTROYER":
                            xLocation = xOffsetLeftRight;
                            yLocation = yDestroyer;
                            if (_friendDestroyerShips % 2 == 0)
                                yLocation = yLocation + ySeparator;

                            int zDestroyerLocal = _friendDestroyerShips / 2;
                            zLocation = zSeparator * zDestroyerLocal;
                            SetShipCounts(_nameArray[1], isFriend);
                            break;
                        case "CRUISER":
                        case "LTCRUISER":
                        case "HVYCRUISER":
                            xLocation = xOffsetLeftRight;
                            yLocation = yCapital;
                            if (_friendCapitalShips % 2 == 0)
                                yLocation = yLocation + ySeparator;

                            int zCapitalLocal = _friendCapitalShips / 2;
                            zLocation = zSeparator * zCapitalLocal;
                            SetShipCounts(_nameArray[1], isFriend);
                            break;
                        case "TRANSPORT":
                        case "COLONY":
                            xLocation = xOffsetLeftRight - zSeparator;
                            yLocation = yCapital;
                            if (_friendUtilityShips % 2 == 0)
                                yLocation = yLocation + ySeparator;

                            int zUtilityLocal = _friendDestroyerShips / 2;
                            zLocation = zSeparator * zUtilityLocal;
                            SetShipCounts(_nameArray[1], isFriend);
                            break;
                        case "ONEMORE":
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    xCameraEmpty = 300;
                    switch (_nameArray[1].ToUpper())
                    {
                        case "SCOUT":
                            xLocation = xOffsetLeftRight;
                            yLocation = yScout;
                            if (_enemyScoutShips % 2 == 0)
                                yLocation = yLocation + ySeparator;

                            int zScoutLocal = _enemyScoutShips / 2;
                            zLocation = zSeparator * zScoutLocal;
                            SetShipCounts(_nameArray[1], isFriend);
                            break;
                        case "DESTROYER":
                            xLocation = xOffsetLeftRight;
                            yLocation = yDestroyer;
                            if (_enemyDestroyerShips % 2 == 0)
                                yLocation = yLocation + ySeparator;

                            int zDestroyerLocal = _enemyDestroyerShips / 2;
                            zLocation = zSeparator * zDestroyerLocal;
                            SetShipCounts(_nameArray[1], isFriend);
                            break;
                        case "CRUISER":
                        case "LTCRUISER":
                        case "HVYCRUISER":
                            xLocation = xOffsetLeftRight;
                            yLocation = yCapital;
                            if (_enemyCapitalShips % 2 == 0)
                                yLocation = yLocation + ySeparator;

                            int zCapitalLocal = _enemyCapitalShips / 2;
                            zLocation = zSeparator * zCapitalLocal;
                            SetShipCounts(_nameArray[1], isFriend);
                            break;
                        case "TRANSPORT":
                        case "COLONY":
                            xLocation = xOffsetLeftRight + ySeparator;
                            yLocation = yCapital;
                            if (_enemyUtilityShips % 2 == 0)
                                yLocation = yLocation + ySeparator;

                            int zUtilityLocal = _enemyDestroyerShips / 2;
                            zLocation = zSeparator * zUtilityLocal;
                            SetShipCounts(_nameArray[1], isFriend);
                            break;
                        case "ONEMORE":
                            break;
                        default:
                            break;
                    }
                }
                GameObject ship = Instantiate(GameManager.PrefabDitionary[preCombatShipNames[i]], new Vector3(xLocation, yLocation, zLocation), Quaternion.identity);
                GameObject aCameraTarget = Instantiate(cameraEmpty, new Vector3(xCameraEmpty, yLocation, zLocation), Quaternion.identity); // camera target where ships are
            
                ship.transform.localScale = new Vector3(transform.localScale.x * shipScale,
                    transform.localScale.y * shipScale, transform.localScale.z * shipScale);
                ship.transform.Rotate(0, rotationOnY, 0);
                
                if (GameManager.ShipDataDictionary.TryGetValue(ship.name.ToUpper(), out int[] _result))
                {
                    ship.GetComponent<Ship>()._shieldsMaxHealth = _result[0];
                    ship.GetComponent<Ship>()._hullMaxHealth = _result[1];
                    ship.GetComponent<Ship>()._torpedoDamage = _result[2];
                    ship.GetComponent<Ship>()._beamDamage = _result[3];
                    ship.GetComponent<Ship>()._cost = _result[4];
                }
                GameManager.Instance.SetShipLayer(_nameArray[0], isFriend); // informs GameManager of layer
                ship.layer = GameManager.Instance.SetShipLayer(_nameArray[0]); // sets ship layer
                
                combatShips.Add(ship);
                cameraTargetList.Add(aCameraTarget);

            }
            Dictionary<int, GameObject> FriendShips = new Dictionary<int, GameObject>();
            Dictionary<int, GameObject> EnemyShips = new Dictionary<int, GameObject>();
            for (int j = 0; j < combatShips.Count; j++)
            {
                if (preCombatFriends.Contains(combatShips[j].name.Replace("(Clone)", "")))
                {
                    FriendShips.Add(j, combatShips[j]);
                }
                else EnemyShips.Add(j, combatShips[j]);
            }
            GameManager.Instance.ProvidCombatShips(FriendShips, EnemyShips);

            #endregion
        }
        private void SetShipCounts(string shipType, bool isFriend)
        {
            if (isFriend)
            {
                switch (shipType)
                {
                    case "SCOUT":
                        _friendScoutShips++;
                        break;
                    case "DESTROYER":
                        _friendDestroyerShips++;
                        break;
                    case "CRUISER":
                    case "LTCRUISER":
                    case "HVYCRUISER":
                        _friendCapitalShips++;
                        break;
                    case "TRANSPORT":
                    case "COLONY":
                        _friendUtilityShips++;
                        break;
                    case "ONEMORE":
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (shipType)
                {
                    case "SCOUT":
                        _enemyScoutShips++;
                        break;
                    case "DESTROYER":
                        _enemyDestroyerShips++;
                        break;
                    case "CRUISER":
                    case "LTCRUISER":
                    case "HVYCRUISER":
                        _enemyCapitalShips++;
                        break;
                    case "TRANSPORT":
                    case "COLONY":
                        _enemyUtilityShips++;
                        break;
                    case "ONEMORE":
                        break;
                    default:
                        break;
                }
            }

        }
        public List<GameObject> GetCameraTargets()
        {
            return cameraTargetList;
        }
    }
}
