using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using BOTF3D_GalaxyMap;
using Assets.Script;
using BOTF3D_Combat;

namespace BOTF3D_Core
{

    public class CivSelection : MonoBehaviour, IPointerDownHandler
    {
        Toggle _activeToggle;
        public Toggle Fed, Kling, Rom, Card, Dom, Borg;
        public ToggleGroup CivilizationGroup;
        public GameObject Canvas;

        private void Awake()
        {
            Canvas = GameObject.Find("Canvas"); 
            var _mainMenu = Canvas.transform.Find("PanelMain_Menu").gameObject;
            var _civilizationGroup = _mainMenu.transform.Find("CIVILIZATIONS").gameObject;
            CivilizationGroup = _civilizationGroup.GetComponent<ToggleGroup>();
            CivilizationGroup.RegisterToggle(Fed);
            CivilizationGroup.RegisterToggle(Kling);
            CivilizationGroup.RegisterToggle(Rom);
            CivilizationGroup.RegisterToggle(Card);
            CivilizationGroup.RegisterToggle(Dom);
            CivilizationGroup.RegisterToggle(Borg);
            Fed.isOn = true;
            Kling.isOn = false;
            Rom.isOn = false;
            Card.isOn = false;
            Dom.isOn = false;
            Borg.isOn = false;           
        }
        private void Start()
        {
            CivilizationGroup.enabled = true;
            Fed.isOn = true;
            Fed.Select();
            Fed.OnSelect(null); // turns background selected color on, go figure.
            Kling.isOn = false;
            Rom.isOn = false;
            Card.isOn = false;
            Dom.isOn = false;
            Borg.isOn = false;
        }
        private void Update()
        {
            if (GameManager.Instance._statePassedLobbyInit)
            {
                _activeToggle = CivilizationGroup.ActiveToggles().ToArray().FirstOrDefault();
                if (_activeToggle != null)
                    ActiveToggle();
            }
        }
        public void ActiveToggle()
        {
            switch (_activeToggle.name.ToUpper())
            {
                case "TOGGLE_FED":
                    Fed = _activeToggle;
                    GameManager.Instance._localPlayer = Civilization.FED;
                    Debug.Log("Active Fed.");
                    break;
                case "TOGGLE_KLING":
                    Debug.Log("Active Kling.");
                    GameManager.Instance._localPlayer = Civilization.KLING;
                    Kling = _activeToggle;
                    break;
                case "TOGGLE_ROM":
                    Debug.Log("Active Rom.");
                    Rom = _activeToggle;
                    GameManager.Instance._localPlayer = Civilization.ROM;
                    break;
                case "TOGGLE_CARD":
                    Debug.Log("Active Card.");
                    Card = _activeToggle;
                    GameManager.Instance._localPlayer = Civilization.CARD;
                    break;
                case "TOGGLE_DOM":
                    Debug.Log("Active Dom.");
                    Dom = _activeToggle;
                    GameManager.Instance._localPlayer = Civilization.DOM;
                    break;
                case "TOGGLE_BORG":
                    Debug.Log("Active Borg.");
                    Borg = _activeToggle;
                    GameManager.Instance._localPlayer = Civilization.BORG;
                    break;
                default:
                    break;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            throw new NotImplementedException();
        }
    }
}
