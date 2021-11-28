using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.Script
{
    public class CombatOrderSelection : MonoBehaviour, IPointerDownHandler
    {

        Toggle _activeToggle;
        public Toggle Engage, Rush, Retreat, Formation, Transports;
        ToggleGroup CombatGroup;

        private void Awake()
        {
            Engage.isOn = true;
            Rush.isOn = false;
            Retreat.isOn = false;
            Formation.isOn = false;
            Transports.isOn = false;
        }
        private void Start()
        {
            CombatGroup = GetComponent<ToggleGroup>();
            CombatGroup.enabled = true;
            Engage.isOn = true;
            Engage.Select();
            Engage.OnSelect(null); // turns background selected color on, go figure.
            Rush.isOn = false;
            Retreat.isOn = false;
            Formation.isOn = false;
            Transports.isOn = false;
        }
        private void Update()
        {
            _activeToggle = CombatGroup.ActiveToggles().ToArray().FirstOrDefault();
            ActiveToggle();
        }
        //public void OnClickPlayCiv() // ToDo: call this on play button in Main Menu
        //{
        //    Toggle toggle = _activeToggle;
        //    Debug.Log(toggle.name + " _ ");
        //}
        public void ActiveToggle()
        {
            switch (_activeToggle.name.ToUpper())
            {
                case "TOGGLE_ENGAGE":
                    Engage = _activeToggle;
                    GameManager.Instance._combatOrder = Orders.Engage;
                    Debug.Log("Active Engage.");
                    break;
                case "TOGGLE_RUSH":
                    Debug.Log("Active Rush.");
                    Rush = _activeToggle;
                    GameManager.Instance._combatOrder = Orders.Rush;
                    break;
                case "TOGGLE_RETREAT":
                    Debug.Log("Active Retreat.");
                    Retreat = _activeToggle;
                    GameManager.Instance._combatOrder = Orders.Retreat;
                    break;
                case "TOGGLE_FORMATION":
                    Debug.Log("Active Formation.");
                    Formation = _activeToggle;
                    GameManager.Instance._combatOrder = Orders.Formation;
                    break;
                case "TOGGLE_TRANSPORTS":
                    Debug.Log("Active Transports.");
                    Transports = _activeToggle;
                    GameManager.Instance._combatOrder = Orders.AttackTransports;
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

