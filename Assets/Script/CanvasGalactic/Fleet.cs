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
    public class Fleet : MonoBehaviour
    {
        public List<GalaxyShip> galaxyShipList = new List<GalaxyShip>();
       // public GameManager gameManager; // grant access to GameManager by assigning it in the Unit inspector field for public gameManager
        public CivEnum _civilization;
        public float _techPoints;
        public Transform _origin;
        public Transform _destination;
        public Transform _location;
        private LineRenderer _lineRenderer;
        private float counter;
        private float distance;
        public float _lineDrawSpeed = 6f;
        public Sprite _insigniaSprite;

        public Fleet(List<GalaxyShip> ships)
        {
            galaxyShipList = ships;
        }

        private void Awake() // what civs are in game and need a fleet???
        {
            //string[] nameArray = new string[3] { "civilization", "shipType", "era" };
            //if (this.name != "Ship")
            //{
            //    nameArray = this.name.Split('_');
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

        // Update is called once per frame
        void Update()
        {

        }
    }
}
