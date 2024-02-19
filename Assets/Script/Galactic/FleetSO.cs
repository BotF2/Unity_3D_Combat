using Assets.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GalaxyMap
{

    [CreateAssetMenu(menuName = "Galaxy/FleetSO")]
    public class FleetSO : ScriptableObject
    {
        [SerializeField] Sprite insignSprite; // civ insignia
        [SerializeField] string description;
        [SerializeField] CivEnum civOwnerEnum;
        [SerializeField] float warpFactor =0f;
        [SerializeField] float defaultWarp = 0f;
        [HideInInspector] public GameObject myObject;
        [HideInInspector] public Vector3 currentPosition;

        public void ResetSO()
        {
            myObject = null;
            warpFactor = defaultWarp;
            currentPosition = Vector3.zero;    
        }

    }
}
