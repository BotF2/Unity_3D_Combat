using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
//using UnityEngine.UI;

namespace Assets.Script
{
    public enum FriendOrFoe
    {
        friend,
        enemy
    }
    public enum NearOrFar
    {
        Near,
        Far
    }
    public enum ShipType
    {
        Scout,
        Destroyer,
        Capital,
        Colony,
        SomethingElse,
        OneMore
    }
    public class GameManager : MonoBehaviour
    {
        public Ship ship;
        public CameraMultiTarget cameraMultiTarget;
        private float shipScale = 5000f;
        private char separator = ';';
        public static Dictionary<string, int[]> ShipDataDictionary = new Dictionary<string, int[]>();

        public GameObject Friend_0; // prefab empty gameobject to clone instantiat into the grids
        public GameObject Enemy_0;
        public int yFactor = 3000; // gap in grid between empties on y axis
        public int zFactor = 3000;
        public int offsetFriendLeft = -5500; // value of x axis for friend grid left side (start here), world location
        public int offsetFriendRight = 5800; // value of x axis for friend grid right side, world location
        public int offsetEnemyRight = 5500; // start here
        public int offsetEnemyLeft = -5800; 

        #region the empties for animation

        public GameObject[] animationEmpties = new GameObject[12]; // { FriendScout_Y0_Z0, 
                                                                   //    FriendDestroyer_Y0_Z1, FriendCapitalShip_Y0_Z2, FriendColony_Y1_Z0, Friend_Y1_Z1, Friend_Y1_Z2, 
                                                                   //    EnemyScout_Y0_Z0, EnemyDestroyer_Y0_Z1, EnemyCapital_Y0_Z2, EnemyColony_Y1_Z0, Enemy_Y1_Z1, Enemy_Y1_Z2 };
                                                                   // Unity does not like c# lists
        #endregion

        #region prefab ships and stations
        public GameObject Borg_Destroyer_i; // prefab ships
        public GameObject Borg_Destroyer_ii;
        public GameObject Borg_Cube_ii;
        public GameObject Borg_Scout_i;

        public GameObject Card_Destroyer_i;
        public GameObject Card_Destroyer_ii;
        public GameObject Card_Cruiser_ii;
        public GameObject Card_Scout_i;
        public GameObject Card_Scout_ii;

        public GameObject Dom_Destroyer_i;
        public GameObject Dom_Destroyer_ii;
        public GameObject Dom_Cruiser_ii;
        public GameObject Dom_Scout_i;
        public GameObject Dom_Scout_ii;

        public GameObject Fed_Cruiser_ii;
        public GameObject Fed_Cruiser_iii;
        public GameObject Fed_lt_Cruiser_iv;
        public GameObject Fed_hvy_Cruiser_iv;
        public GameObject Fed_Destroyer_i;
        public GameObject Fed_Destroyer_ii;
        public GameObject Fed_Destroyer_iii;
        public GameObject Fed_Destroyer_iv;
        public GameObject Fed_Scout_i;
        public GameObject Fed_Scout_ii;
        public GameObject Fed_Scout_iii;
        public GameObject Fed_Scout_iv;

        public GameObject Kling_Cruiser_ii;
        public GameObject Kling_Destroyer_i;
        public GameObject Kling_Destroyer_ii;
        public GameObject Kling_Scout_i;
        public GameObject Kling_Scout_ii;

        public GameObject Rom_Destroyer_i;
        public GameObject Rom_Destroyer_ii;
        public GameObject Rom_Cruiser_ii;
        public GameObject Rom_Cruiser_iii;
        public GameObject Rom_Scout_i;
        public GameObject Rom_Scout_ii;
        public GameObject Rom_Scout_iii;
        #endregion

        #region Animation empties by ship type
        public GameObject FriendScout_Y0_Z0;
        public GameObject FriendDestroyer_Y0_Z1;
        public GameObject FriendCapital_Y0_Z2;
        public GameObject FriendColony_Y1_Z0;
        public GameObject Friend_Y1_Z1;
        public GameObject Friend_Y1_Z2;
        public GameObject EnemyScout_Y0_Z0;
        public GameObject EnemyDestroyer_Y0_Z1;
        public GameObject EnemyCapital_Y0_Z2;
        public GameObject EnemyColony_Y1_Z0;
        public GameObject Enemy_Y1_Z1;
        public GameObject Enemy_Y1_Z2;
        #endregion

