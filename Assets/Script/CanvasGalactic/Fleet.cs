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
        public Transform _location;
        //public GameObject _fleetPointOnGalaxyFloor;
        public Canvas canvasGalactic;
        //public GalaxyDropLine galaxyDropLine;
        public Transform _galaxyPlanePoint;
        private LineRenderer _lineRenderer;
        private float counter;
        private float distance;
        //public float _lineDrawSpeed = 6f;
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
        public Fleet(List<GalaxyShip> ships) //, Transform where)
        {
            shipsInFeet = ships;
            //_location = where;
        }
        private void Update()
        {
            if (GalaxyView._movingGalaxyObjects.Contains(this.gameObject))
            {
                //this._galaxyPlanePoint = new Transform()
                this.CreateGalaxyFloorEndPoint();
            }
        }
        public void CreateGalaxyFloorEndPoint() // and create dropline
        {
            // Now we use TimeManager and MoveGalacticObject to move
            //if (inDeepSpace)
            //    Move();
            if (this._location != null)
            {
                int x = (int)this._location.position.x;
                int y = (int)this._location.position.y;
                int z = 600;
                Vector3 worldSpace = new Vector3(x, y, z);
                GameObject emptyForFleetGalacticFloor = new GameObject();//Instantiate(_fleetLineEndpointPrefab, new Vector3(x, y, 600f), Quaternion.identity);
                emptyForFleetGalacticFloor.transform.position = worldSpace;
                _galaxyPlanePoint = emptyForFleetGalacticFloor.transform;


                emptyForFleetGalacticFloor.transform.SetParent(canvasGalactic.transform, false);
                emptyForFleetGalacticFloor.layer = 6;
                emptyForFleetGalacticFloor.name = this.name + "_FleetEndPoint";
                _galaxyPlanePoint = emptyForFleetGalacticFloor.transform;
                //GalaxyDropLine fleetLine = Instantiate(dropLine, worldSpace, Quaternion.identity);
                ////firstFleet._galaxyPlanePoint = emptyForFleetPlanePoint.transform;

                //Transform[] endFleetPoints = new Transform[2] { this.transform, emptyForFleetGalacticFloor.transform };
                //fleetLine.SetUpLine(endFleetPoints);
            }
        }

        void Move()
        {
            //transform.position += transform.forward * warpSpeed * Time.deltaTime;
        }
        void SetTarget()
        {
            //newTarget = true;
            inDeepSpace = true;
        }
        //public void SendTheAllSystemsList(List<GameObject> dalist)
        //{
        //    destinationList = dalist;
        //}
        void Pathfinding()
        {

        }
    }
}
