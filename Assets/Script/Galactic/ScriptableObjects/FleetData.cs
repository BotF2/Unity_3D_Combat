
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Core;

namespace GalaxyMap
{
    [CreateAssetMenu(menuName = "Galaxy/FleetData")]
    public class FleetData: ScriptableObject
    {
        public new string name;
        public string description;
        public Sprite insign;
        public Vector3 location;
        public Civilization civOwnerEnum;
        public List<Ship> ships;
        //[SerializeField]
        public float warpFactor; // public?
        //public GameObject destination;
        //public GameObject origin;
        public float defaultWarp =0;
        [HideInInspector]
        public GameObject myObject;

        public void ResetData()
        {
            myObject = null;
            warpFactor = defaultWarp;
            location = Vector3.zero;
        }
    }
}

