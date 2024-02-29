using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Core;

[CreateAssetMenu(menuName = "Galaxy/StarSysSO")]
public class StarSysSO : ScriptableObject
{
    public int StarSysInt;
    public int _x;
    public int _y;
    public int _z;
    public Vector3 Position;
    public string sysName;
    public CivEnum starSystemFirstOwner;
    public StarType starSystemType;
    public string _originalOwnerName;
    public Sprite starSprit;
}
