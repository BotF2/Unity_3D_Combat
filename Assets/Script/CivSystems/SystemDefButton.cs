using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Core;
//using BOTF3D_GalaxyMap;
//using BOTF3D_Combat;
//using BOTF3D_Core;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;

namespace GalaxyMap
{

    public class SystemDefButton : MonoBehaviour
    {
        [SerializeField] private Text daSysText;
        public void SetText(string sysName)
        {
            daSysText.text = sysName;
        }
        public void SetButton()
        {

        }
        public void OnClick()
        {
            
        }
    }
}
