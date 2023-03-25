using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using Assets.Script;
using BOTF3D_Core;
using BOTF3D_Combat;

namespace BOTF3D_GalaxyMap
{
    public class GalaxyShip : MonoBehaviour // Do We Need this as well as Fleet?????
    {
        public GameManager gameManager; // grant access to GameManager by assigning it in the Unit inspector field for public gameManager
                                        //public Combat combat;
        public CivEnum _civilization;
        public ShipType _shipType;
        //public float _techPoints; // this comes from the owner civ so fill it in once in combat, not here

        private void Awake()
        {
            //string[] nameArray = new string[3] { "civilization", "shipType", "era" };
            //if (this.name != "Ship")
            //{
            //    nameArray = this.name.Split('_');
            //}
            //string typeOfShip = nameArray[1];

            //switch (typeOfShip.ToUpper())
            //{
            //    case "SCOUT":
            //        _shipType = ShipType.Scout;
            //        break;
            //    case "DESTROYER":
            //        _shipType = ShipType.Destroyer;
            //        break;
            //    case "CURISER":
            //        _shipType = ShipType.Cruiser;
            //        break;
            //    case "LTCURISER":
            //        _shipType = ShipType.LtCruiser;
            //        break;
            //    case "HVYCURISER":
            //        _shipType = ShipType.HvyCruiser;
            //        break;
            //    case "TRANSPORT":
            //        _shipType = ShipType.Transport;
            //        break;
            //    case "COLONYSHIP":
            //        _shipType = ShipType.Colonyship;
            //        break;
            //    case "ONEMORE":
            //        _shipType = ShipType.OneMore;
            //        break;
            //    default:
            //        break;
            //}
            //string civ = nameArray[0];
            //switch (civ.ToUpper())
            //{
            //    case "FED":
            //        _civilization = CivEnum.FED;
            //        break;
            //    //case "TERRAN":
            //    //    _civilization = Civilization.TERRAN;
            //    //    break;
            //    case "ROM":
            //        _civilization = CivEnum.ROM;
            //        break;
            //    case "KLING":
            //        _civilization = CivEnum.KLING;
            //        break;
            //    case "CARD":
            //        _civilization = CivEnum.CARD;
            //        break;
            //    case "DOM":
            //        _civilization = CivEnum.DOM;
            //        break;
            //    case "BORG":
            //        _civilization = CivEnum.BORG;
            //        break;
            //    default:
            //        //_civilization = CivEnum.ACAMARIANS;
            //        break;
            //}
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
