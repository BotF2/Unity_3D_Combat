using GalaxyMap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetController : MonoBehaviour
{
    //Fields
    public FleetData fleetData;
    
    public void UpdateWarpFactor(int delta)
    {
       fleetData.warpFactor += delta ;
    }
}
