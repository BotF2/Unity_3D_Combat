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
        [SerializeField] Transform target;
        public bool newTarget = false;
        public bool inDeepSpace = false;
        [SerializeField] float movementSpeed = 10f;
        [SerializeField] float rotationalDamp = .5f;
        public List<GameObject> destinationList;

        public Fleet(List<GalaxyShip> ships)
        {
            galaxyShipList = ships;
        }
        void Update()
        {
            //if (newTarget) // galaxy fleets always face camera, not turning
            //    Turn();
            if (inDeepSpace)
                Move();
        }
        //void Turn() // galaxy fleets always face camera, not turning
        //{
        //    if (target != null)
        //    {
        //        transform.rotation = Quaternion.LookRotation(target.position);
        //        newTarget = false;
        //        inDeepSpace = true;
        //    }
        //}
        void Move()
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
        void SetTarget()
        {
            newTarget = true;
            inDeepSpace = true;
        }
        public void SendTheAllSystemsList(List<GameObject> dalist)
        {
            destinationList = dalist;
        }
        void Pathfinding()
        {

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
    }
}
