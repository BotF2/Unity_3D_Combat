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
        public List<GalaxyShip> shipsInFeet = new List<GalaxyShip>();
        public CivEnum _civilization;
        public float _techPoints;
        //public Transform _origin;
        //public Transform _destination;
        //public Transform _loca;

        public Canvas canvasGalactic;

        public GameObject galaxyPlaneGO;
        //private LineRenderer _lineRenderer;
        private float counter;
        private float distance;

        public Sprite _insigniaSprite;
        //[SerializeField] Transform target;
        //public bool newTarget = false;
        public bool inDeepSpace = false;
        public float warpSpeed = 0f;
       // [SerializeField] float rotationalDamp = .5f;
        //public List<GameObject> destinationList;
       // public MoveGalacticObjects moveGalacticObjects;

        public void Awake()
        {
            GameObject canvasObject = GameObject.Find("CanvasGalactic");
            canvasGalactic = canvasObject.GetComponent<Canvas>();
        }
        public Fleet(List<GalaxyShip> ships) 
        {
            shipsInFeet = ships;
            //_location = where;
        }
        private void Update()
        {
 
        }

        void SetTarget()
        {
            //newTarget = true;
            inDeepSpace = true;
        }

        void Pathfinding()
        {

        }
    }
}
