using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using BOTF3D_Core;
using Assets.Script;
using BOTF3D_Core;
using Assets.Script;

namespace BOTF3D_GalaxyMap
{

    public class NextSolarSystem : MonoBehaviour
    {
        public GameObject solarSystemView;

        public void ShowThisSolarSystemView(int buttonSystemID)
        {
            solarSystemView = GameObject.Find("SolarSystemView");
            SolarSystemView view = solarSystemView.GetComponent<SolarSystemView>();
            view.ShowNextSolarSystemView(buttonSystemID);

        }
    }
}
