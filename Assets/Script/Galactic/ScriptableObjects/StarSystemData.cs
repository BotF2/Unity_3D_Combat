using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Core;

namespace GalaxyMap
{
    [CreateAssetMenu(menuName = "Galaxy/SystemData")]
    public class StarSystemData : ScriptableObject
    {
        public new string name;
        public string description;
        public Sprite starSprit;
        public string thisSystem;
        public Vector3 location;
        [SerializeField]
        public int sysIn;
        public Civilization civOwnerEnum;
        [HideInInspector]
        public GameObject myObject;


        public void ResetData()
        {
            myObject = null;
            location = Vector3.zero;
        }
    }
}

