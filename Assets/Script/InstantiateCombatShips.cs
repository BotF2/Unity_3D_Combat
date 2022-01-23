using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Script
{
    public class InstantiateCombatShips : MonoBehaviour
    {
        public List<GameObject> combatShips;
        private Orders order;
        //public GameObject Friend_0; // prefab empty gameobject to clone instantiat into the grids
        //public GameObject Enemy_0;
        public bool _isFriend;
        public GameObject cameraEmpty;
        public GameObject animFriend1;
        public GameObject animFriend2;
        public GameObject animFriend3;
        public GameObject animEnemy1;
        public GameObject animEnemy2;
        public GameObject animEnemy3;
        int ySeparator = 40; // gap in grid between ships on y axis
        int zSeparator = 100;
       // public int offsetFriendLeft = -5500; // value of x axis for friend grid left side (start here), world location
                                             // public int offsetFriendRight = 5800; // value of x axis for friend grid right side, world location
        //public int offsetEnemyRight = 5500; // start here
                                            // public int offsetEnemyLeft = -5800;

        // ****** Use a running count of ships by type for ship starting locaitons
        int _ScoutShips = 0;
        int _DestroyerShips = 0;
        int _CapitalShips = 0;
        int _UtilityShips = 0;

        int zLocation = 0;
        int _zScoutDepth = 0;
        int _zDestroyerDepth = 0;
        int _zCapitalDepth = 0;
        int _zUtilityDepth = 0;
        bool firstTimeNotFriend = false;

        public List<GameObject> CameraTargetList; // do not send directly to CameraMultiTarget, send to GameManager first


        public void PreCombatSetup(string[] preCombatShips, bool _isFriend) // string[] preCombatEnemies) //, bool weAreFriend)
        // The preCombatShips is one side of the list of combatents that will come from galaxy screen incoming combat data

        {

            int yScout = 180; // ship types gap roes up
            int yCapital = 90;
            int yDestroyer = 0;
            float shipScale = 100f;

            List<string> preCombatShipNames = preCombatShips.ToList();

            var cameraTargets = new List<GameObject>();

              #region sort to get data for instantiating a ship
            //List<GameObject> tempList = new List<GameObject>();
            for (int i = 0; i < preCombatShipNames.Count; i++)
            {
                int xLocation = -5500;
                int yLocation = 0;
                int rotationOnY = 90;

                if (!_isFriend)
                {
                    xLocation = 5500;
                    rotationOnY = -90;
                }
                string[] _nameArray = preCombatShipNames[i].Split('_');

                switch (GameManager.Instance._combatOrder)
                {
                #region Engage Region
                case Orders.Engage:
                {
                    switch (_nameArray[1].ToUpper())
                    {
                        case "SCOUT":
                            //xLocation = xOffsetLeftRight;
                            yLocation = yScout;
                            if (_ScoutShips % 2 == 0)
                            {
                                yLocation += ySeparator;
                                zLocation = zSeparator * _zScoutDepth;
                                _zScoutDepth++;
                            }

                            SetShipCounts(_nameArray[1].ToUpper(), _isFriend);
                            break;
                        case "DESTROYER":
                            //xLocation = xOffsetLeftRight;
                            yLocation = yDestroyer;
                            if (_DestroyerShips % 2 == 0)
                            {
                                yLocation += ySeparator;
                                zLocation = zSeparator * _zDestroyerDepth;
                                _zDestroyerDepth++;
                            }

                            SetShipCounts(_nameArray[1].ToUpper(), _isFriend);
                            break;
                        case "CRUISER":
                        case "LTCRUISER":
                        case "HVYCRUISER":
                            //xLocation = xOffsetLeftRight;
                            yLocation = yCapital;
                            if (_CapitalShips % 2 == 0)
                            {
                                yLocation += ySeparator;
                                zLocation = zSeparator * _zCapitalDepth;
                                _zCapitalDepth++;
                            }

                            SetShipCounts(_nameArray[1].ToUpper(), _isFriend);
                            break;
                        case "TRANSPORT":
                        case "COLONY":
                        case "CONSTRUCTION":
                            if (_isFriend)
                                xLocation -= zSeparator;
                            else
                                xLocation += zSeparator;
                            yLocation = yCapital;
                            if (_UtilityShips % 2 == 0)
                            {
                                yLocation += ySeparator;
                                zLocation = zSeparator * _zUtilityDepth;
                                _zUtilityDepth++;
                            }

                            SetShipCounts(_nameArray[1].ToUpper(), _isFriend);
                            break;
                        case "ONEMORE":
                            break;
                        default:
                            break;
                    }
                    
                    GameObject ship = Instantiate(GameManager.PrefabDitionary[preCombatShipNames[i]], new Vector3(xLocation, yLocation, zLocation), Quaternion.identity);
                    GameObject aCameraTarget = Instantiate(cameraEmpty, new Vector3(xLocation, yLocation, zLocation), Quaternion.identity); // camera target where ships are
                    ship.transform.localScale = new Vector3(transform.localScale.x * shipScale,
                            transform.localScale.y * shipScale, transform.localScale.z * shipScale);
                    ship.transform.Rotate(0, rotationOnY, 0);
                    ParentToAnimation(ship, aCameraTarget, _isFriend);
                    
                    if (GameManager.ShipDataDictionary.TryGetValue(ship.name.ToUpper(), out int[] _result))
                    {
                        ship.GetComponent<Ship>()._shieldsMaxHealth = _result[0];
                        ship.GetComponent<Ship>()._hullMaxHealth = _result[1];
                        ship.GetComponent<Ship>()._torpedoDamage = _result[2];
                        ship.GetComponent<Ship>()._beamDamage = _result[3];
                        ship.GetComponent<Ship>()._cost = _result[4];
                    }
                    GameManager.Instance.SetShipLayer(_nameArray[0]); // informs GameManager of layer
                    ship.layer = GameManager.Instance.SetShipLayer(_nameArray[0].ToUpper()); // sets ship layer

                    combatShips.Add(ship);
                    cameraTargets.Add(aCameraTarget);
                    break;
                }

         #endregion Engage Region

                case Orders.Rush:
            #region Rush Region
                {
                    switch (_nameArray[1].ToUpper())
                    {
                        case "SCOUT":
                            if (_isFriend)
                                xLocation = xLocation + 100;
                            else xLocation = xLocation - 100;
                            yLocation = yScout;
                            if (_ScoutShips % 2 == 0)
                            {
                                yLocation += ySeparator;
                                zLocation = zSeparator * _zScoutDepth;
                                _zScoutDepth++;
                            }

                            SetShipCounts(_nameArray[1].ToUpper(), _isFriend);
                            break;
                        case "DESTROYER":
                            if(_isFriend)
                                xLocation = xLocation + 50;
                            else xLocation = xLocation - 50;
                            yLocation = yDestroyer;
                            if (_DestroyerShips % 2 == 0)
                            {
                                yLocation += ySeparator;
                                zLocation = zSeparator * _zDestroyerDepth;
                                _zDestroyerDepth++;
                            }

                            SetShipCounts(_nameArray[1].ToUpper(), _isFriend);
                            break;
                        case "CRUISER":
                        case "LTCRUISER":
                        case "HVYCRUISER":
                            //xLocation = xOffsetLeftRight;
                            yLocation = yCapital;
                            if (_CapitalShips % 2 == 0)
                            {
                                yLocation += ySeparator;
                                zLocation = zSeparator * _zCapitalDepth;
                                _zCapitalDepth++;
                            }

                            SetShipCounts(_nameArray[1].ToUpper(), _isFriend);
                            break;
                        case "TRANSPORT":
                        case "COLONY":
                        case "CONSTRUCTION":
                            if (_isFriend)
                                xLocation -= zSeparator;
                            else
                                xLocation += zSeparator;
                            yLocation = yCapital;
                            if (_UtilityShips % 2 == 0)
                            {
                                yLocation += ySeparator;
                                zLocation = zSeparator * _zUtilityDepth;
                                _zUtilityDepth++;
                            }

                            SetShipCounts(_nameArray[1].ToUpper(), _isFriend);
                            break;
                        case "ONEMORE":
                            break;
                        default:
                            break;
                    }
                    GameObject ship = Instantiate(GameManager.PrefabDitionary[preCombatShipNames[i]], new Vector3(xLocation, yLocation, zLocation), Quaternion.identity);
                    GameObject aCameraTarget = Instantiate(cameraEmpty, new Vector3(xLocation, yLocation, zLocation), Quaternion.identity); // camera target where ships are


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
                    GameManager.Instance.SetShipLayer(_nameArray[0]); // informs GameManager of layer
                    ship.layer = GameManager.Instance.SetShipLayer(_nameArray[0]); // sets ship layer

                    combatShips.Add(ship);
                    cameraTargets.Add(aCameraTarget);
                    break;
                }
                #endregion Rush Region
                case Orders.Retreat:
            #region Retreat Region
                {
                   // do something
                }
                break;
        #endregion Retreat Region
                case Orders.Formation:
            #region Formation Region
                {
                    // Do something
                }
                break;
        #endregion Formation Region
                case Orders.ProtectTransports:
            #region Protect Transports Region
                {
                    // Do Something
                }
                break;
        #endregion Protect Transports Region
                case Orders.TargetTransports:
            #region Traget Transports Region
                {
                    // do Something
                }
                break;
        #endregion Traget Transports Region
                default:
                break;
                }

            }
            CameraTargetList.AddRange(cameraTargets);
            Dictionary<int, GameObject> FriendShips = new Dictionary<int, GameObject>();
            Dictionary<int, GameObject> EnemyShips = new Dictionary<int, GameObject>();
            for (int j = 0; j < combatShips.Count; j++)
            {
                if (preCombatShips.Contains(combatShips[j].name.Replace("(Clone)", "")))
                {
                    FriendShips.Add(j, combatShips[j]);
                }
                else EnemyShips.Add(j, combatShips[j]);
            }
            GameManager.Instance.ProvideCombatShips(FriendShips, EnemyShips);

            #endregion
        }
        public void SetCombatOrder(Orders daOrder)
        {
            order = daOrder;
        }
        private void SetShipCounts(string shipType, bool isFriend)
        {

            if (!isFriend && !firstTimeNotFriend)
            {
                firstTimeNotFriend = true;
                _ScoutShips = 0;
                _DestroyerShips = 0;
                _CapitalShips = 0;
                _UtilityShips = 0;
                _zScoutDepth = 0;
                _zDestroyerDepth = 0;
                _zCapitalDepth = 0;
                _zUtilityDepth = 0; 
            }

            if (true) //isFriend)
            {
                switch (shipType)
                {
                    case "SCOUT":
                        _ScoutShips++;
                        break;
                    case "DESTROYER":
                        _DestroyerShips++;
                        break;
                    case "CRUISER":
                    case "LTCRUISER":
                    case "HVYCRUISER":
                        _CapitalShips++;
                        break;
                    case "TRANSPORT":
                    case "COLONY":
                        _UtilityShips++;
                        break;
                    case "ONEMORE":
                        break;
                    default:
                        break;
                }
            }
            //else
            //{
            //    switch (shipType)
            //    {
            //        case "SCOUT":
            //            _enemyScoutShips++;
            //            break;
            //        case "DESTROYER":
            //            _enemyDestroyerShips++;
            //            break;
            //        case "CRUISER":
            //        case "LTCRUISER":
            //        case "HVYCRUISER":
            //            _enemyCapitalShips++;
            //            break;
            //        case "TRANSPORT":
            //        case "COLONY":
            //            _enemyUtilityShips++;
            //            break;
            //        case "ONEMORE":
            //            break;
            //        default:
            //            break;
            //    }
            //}

        }
        public List<GameObject> GetCameraTargets()
        {
            return CameraTargetList;
        }
        public void ParentToAnimation(GameObject ship, GameObject cameraEmpty, bool _aFriend) // Orders order,
        {
            cameraEmpty.layer = ship.layer;
            //cameraEmpty.transform.SetParent(ship.transform, false); // ship is parent to cameraEmpty and animFriend or animEnemy set as parent of ship below
            if (_aFriend)
            {
                int choseWarp1 = Random.Range(0, 3);
                switch (choseWarp1)
                {
                    case 0:
                        animFriend1.layer = ship.layer;
                        ship.transform.SetParent(animFriend1.transform, true);
                        cameraEmpty.transform.SetParent(animFriend1.transform, true);
                        break;
                    case 1:
                        animFriend2.layer = ship.layer;
                        ship.transform.SetParent(animFriend2.transform, true);
                        cameraEmpty.transform.SetParent(animFriend2.transform, true);
                        break;
                    case 2:
                        animFriend3.layer = ship.layer;
                        ship.transform.SetParent(animFriend3.transform, true);
                        cameraEmpty.transform.SetParent(animFriend3.transform, true);
                        break;
                    default:
                        animFriend1.layer = ship.layer;
                        ship.transform.SetParent(animFriend1.transform, true);
                        cameraEmpty.transform.SetParent(animFriend1.transform, true);
                        break;
                }
            }
            else
            {

                int choseWarp2 = Random.Range(0, 3);
                switch (choseWarp2)
                {
                    case 0:
                        animEnemy1.layer = ship.layer;
                        ship.transform.SetParent(animEnemy1.transform, true);
                        cameraEmpty.transform.SetParent(animEnemy1.transform, true);
                        break;
                    case 1:
                        animEnemy2.layer = ship.layer;
                        ship.transform.SetParent(animEnemy2.transform, true);
                        cameraEmpty.transform.SetParent(animEnemy2.transform, true);
                        break;
                    case 2:
                        animEnemy3.layer = ship.layer;
                        ship.transform.SetParent(animEnemy3.transform, true);
                        cameraEmpty.transform.SetParent(animEnemy3.transform, true);
                        break;
                    default:
                        animEnemy1.layer = ship.layer;
                        ship.transform.SetParent(animEnemy1.transform, true);
                        cameraEmpty.transform.SetParent(animEnemy1.transform, true);
                        break;
                }
            }
        }
    }
}
