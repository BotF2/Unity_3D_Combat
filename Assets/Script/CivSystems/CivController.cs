using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GalaxyMap;

namespace Assets.Core
{
    public class CivController : MonoBehaviour
    {
        public CivData civData;
        public void UpdateCredits()
        {
            civData._civCredits += 50f;
        }
    }

}

