using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{

    public class GameManager : MonoBehaviour
    {
        public Text textScore;
        public Text textShips_0;
        public Text textShips_1;

        //public List<GameObject> fedPrefabs;
        //public List<GameObject> terranPrefabs;
        //public List<GameObject> romPrefabs;
        //public List<GameObject> klingPrefabs;
        //public List<GameObject> cardPrefabs;
        //public List<GameObject> domPrefabs;
        //public List<GameObject> borgPrefabs;

        public GameObject panelMenu;
        public GameObject panelPlay;
        public GameObject panelCompleted;
        public GameObject panelGameOver;
        //public GameObject[] levels;
        public static GameManager Instance { get; private set; } // a static singleton, imporve this later

        //List<Tuple<CombatUnit, CombatWeapon[]>>

        public enum State { MENU, INIT, PLAY, COMPLETED, LOADNEXT, GAMEOVER };
        private State _state;
        bool _isSwitchingState;
        
        private bool _statePassedInit = false;
        public bool StatePassedInit { get { return _statePassedInit; } set { _statePassedInit = value; } }
        private int _score;
        private int _ships_0 = 2;
        private int _ships_1 = 2;

        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                textScore.text = "SCORE: " + _score;
            }
        }

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

        // Start is called before the first frame update
        void Start()
        {
            Instance = this;
            SwitchtState(State.MENU);
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
                    Score = 0;
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
    }
}