        // ToDo created this in galactic game level from combat ships and stations in the combat sector
        public static string[] FriendNameArray; // = new string[] { "Fed_Cruiser_ii", "Fed_Cruiser_ii", "Fed_Destroyer_ii" };
        public static string[] EnemyNameArray; //= new string[] { "Kling_Cruiser_ii", "Kling_Cruiser_ii", "Kling_Scout_ii", "Kling_Scout_ii" };
        public int friends;
        public int enemies;
        public static Dictionary<int, GameObject> FriendShips = new Dictionary<int, GameObject>();  // { { 500, Friend_0 } };
        public static Dictionary<int, GameObject> EnemyShips = new Dictionary<int, GameObject>();  // { { 500, Enemy_0 } };

        private int friendShipLayer;
        private int enemyShipLayer;

        public GameObject panelMenu;
        public GameObject panelPlay;
        public GameObject panelCompleted;
        public GameObject panelGameOver;
        //public GameObject[] levels;

        private GameObject[] _friendScouts;
        private GameObject[] _friendFarScouts;
        private GameObject[] _friendDestroyer;
        private GameObject[] _friendFarDestroyer;
        private GameObject[] _friendCapital;
        private GameObject[] _friendFarCapital;
        private GameObject[] _friendColony;
        private GameObject[] _friendFarColony;

        private GameObject[] _enemyScouts;
        private GameObject[] _enemyFarScouts;
        private GameObject[] _enemyDestroyer;
        private GameObject[] _enemyFarDestroyer;
        private GameObject[] _enemyCapital;
        private GameObject[] _enemyFarCapital;
        private GameObject[] _enemyColony;
        private GameObject[] _enemyFarColony;
        public Dictionary<GameObject, GameObject[]> _shipTargetDictionary;

        public static GameManager Instance { get; private set; } // a static singleton, no other script can instatniate a GameManager, must us the singleton

        //List<Tuple<CombatUnit, CombatWeapon[]>> // will we need to us this here too?
        public enum State { MAIN_MENU, MAIN_INIT, GALACTIC_PLAY, MENU, INIT, PLAY_3D, COMPLETED, LOADNEXT, GAMEOVER };
        private State _state;

        private int _level;

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        bool _isSwitchingState;

        public bool _statePasedInit = false;
       // public bool StatePassedInit { get { return _statePassedInit; } set { _statePassedInit = value; } }

        public void PlayClicked()
        {
            SwitchtState(State.INIT);
        }
        private void Awake()
        {
            Instance = this; // static reference to single GameManager
        }

        // Start is called before the first frame update
        void Start()
        {
            SwitchtState(State.MENU);
            LoadShipData(Environment.CurrentDirectory + "\\Assets\\" + "ShipData.txt");
        }

        public void SwitchtState(State newState, float delay = 0)
        {
            StartCoroutine(SwitchDelay(newState, delay));
            Instance = this;
            EndState();
            BeginState(newState);
        }
        IEnumerator SwitchDelay(State newState, float delay)
        {
            _isSwitchingState = true;
            yield return new WaitForSeconds(delay);
            EndState();
            _state = newState;
            BeginState(newState);
            _isSwitchingState = false;
        }

        void BeginState(State newState)
        {
            switch (newState)
            {
                case State.MENU:
                    //panelPlay.SetActive(false);
                    panelMenu.SetActive(true);
                    break;
                case State.INIT:
                    panelPlay.SetActive(true);
                    //Score = 0;
                    _statePasedInit = true;
                    SwitchtState(State.LOADNEXT);
                    break;
                case State.PLAY_3D:
                    _statePasedInit = true;
                    break;
                case State.COMPLETED:
                    panelPlay.SetActive(true);
                    panelCompleted.SetActive(true);
                    break;
                case State.LOADNEXT:
                    // no levels to load
                    SwitchtState(State.PLAY_3D);
                    break;
                case State.GAMEOVER:
                    panelGameOver.SetActive(true);
                    break;
                default:
                    break;
            }
        }

