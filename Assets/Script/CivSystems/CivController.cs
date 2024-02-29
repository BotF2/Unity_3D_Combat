using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivController : MonoBehaviour
{
    //Fields
    public CivData civData;
    public void UpdateCredits()
    {
        civData.Credits += 50;
    }
}
