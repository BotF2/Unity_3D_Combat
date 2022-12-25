using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;
using BOTF3D_Combat;
using BOTF3D_Core;
using System;
using System.Linq;
using UnityEngine.Rendering.VirtualTexturing;
using TMPro;

namespace BOTF3D_GalaxyMap
{
    public class DropdownSystems : MonoBehaviour
    {
        public TMPro.TMP_Dropdown resolutionDropdown; // get DropdownSystems menu
        public GameManager _gameManager;
        public Civ? _localPlayer;
        private List<string> _systemsList;

        public void Awake()
        {
            _systemsList = new List<string>() { "Earth System/Sol", "Vulcan System/40 Eridani A", "Andorian System/Andoria" };
            resolutionDropdown.AddOptions(_systemsList);
        }

        public void Update()
        {
            if (_gameManager._statePassedMain_Init)
            {
                if (_localPlayer == null)
                    _localPlayer = _gameManager._localPlayer;
                UpdateSystems();
            }
        }
        void UpdateSystems()
        {
            switch (_localPlayer)
            {
                case Civ.FED:
                    FindCivSystems((int)Civ.FED);
                    break;
                case Civ.ROM:
                    FindCivSystems((int)Civ.ROM);
                    break;
                case Civ.KLING:
                    FindCivSystems((int)Civ.KLING);
                    break;
                case Civ.CARD:
                    FindCivSystems((int)Civ.CARD);
                    break;
                case Civ.DOM:
                    FindCivSystems((int)Civ.DOM);
                    break;
                case Civ.BORG:
                    FindCivSystems((int)Civ.BORG);
                    break;
                default:
                    break;
            }
        }
        private void FindCivSystems(int civID)
        {
            //resolutionDropdown.options.Clear(); // Clear Options

            //ToDo: go get current owned system, _systemList field as string names of systems, for Local Player

            //resolutionDropdown.AddOptions(_systemsList);
               
        }
    }
}