        // Update is called once per frame
        void Update()
        {
            switch (_state)
            {
                case State.MENU:
                    break;
                case State.INIT:
                    _statePasedInit = true;
                    break;
                case State.PLAY_3D:
                    _statePasedInit = true;
                    break;
                case State.COMPLETED:
                    break;
                case State.LOADNEXT:
                    break;
                case State.GAMEOVER:
                    _statePasedInit = false;
                    break;
                default:
                    break;
            }
        }
        void EndState()
        {
            switch (_state)
            {
                case State.MENU:
                    panelMenu.SetActive(false);                   
                    break;
                case State.INIT:
                    break;
                case State.PLAY_3D:
                    break;
                case State.COMPLETED:
                    panelCompleted.SetActive(false);
                    break;
                case State.LOADNEXT:
                    break;
                case State.GAMEOVER:
                    panelPlay.SetActive(false);
                    panelGameOver.SetActive(false);
                    break;
                default:
                    break;
            }
        }
        public void SetShipLayer(string civ, FriendOrFoe who)
        {
            switch (civ)
            {
                case "FED":
                    {
                        if (who == FriendOrFoe.friend)
                            friendShipLayer = 10;
                        else
                            enemyShipLayer = 10;
                        break;
                    }
                case "TERRAN":
                    {
                        if (who == FriendOrFoe.friend)
                            friendShipLayer = 11;
                        else
                            enemyShipLayer = 11;
                        break;
                    }
                case "ROM":
                    {
                        if (who == FriendOrFoe.friend)
                            friendShipLayer = 12;
                        else
                            enemyShipLayer = 12;
                        break;
                    }
                case "KLING":
                    {
                        if (who == FriendOrFoe.friend)
                            friendShipLayer = 13;
                        else
                            enemyShipLayer = 13;
                        break;
                    }
                case "CARD":
                    {
                        if (who == FriendOrFoe.friend)
                            friendShipLayer = 14;
                        else
                            enemyShipLayer = 14;
                        break;
                    }
                case "DOM":
                    {
                        if (who == FriendOrFoe.friend)
                            friendShipLayer = 15;
                        else
                            enemyShipLayer = 15;
                        break;
                    }
                case "BORG":
                    {
                        if (who == FriendOrFoe.friend)
                            friendShipLayer = 16;
                        else
                            enemyShipLayer = 16;
                        break;
                    }
                default:
                    break;
            }
        }

        private GameObject GetAnimatorEmpty(GameObject _temp, FriendOrFoe who)
        {
            int shipTypeIncrement = 0;
            int enemyIncrement = 0;
            if (who == FriendOrFoe.enemy)
                enemyIncrement = 6;
            string readName = _temp.name.ToUpper();
            string[] _nameParts = readName.Split('_');
            string shipType = _nameParts[1];
            switch (shipType)
            {
                case "SCOUT":
                    shipTypeIncrement = 0;
                    break;
                case "DESTROYER":
                    shipTypeIncrement = 1;
                    break;
                case "CRUISER":
                case "LT-CRUISER":
                case "HVY-CRISER":
                    shipTypeIncrement = 2;
                    break;
                case "COLONY":
                    shipTypeIncrement = 3;
                    break;
                //case "more ship types here":
                //    shipIncrement = 0;
                //    break;
                default:
                    break;
            }
            return animationEmpties[shipTypeIncrement + enemyIncrement];
        }
        private GameObject[] GetRoeByShipType(string shipName, FriendOrFoe side, NearOrFar nearOrFar)
        {
            string[] _nameParts = shipName.ToUpper().Split('_');
            string shipType = _nameParts[1];
            switch (shipType)
            {
                case "SCOUT":
                    if (side == FriendOrFoe.friend)
                        if (nearOrFar == NearOrFar.Near)
                            return _friendScouts;
                        else return _friendFarScouts;
                    else if (nearOrFar == NearOrFar.Near)
                        return _enemyScouts;
                    else return _enemyFarScouts;
                case "DESTROYER":
                    if (side == FriendOrFoe.friend)
                        if (nearOrFar == NearOrFar.Near)
                            return _friendDestroyer;
                        else return _friendFarDestroyer;
                    else if (nearOrFar == NearOrFar.Near)
                        return _enemyDestroyer;
                    else return _enemyFarDestroyer;
                case "CRUISER":
                case "LT-CRUISER":
                case "HVY-CRISER":
                    if (side == FriendOrFoe.friend)
                        if (nearOrFar == NearOrFar.Near)
                            return _friendCapital;
                        else return _friendFarCapital;
                    else if (nearOrFar == NearOrFar.Near)
                        return _enemyCapital;
                    else return _enemyFarCapital;
                //case "COLONY":
                //    return ShipType.Colony;
                //case "more ship types here":
                default:
                    if (side == FriendOrFoe.friend)
                        if (nearOrFar == NearOrFar.Near)
                            return _friendScouts;
                        else return _friendFarScouts;
                    else if (nearOrFar == NearOrFar.Near)
                        return _enemyScouts;
                    else return _enemyFarScouts;
            }

        }
        private void UpdateTheArrays(string shipName, List<GameObject> shortList, FriendOrFoe side, NearOrFar nearOrFar)
        {
            string[] _nameParts = shipName.ToUpper().Split('_');
            string shipType = _nameParts[1];
            switch (shipType)
            {
                case "SCOUT":
                    if (side == FriendOrFoe.friend)
                        if (nearOrFar == NearOrFar.Near)
                            _friendScouts = shortList.ToArray();
                        else _friendFarScouts = shortList.ToArray();
                    else if (nearOrFar == NearOrFar.Near)
                        _enemyScouts = shortList.ToArray();
                    else _enemyFarScouts = shortList.ToArray();
                    break;
                case "DESTROYER":
                    if (side == FriendOrFoe.friend)
                        if (nearOrFar == NearOrFar.Near)
                            _friendDestroyer = shortList.ToArray();
                        else _friendFarDestroyer = shortList.ToArray();
                    else if (nearOrFar == NearOrFar.Near)
                        _enemyDestroyer = shortList.ToArray();
                    else _enemyFarDestroyer = shortList.ToArray();
                    break;
                case "CRUISER":
                case "LT-CRUISER":
                case "HVY-CRISER":
                    if (side == FriendOrFoe.friend)
                        if (nearOrFar == NearOrFar.Near)
                            _friendCapital = shortList.ToArray();
                        else _friendFarCapital = shortList.ToArray();
                    else if (nearOrFar == NearOrFar.Near)
                        _enemyCapital = shortList.ToArray();
                    else _enemyFarCapital = shortList.ToArray();
                    break;
                //case "COLONY":
                //    return ShipType.Colony;
                //case "more ship types here":
                default:
                    break;
            }
        }   

