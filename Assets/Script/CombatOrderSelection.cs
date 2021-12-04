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
        public Toggle Engage, Rush, Retreat, Formation, ProtectTransports, TargetTransports;
        ToggleGroup CombatGroup;
        //private Orders _combatOrder;

        private void Awake()
        {
            Engage.isOn = true;
            Rush.isOn = false;
            Retreat.isOn = false;
            Formation.isOn = false;
            ProtectTransports.isOn = false;
            TargetTransports.isOn = false;
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
            ProtectTransports.isOn = false;
            TargetTransports.isOn = false;
        }
        private void Update()
        {
            _activeToggle = CombatGroup.ActiveToggles().ToArray().FirstOrDefault();
            ActiveToggle();
        }
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
                case "TOGGLE_PROTECT_TRANSPORTS":
                    Debug.Log("Active Protect Transports.");
                    ProtectTransports = _activeToggle;
                    GameManager.Instance._combatOrder = Orders.ProtectTransports;
                    break;
                case "TOGGLE_ATTACK_TRANSPORTS":
                    Debug.Log("Active Target Transports.");
                    TargetTransports = _activeToggle;
                    GameManager.Instance._combatOrder = Orders.TargetTransports;
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

