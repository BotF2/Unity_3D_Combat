using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
//using UnityEngine.UI;

namespace Assets.Script
{
    public enum FriendOrFoe
    {
        friend,
        enemy
    }
    public class GameManager : MonoBehaviour
    {
        public CameraMultiTarget cameraMultiTarget;
        private float shipScale = 7000f;
        private char separator = ';';
        public static Dictionary<string, int[]> ShipDataDictionary = new Dictionary<string, int[]>();

        public GameObject Friend_0;  // prefab empty gameobjects for the grid
        public GameObject Enemy_0;
        //public static GameObject dummy;

        #region the grid of empties
        public GameObject Friend_Y0_Z0; // warp animation empties
        public GameObject Friend_Y0_Z1;
        public GameObject Friend_Y0_Z2;
        public GameObject Friend_Y1_Z0;
        public GameObject Friend_Y1_Z1;
        public GameObject Friend_Y1_Z2;
        public GameObject Enemy_Y0_Z0;
        public GameObject Enemy_Y0_Z1;
        public GameObject Enemy_Y0_Z2;
        public GameObject Enemy_Y1_Z0;
        public GameObject Enemy_Y1_Z1;
        public GameObject Enemy_Y1_Z2;
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

        #endregion

        // ToDo created this in galactic game level from combat ships and stations in the combat sector
        public static string[] FriendArray; // = new string[] { "Fed_Cruiser_ii", "Fed_Cruiser_ii", "Fed_Destroyer_ii" };
        public static string[] EnemyArray; //= new string[] { "Kling_Cruiser_ii", "Kling_Cruiser_ii", "Kling_Scout_ii", "Kling_Scout_ii" };
        public static Dictionary<int, GameObject> FriendShips = new Dictionary<int, GameObject>();  // { { 500, Friend_0 } };
        public static Dictionary<int, GameObject> EnemyShips = new Dictionary<int, GameObject>();  // { { 500, Enemy_0 } };

        private int friendShipLayer;
        private int enemyShipLayer;

        public GameObject panelMenu;
        public GameObject panelPlay;
        public GameObject panelCompleted;
        public GameObject panelGameOver;
        //public GameObject[] levels;
        public static GameManager Instance { get; private set; } // a static singleton, no other script can instatniate a GameManager, must us the singleton

        //public Dictionary<string, List<int>> ShipDataDictionary { get { return _shipDataDictionary; } }

        //List<Tuple<CombatUnit, CombatWeapon[]>> // will we need to us this here too?
        public enum State { MENU, INIT, PLAY, COMPLETED, LOADNEXT, GAMEOVER };
        private State _state;
        bool _isSwitchingState;

        private bool _statePassedInit = false;
        public bool StatePassedInit { get { return _statePassedInit; } set { _statePassedInit = value; } }

