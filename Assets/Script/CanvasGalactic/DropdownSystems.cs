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
        public CivEnum? _localPlayer;
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
                case CivEnum.FED:
                    FindCivSystems((int)CivEnum.FED);
                    break;
                case CivEnum.ROM:
                    FindCivSystems((int)CivEnum.ROM);
                    break;
                case CivEnum.KLING:
                    FindCivSystems((int)CivEnum.KLING);
                    break;
                case CivEnum.CARD:
                    FindCivSystems((int)CivEnum.CARD);
                    break;
                case CivEnum.DOM:
                    FindCivSystems((int)CivEnum.DOM);
                    break;
                case CivEnum.BORG:
                    FindCivSystems((int)CivEnum.BORG);
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