        private void RotateFriend(GameObject who)
        {
            who.transform.Rotate(0, 90, 0);
        }
        private void RotateEnemy(GameObject who)
        {
            who.transform.Rotate(0, -90, 0);
        }

        public bool AreWeFriends(GameObject who)
        {
            return FriendShips.ContainsValue(who);
        }

        public Transform GetShipTravelTarget(GameObject aShip)
        {
            return aShip.transform;
        }

        public void LoadShipData(string filename) // List<sting>
        {
            GameObject[] localAnimationEmpties = new GameObject[12] { FriendScout_Y0_Z0,
            FriendDestroyer_Y0_Z1, FriendCapital_Y0_Z2, FriendColony_Y1_Z0, Friend_Y1_Z1, Friend_Y1_Z2,
            EnemyScout_Y0_Z0, EnemyDestroyer_Y0_Z1, EnemyCapital_Y0_Z2, EnemyColony_Y1_Z0, Enemy_Y1_Z1, Enemy_Y1_Z2 };
            animationEmpties = localAnimationEmpties;

            Dictionary<string, GameObject> prefabDitionary = new Dictionary<string, GameObject>() // !! only try to load prefabs that exist
            {
                { "FED_DESTROYER_I", Fed_Destroyer_i }, //{ "FED_SCOUT_I", Fed_Scout_i },
                { "FED_CRUISER_II", Fed_Cruiser_ii }, { "FED_DESTROYER_II", Fed_Destroyer_ii }, // { "FED_SCOUT_II", Fed_Scout_ii },
                { "FED_CRUISER_III", Fed_Cruiser_iii }, //{ "FED_DESTROYER_III", Fed_Destroyer_iii }, { "FED_SCOUT_III", Fed_Scout_iii },
                { "KLING_DESTROYER_I", Kling_Destroyer_i},
                { "KLING_CRUISER_II", Kling_Cruiser_ii }, { "KLING_SCOUT_II", Kling_Scout_ii },
                { "CARD_SCOUT_I", Card_Scout_i },
                { "ROM_SCOUT_III", Rom_Scout_iii },
                { "ROM_CRUISER_II", Rom_Cruiser_ii }, { "ROM_CRUISER_III", Rom_Cruiser_iii }
            };
            #region Ships to load for Combat

            string[] _friendNameArray = new string[] { "FED_CRUISER_II", "FED_CRUISER_III", "FED_DESTROYER_II", "FED_DESTROYER_II", "FED_DESTROYER_I" };
            FriendNameArray = _friendNameArray;
            string[] _enemyNameArray = new string[] { "KLING_DESTROYER_I", "CARD_SCOUT_I", "KLING_CRUISER_II", "KLING_SCOUT_II", "ROM_CRUISER_III", "ROM_CRUISER_II", "ROM_SCOUT_III" }; //"KLING_DESTROYER_I",
            EnemyNameArray = _enemyNameArray;
            #endregion

            //int yFactor = 3000;
            //int zFactor = 3500;
            //int xFactorFriend = -3500;

            #region Grid roes for Friends
            GameObject _scoutNearFriend = Instantiate(Friend_0, new Vector3(offsetFriendLeft, 0, 0), Quaternion.identity);
            RotateFriend(_scoutNearFriend);
            List<GameObject> emptyFriendScouts = new List<GameObject>() { _scoutNearFriend };
            GameObject _scoutFarFriend = Instantiate(Friend_0, new Vector3(offsetFriendRight, 0, 0), Quaternion.identity);
            //RotateFriend(_scoutFarFriend);
            List<GameObject> emptyFriendFarScouts = new List<GameObject>() { _scoutFarFriend };
            for (int i = 1; i < 21; i++)
            {
                GameObject _tempStartScout = Instantiate(Friend_0, new Vector3(offsetFriendLeft, 0, zFactor * i), Quaternion.identity);
                RotateFriend(_tempStartScout);
                emptyFriendScouts.Add(_tempStartScout); // add to list of friend empty the next scout start points 
                GameObject _tempFarScout = Instantiate(Friend_0, new Vector3(offsetFriendRight, 0, zFactor * i), Quaternion.identity);
               //   RotateFriend(_tempFarScout);
                emptyFriendFarScouts.Add(_tempFarScout); // add to list of friend empty the next scout FAR points 
            }
            _friendScouts = emptyFriendScouts.ToArray();
            _friendFarScouts = emptyFriendFarScouts.ToArray();

            GameObject _capitalNearFriend = Instantiate(Friend_0, new Vector3(offsetFriendLeft, yFactor * 1, 0), Quaternion.identity);
            RotateFriend(_capitalNearFriend);
            List<GameObject> emptyFriendCapital = new List<GameObject>() { _capitalNearFriend };
            GameObject _capitalFarFriend = Instantiate(Friend_0, new Vector3(offsetFriendRight, yFactor * 1, 0), Quaternion.identity);
            //RotateFriend(_capitalFarFriend);
            List<GameObject> emptyFriendFarCapital = new List<GameObject>() { _capitalFarFriend };
            for (int i = 1; i < 21; i++)
            {
                GameObject _tempStartCapital = Instantiate(Friend_0, new Vector3(offsetFriendLeft, yFactor * 1, zFactor * i), Quaternion.identity);
                RotateFriend(_tempStartCapital);
                emptyFriendCapital.Add(_tempStartCapital); // list of friend empty capital start points
                GameObject _tempFarCapital = Instantiate(Friend_0, new Vector3(offsetFriendRight, yFactor * 1, zFactor * i), Quaternion.identity);
                //RotateFriend(_tempFarCapital);
                emptyFriendFarCapital.Add(_tempFarCapital); 
            }
            _friendCapital = emptyFriendCapital.ToArray();
            _friendFarCapital = emptyFriendFarCapital.ToArray();

            GameObject _destroyerNearFriend = Instantiate(Friend_0, new Vector3(offsetFriendLeft, yFactor * 2, 0), Quaternion.identity);
            RotateFriend(_destroyerNearFriend);
            List<GameObject> emptyFriendDestroyers = new List<GameObject>() { _destroyerNearFriend };
            GameObject _destroyerFarFriend = Instantiate(Friend_0, new Vector3(offsetFriendRight, yFactor * 2, 0), Quaternion.identity);
            //RotateFriend(_destroyerFarFriend);
            List<GameObject> emptyFriendFarDestroyers = new List<GameObject>() { _destroyerFarFriend };
            for (int i = 1; i < 21; i++)
            {
                GameObject _tempStartDestroyers = Instantiate(Friend_0, new Vector3(offsetFriendLeft, yFactor * 2, zFactor * i), Quaternion.identity);
                RotateFriend(_tempStartDestroyers);
                emptyFriendDestroyers.Add(_tempStartDestroyers); // list of friend empty destroyer start point
                GameObject _tempFarDestroyers = Instantiate(Friend_0, new Vector3(offsetFriendRight, yFactor * 2, zFactor * i), Quaternion.identity);
                //RotateFriend(_tempFarDestroyers);
                emptyFriendFarDestroyers.Add(_tempFarDestroyers); // list of friend empty destroyer start point
            }
            _friendDestroyer = emptyFriendDestroyers.ToArray();
            _friendFarDestroyer = emptyFriendFarDestroyers.ToArray();
            #endregion

            #region Grid roes for Enemies

            GameObject _scoutNearEnemy = Instantiate(Enemy_0, new Vector3(offsetEnemyRight, yFactor * 0, 1500), Quaternion.identity);
            RotateEnemy(_scoutNearEnemy);
            List<GameObject> emptyEnemyScouts = new List<GameObject>() { _scoutNearEnemy };
            GameObject _scoutFarEnemy = Instantiate(Enemy_0, new Vector3(offsetEnemyLeft, yFactor * 0, 1500), Quaternion.identity);
            //RotateEnemy(_scoutFarEnemy);
            List<GameObject> emptyEnemyFarScouts = new List<GameObject>() { _scoutFarEnemy };
            for (int i = 1; i < 21; i++)
            {
                GameObject _tempNearScout = Instantiate(Enemy_0, new Vector3(offsetEnemyRight, 0, (zFactor * i + 1500)), Quaternion.identity);
                RotateEnemy(_tempNearScout);
                emptyEnemyScouts.Add(_tempNearScout);
                GameObject _tempFarScout = Instantiate(Enemy_0, new Vector3(offsetEnemyLeft, 0, (zFactor * i + 1500)), Quaternion.identity);
                //RotateEnemy(_tempFarScout);
                emptyEnemyFarScouts.Add(_tempFarScout);
            } 
            _enemyScouts = emptyEnemyScouts.ToArray();
            _enemyFarScouts = emptyEnemyFarScouts.ToArray();

            GameObject _capitalNearEnemy = Instantiate(Enemy_0, new Vector3(offsetEnemyRight, yFactor * 1, 1500), Quaternion.identity);
            RotateEnemy(_capitalNearEnemy);
            List<GameObject> emptyEnemyCapital = new List<GameObject>() { _capitalNearEnemy };
            GameObject _capitalFarEnemy = Instantiate(Enemy_0, new Vector3(offsetEnemyLeft, yFactor * 1, 1500), Quaternion.identity);
            //RotateEnemy(_capitalFarEnemy);
            List<GameObject> emptyEnemyFarCapital = new List<GameObject>() { _capitalFarEnemy };
            for (int i = 1; i < 21; i++)
            {
                GameObject _tempNearCapital = Instantiate(Enemy_0, new Vector3(offsetEnemyRight, yFactor * 1, (zFactor * i + 1500)), Quaternion.identity);
                RotateEnemy(_tempNearCapital);
                emptyEnemyCapital.Add(_tempNearCapital);
                GameObject _tempFarCapital = Instantiate(Enemy_0, new Vector3(offsetEnemyLeft, yFactor * 1, (zFactor * i + 1500)), Quaternion.identity);
                //RotateEnemy(_tempFarCapital);
                emptyEnemyFarCapital.Add(_tempFarCapital);

            }
            _enemyCapital = emptyEnemyCapital.ToArray();
            _enemyFarCapital = emptyEnemyFarCapital.ToArray();

            GameObject _destroyerNearEnemy = Instantiate(Enemy_0, new Vector3(offsetEnemyRight, yFactor * 2, 1500), Quaternion.identity);
            RotateEnemy(_destroyerNearEnemy);
            List<GameObject> emptyEnemyDestroyers = new List<GameObject>() { _destroyerNearEnemy };
            GameObject _destroyerFarEnemy = Instantiate(Enemy_0, new Vector3(offsetEnemyLeft, yFactor * 2, 1500), Quaternion.identity);
            //RotateEnemy(_destroyerFarEnemy);
            List<GameObject> emptyEnemyFarDestroyers = new List<GameObject>() { _destroyerFarEnemy };
            for (int i = 1; i < 21; i++)
            {
                GameObject _tempNearDestroyers = Instantiate(Enemy_0, new Vector3(offsetEnemyRight, yFactor * 2, (zFactor * i + 1500)), Quaternion.identity);
                RotateEnemy(_tempNearDestroyers);
                emptyEnemyDestroyers.Add(_tempNearDestroyers);
                GameObject _tempFarDestroyers = Instantiate(Enemy_0, new Vector3(offsetEnemyLeft, yFactor * 2, (zFactor * i + 1500)), Quaternion.identity);
               // RotateEnemy(_tempFarDestroyers);
                emptyEnemyFarDestroyers.Add(_tempFarDestroyers);

            }
            _enemyDestroyer = emptyEnemyDestroyers.ToArray();
            _enemyFarDestroyer = emptyEnemyFarDestroyers.ToArray();
            

            #endregion

            // Do ship layers
            string readFriendName = _friendNameArray[0].ToUpper();
            string[] _collFriend = readFriendName.Split('_');
            SetShipLayer(_collFriend[0], FriendOrFoe.friend);

            string readEnemyName = _enemyNameArray[0].ToUpper();
            string[] _collEnemy = readEnemyName.Split('_');
            SetShipLayer(_collEnemy[0], FriendOrFoe.enemy);

            Dictionary<string, int[]> _shipDataDictionary = new Dictionary<string, int[]>();

            #region Read ShipData.txt 

            var file = new FileStream(filename, FileMode.Open, FileAccess.Read);

            var _dataPoints = new List<string>();
            using (var reader = new StreamReader(file))
            {
                //Note1("string", int, int, int, int, int"---------------  reading __to_PLZ_DB.txt (from file)");
                //string infotext = "---------------  reading __to_PLZ_DB.txt (from file)";
                //Console.WriteLine(infotext);

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                        continue;
                    _dataPoints.Add(line.Trim());
                    //int[] _shipInts = new int[4];
                    if (line.Length > 0)
                    {
                        var coll = line.Split(separator);

                        _ = int.TryParse(coll[1], out int currentValueOne);
                        _ = int.TryParse(coll[2], out int currentValueTwo);
                        _ = int.TryParse(coll[3], out int currentValueThree);
                        _ = int.TryParse(coll[4], out int currentValueFour);
                        _ = int.TryParse(coll[5], out int currentValueFive);
                        int[] shipDataArray = new int[] { currentValueOne, currentValueTwo, currentValueThree, currentValueFour, currentValueFive };

                        _shipDataDictionary.Add(coll[0].ToString(), shipDataArray);
                        //_shipInts.Clear();
                    }
                }

                reader.Close();
                ShipDataDictionary = _shipDataDictionary;
                //StaticStuff staticStuffToLoad = new StaticStuff();
                //staticStuffToLoad.LoadStaticShipData(_shipDataDictionary);
            }
            #endregion

