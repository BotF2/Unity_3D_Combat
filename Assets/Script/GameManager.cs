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
    //public class ShipData
    //{
    //    public string A_INDEX;
    //    public string Key;
    //    public int Hull;
    //    public int Shield;
    //    public int TorpedoDamage;
    //    public int BeamDamage;

    //    public ShipData(
    //            string a_index
    //            , string key
    //            , int hull
    //            , int shield
    //            , int torpedoDamage
    //            , int beamDamaga
    //            )
    //    {
    //        A_INDEX = a_index;
    //        Key = key;
    //        Hull = hull;
    //        Shield = shield;
    //        TorpedoDamage = torpedoDamage;
    //        BeamDamage = beamDamaga;
    //    }
    //}
    public class GameManager : MonoBehaviour
    {
        private float shipScale = 7000f;
        private char separator = ';';
        public Dictionary<string, int[]> _shipDataDictionary = new Dictionary<string, int[]>();

        public GameObject friend_0;  // prefab empty gameobjects for the grid
        public GameObject enemy_0;
        public static GameObject dummy;

        #region the grid of empties
        public GameObject Friend_YO_Z0; // warp animation empties
        public GameObject Friend_YO_Z1;
        public GameObject Friend_YO_Z2;
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
        public GameObject Fed_Cruiser_ii; // prefab ships
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
        public GameObject Rom_Scout_i;
        public GameObject Rom_Scout_ii;

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

        public GameObject Borg_Destroyer_i;
        public GameObject Borg_Destroyer_ii;
        public GameObject Borg_Cube_ii;
        public GameObject Borg_Scout_i;
        #endregion

        // ToDo created this in galactic game level from combat ships and stations in the combat sector
        public static string[] friendArray; // = new string[] { "Fed_Cruiser_ii", "Fed_Cruiser_ii", "Fed_Destroyer_ii" };
        public static string[] enemyArray; //= new string[] { "Kling_Cruiser_ii", "Kling_Cruiser_ii", "Kling_Scout_ii", "Kling_Scout_ii" };
        public static Dictionary<int, GameObject> FriendShips = new Dictionary<int, GameObject>{ { 500, dummy } };
        public static Dictionary<int, GameObject> EnemyShips = new Dictionary<int, GameObject> { { 500, dummy } };

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
            
        }

        // Start is called before the first frame update
        void Start()
        {

            SwitchtState(State.MENU);
            LoadShipData(Environment.CurrentDirectory + "\\Assets\\" + "ShipData.txt");

            List<GameObject> friendEmpties = new List<GameObject>()
                {Friend_YO_Z0,Friend_YO_Z1, Friend_YO_Z2, Friend_Y1_Z0, Friend_Y1_Z1, Friend_Y1_Z2};
            List<GameObject> enemyEmpties = new List<GameObject>()
                {Enemy_Y0_Z0, Enemy_Y0_Z1, Enemy_Y0_Z2, Enemy_Y1_Z0, Enemy_Y1_Z1, Enemy_Y1_Z2};

            Dictionary<string, GameObject> prefabDitionary = new Dictionary<string, GameObject>() // !! only try to load prefabs that exist
            {
                { "FED_DESTROYER_I", Fed_Destroyer_i }, //{ "FED_SCOUT_I", Fed_Scout_i },
                { "FED_CRUISER_II", Fed_Cruiser_ii }, { "FED_DESTROYER_II", Fed_Destroyer_ii }, // { "FED_SCOUT_II", Fed_Scout_ii },
                { "FED_CRUISER_III", Fed_Cruiser_iii }, //{ "FED_DESTROYER_III", Fed_Destroyer_iii }, { "FED_SCOUT_III", Fed_Scout_iii },
                { "KLING_CRUISER_II", Kling_Cruiser_ii }, //{ "KLING_DESTROYER_II", Kling_Destroyer_ii },
                { "KLING_SCOUT_II", Kling_Scout_ii }
            };

            # region load grids
            int yFactor = 3000;
            int zFactor = 3500;
            int xFactorFriend = -3000;
            friendArray = new string[] { "FED_CRUISER_II", "FED_CRUISER_II", "FED_DESTROYER_II", "FED_DESTROYER_II" };
            List<GameObject> emptyFriendMarkers = new List<GameObject>() { friend_0 };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameObject _tempFriend = Instantiate(friend_0, new Vector3(xFactorFriend, i * yFactor, j * zFactor), Quaternion.identity); 
                    _tempFriend.transform.Rotate(0, 90, 0);
                    emptyFriendMarkers.Add(_tempFriend);
                }
                for (int j = 3; j < 6; j++)
                {
                    GameObject _tempFriend = Instantiate(friend_0, new Vector3(xFactorFriend, i * yFactor, j * zFactor), Quaternion.identity);
                    _tempFriend.transform.Rotate(0, 90, 0);
                    emptyFriendMarkers.Add(_tempFriend);
                }
                for (int j = 6; j < 9; j++)
                {
                    GameObject _tempFriend = Instantiate(friend_0, new Vector3(xFactorFriend, i * yFactor, j * zFactor), Quaternion.identity);
                    _tempFriend.transform.Rotate(0, 90, 0);
                    emptyFriendMarkers.Add(_tempFriend);
                }
                for (int j = 9; j < 12; j++)
                {
                    GameObject _tempFriend = Instantiate(friend_0, new Vector3(xFactorFriend, i * yFactor, j * zFactor), Quaternion.identity);
                    _tempFriend.transform.Rotate(0, 90, 0);
                    emptyFriendMarkers.Add(_tempFriend);
                }
                for (int j = 12; j < 15; j++)
                {
                    GameObject _tempFriend = Instantiate(friend_0, new Vector3(xFactorFriend, i * yFactor, j * zFactor), Quaternion.identity);
                    _tempFriend.transform.Rotate(0, 90, 0);
                    emptyFriendMarkers.Add(_tempFriend);
                }
                for (int j = 15; j < 18; j++)
                {
                    GameObject _tempFriend = Instantiate(friend_0, new Vector3(xFactorFriend, i * yFactor, j * zFactor), Quaternion.identity);
                    _tempFriend.transform.Rotate(0, 90, 0);
                    emptyFriendMarkers.Add(_tempFriend);
                }
                for (int j = 18; j < 21; j++)
                {
                    GameObject _tempFriend = Instantiate(friend_0, new Vector3(xFactorFriend, i * yFactor, j * zFactor), Quaternion.identity);
                    _tempFriend.transform.Rotate(0, 90, 0);
                    emptyFriendMarkers.Add(_tempFriend);
                }
            }
            emptyFriendMarkers.RemoveAt(0);
            int xFactor = 10000;
            enemyArray = new string[] { "KLING_CRUISER_II", "KLING_CRUISER_II", "KLING_SCOUT_II", "KLING_SCOUT_II" };
            List<GameObject> emptyEnemyMarkers = new List<GameObject>() { enemy_0 };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameObject _tempEnemy = Instantiate(enemy_0, new Vector3(xFactor, i * yFactor, j * zFactor), Quaternion.identity);
                    _tempEnemy.transform.Rotate(0, -90, 0);
                    emptyEnemyMarkers.Add(_tempEnemy);
                }
                for (int j = 3; j < 6; j++)
                {
                    GameObject _tempEnemy = Instantiate(enemy_0, new Vector3(xFactor, i * yFactor, j * zFactor), Quaternion.identity);
                    _tempEnemy.transform.Rotate(0, -90, 0);
                    emptyEnemyMarkers.Add(_tempEnemy);
                }
                for (int j = 6; j < 9; j++)
                {
                    GameObject _tempEnemy = Instantiate(enemy_0, new Vector3(xFactor, i * yFactor, j * zFactor), Quaternion.identity);
                    _tempEnemy.transform.Rotate(0, -90, 0);
                    emptyEnemyMarkers.Add(_tempEnemy);
                }
                for (int j = 9; j < 12; j++)
                {
                    GameObject _tempEnemy = Instantiate(enemy_0, new Vector3(xFactor, i * yFactor, j * zFactor), Quaternion.identity);
                    _tempEnemy.transform.Rotate(0, -90, 0);
                    emptyEnemyMarkers.Add(_tempEnemy);
                }
                for (int j = 12; j < 15; j++)
                {
                    GameObject _tempEnemy = Instantiate(enemy_0, new Vector3(xFactor, i * yFactor, j * zFactor), Quaternion.identity);
                    _tempEnemy.transform.Rotate(0, -90, 0);
                    emptyEnemyMarkers.Add(_tempEnemy);
                }
                for (int j = 15; j < 18; j++)
                {
                    GameObject _tempEnemy = Instantiate(enemy_0, new Vector3(xFactor, i * yFactor, j * zFactor), Quaternion.identity);
                    _tempEnemy.transform.Rotate(0, -90, 0);
                    emptyEnemyMarkers.Add(_tempEnemy);
                }
                for (int j = 18; j < 21; j++)
                {
                    GameObject _tempEnemy = Instantiate(enemy_0, new Vector3(xFactor, i * yFactor, j * zFactor), Quaternion.identity);
                    _tempEnemy.transform.Rotate(0, -90, 0);
                    emptyEnemyMarkers.Add(_tempEnemy);
                }              
            }
            emptyEnemyMarkers.RemoveAt(0);
            #endregion

            // Get ship layers
            string readFriendName = friendArray[0].ToUpper();
            string[] _collFriend = readFriendName.Split('_');
            SetShipLayer(_collFriend[0], FriendOrFoe.friend);

            string readEnemyName = enemyArray[0].ToUpper();
            string[] _collEnemy = readEnemyName.Split('_');
            SetShipLayer(_collEnemy[0], FriendOrFoe.enemy);
            int _countFriends = 0;
            //instantiate prefab ships from friendArray onto as may emptyFriendMarkers using the prefab dictionary
            for (int i = 0; i < friendArray.Count(); i++)
            {

                GameObject _tempPrefabFriend = (GameObject)Instantiate(prefabDitionary[friendArray[i]], emptyFriendMarkers[i].transform.position, emptyFriendMarkers[i].transform.rotation);
                _tempPrefabFriend.transform.localScale = new Vector3(transform.localScale.x * shipScale, transform.localScale.y * shipScale, transform.localScale.z * shipScale);
                _tempPrefabFriend.transform.SetParent(emptyFriendMarkers[i].transform, true);
                //var rend = _tempPrefabFriend.GetComponent<Renderer>();
                //rend.enabled = false;
                //_tempPrefabFriend.transform.position = new Vector3(emptyFriendMarkers[i].transform.position.x, emptyFriendMarkers[i].transform.position.y, emptyFriendMarkers[i].transform.position.z);
                //SetRandomWarp(emptyFriendMarkers[i], friendEmpties);
                emptyFriendMarkers[i].transform.SetParent(Friend_YO_Z0.transform, true);
       
                Ship.SetLayerRecursively(Friend_YO_Z0, friendShipLayer);

                //_tempPrefabFriend.transform.localScale = new Vector3(transform.localScale.x * shipScale, transform.localScale.y * shipScale, transform.localScale.z * shipScale);
                FriendShips.Add(_countFriends, _tempPrefabFriend);
                _countFriends += 1;
            }
            //StaticStuff.LoadStaticFriendDictionary(FriendShips);
            int _countEnemies = 0;
            for (int i = 0; i < enemyArray.Count(); i++)
            {

                GameObject _tempPrefabEnemy = (GameObject)Instantiate(prefabDitionary[enemyArray[i]], emptyEnemyMarkers[i].transform.position, emptyEnemyMarkers[i].transform.rotation);
                _tempPrefabEnemy.transform.localScale = new Vector3(transform.localScale.x * shipScale, transform.localScale.y * shipScale, transform.localScale.z * shipScale);
                _tempPrefabEnemy.transform.SetParent(emptyEnemyMarkers[i].transform, true);
               //SetRandomWarp(emptyEnemyMarkers[i], enemyEmpties);
                emptyEnemyMarkers[i].transform.SetParent(Enemy_Y0_Z0.transform, true);
                Ship.SetLayerRecursively(Enemy_Y0_Z0, enemyShipLayer);
                EnemyShips.Add(_countEnemies, _tempPrefabEnemy);
                _countEnemies += 1;
            }
            //StaticStuff.LoadStaticEnemyDictionary(EnemyShips);
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
        // will give the child the same location, rotation and scale as the parent
        //public static void SetParent(this Transform child, Transform parent)
        //{
        //    child.parent = parent;
        //    child.localPosition = Vector3.zero;
        //    child.localRotation = Quaternion.identity;
        //    child.localScale = Vector3.one;
        //}
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
        //public class ShipData
        //{
        //    string A_INDEX;
        //    //string Key;
        //    int Hull;
        //    int Shield;
        //    int TorpedoDamage;
        //    int BeamDamage;

        //    public ShipData(
        //            string a_index
        //           // , string key
        //            , int hull
        //            , int shield
        //            , int torpedoDamage
        //            , int beamDamaga
        //            )
        //    {
        //        A_INDEX = a_index;
        //        //Key = key;
        //        Hull = hull;
        //        Shield = shield;
        //        TorpedoDamage = torpedoDamage;
        //        BeamDamage = beamDamaga;
        //    }
        //}
        public void LoadShipData(string filename) // List<sting>
        {

            var file = new FileStream(filename, FileMode.Open, FileAccess.Read);

            var _dataPoints = new List<string>();
            using (var reader = new StreamReader(file))
            {
                //Note1("string", int, int, int, int, "---------------  reading __to_PLZ_DB.txt (from file)");
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
                        //_ = int.TryParse(coll[1], out int currentValueOne);
                        //_ = int.TryParse(coll[2], out int currentValueTwo);
                        //_ = int.TryParse(coll[3], out int currentValueThree);
                        //_ = int.TryParse(coll[4], out int currentValueFour);
                        //ShipData shipDataNew = new ShipData(
                        //  coll[0]
                        //  //,coll[0]
                        //  , currentValueOne
                        //  , currentValueTwo
                        //  , currentValueThree
                        //  , currentValueFour
                        //  );
                        //shipDataList.Add(shipDataNew);

                        _ = int.TryParse(coll[1], out int currentValueOne);
                        _ = int.TryParse(coll[2], out int currentValueTwo);
                        _ = int.TryParse(coll[3], out int currentValueThree);
                        _ = int.TryParse(coll[4], out int currentValueFour);
                        int[] shipDataArray = new int[] {currentValueOne, currentValueTwo, currentValueThree, currentValueFour};

                        _shipDataDictionary.Add(coll[0].ToString(), shipDataArray);
                        //_shipInts.Clear();
                    }
                }
                reader.Close();
                StaticStuff staticStuffToLoad = new StaticStuff();
                staticStuffToLoad.LoadStaticShipData(_shipDataDictionary);
            }
        }
    }
}
