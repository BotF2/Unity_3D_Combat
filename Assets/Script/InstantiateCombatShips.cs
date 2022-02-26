using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Script
{
    public class InstantiateCombatShips : MonoBehaviour
    {
        public List<GameObject> combatShips;
        //public List<Ship> ships;
        public Orders order;
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
        public GameObject animFriendRushScout;
        public GameObject animFriendRushDistroy;
        public GameObject animFriendRushCapital;
        public GameObject animEnemyRushScout;
        public GameObject animEnemyRushDistroy;
        public GameObject animEnemyRushCapital;
        int ySeparator = 40; // gap in grid between ships on y axis
        int zSeparator = 70;
        float shipScale = 100f;

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
        int timesNotFriend = 0;

        public List<GameObject> CameraTargetList; // do not send directly to CameraMultiTarget, send to GameManager first
        private string[] arrayOfNames;

        public void PreCombatSetup(string[] preCombatShips, bool _isFriend) // string[] preCombatEnemies) //, bool weAreFriend)
        // The preCombatShips is one side of the list of combatents that will come from galaxy screen incoming combat data
        {
            int yScout = 180; // ship types gap roes up
            int yCapital = 90;
            int yDestroyer = 0;

            List<string> preCombatShipNames = preCombatShips.ToList();
            List<string> scoutList = new List<string>();
            List<string> destroyerList = new List<string>();
            List<string> capitalList = new List<string>();
            List<string> otherShipsList = new List<string>();

            var cameraTargets = new List<GameObject>();
            if (CombatOrderSelection.order == Orders.Formation)
            {
                for (int i = 0; i < preCombatShipNames.Count; i++)
                {
                    arrayOfNames = preCombatShipNames[i].Split('_');
                    switch (arrayOfNames[1].ToUpper())
                    {
                    case "SCOUT":
                        scoutList.Add(preCombatShipNames[i]);
                        break;
                    case "DESTROYER":
                        destroyerList.Add(preCombatShipNames[i]);
                        break;
                    case "CRUISER":
                    case "LTCRUISER":
                    case "HVYCRUISER":
                        capitalList.Add(preCombatShipNames[i]);
                        break;
                    case "TRANSPORT":
                    case "COLONY":
                    case "CONSTRUCTION":
                        otherShipsList.Add(preCombatShipNames[i]);
                        break;
                    case "ONEMORE":
                        break;
                    default:
                        break;
                    }
                }
            }

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
                arrayOfNames = preCombatShipNames[i].Split('_');

                switch (CombatOrderSelection.order)
                {
                    case Orders.Engage:
                    #region Engage Region
                    {
                        switch (arrayOfNames[1].ToUpper())
                        {
                            case "SCOUT":

                                yLocation = yScout;
                                if (_ScoutShips % 2 == 0)
                                {
                                    yLocation += ySeparator;
                                    zLocation = zSeparator * _zScoutDepth;
                                    _zScoutDepth++;
                                }

                                SetShipCounts(arrayOfNames[1].ToUpper(), _isFriend);
                                break;
                            case "DESTROYER":

                                yLocation = yDestroyer;
                                if (_DestroyerShips % 2 == 0)
                                {
                                    yLocation += ySeparator;
                                    zLocation = zSeparator * _zDestroyerDepth;
                                    _zDestroyerDepth++;
                                }

                                SetShipCounts(arrayOfNames[1].ToUpper(), _isFriend);
                                break;
                            case "CRUISER":
                            case "LTCRUISER":
                            case "HVYCRUISER":

                                yLocation = yCapital;
                                if (_CapitalShips % 2 == 0)
                                {
                                    yLocation += ySeparator;
                                    zLocation = zSeparator * _zCapitalDepth;
                                    _zCapitalDepth++;
                                }

                                SetShipCounts(arrayOfNames[1].ToUpper(), _isFriend);
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

                                SetShipCounts(arrayOfNames[1].ToUpper(), _isFriend);
                                break;
                            case "ONEMORE":
                                break;
                            default:
                                break;
                        }                  
                        GameObject ship = Instantiate(GameManager.PrefabDitionary[preCombatShipNames[i]], new Vector3(xLocation, yLocation, zLocation), Quaternion.identity);
                        GameObject aCameraTarget = Instantiate(cameraEmpty, new Vector3(xLocation, yLocation, zLocation), Quaternion.identity); // camera target where ships are
                        aCameraTarget.transform.Rotate(0, rotationOnY, 0); // match ship rotation
                        ShipScaleAndRotation(ship, rotationOnY);
                        ParentToAnimation(ship, aCameraTarget, _isFriend, CombatOrderSelection.order);
                        PopulateShipData(ship);
                        GameManager.Instance.SetShipLayer(arrayOfNames[0]); // informs GameManager of layer
                        ship.layer = GameManager.Instance.SetShipLayer(arrayOfNames[0].ToUpper()); // sets ship layer

                        combatShips.Add(ship);
                        cameraTargets.Add(aCameraTarget);
                        break;
                    }
                    #endregion Engage Region

                    case Orders.Rush:
                    #region Rush Region
                    {
                        switch (arrayOfNames[1].ToUpper())
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

                                SetShipCounts(arrayOfNames[1].ToUpper(), _isFriend);
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

                                SetShipCounts(arrayOfNames[1].ToUpper(), _isFriend);
                                break;
                            case "CRUISER":
                            case "LTCRUISER":
                            case "HVYCRUISER":

                                yLocation = yCapital;
                                if (_CapitalShips % 2 == 0)
                                {
                                    yLocation += ySeparator;
                                    zLocation = zSeparator * _zCapitalDepth;
                                    _zCapitalDepth++;
                                }

                                SetShipCounts(arrayOfNames[1].ToUpper(), _isFriend);
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

                                SetShipCounts(arrayOfNames[1].ToUpper(), _isFriend);
                                break;
                            case "ONEMORE":
                                break;
                            default:
                                break;
                        }
                        GameObject ship = Instantiate(GameManager.PrefabDitionary[preCombatShipNames[i]], new Vector3(xLocation, yLocation, zLocation), Quaternion.identity);
                        GameObject aCameraTarget = Instantiate(cameraEmpty, new Vector3(xLocation, yLocation, zLocation), Quaternion.identity); // camera target where ships are
                        aCameraTarget.transform.Rotate(0, rotationOnY, 0); // match ship rotation
                        ShipScaleAndRotation(ship, rotationOnY);
                        ParentToAnimation(ship, aCameraTarget, _isFriend, CombatOrderSelection.order);
                        PopulateShipData(ship);
                        GameManager.Instance.SetShipLayer(arrayOfNames[0]); // informs GameManager of layer
                        ship.layer = GameManager.Instance.SetShipLayer(arrayOfNames[0].ToUpper()); // sets ship layer

                        combatShips.Add(ship);
                        cameraTargets.Add(aCameraTarget);
                        break;
                    }
                    #endregion Rush Region

                    case Orders.Retreat:
                    #region Retreat Region
                    {

                        if (_isFriend)
                        {
                            xLocation = 0;
                            rotationOnY = -90;
                        }
                        else
                        {
                            xLocation = 300;
                            rotationOnY = 90;
                        }

                        switch (arrayOfNames[1].ToUpper())
                        {
                        case "SCOUT":
                            if (_isFriend)
                                xLocation = xLocation - 100;
                            else xLocation = xLocation + 100;
                            yLocation = yScout;
                            if (_ScoutShips % 2 == 0)
                            {
                                yLocation += ySeparator;
                                zLocation = zSeparator * _zScoutDepth;
                                _zScoutDepth++;
                            }

                            SetShipCounts(arrayOfNames[1].ToUpper(), _isFriend);
                            break;
                        case "DESTROYER":
                            if (_isFriend)
                                xLocation = xLocation - 50;
                            else xLocation = xLocation + 50;
                            yLocation = yDestroyer;
                            if (_DestroyerShips % 2 == 0)
                            {
                                yLocation += ySeparator;
                                zLocation = zSeparator * _zDestroyerDepth;
                                _zDestroyerDepth++;
                            }

                            SetShipCounts(arrayOfNames[1].ToUpper(), _isFriend);
                            break;
                        case "CRUISER":
                        case "LTCRUISER":
                        case "HVYCRUISER":

                            yLocation = yCapital;
                            if (_CapitalShips % 2 == 0)
                            {
                                yLocation += ySeparator;
                                zLocation = zSeparator * _zCapitalDepth;
                                _zCapitalDepth++;
                            }

                            SetShipCounts(arrayOfNames[1].ToUpper(), _isFriend);
                            break;
                        case "TRANSPORT":
                        case "COLONY":
                        case "CONSTRUCTION":
                            if (_isFriend)
                                xLocation += zSeparator;
                            else
                                xLocation -= zSeparator;
                            yLocation = yCapital;
                            if (_UtilityShips % 2 == 0)
                            {
                                yLocation += ySeparator;
                                zLocation = zSeparator * _zUtilityDepth;
                                _zUtilityDepth++;
                            }

                            SetShipCounts(arrayOfNames[1].ToUpper(), _isFriend);
                            break;
                        case "ONEMORE":
                            break;
                        default:
                            break;
                        }
                        GameObject ship = Instantiate(GameManager.PrefabDitionary[preCombatShipNames[i]], new Vector3(xLocation, yLocation, zLocation), Quaternion.identity);
                        GameObject aCameraTarget = Instantiate(cameraEmpty, new Vector3(xLocation, yLocation, zLocation), Quaternion.identity); // camera target where ships are
                        aCameraTarget.transform.Rotate(0, rotationOnY, 0); // match ship rotation
                        ShipScaleAndRotation(ship, rotationOnY);
                        ParentToAnimation(ship, aCameraTarget, _isFriend, CombatOrderSelection.order);
                        PopulateShipData(ship);
                        GameManager.Instance.SetShipLayer(arrayOfNames[0]); // informs GameManager of layer
                        ship.layer = GameManager.Instance.SetShipLayer(arrayOfNames[0].ToUpper()); // sets ship layer

                        combatShips.Add(ship);
                        cameraTargets.Add(aCameraTarget);
                        break;
                    }
                    #endregion Retreat Region

                    case Orders.Formation:
                    #region Formation Region
                    {
                        switch (arrayOfNames[1].ToUpper())
                        {
                            case "SCOUT":
                                yLocation = yScout;
                                if (_ScoutShips % 2 == 0)
                                {
                                    yLocation += ySeparator;
                                    zLocation = zSeparator * _zScoutDepth;
                                    _zScoutDepth++;
                                }
                                SetShipCounts(arrayOfNames[1].ToUpper(), _isFriend);
                                break;
                            case "DESTROYER":
                                yLocation = yDestroyer;
                                if (_DestroyerShips % 2 == 0)
                                {
                                    yLocation += ySeparator;
                                    zLocation = zSeparator * _zDestroyerDepth;
                                    _zDestroyerDepth++;
                                }
                                SetShipCounts(arrayOfNames[1].ToUpper(), _isFriend);
                                break;
                            case "CRUISER":
                            case "LTCRUISER":
                            case "HVYCRUISER":
                                yLocation = yCapital;
                                if (_CapitalShips % 2 == 0)
                                {
                                    yLocation += ySeparator;
                                    zLocation = zSeparator * _zCapitalDepth;
                                    _zCapitalDepth++;
                                }
                                SetShipCounts(arrayOfNames[1].ToUpper(), _isFriend);
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
                                SetShipCounts(arrayOfNames[1].ToUpper(), _isFriend);
                                break;
                            case "ONEMORE":
                                break;
                            default:
                                break;
                        }
                        GameObject ship = Instantiate(GameManager.PrefabDitionary[preCombatShipNames[i]], new Vector3(xLocation, yLocation, zLocation), Quaternion.identity);
                        GameObject aCameraTarget = Instantiate(cameraEmpty, new Vector3(xLocation, yLocation, zLocation), Quaternion.identity); // camera target where ships are
                        aCameraTarget.transform.Rotate(0, rotationOnY, 0); // match ship rotation
                        ShipScaleAndRotation(ship, rotationOnY);
                        ParentToAnimation(ship, aCameraTarget, _isFriend, CombatOrderSelection.order);
                        PopulateShipData(ship);
                        GameManager.Instance.SetShipLayer(arrayOfNames[0]); // informs GameManager of layer
                        ship.layer = GameManager.Instance.SetShipLayer(arrayOfNames[0].ToUpper()); // sets ship layer

                        combatShips.Add(ship);
                        cameraTargets.Add(aCameraTarget);
                        break;
                            
                    }
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
            Dictionary<int, GameObject> localShipObjectDictionary = new Dictionary<int, GameObject>();

            for (int j = 0; j < combatShips.Count; j++)
            {
                localShipObjectDictionary.Add(j, combatShips[j]);
            }
            if (_isFriend)
            {
                GameManager.Instance.ProvideFriendCombatShips(localShipObjectDictionary);
            }
            else GameManager.Instance.ProvideEnemyCombatShips(localShipObjectDictionary);
            combatShips.Clear();
            #endregion
        } // end of pre combat setup methode call for friend or enemy
        private void PopulateShipData(GameObject _ship)
        {
            if (GameManager.ShipDataDictionary.TryGetValue(_ship.name.ToUpper(), out int[] _result))
            {
                _ship.GetComponent<Ship>()._shieldsMaxHealth = _result[0];
                _ship.GetComponent<Ship>()._hullMaxHealth = _result[1];
                _ship.GetComponent<Ship>()._torpedoDamage = _result[2];
                _ship.GetComponent<Ship>()._beamDamage = _result[3];
                _ship.GetComponent<Ship>()._cost = _result[4];
            }
        }
        private void ShipScaleAndRotation(GameObject the_ship, int rotation)
        {
            the_ship.transform.localScale = new Vector3(transform.localScale.x * shipScale,
                transform.localScale.y * shipScale, transform.localScale.z * shipScale);
            the_ship.transform.Rotate(0, rotation, 0);
        }
        public void SetCombatOrder(Orders daOrder)
        {
            order = daOrder;
        }
        private void SetShipCounts(string shipType, bool isFriend)
        {
            if (!isFriend && timesNotFriend == 0)
            {
                timesNotFriend = 1;
            }

            if (timesNotFriend == 1)
            { 
                _ScoutShips = 0;
                _DestroyerShips = 0;
                _CapitalShips = 0;
                _UtilityShips = 0;
                _zScoutDepth = 0;
                _zDestroyerDepth = 0;
                _zCapitalDepth = 0;
                _zUtilityDepth = 0;
                timesNotFriend++;
            }
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
        public List<GameObject> GetCameraTargets()
        {
            return CameraTargetList;
        }
        public void ParentToAnimation(GameObject ship, GameObject cameraEmpty, bool _aFriend, Orders order)
        {
            cameraEmpty.layer = ship.layer;
            //cameraEmpty.transform.SetParent(ship.transform, false); // ship is parent to cameraEmpty and animFriend or animEnemy set as parent of ship below
            switch (order)
            {
                case Orders.Engage:
                #region Engage animation
                {
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
            break;
            #endregion
            case Orders.Rush:
            #region Rush animation
            {
                if (_aFriend)
                {
                    switch (arrayOfNames[1].ToUpper())
                    {
                        case "CRUISER":
                        case "LT-CRUISER":
                        case "HVY-CRISER":
                            animFriendRushScout.layer = ship.layer;
                            ship.transform.SetParent(animFriendRushScout.transform, true);
                            cameraEmpty.transform.SetParent(animFriendRushScout.transform, true);
                            break;
                        case "TRANSPORT":
                        case "COLONY":
                        case "CONSTRUCTION":
                            animFriendRushScout.layer = ship.layer;
                            ship.transform.SetParent(animFriendRushScout.transform, true);
                            cameraEmpty.transform.SetParent(animFriendRushScout.transform, true);
                            break;
                        case "DESTROYER":
                            animFriendRushDistroy.layer = ship.layer;
                            ship.transform.SetParent(animFriendRushDistroy.transform, true);
                            cameraEmpty.transform.SetParent(animFriendRushDistroy.transform, true);
                            break;
                        case "SCOUT":
                            animFriendRushCapital.layer = ship.layer;
                            ship.transform.SetParent(animFriendRushCapital.transform, true);
                            cameraEmpty.transform.SetParent(animFriendRushCapital.transform, true);
                            break;

                        default:
                            animFriendRushCapital.layer = ship.layer;
                            ship.transform.SetParent(animFriendRushCapital.transform, true);
                            cameraEmpty.transform.SetParent(animFriendRushCapital.transform, true);
                            break;
                    }
                }
                else
                {
                    switch (arrayOfNames[1].ToUpper())
                    {
                        case "CRUISER":
                        case "LT-CRUISER":
                        case "HVY-CRISER":
                            animEnemyRushScout.layer = ship.layer;
                            ship.transform.SetParent(animEnemyRushScout.transform, true);
                            cameraEmpty.transform.SetParent(animEnemyRushScout.transform, true);
                            break;
                        case "TRANSPORT":
                        case "COLONY":
                        case "CONSTRUCTION":
                            animEnemyRushScout.layer = ship.layer;
                            ship.transform.SetParent(animEnemyRushScout.transform, true);
                            cameraEmpty.transform.SetParent(animEnemyRushScout.transform, true);
                            break;
                        case "DESTROYER":
                            animEnemyRushDistroy.layer = ship.layer;
                            ship.transform.SetParent(animEnemyRushDistroy.transform, true);
                            cameraEmpty.transform.SetParent(animEnemyRushDistroy.transform, true);
                            break;
                        case "SCOUT":
                            animEnemyRushCapital.layer = ship.layer;
                            ship.transform.SetParent(animEnemyRushCapital.transform, true);
                            cameraEmpty.transform.SetParent(animEnemyRushCapital.transform, true);
                            break;
                        default:
                            animEnemyRushCapital.layer = ship.layer;
                            ship.transform.SetParent(animEnemyRushCapital.transform, true);
                            cameraEmpty.transform.SetParent(animEnemyRushCapital.transform, true);
                            break;
                    }
                }
            }
            break;
            #endregion
            case Orders.Retreat:
            break;
            case Orders.Formation:
            {
            #region Formation animation
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
            break;
            #endregion
            case Orders.ProtectTransports:
                break;
            case Orders.TargetTransports:
                break;
            default:
                break;            
            }
        }
    }
}