            #region Instantiate Prefab Friend Ships
            //instantiate prefab ships using friendNameArray to prefab Dictionary onto as many empties in grids 
            Dictionary<int, GameObject> _friendsLocal = new Dictionary<int, GameObject>();
            var cameraTargets = new List<GameObject>();
            //var friendNearTargets = new List<GameObject>();
            Dictionary<GameObject, GameObject[]> localShipTargetDictionary = new Dictionary<GameObject, GameObject[]>();

            for (int i = 0; i < _friendNameArray.Count(); i++)
            {
                GameObject[] resetFriendArray = GetRoeByShipType(_friendNameArray[i], FriendOrFoe.friend, NearOrFar.Near);  
                GameObject _tempPrefabFriend = (GameObject)Instantiate(prefabDitionary[_friendNameArray[i]], resetFriendArray[0].transform.position, resetFriendArray[0].transform.rotation);
                GameObject newEmptyCameraTarget = (GameObject)Instantiate(resetFriendArray[0], resetFriendArray[0].transform.position, resetFriendArray[0].transform.rotation);
                GameObject[] resetFriendFarArray = GetRoeByShipType(_friendNameArray[i], FriendOrFoe.friend, NearOrFar.Far);
               // GameObject newEmptyFriendFarTarget = (GameObject)Instantiate(resetFriendFarArray[0], resetFriendFarArray[0].transform.position, resetFriendFarArray[0].transform.rotation);
                GameObject noAnimationNearFTarget = (GameObject)Instantiate( new GameObject(), resetFriendArray[0].transform.position, resetFriendArray[0].transform.rotation);
                GameObject noAnimationFarFTarget = (GameObject)Instantiate(new GameObject(), resetFriendFarArray[0].transform.position, resetFriendFarArray[0].transform.rotation);
                localShipTargetDictionary.Add(_tempPrefabFriend, new GameObject[] { noAnimationNearFTarget, noAnimationFarFTarget });

                newEmptyCameraTarget.transform.SetParent(resetFriendArray[0].transform, true);
                cameraTargets.Add(newEmptyCameraTarget);
                _tempPrefabFriend.transform.localScale = new Vector3(transform.localScale.x * shipScale, transform.localScale.y * shipScale, transform.localScale.z * shipScale);
                _tempPrefabFriend.transform.SetParent(resetFriendArray[0].transform, true);
                _friendsLocal.Add(i, _tempPrefabFriend);
                GameObject animationEmtpy = GetAnimatorEmpty(_tempPrefabFriend, FriendOrFoe.friend);
                resetFriendArray[0].transform.SetParent(animationEmtpy.transform, true);

                List<GameObject> resetingAList = resetFriendArray.ToList();
                List<GameObject> resetingFarList = resetFriendFarArray.ToList();
                resetingAList.Remove(resetingAList[0]);
                resetingFarList.Remove(resetingFarList[0]);
                UpdateTheArrays(_friendNameArray[i], resetingAList, FriendOrFoe.friend, NearOrFar.Near); // rebuild Array Lists
                UpdateTheArrays(_friendNameArray[i], resetingFarList, FriendOrFoe.friend, NearOrFar.Far); // rebuild Array Lists

                Ship.SetLayerRecursively(animationEmtpy, friendShipLayer);

                if (_shipDataDictionary.TryGetValue(_tempPrefabFriend.name.ToUpper(), out int[] _result))
                {
                    _tempPrefabFriend.GetComponent<Ship>()._shieldsMaxHealth = _result[0];
                    _tempPrefabFriend.GetComponent<Ship>()._hullMaxHealth = _result[1];
                    _tempPrefabFriend.GetComponent<Ship>()._torpedoDamage = _result[2];
                    _tempPrefabFriend.GetComponent<Ship>()._beamDamage = _result[3];
                    _tempPrefabFriend.GetComponent<Ship>()._cost = _result[4];
                }
            }
            FriendShips = _friendsLocal;
            //ship.SetFriendTargets(friendTargetDictionary);

