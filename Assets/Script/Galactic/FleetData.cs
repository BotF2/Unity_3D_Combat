using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Core;
using UnityEngine.UI;

namespace GalaxyMap
{
    public class FleetData : MonoBehaviour
    {
        public new string name;
        public string description;
        public Sprite insign;
        public Vector3 currentPosition;
        public CivEnum civOwnerEnum;
        public List<Ship> galaxyShips; // ToDo make a GalaxyShip scriptable obj for the list
        public int fleetNum;
        public float maxWarpFactor;
        public float warpFactor; 
        public float defaultWarp = 0;
        public GameObject targetDestination;
        public GameObject thisGameObject;
        public GameObject IntersectingFleet { get; set; }
        public void IntersectingFleets(GameObject go)
        {
            
        }
    }
}
