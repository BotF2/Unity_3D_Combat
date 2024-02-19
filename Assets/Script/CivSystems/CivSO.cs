using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GalaxyMap;

namespace Assets.Core
{
    [CreateAssetMenu(fileName = "CivSO", menuName = "Civ")]
    public class CivSO : ScriptableObject
    {
        //[SerializeField] Sprite insignSprite; // civ insignia
        //[SerializeField] string description;
        //[SerializeField] CivEnum civOwnerEnum;
        [HideInInspector] public GameObject myObject;
        [HideInInspector] public string civName;
        [HideInInspector] public int civInt;
    }
}