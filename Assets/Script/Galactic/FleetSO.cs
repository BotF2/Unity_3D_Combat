
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Core;
using Unity.VisualScripting;

[CreateAssetMenu(menuName = "Galaxy/FleetSO")]
public class FleetSO : ScriptableObject
{
    public Sprite Insignia;
    public CivEnum CivOwnerEnum;
    public float DefaultWarpFactor = 0f;

}