        public void PlayClicked()
        {
            SwitchtState(State.INIT);
        }
        private void Awake()
        {
            Instance = this; // static reference to single GameManager
            //LoadShipData(Environment.CurrentDirectory + "\\Assets\\" + "ShipData.txt");
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
                    _statePassedInit = true;
                    SwitchtState(State.LOADNEXT);
                    break;
                case State.PLAY:
                    break;
                case State.COMPLETED:
                    panelPlay.SetActive(true);
                    break;
                case State.LOADNEXT:
                    // no levels to load
                    SwitchtState(State.PLAY);
                    break;
                case State.GAMEOVER:
                    _statePassedInit = false;
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
                    break;
                case State.PLAY:
                    break;
                case State.COMPLETED:
                    break;
                case State.LOADNEXT:
                    break;
                case State.GAMEOVER:
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
                case State.PLAY:
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
        private void SetRandomWarp(GameObject child, List<GameObject> warpEmpties)
        {

            System.Random num = new System.Random();
            int choseOne = num.Next(0, 6);

            switch (choseOne)
            {
                case 0:
                    {
                        child.transform.SetParent(warpEmpties[0].transform, true);
                        break;
                    }
                case 1:
                    {
                        child.transform.SetParent(warpEmpties[1].transform, true);
                        break;
                    }
                case 2:
                    {
                        child.transform.SetParent(warpEmpties[2].transform, true);
                        break;
                    }
                case 3:
                    {
                        child.transform.SetParent(warpEmpties[3].transform, true);
                        break;
                    }
                case 4:
                    {
                        child.transform.SetParent(warpEmpties[4].transform, true);
                        break;
                    }
                case 5:
                    {
                        child.transform.SetParent(warpEmpties[5].transform, true);
                        break;
                    }
                default:
                    break;
            }
        }

        public void LoadShipData(string filename) // List<sting>
        {
            List<GameObject> friendAnimationEmpties = new List<GameObject>()
                {Friend_Y0_Z0, Friend_Y0_Z1, Friend_Y0_Z2, Friend_Y1_Z0, Friend_Y1_Z1, Friend_Y1_Z2};
            List<GameObject> enemyAnimationEmpties = new List<GameObject>()
                {Enemy_Y0_Z0, Enemy_Y0_Z1, Enemy_Y0_Z2, Enemy_Y1_Z0, Enemy_Y1_Z1, Enemy_Y1_Z2};

            Dictionary<string, GameObject> prefabDitionary = new Dictionary<string, GameObject>() // !! only try to load prefabs that exist
            {
                { "FED_DESTROYER_I", Fed_Destroyer_i }, //{ "FED_SCOUT_I", Fed_Scout_i },
                { "FED_CRUISER_II", Fed_Cruiser_ii }, { "FED_DESTROYER_II", Fed_Destroyer_ii }, // { "FED_SCOUT_II", Fed_Scout_ii },
                { "FED_CRUISER_III", Fed_Cruiser_iii }, //{ "FED_DESTROYER_III", Fed_Destroyer_iii }, { "FED_SCOUT_III", Fed_Scout_iii },
                { "KLING_DESTROYER_I", Kling_Destroyer_i},
                { "KLING_CRUISER_II", Kling_Cruiser_ii }, { "KLING_SCOUT_II", Kling_Scout_ii },
                { "CARD_SCOUT_I", Card_Scout_i },
                { "ROM_CRUISER_II", Rom_Cruiser_ii },
                { "ROM_CRUISER_III", Rom_Cruiser_iii }
            };
            #region Ships to load for Combat
            string[] _friendArray = new string[] { "FED_CRUISER_II", "FED_CRUISER_III", "FED_DESTROYER_II", "FED_DESTROYER_II", "FED_DESTROYER_I" };
            FriendArray = _friendArray;
            string[] _enemyArray = new string[] { "CARD_SCOUT_I", "KLING_CRUISER_II", "KLING_DESTROYER_I", "KLING_SCOUT_II", "ROM_CRUISER_II" }; //"ROM_CRUISER_III",
            EnemyArray = _enemyArray;
            #endregion


            #region load position grids
            int yFactor = 3000;
            int zFactor = 3500;
            int xFactorFriend = -3000;

            List<GameObject> emptyFriendMarkers = new List<GameObject>() { Friend_0 };
            for (int i = 0; i < 21; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameObject _tempFriend = Instantiate(Friend_0, new Vector3(xFactorFriend, j * yFactor, i * zFactor), Quaternion.identity);
                    _tempFriend.transform.Rotate(0, 90, 0);
                    emptyFriendMarkers.Add(_tempFriend);
                }
            }
            //for (int i = 3; i < 6; i++)
            //{ 
            //    for (int j = 3; j < 6; j++)
            //    {
            //        GameObject _tempFriend = Instantiate(Friend_0, new Vector3(xFactorFriend, j * yFactor, i * zFactor), Quaternion.identity);
            //        _tempFriend.transform.Rotate(0, 90, 0);
            //        emptyFriendMarkers.Add(_tempFriend);
            //    }
            //}

            emptyFriendMarkers.RemoveAt(0);
            int xFactor = 10000;

            List<GameObject> emptyEnemyMarkers = new List<GameObject>() { Enemy_0 };
            for (int i = 0; i < 21; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameObject _tempEnemy = Instantiate(Enemy_0, new Vector3(xFactor, j * yFactor, i * zFactor), Quaternion.identity);
                    _tempEnemy.transform.Rotate(0, -90, 0);
                    emptyEnemyMarkers.Add(_tempEnemy);
                }
            }