            #endregion

            #region Instantiate Prefab Enemy Ships
            Dictionary<int, GameObject> _enemysLocal = new Dictionary<int, GameObject>();
            //var enemyNearTargets = new List<GameObject>();

            for (int i = 0; i < _enemyNameArray.Count(); i++)
               {
                GameObject[] resetEnemyArray = GetRoeByShipType(_enemyNameArray[i], FriendOrFoe.enemy, NearOrFar.Near);
                GameObject _tempPrefabEnemy = (GameObject)Instantiate(prefabDitionary[_enemyNameArray[i]], resetEnemyArray[0].transform.position, resetEnemyArray[0].transform.rotation);
                GameObject anEmptyCameraTarget = (GameObject)Instantiate(resetEnemyArray[0], resetEnemyArray[0].transform.position, resetEnemyArray[0].transform.rotation);
                GameObject[] resetEnemyFarArray = GetRoeByShipType(_enemyNameArray[i], FriendOrFoe.enemy, NearOrFar.Far);
               // GameObject newEmptyEnemyFarTarget = (GameObject)Instantiate(resetEnemyFarArray[0], resetEnemyFarArray[0].transform.position, resetEnemyFarArray[0].transform.rotation);
                GameObject noAnimationNearETarget = (GameObject)Instantiate(new GameObject(), resetEnemyArray[0].transform.position, resetEnemyArray[0].transform.rotation);
                GameObject noAnimationFarETarget = (GameObject)Instantiate(new GameObject(), resetEnemyFarArray[0].transform.position, resetEnemyFarArray[0].transform.rotation);
                localShipTargetDictionary.Add(_tempPrefabEnemy, new GameObject[] { noAnimationNearETarget, noAnimationFarETarget  });

                anEmptyCameraTarget.transform.SetParent(resetEnemyArray[0].transform, true);
                cameraTargets.Add(anEmptyCameraTarget);
                _tempPrefabEnemy.transform.localScale = new Vector3(transform.localScale.x * shipScale, transform.localScale.y * shipScale, transform.localScale.z * shipScale);
                _tempPrefabEnemy.transform.SetParent(resetEnemyArray[0].transform, true);
                _enemysLocal.Add(i, _tempPrefabEnemy);
                GameObject animationEmtpy = GetAnimatorEmpty(_tempPrefabEnemy, FriendOrFoe.enemy);
                resetEnemyArray[0].transform.SetParent(animationEmtpy.transform, true);

                List<GameObject> resetingList = resetEnemyArray.ToList();
                List<GameObject> resetingFarList = resetEnemyFarArray.ToList();
                resetingList.Remove(resetingList[0]);
                resetingFarList.Remove(resetingFarList[0]);
                UpdateTheArrays(_enemyNameArray[i], resetingList, FriendOrFoe.enemy, NearOrFar.Near);
                UpdateTheArrays(_enemyNameArray[i], resetingFarList, FriendOrFoe.enemy, NearOrFar.Far);

                Ship.SetLayerRecursively(animationEmtpy, enemyShipLayer);

                if (_shipDataDictionary.TryGetValue(_tempPrefabEnemy.name.ToUpper(), out int[] _result))
                {
                    _tempPrefabEnemy.GetComponent<Ship>()._shieldsMaxHealth = _result[0];
                    _tempPrefabEnemy.GetComponent<Ship>()._hullMaxHealth = _result[1];
                    _tempPrefabEnemy.GetComponent<Ship>()._torpedoDamage = _result[2];
                    _tempPrefabEnemy.GetComponent<Ship>()._beamDamage = _result[3];
                    _tempPrefabEnemy.GetComponent<Ship>()._cost = _result[4];
                }
            }
            EnemyShips = _enemysLocal;
            _shipTargetDictionary = localShipTargetDictionary;

            #endregion

            cameraMultiTarget.SetTargets(cameraTargets.ToArray());

            friends = FriendNameArray.Count();
            enemies = EnemyNameArray.Count();
      
            //StaticStuff.LoadStaticEnemyDictionary(EnemyShips);   
        }
        public Dictionary<GameObject,GameObject[]> GetShipTravelTargets()
        {
            return _shipTargetDictionary;
        }
    }
}