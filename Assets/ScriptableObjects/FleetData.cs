using Assets.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    [CreateAssetMenu]
    public class FleetData: ScriptableObject
    {
        public Vector3 location;
        public Civilization civOwnerEnum;
        public List<Ship> ships;
        public GameObject destination;
        public GameObject origin;

    }
}

