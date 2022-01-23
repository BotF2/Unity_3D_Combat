using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Assets.Script
{
    [RequireComponent(typeof(Toggle))]
    public class CombatOrderSelection : MonoBehaviour, IPointerDownHandler
    {
        public static Toggle Engage, Rush, Retreat, Formation, ProtectTransports, TargetTransports;
        public List<Toggle> toggleOrderList = new List<Toggle>() { Engage, Rush, Retreat, Formation, ProtectTransports, TargetTransports};
        private Toggle _activeToggle;



        private void Update()
        {
            foreach (var toggle in toggleOrderList)
            {
                if (toggle.isOn)
                {
                    _activeToggle = toggle;
                    break;
                }
            }
            ActiveToggle(_activeToggle);
        }
        public void ActiveToggle(Toggle activeToggleOrder)
        {

            switch (activeToggleOrder.name.ToUpper())
            {
                case "TOGGLE_ENGAGE":
                    //Engage = _activeToggle;
                    GameManager.Instance._combatOrder = Orders.Engage;
                    Debug.Log("Active Engage.");
                    break;
                case "TOGGLE_RUSH":
                    Debug.Log("Active Rush.");
                    //Rush = _activeToggle;
                    GameManager.Instance._combatOrder = Orders.Rush;
                    break;
                case "TOGGLE_RETREAT":
                    Debug.Log("Active Retreat.");
                    //Retreat = _activeToggle;
                    GameManager.Instance._combatOrder = Orders.Retreat;
                    break;
                case "TOGGLE_FORMATION":
                    Debug.Log("Active Formation.");
                    //Formation = _activeToggle;
                    GameManager.Instance._combatOrder = Orders.Formation;
                    break;
                case "TOGGLE_PROTECT_TRANSPORTS":
                    Debug.Log("Active Protect Transports.");
                    //ProtectTransports = _activeToggle;
                    GameManager.Instance._combatOrder = Orders.ProtectTransports;
                    break;
                case "TOGGLE_TARGET_TRANSPORTS":
                    Debug.Log("Active Target Transports.");
                    //TargetTransports = _activeToggle;
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

