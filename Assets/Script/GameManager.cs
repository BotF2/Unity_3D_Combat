using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using MLAPI;
using UnityEngine.UI;
//using UnityEngine.UI;

namespace Assets.Script
{
    public enum Civilization    {
        Fed,
        Terran,
        Rom,
        Kling,
        Card,
        Dom,
        Borg
    }
    public enum HomeSystem
    {
        SOL,
        TERRA,
        ROMULUS,
        KRONOS,
        CARDASSIA,
        OMARIAN_NEBULA,
        DELTA_PRIME
    }
    public enum TechLevel
    {
        Early,
        Developed,
        Advanced,
        Supreme,
    }
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
        Transport,
        Colony,
        OneMore
    }
    public enum Orders
    {
        Engage,
        Rush,
        Retreat,
        Formation,
        ProtectTransports,
        TargetTransports
    }
    public class GameManager : NetworkBehaviour
    {
        public bool _weAreFriend = false;
        public static bool _isSinglePlayer = true;
        public Civilization _localPlayer;
        public Civilization _hostPlayer;
        public Civilization _cliantZero;
        public Civilization _cliantOne;
        public Civilization _cliantTwo;
        public Civilization _cliantThree;
        public Civilization _cliantFour;
        public Civilization _cliantFive;   
        public static TechLevel _techLevel;
        public Orders _combatOrder;
        private GameObject[] _cameraTargets;
        public static Dictionary<int, GameObject> CombatObjects = new Dictionary<int, GameObject>();

        public Ship ship;
        public CameraMultiTarget cameraMultiTarget;
        public InstantiateCombatShips instantiateCombatShips;
        public ActOnCombatOrder actOnCombatOrder;
        public ZoomCamera zoomCamera;
        public CombatOrderSelection combatOrderSelection;

        public float shipScale = 2000f; // old LoadCombatData Combat
        private char separator = ',';
        public static Dictionary<string, int[]> ShipDataDictionary = new Dictionary<string, int[]>();
        public GameObject animFriend1;
        public GameObject animFriend2;
        public GameObject animFriend3;
        public GameObject animEnemy1;
        public GameObject animEnemy2;
        public GameObject animEnemy3;

        public static GameObject Friend_0; // prefab empty gameobject to clone instantiat into the grids
        public static GameObject Enemy_0;
        public int yFactor = 3000; // old LoadCombatData combat, gap in grid between empties on y axis
        public int zFactor = 3000;
        public int offsetFriendLeft = -5500; // value of x axis for friend grid left side (start here), world location
        public int offsetFriendRight = 5800; // value of x axis for friend grid right side, world location
        public int offsetEnemyRight = 5500; // start here
        public int offsetEnemyLeft = -5800;

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
        public GameObject Fed_LtCruiser_iv;
        public GameObject Fed_HvyCruiser_iv;
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

        public static Dictionary<string, GameObject> PrefabDitionary;
        #endregion

        #region Animation empties by ship type Now from ActOnCombatOrder.cs?
        //public GameObject FriendScout_Y0_Z0;
        //public GameObject FriendDestroyer_Y0_Z1;
        //public GameObject FriendCapital_Y0_Z2;
        //public GameObject FriendColony_Y1_Z0;
        //public GameObject Friend_Y1_Z1;
        //public GameObject Friend_Y1_Z2;
        //public GameObject EnemyScout_Y0_Z0;
        //public GameObject EnemyDestroyer_Y0_Z1;
        //public GameObject EnemyCapital_Y0_Z2;
        //public GameObject EnemyColony_Y1_Z0;
        //public GameObject Enemy_Y1_Z1;
        //public GameObject Enemy_Y1_Z2;

        public GameObject[] animationEmpties = new GameObject[12]; // Populated in Unity Hierarchy under Combat for animation empty objexts
                                                                   // { FriendScout_Y0_Z0, 
                                                                   //    FriendDestroyer_Y0_Z1, FriendCapitalShip_Y0_Z2, FriendColony_Y1_Z0, Friend_Y1_Z1, Friend_Y1_Z2, 
                                                                   //    EnemyScout_Y0_Z0, EnemyDestroyer_Y0_Z1, EnemyCapital_Y0_Z2, EnemyColony_Y1_Z0, Enemy_Y1_Z1, Enemy_Y1_Z2 };
                                                                   // Unity does not like c# lists
        #endregion

        public static List<string> StartGameObjectNames = new List<string>();
        public static Dictionary<int, GameObject> CurrentGameObjects = new Dictionary<int, GameObject>(); // not used yet

        //ToDo: move all these to combatEngine class?
        public static string[] FriendNameArray; // For current Combat ****
        public static string[] EnemyNameArray; 
        public int friends;
        public int enemies;
        public static Dictionary<int, GameObject> FriendShips = new Dictionary<int, GameObject>();  // updated to current combat
        public static Dictionary<int, GameObject> EnemyShips = new Dictionary<int, GameObject>();
        //public static Dictionary<int, GameObject> CombatObjects = new Dictionary<int, GameObject>();

        private int friendShipLayer;
        private int enemyShipLayer;

        #region travel points as game object
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
        public Dictionary<GameObject, GameObject[]> _shipTargetDictionary;  // key ship gameObject, value target gameObject (problem, is loaded inside LoadCombat()
        #endregion

        public static GameManager Instance { get; private set; } // a static singleton, no other script can instatniate a GameManager, must us the singleton

        public GameObject panelLobby_Menu;
        // public GameObject panelLobby_Init; // no init gameobjects
        public GameObject panelMain_Menu;
        public GameObject panelGalactic_Play;
        public GameObject panelGalactic_Completed;
        public GameObject panelCombat_Menu;
        public GameObject panelCombat_Play;
        public GameObject panelCombat_Completed;
        public GameObject panelGameOver;
        //public GameObject[] levels;

        //List<Tuple<CombatUnit, CombatWeapon[]>> // will we need to us this here too?
        public enum State { LOBBY_MENU, LOBBY_INIT, MAIN_MENU, MAIN_INIT, GALACTIC_PLAY, GALACTIC_COMPLETED,
            COMBAT_MENU, COMBAT_INIT, COMBAT_PLAY, COMBAT_COMPLETED, GAMEOVER }; //LOADNEXT,
        private State _state;

        private int _level;

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        bool _isSwitchingState = false;

        public bool _statePassedLobbyInit = false;
        // public bool StatePassedInit { get { return _statePassedInit; } set { _statePassedInit = value; } }
        public bool _statePassedMain_Init = false;
        public bool _statePassedCombatMenu_Init = false;
        public bool _statePassedCombatInit = false; // COMBAT INIT
        public bool _statePassedCombatPlay = false;

        private void Awake()
        {
            Instance = this; // static reference to single GameManager
        }


        void Start()
        {
            SwitchtState(State.LOBBY_MENU);
            if (SaveManager.hasLoaded)
            {
                // get respons with locations... SaveManager.activeSave.(somethings here from save data)
            }
            LoadShipData(Environment.CurrentDirectory + "\\Assets\\" + "ShipData.txt"); // populate prefabs
                                                                                        // ToDo: LoadSystemData(Environment.CurrentDirectory + "\\Assets\\" + "SystemData.txt");
            LoadStartGameObjectNames(Environment.CurrentDirectory + "\\Assets\\" + "Temp_GameObjectData.txt"); //"EarlyGameObjectData.txt");
            LoadPrefabs();
            _techLevel = TechLevel.Early;
            _localPlayer = Civilization.Fed;
            if (_isSinglePlayer)
                _weAreFriend = true; // ToDo: Need to sort out friend and enemy in multiplayer civilizations local player host and clients 

            // *** moving load Combat ships to BeginState newState CombatMenu CombatInit that turns true on entering combat in galaxy view.

            //StarterGalaxyObjects(); // GNDN ToDo: move to Main_Init in pre for galaxy play

           // LoadCombatData();
        }

        public void BackToLobbyClick()  // from Main Menu
        {
            SwitchtState(State.LOBBY_MENU);
        }

        public void SinglePlayerLobbyClicked() // go to main menu
        {
            SwitchtState(State.LOBBY_INIT);
            _isSinglePlayer = true;
        }
        public void MultiPlayerLobbyClicked() // go to main menu
        {
            SwitchtState(State.LOBBY_INIT);
            _isSinglePlayer = false;
            //ToDo: network manager here IsHost IsLocalPlayer or in BeginState??
        }
        public void GalaxyPlayClicked()
        {
            //if (IsHost) // if (IsLocalPlayer)
            //{ 
            SwitchtState(State.MAIN_INIT);
            //LoadGameObjects();
            // ToDo: get Empire and techlevel from MainMenu
            //}
        }
        public void EndGalacticPlayClicked()
        {
            //if (IsHost) // if (IsLocalPlayer)
            //{ 
            SwitchtState(State.GALACTIC_COMPLETED);
            //}
        }

        public void CombatPlayClicked()
        {
            //if (IsHost) // if (IsLocalPlayer)
            //{ 
            SwitchtState(State.COMBAT_INIT);
            //}
        }

        public void SwitchtState(State newState, float delay = 0)
        {
            StartCoroutine(SwitchDelay(newState, delay));
            Instance = this;
            EndState();
            BeginState(newState);
            _isSwitchingState = false;
        }
        IEnumerator SwitchDelay(State newState, float delay)
        {
            _isSwitchingState = true;
            yield return new WaitForSeconds(delay);
            //EndState();
            _state = newState;
            //BeginState(newState);
            _isSwitchingState = false;
        }

        void BeginState(State newState)
        {
            switch (newState)
            {
                case State.LOBBY_MENU:
                    panelMain_Menu.SetActive(false); // turn off if returning to lobby
                    panelLobby_Menu.SetActive(true);

                    break;
                case State.LOBBY_INIT:
                    panelMain_Menu.SetActive(true);
                    SwitchtState(State.MAIN_MENU);
                    _statePassedLobbyInit = true;
                    switch (_isSinglePlayer) // we set this bool in the singlePlayerLobby and multipPlayerLobby buttons above so do we need this for something else??
                    {
                        case true: //Do something here??
                            break;
                        case false:
                            break;
                        default:
                            break;
                    }
                    break;
                case State.MAIN_MENU:
                    break;
                case State.MAIN_INIT:
                    switch (_techLevel) // is set in TechSelection.cs for GameManager._techLevel
                    {
                        case TechLevel.Early: //Do something here??
                            break;
                        case TechLevel.Developed:
                            break;
                        case TechLevel.Advanced:
                            break;
                        case TechLevel.Supreme:
                            break;
             
                        default:
                            break;
                    }
                    switch (_localPlayer) // is set in CivSelection.cs for GameManager._localPlayer
                    {
                        case Civilization.Fed: // do something about multiplayer and civs here??
                            break;
                        case Civilization.Terran:
                            break;
                        case Civilization.Rom:
                            break;
                        case Civilization.Kling:
                            break;
                        case Civilization.Card:
                            break;
                        case Civilization.Dom:
                            break;
                        case Civilization.Borg:
                            break;
                        default:
                            break;
                    }
                    panelMain_Menu.SetActive(false);
                    panelGalactic_Play.SetActive(true);
                    _statePassedMain_Init = true;
                    SwitchtState(State.GALACTIC_PLAY);
                    break;
                case State.GALACTIC_PLAY:
                    _statePassedMain_Init = true;
                    break;
                case State.GALACTIC_COMPLETED:
                    panelGalactic_Play.SetActive(false);
                    panelCombat_Menu.SetActive(true);
                    //panelCombat_Completed.SetActive(true);
                    SwitchtState(State.COMBAT_MENU);
                    break;
                case State.COMBAT_MENU:
                    panelCombat_Menu.SetActive(true);
                    //_statePassedInit = true;
                    LoadFriendAndEnemyNames(); // for combat
                    //combatOrderSelection.ImplementCombatOrder();
                    // combat order toggle in CombatOderSelection code updates GameManager _combatOrder field
                    break;
                case State.COMBAT_INIT:
                    _statePassedCombatMenu_Init = true;
                    actOnCombatOrder.CombatOrderAction(_combatOrder, FriendShips, EnemyShips);
                    instantiateCombatShips.PreCombatSetup(FriendNameArray, EnemyNameArray); //, true);
                    //_statePassedCombatInit = true; 
                    SetDummyCameraTargets(); // turn on multiCamera                   
                    zoomCamera.ZoomIn();
                    _statePassedCombatInit = true; // animation... can now run 
                    panelCombat_Menu.SetActive(false);
                    DropOutOfWarp(FriendShips, EnemyShips); // _combatOrder, _combatOrder set in toggle by CombatOrderSelection.cs

                    panelCombat_Play.SetActive(true);
                    SwitchtState(State.COMBAT_PLAY);
                    break;
                case State.COMBAT_PLAY:
                    _statePassedCombatPlay = true; 
                    break;
                case State.COMBAT_COMPLETED:
                    // panelCombat_Play.SetActive(true);
                    panelCombat_Completed.SetActive(true);
                    if (false)// requirments for game over here
                        SwitchtState(State.GAMEOVER);
                    else
                    {
                        SwitchtState(State.GALACTIC_PLAY);
                        _statePassedCombatInit = false;
                        _statePassedCombatMenu_Init = false;
                        zoomCamera.TurnOfZoomerUpdate();
                    }
                    break;
                //case State.LOADNEXT: // was for load levels
                //    // no levels to load
                //    SwitchtState(State.COMBAT_PLAY);
                //    break;
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
            //zoomCamera.CheckUpdateZoom();
            switch (_state)
            {
                case State.LOBBY_MENU:
                    break;
                case State.LOBBY_INIT:
                    break;
                case State.MAIN_MENU:
                    break;
                case State.MAIN_INIT:
                    _statePassedMain_Init = true;
                    break;
                case State.GALACTIC_PLAY:
                    _statePassedMain_Init = true;
                    break;
                case State.GALACTIC_COMPLETED:
                    break;
                case State.COMBAT_MENU:
                    // ToDo: end combat
                    //if (enemies are == 0 || friends are == 0)
                    //    {
                    //    End Combat
                    //}
                    break;
                case State.COMBAT_INIT:
                   // _statePassedInit = true;
                    break;
                case State.COMBAT_PLAY:
                   // _statePassedInit = true;
                    break;
                case State.COMBAT_COMPLETED:
                    break;
                //case State.LOADNEXT:
                //    break;
                case State.GAMEOVER:
                   // _statePassedInit = false;
                    break;
                default:
                    break;
            }
        }
        void EndState()
        {
            switch (_state)
            {
                case State.LOBBY_MENU:
                    panelLobby_Menu.SetActive(false);
                    break;
                case State.LOBBY_INIT: // no init panles to turn off
                    break;
                case State.MAIN_MENU:
                    panelMain_Menu.SetActive(false);
                    break;
                case State.MAIN_INIT:
                    break;
                case State.GALACTIC_PLAY:
                    panelGalactic_Play.SetActive(false);
                    break;
                case State.GALACTIC_COMPLETED:
                    panelGalactic_Play.SetActive(false);
                    panelGalactic_Completed.SetActive(false);
                    break;
                case State.COMBAT_MENU:
                    // panelGalactic_Play.SetActive(false);
                    panelCombat_Menu.SetActive(false);
                    break;
                case State.COMBAT_INIT:
                    panelCombat_Menu.SetActive(false);
                    // panelGalactic_Completed.SetActive(false);
                    break;
                case State.COMBAT_PLAY:
                    panelCombat_Play.SetActive(false);
                    break;
                case State.COMBAT_COMPLETED:
                    panelCombat_Completed.SetActive(false);
                    break;
                //case State.LOADNEXT:
                //    break;
                case State.GAMEOVER:
                    // panelCombat_Play.SetActive(false); // ToDo: get Combat to return to Galactic on Combat_Completed
                    panelGameOver.SetActive(false);
                    break;
                default:
                    break;
            }
        }
        public void SetDummyCameraTargets()
        {
            _cameraTargets = instantiateCombatShips.GetCameraTargets().ToArray(); // array for CameraMultiTarget
            cameraMultiTarget.SetTargets(_cameraTargets); // start multiCamera - main camers before warp in of ships
        }
        public void ProvidCombatShips(Dictionary<int, GameObject> combatFriends, Dictionary<int, GameObject> combatEnemies)
        {
            FriendShips = combatFriends;
            EnemyShips = combatEnemies;
        }
        //public void ProvidCombatShips(Dictionary<int, GameObject> combatObjects)
        //{
        //    CombatObjects = CombatObjects;
        //}
        public void SetShipLayer(string civ, bool isFriend)
          {
            switch (civ)
            {
                case "FED":
                    {
                        if (isFriend)
                            friendShipLayer = 10;
                        else
                            enemyShipLayer = 10;
                        break;
                    }
                case "TERRAN":
                    {
                        if (isFriend)
                            friendShipLayer = 11;
                        else
                            enemyShipLayer = 11;
                        break;
                    }
                case "ROM":
                    {
                        if (isFriend)
                            friendShipLayer = 12;
                        else
                            enemyShipLayer = 12;
                        break;
                    }
                case "KLING":
                    {
                        if (isFriend)
                            friendShipLayer = 13;
                        else
                            enemyShipLayer = 13;
                        break;
                    }
                case "CARD":
                    {
                        if (isFriend)
                            friendShipLayer = 14;
                        else
                            enemyShipLayer = 14;
                        break;
                    }
                case "DOM":
                    {
                        if (isFriend)
                            friendShipLayer = 15;
                        else
                            enemyShipLayer = 15;
                        break;
                    }
                case "BORG":
                    {
                        if (isFriend)
                            friendShipLayer = 16;
                        else
                            enemyShipLayer = 16;
                        break;
                    }
                default:
                    break;
            }
        }

        public int SetShipLayer(string civ)
        {
            switch (civ)
            {
                case "FED":
                    {
                        return 10;

                    }
                case "TERRAN":
                    {
                        return 11;

                    }
                case "ROM":
                    {
                        return 12;

                    }
                case "KLING":
                    {
                        return 13;

                    }
                case "CARD":
                    {
                        return 14;

                    }
                case "DOM":
                    {
                        return 15;

                    }
                case "BORG":
                    {
                        return 16;

                    }
                default:
                    return 10;

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
        public void LoadFriendAndEnemyNames()
        {
            string[] _friendNameArray = new string[] { "FED_CRUISER_II", "FED_CRUISER_III", "FED_DESTROYER_II", "FED_DESTROYER_II", "FED_DESTROYER_I", "FED_SCOUT_II" };
            FriendNameArray = _friendNameArray;
            string[] _enemyNameArray = new string[] { "KLING_DESTROYER_I", "CARD_SCOUT_I", "KLING_CRUISER_II", "KLING_SCOUT_II",
                "ROM_CRUISER_III", "ROM_CRUISER_II", "ROM_SCOUT_III" }; //"KLING_DESTROYER_I",
            EnemyNameArray = _enemyNameArray;
        }

        #region Read Tech era in TechSelection.cs (Ship)GameObjectData.txt
        public void LoadStartGameObjectNames(string filename) //****  from TechSelection.cs ToDo: read for selected tech level
        {
            List<string> _startGameObjectNames = new List<string>();
            var file = new FileStream(filename, FileMode.Open, FileAccess.Read);

            var _dataPoints = new List<string>();
            using (var reader = new StreamReader(file))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                        continue;
                    _dataPoints.Add(line.Trim());
                    if (line.Length > 0)
                    {
                        var coll = line.Split(separator);

                        string currentValueZero = coll[0];

                        string[] shipDataArray = new string[] { currentValueZero };

                        _startGameObjectNames.Add(coll[0].ToString().ToUpper());
                    }
                }

                reader.Close();
                StartGameObjectNames = _startGameObjectNames;
            }
        }
        public void LoadPrefabs()
        {
            // Do this in InstantiateCombatShips.cs
            //foreach (string name in StartGameObjectNames)
            //{
            //    string[] collObjectName = name.ToUpper().Split('_');
            //    int _shipLayer = 10;
            //    if (collObjectName[1] == "SCOUT" || collObjectName[1] == "DESTROYER" || collObjectName[1] == "CRUISER" ||
            //        collObjectName[1] == "LT_CRUISER" || collObjectName[1] == "HVY_CRUISER" || collObjectName[1] == "TRANSPORT")
            //        _shipLayer = SetShipLayer(collObjectName[0]);
            //}

            //ToDo: build all prefabs needed for game and laod here in place of tempPrefabDitionary
            //foreach (var item in StartGameObjectNames)
            //{
            //    prefabDitionary.Add(item, name of prefab here)
            //}
            Dictionary<string, GameObject> tempPrefabDitionary = new Dictionary<string, GameObject>() // !! only try to load prefabs that exist
            {
                { "FED_DESTROYER_I", Fed_Destroyer_i }, { "FED_SCOUT_II", Fed_Scout_ii },
                { "FED_CRUISER_II", Fed_Cruiser_ii }, { "FED_DESTROYER_II", Fed_Destroyer_ii }, // { "FED_SCOUT_II", Fed_Scout_ii },
                { "FED_CRUISER_III", Fed_Cruiser_iii }, //{ "FED_DESTROYER_III", Fed_Destroyer_iii }, { "FED_SCOUT_III", Fed_Scout_iii },
                { "KLING_DESTROYER_I", Kling_Destroyer_i},
                { "KLING_CRUISER_II", Kling_Cruiser_ii }, { "KLING_SCOUT_II", Kling_Scout_ii },
                { "CARD_SCOUT_I", Card_Scout_i },
                { "ROM_SCOUT_III", Rom_Scout_iii },
                { "ROM_CRUISER_II", Rom_Cruiser_ii }, { "ROM_CRUISER_III", Rom_Cruiser_iii }
            };
            PrefabDitionary = tempPrefabDitionary;
        }
        public void StarterGalaxyObjects()
        {
            #region Instantiate Prefab GameObjects

            //Dictionary<int, GameObject> _starterLocal = new Dictionary<int, GameObject>();
            //// Dictionary<GameObject, GameObject[]> localShipTargetDictionary = new Dictionary<GameObject, GameObject[]>();
            ////Dictionary<string, int[]> tempshipDataDictionary = new Dictionary<string, int[]>();
            //for (int i = 0; i < StartGameObjectNames.Count(); i++)
            //{
            //    //GameObject[] resetFriendArray = GetRoeByShipType(_friendNameArray[i], FriendOrFoe.friend, NearOrFar.Near);
            //    GameObject _tempPrefab = (GameObject)Instantiate(PrefabDitionary[StartGameObjectNames[i]], HomeSystemTrans(StartGameObjectNames[i]), Quaternion.identity);

            //    _tempPrefab.transform.localScale = new Vector3(transform.localScale.x * shipScale, transform.localScale.y * shipScale, transform.localScale.z * shipScale);
            //    _starterLocal.Add(i, _tempPrefab);
            //    if (ShipDataDictionary.TryGetValue(StartGameObjectNames[i].ToUpper(), out int[] _result))
            //    {
            //        _tempPrefab.GetComponent<Ship>()._shieldsMaxHealth = _result[0];
            //        _tempPrefab.GetComponent<Ship>()._hullMaxHealth = _result[1];
            //        _tempPrefab.GetComponent<Ship>()._torpedoDamage = _result[2];
            //        _tempPrefab.GetComponent<Ship>()._beamDamage = _result[3];
            //        _tempPrefab.GetComponent<Ship>()._cost = _result[4];
            //    }
            //}
            //CurrentGameObjects = _starterLocal;
            #endregion
        }
        #endregion
        public void LoadShipData(string filename)
        {
            #region Read ShipData.txt 

            Dictionary<string, int[]> _shipDataDictionary = new Dictionary<string, int[]>();
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

                        _ = int.TryParse(coll[2], out int currentValueOne);
                        _ = int.TryParse(coll[4], out int currentValueTwo);
                        _ = int.TryParse(coll[6], out int currentValueThree);
                        _ = int.TryParse(coll[8], out int currentValueFour);
                        _ = int.TryParse(coll[10], out int currentValueFive);
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
        }
        public void DropOutOfWarp( Dictionary<int, GameObject> daFriends, Dictionary<int, GameObject> daEnemies) // Orders order,
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
            foreach (KeyValuePair<int, GameObject> daShip in CombatObjects)
            {

                if (FriendShips.ContainsValue(daShip.Value))
                {
                    int choseWarp = UnityEngine.Random.Range(0, 3);
                    switch (choseWarp)
                    {
                        case 0:
                            animFriend1.layer = daShip.Value.layer; 
                            daShip.Value.transform.SetParent(animFriend1.transform, true);
                            break;
                        case 1:
                            animFriend2.layer = daShip.Value.layer;
                            daShip.Value.transform.SetParent(animFriend2.transform, true);
                            break;
                        case 2:
                            animFriend3.layer = daShip.Value.layer;
                            daShip.Value.transform.SetParent(animFriend3.transform, true);
                            break;
                        default:
                            animFriend1.layer = daShip.Value.layer;
                            daShip.Value.transform.SetParent(animFriend1.transform, true);
                            break;
                    }
                }
                if (EnemyShips.ContainsValue(daShip.Value))
                {
                    //animEnemy1.layer = daShip.Value.layer;
                    //daShip.Value.transform.SetParent(animEnemy1.transform, true);
                    int choseWarp = UnityEngine.Random.Range(0, 3);
                    switch (choseWarp)
                    {
                        case 0:
                            animEnemy1.layer = daShip.Value.layer;
                            daShip.Value.transform.SetParent(animEnemy1.transform, true);
                            break;
                        case 1:
                            animEnemy2.layer = daShip.Value.layer;
                            daShip.Value.transform.SetParent(animEnemy2.transform, true);
                            break;
                        case 2:
                            animEnemy3.layer = daShip.Value.layer;
                            daShip.Value.transform.SetParent(animEnemy3.transform, true);
                            break;
                        default:
                            animEnemy1.layer = daShip.Value.layer;
                            daShip.Value.transform.SetParent(animEnemy1.transform, true);
                            break;
                    }
                }
            }
        }

        public void LoadCombatData() //(string filename) // List<sting>
        {
            // ToDo: relocate to combat class
            //GameObject[] localAnimationEmpties = new GameObject[12] { FriendScout_Y0_Z0,
            //FriendDestroyer_Y0_Z1, FriendCapital_Y0_Z2, FriendColony_Y1_Z0, Friend_Y1_Z1, Friend_Y1_Z2,
            //EnemyScout_Y0_Z0, EnemyDestroyer_Y0_Z1, EnemyCapital_Y0_Z2, EnemyColony_Y1_Z0, Enemy_Y1_Z1, Enemy_Y1_Z2 };
            //var something = animationEmpties; // = localAnimationEmpties;

            //Dictionary<string, GameObject> prefabDitionary = new Dictionary<string, GameObject>() // !! only try to load prefabs that exist
            //{
            //    { "FED_DESTROYER_I", Fed_Destroyer_i }, //{ "FED_SCOUT_I", Fed_Scout_i },
            //    { "FED_CRUISER_II", Fed_Cruiser_ii }, { "FED_DESTROYER_II", Fed_Destroyer_ii }, // { "FED_SCOUT_II", Fed_Scout_ii },
            //    { "FED_CRUISER_III", Fed_Cruiser_iii }, //{ "FED_DESTROYER_III", Fed_Destroyer_iii }, { "FED_SCOUT_III", Fed_Scout_iii },
            //    { "KLING_DESTROYER_I", Kling_Destroyer_i},
            //    { "KLING_CRUISER_II", Kling_Cruiser_ii }, { "KLING_SCOUT_II", Kling_Scout_ii },
            //    { "CARD_SCOUT_I", Card_Scout_i },
            //    { "ROM_SCOUT_III", Rom_Scout_iii },
            //    { "ROM_CRUISER_II", Rom_Cruiser_ii }, { "ROM_CRUISER_III", Rom_Cruiser_iii }
            //};
            //#region Ships to load for game
            //string[] _gameShipsNameArray = new string[] { "FED_CRUISER_II", "FED_CRUISER_III", "FED_DESTROYER_II", "FED_DESTROYER_II", "FED_DESTROYER_I",
            //    "KLING_DESTROYER_I", "CARD_SCOUT_I", "KLING_CRUISER_II", "KLING_SCOUT_II", "ROM_CRUISER_III", "ROM_CRUISER_II", "ROM_SCOUT_III" };
            //#endregion
            #region Ships to load for Combat

            //string[] _friendNameArray = new string[] { "FED_CRUISER_II", "FED_CRUISER_III", "FED_DESTROYER_II", "FED_DESTROYER_II", "FED_DESTROYER_I" };
            //FriendNameArray = _friendNameArray;
            //string[] _enemyNameArray = new string[] { "KLING_DESTROYER_I", "CARD_SCOUT_I", "KLING_CRUISER_II", "KLING_SCOUT_II",
            //    "ROM_CRUISER_III", "ROM_CRUISER_II", "ROM_SCOUT_III" }; //"KLING_DESTROYER_I",
            //EnemyNameArray = _enemyNameArray;
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
            string readFriendName = FriendNameArray[0].ToUpper();
            string[] _collFriend = readFriendName.Split('_');
            SetShipLayer(_collFriend[0], true);

            string readEnemyName = EnemyNameArray[0].ToUpper();
            string[] _collEnemy = readEnemyName.Split('_');
            SetShipLayer(_collEnemy[0], false);

            #region Instantiate Prefab Friend Ships
            //instantiate prefab ships using friendNameArray to prefab Dictionary onto as many empties in grids 
            Dictionary<int, GameObject> _friendsLocal = new Dictionary<int, GameObject>();
            var cameraTargets = new List<GameObject>();
            //var friendNearTargets = new List<GameObject>();
            Dictionary<GameObject, GameObject[]> localShipTargetDictionary = new Dictionary<GameObject, GameObject[]>();

            for (int i = 0; i < FriendNameArray.Count(); i++)
            {
                GameObject[] resetFriendArray = GetRoeByShipType(FriendNameArray[i], FriendOrFoe.friend, NearOrFar.Near); //use the current first empty from the correct side and roe by ship type
                GameObject _tempPrefabFriend = (GameObject)Instantiate(PrefabDitionary[FriendNameArray[i]], resetFriendArray[0].transform.position, resetFriendArray[0].transform.rotation);
                GameObject newEmptyCameraTarget = (GameObject)Instantiate(resetFriendArray[0], resetFriendArray[0].transform.position, resetFriendArray[0].transform.rotation);
                GameObject[] resetFriendFarArray = GetRoeByShipType(FriendNameArray[i], FriendOrFoe.friend, NearOrFar.Far);
                GameObject newEmptyFriendFarTarget = (GameObject)Instantiate(resetFriendFarArray[0], resetFriendFarArray[0].transform.position, resetFriendFarArray[0].transform.rotation);
                GameObject animationNearFTarget = (GameObject)Instantiate(new GameObject(), resetFriendArray[0].transform.position, resetFriendArray[0].transform.rotation);
                GameObject animationFarFTarget = (GameObject)Instantiate(new GameObject(), resetFriendFarArray[0].transform.position, resetFriendFarArray[0].transform.rotation);
                localShipTargetDictionary.Add(_tempPrefabFriend, new GameObject[] { animationNearFTarget, animationFarFTarget });

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
                UpdateTheArrays(FriendNameArray[i], resetingAList, FriendOrFoe.friend, NearOrFar.Near); // rebuild Array Lists
                UpdateTheArrays(FriendNameArray[i], resetingFarList, FriendOrFoe.friend, NearOrFar.Far); // rebuild Array Lists

                Ship.SetLayerRecursively(animationEmtpy, friendShipLayer);

                if (ShipDataDictionary.TryGetValue(_tempPrefabFriend.name.ToUpper(), out int[] _result))
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

            for (int i = 0; i < EnemyNameArray.Count(); i++)
            {
                GameObject[] resetEnemyArray = GetRoeByShipType(EnemyNameArray[i], FriendOrFoe.enemy, NearOrFar.Near);
                GameObject _tempPrefabEnemy = (GameObject)Instantiate(PrefabDitionary[EnemyNameArray[i]], resetEnemyArray[0].transform.position, resetEnemyArray[0].transform.rotation);
                GameObject anEmptyCameraTarget = (GameObject)Instantiate(resetEnemyArray[0], resetEnemyArray[0].transform.position, resetEnemyArray[0].transform.rotation);
                GameObject[] resetEnemyFarArray = GetRoeByShipType(EnemyNameArray[i], FriendOrFoe.enemy, NearOrFar.Far);
                GameObject newEmptyEnemyFarTarget = (GameObject)Instantiate(resetEnemyFarArray[0], resetEnemyFarArray[0].transform.position, resetEnemyFarArray[0].transform.rotation);
                GameObject animationNearETarget = (GameObject)Instantiate(new GameObject(), resetEnemyArray[0].transform.position, resetEnemyArray[0].transform.rotation);
                GameObject animationFarETarget = (GameObject)Instantiate(new GameObject(), resetEnemyFarArray[0].transform.position, resetEnemyFarArray[0].transform.rotation);
                localShipTargetDictionary.Add(_tempPrefabEnemy, new GameObject[] { animationNearETarget, animationFarETarget });

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
                UpdateTheArrays(EnemyNameArray[i], resetingList, FriendOrFoe.enemy, NearOrFar.Near);
                UpdateTheArrays(EnemyNameArray[i], resetingFarList, FriendOrFoe.enemy, NearOrFar.Far);

                Ship.SetLayerRecursively(animationEmtpy, enemyShipLayer);

                if (ShipDataDictionary.TryGetValue(_tempPrefabEnemy.name.ToUpper(), out int[] _result))
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
        public Dictionary<GameObject, GameObject[]> GetShipTravelTargets()
        {
            return _shipTargetDictionary;
        }
        private Vector3 HomeSystemTrans(string objectName)
        {
            //ToDo: where is everyone?
            var coll = objectName.Split(separator);

            string currentValueZero = coll[0].ToUpper();
            switch (currentValueZero)
            {
                case "SOL":
                    return new Vector3(0, 0, 0);    
                case "TERRA":
                    return new Vector3(0, 0, 1);
                case "ROMULUS":
                    return new Vector3(0, 0, 2);
                case "KRONOS":
                    return new Vector3(0, 0, 3);
                case "CARDASSIA":
                    return new Vector3(0, 0, 4);
                case "OMARIAN":
                    return new Vector3(0, 0, 5);
                case "UNIMATRIX":
                    return new Vector3(0, 0, 6);
                default:
                    return new Vector3(0, 0, 07);
            }
        }
    
    }
}