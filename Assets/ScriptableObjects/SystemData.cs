using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Core;

namespace Galaxy 
{
    [CreateAssetMenu]
    public class SystemData : ScriptableObject
    {
        public Vector3 location;
        public int sysIn;
        //public string name;
        public Civilization civOwnerEnum;

    }
}

