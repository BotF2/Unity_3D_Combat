using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public enum FriendOrFoe
    {
        friend,
        enemy
    }
    public class GameManager : MonoBehaviour
    {
        public GameObject friend_0;  // prefab empty gameobjects
        public GameObject enemy_0;

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

        // ToDo created this in galactic game level from combat ships and stations in the combat sector
        public string[] friendArray; // = new string[] { "Fed_Cruiser_ii", "Fed_Cruiser_ii", "Fed_Destroyer_ii" };
        public string[] enemyArray; //= new string[] { "Kling_Cruiser_ii", "Kling_Cruiser_ii", "Kling_Scout_ii", "Kling_Scout_ii" };
        private int friendShipLayer;
        private int enemyShipLayer;

        //public Text textScore;
        public Text textShips_0;
        public Text textShips_1;

        public GameObject panelMenu;
        public GameObject panelPlay;
        public GameObject panelCompleted;
        public GameObject panelGameOver;
        //public GameObject[] levels;
        public static GameManager Instance { get; private set; } // a static singleton, imporve this later

        //List<Tuple<CombatUnit, CombatWeapon[]>> // will we need to us this here too?
        public enum State { MENU, INIT, PLAY, COMPLETED, LOADNEXT, GAMEOVER };
        private State _state;
        bool _isSwitchingState;

        private bool _statePassedInit = false;
        public bool StatePassedInit { get { return _statePassedInit; } set { _statePassedInit = value; } }
        //private int _score;
        private int _ships_0 = 2;
        private int _ships_1 = 2;

        //public int Score
        //{
        //    get { return _score; }
        //    set
        //    {
        //        _score = value;
        //        textScore.text = "SCORE: " + _score;
        //    }
        //}

        public int Ships_0
        {
            get { return _ships_0; }
            set
            {
                _ships_0 = value;
                textShips_0.text = "SHIPS: " + _ships_0;
            }
        }


        public int Ships_1
        {
            get { return _ships_1; }
            set
            {
                _ships_1 = value;
                textShips_1.text = "SHIPS: " + _ships_1;
            }
        }

        public void PlayClicked()
        {
            SwitchtState(State.INIT);
        }
        private void Awake()
        {

        }

        // Start is called before the first frame update
        void Start()
        {
            Instance = this;
            SwitchtState(State.MENU);

            Dictionary<string, GameObject> prefabDitionary = new Dictionary<string, GameObject>() // !! only try to load prefabs that exist
            {
                { "Fed_Destroyer_i", Fed_Destroyer_i }, //{ "Fed_Scout_i", Fed_Scout_i },
                { "Fed_Cruiser_ii", Fed_Cruiser_ii }, { "Fed_Destroyer_ii", Fed_Destroyer_ii }, { "Fed_Scout_ii", Fed_Scout_ii },
                { "Fed_Cruiser_iii", Fed_Cruiser_iii }, //{ "Fed_Destroyer_iii", Fed_Destroyer_iii }, { "Fed_Scout_iii", Fed_Scout_iii },
                { "Kling_Cruiser_ii", Kling_Cruiser_ii }, //{ "Kling_Destroyer_ii", Kling_Destroyer_ii },
                                                         { "Kling_Scout_ii", Kling_Scout_ii }
            };

            // load friend grid
            friendArray = new string[] { "Fed_Cruiser_ii", "Fed_Cruiser_ii", "Fed_Destroyer_ii" };
            List<GameObject> emptyFriendMarkers = new List<GameObject>() { friend_0 };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameObject _tempFriend = Instantiate(friend_0, new Vector3(-300, i * 300, j * 350), Quaternion.identity);
                    _tempFriend.transform.Rotate(0, 90, 0);
                    emptyFriendMarkers.Add(_tempFriend);
                }
                for (int j = 3; j < 6; j++)
                {
                    GameObject _tempFriend = Instantiate(friend_0, new Vector3(-300, i * 300, j * 350), Quaternion.identity);
                    _tempFriend.transform.Rotate(0, 90, 0);
                    emptyFriendMarkers.Add(_tempFriend);
                }
                for (int j = 6; j < 9; j++)
                {
                    GameObject _tempFriend = Instantiate(friend_0, new Vector3(-300, i * 300, j * 350), Quaternion.identity);
                    _tempFriend.transform.Rotate(0, 90, 0);
                    emptyFriendMarkers.Add(_tempFriend);
                }
                for (int j = 9; j < 12; j++)
                {
                    GameObject _tempFriend = Instantiate(friend_0, new Vector3(-300, i * 300, j * 350), Quaternion.identity);
                    _tempFriend.transform.Rotate(0, 90, 0);
                    emptyFriendMarkers.Add(_tempFriend);
                }
                for (int j = 12; j < 15; j++)
                {
                    GameObject _tempFriend = Instantiate(friend_0, new Vector3(-300, i * 300, j * 350), Quaternion.identity);
                    _tempFriend.transform.Rotate(0, 90, 0);
                    emptyFriendMarkers.Add(_tempFriend);
                }
                for (int j = 15; j < 18; j++)
                {
                    GameObject _tempFriend = Instantiate(friend_0, new Vector3(-300, i * 300, j * 350), Quaternion.identity);
                    _tempFriend.transform.Rotate(0, 90, 0);
                    emptyFriendMarkers.Add(_tempFriend);
                }
                for (int j = 18; j < 21; j++)
                {
                    GameObject _tempFriend = Instantiate(friend_0, new Vector3(-300, i * 300, j * 350), Quaternion.identity);
                    _tempFriend.transform.Rotate(0, 90, 0);
                    emptyFriendMarkers.Add(_tempFriend);
                }
                emptyFriendMarkers.RemoveAt(0);
            }

            // load enemy grid
            //enemy_0.transform.localScale = new Vector3(transform.localScale.x + 400f, transform.localScale.y + 400f, transform.localScale.z + 400f);
            enemyArray = new string[] { "Kling_Cruiser_ii", "Kling_Cruiser_ii", "Kling_Scout_ii", "Kling_Scout_ii" };
            List<GameObject> emptyEnemyMarkers = new List<GameObject>() { enemy_0 };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameObject _tempEnemy = Instantiate(enemy_0, new Vector3(500, i * 300, j * 350), Quaternion.identity);
                    _tempEnemy.transform.Rotate(0, -90, 0);
                    emptyEnemyMarkers.Add(_tempEnemy);
                }
                for (int j = 3; j < 6; j++)
                {
                    GameObject _tempEnemy = Instantiate(enemy_0, new Vector3(500, i * 300, j * 350), Quaternion.identity);
                    _tempEnemy.transform.Rotate(0, -90, 0);
                    emptyEnemyMarkers.Add(_tempEnemy);
                }
                for (int j = 6; j < 9; j++)
                {
                    GameObject _tempEnemy = Instantiate(enemy_0, new Vector3(500, i * 300, j * 350), Quaternion.identity);
                    _tempEnemy.transform.Rotate(0, -90, 0);
                    emptyEnemyMarkers.Add(_tempEnemy);
                }
                for (int j = 9; j < 12; j++)
                {
                    GameObject _tempEnemy = Instantiate(enemy_0, new Vector3(500, i * 300, j * 350), Quaternion.identity);
                    _tempEnemy.transform.Rotate(0, -90, 0);
                    emptyEnemyMarkers.Add(_tempEnemy);
                }
                for (int j = 12; j < 15; j++)
                {
                    GameObject _tempEnemy = Instantiate(enemy_0, new Vector3(500, i * 300, j * 350), Quaternion.identity);
                    _tempEnemy.transform.Rotate(0, -90, 0);
                    emptyEnemyMarkers.Add(_tempEnemy);
                }
                for (int j = 15; j < 18; j++)
                {
                    GameObject _tempEnemy = Instantiate(enemy_0, new Vector3(500, i * 300, j * 350), Quaternion.identity);
                    _tempEnemy.transform.Rotate(0, -90, 0);
                    emptyEnemyMarkers.Add(_tempEnemy);
                }
                for (int j = 18; j < 21; j++)
                {
                    GameObject _tempEnemy = Instantiate(enemy_0, new Vector3(500, i * 300, j * 350), Quaternion.identity);
                    _tempEnemy.transform.Rotate(0, -90, 0);
                    emptyEnemyMarkers.Add(_tempEnemy);
                }
                emptyEnemyMarkers.RemoveAt(0);
            }

            // Get ship layers
            string readFriendName = friendArray[0].ToUpper();
            string[] _collFriend = readFriendName.Split('_');
            SetShipLayer(_collFriend[0], FriendOrFoe.friend);

            string readEnemyName = enemyArray[0].ToUpper();
            string[] _collEnemy = readEnemyName.Split('_');
            SetShipLayer(_collEnemy[0], FriendOrFoe.enemy);

            //instantiate prefab ships from friendArray onto as may emptyFriendMarkers using the prefab dictionary
            for (int i = 0; i < friendArray.Count(); i++)
            {
                GameObject _tempPrefabFriend = (GameObject)Instantiate(prefabDitionary[friendArray[i]], emptyFriendMarkers[i].transform.position, emptyFriendMarkers[i].transform.rotation);
                _tempPrefabFriend.transform.SetParent(emptyFriendMarkers[i].transform, true);
                _tempPrefabFriend.transform.localScale = new Vector3(transform.localScale.x * 400f, transform.localScale.y * 400f, transform.localScale.z * 400f);
                Ship.SetLayerRecursively(emptyFriendMarkers[i], friendShipLayer);
            }

            for (int i = 0; i < enemyArray.Count(); i++)
            {
                GameObject _tempPrefabEnemy = (GameObject)Instantiate(prefabDitionary[enemyArray[i]], emptyEnemyMarkers[i].transform.position, emptyEnemyMarkers[i].transform.rotation);
                _tempPrefabEnemy.transform.SetParent(emptyEnemyMarkers[i].transform, true);
                _tempPrefabEnemy.transform.localScale = new Vector3(transform.localScale.x * 400f, transform.localScale.y * 400f, transform.localScale.z * 400f);
                Ship.SetLayerRecursively(emptyEnemyMarkers[i], enemyShipLayer);
            }
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
                    //Instantiate(playerPrefab);
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
        
      

    }
}