            emptyEnemyMarkers.RemoveAt(0);
            #endregion

            // Do ship layers
            string readFriendName = _friendArray[0].ToUpper();
            string[] _collFriend = readFriendName.Split('_');
            SetShipLayer(_collFriend[0], FriendOrFoe.friend);

            string readEnemyName = _enemyArray[0].ToUpper();
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
                #endregion

                //instantiate prefab ships from friendArray onto as many emptyFriendMarkers from the prefab dictionary for the FriendDictionary 
                Dictionary<int, GameObject> _friendsLocal = new Dictionary<int, GameObject>();
                var cameraTargets = new List<GameObject>();
                for (int i = 0; i < _friendArray.Count(); i++)
                {
                    GameObject _tempPrefabFriend = (GameObject)Instantiate(prefabDitionary[_friendArray[i]], emptyFriendMarkers[i].transform.position, emptyFriendMarkers[i].transform.rotation);
                    _tempPrefabFriend.transform.localScale = new Vector3(transform.localScale.x * shipScale, transform.localScale.y * shipScale, transform.localScale.z * shipScale);
                    _tempPrefabFriend.transform.SetParent(emptyFriendMarkers[i].transform, true);
                   cameraTargets.Add(_tempPrefabFriend);
                    //cameraMultiTarget.SetTargets(_tempPrefabFriend.ToArray());
                    _friendsLocal.Add(i, _tempPrefabFriend);
                    //SetRandomWarp(emptyFriendMarkers[i], friendEmpties);
                    emptyFriendMarkers[i].transform.SetParent(friendAnimationEmpties[i].transform, true);
                    Ship.SetLayerRecursively(friendAnimationEmpties[i], friendShipLayer);          

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
                //StaticStuff.LoadStaticFriendDictionary(FriendShips);
                Dictionary<int, GameObject> _enemysLocal = new Dictionary<int, GameObject>();

                for (int i = 0; i < _enemyArray.Count(); i++)
                {

                    GameObject _tempPrefabEnemy = (GameObject)Instantiate(prefabDitionary[_enemyArray[i]], emptyEnemyMarkers[i].transform.position, emptyEnemyMarkers[i].transform.rotation);
                    _tempPrefabEnemy.transform.localScale = new Vector3(transform.localScale.x * shipScale, transform.localScale.y * shipScale, transform.localScale.z * shipScale);
                    _tempPrefabEnemy.transform.SetParent(emptyEnemyMarkers[i].transform, true);
                    cameraTargets.Add(_tempPrefabEnemy);
                    _enemysLocal.Add(i, _tempPrefabEnemy);
                    //SetRandomWarp(emptyEnemyMarkers[i], enemyEmpties);
                    emptyEnemyMarkers[i].transform.SetParent(enemyAnimationEmpties[i].transform, true);
                    Ship.SetLayerRecursively(enemyAnimationEmpties[i], enemyShipLayer);

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
                cameraMultiTarget.SetTargets(cameraTargets.ToArray());
                //StaticStuff.LoadStaticEnemyDictionary(EnemyShips); 
            }
        }
        //private GameObject CreateTarget()
        //{
        //    GameObject target = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        //    target.transform.position = UnityEngine.Random.insideUnitSphere * 10f;
        //    return target;
        //}
    }
}
