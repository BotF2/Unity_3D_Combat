using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Assets.Script;
using BOTF3D_GalaxyMap;
using BOTF3D_Combat;
using UnityEngine.UI;
using DG.Tweening.Core.Easing;
//using MLAPI;
//using UnityEngine.UI;

namespace BOTF3D_Core
{
    public class AlphaChange : MonoBehaviour
    {
        [SerializeField] private Material myMaterial;

        private void Start()
        {
            Color color = myMaterial.color;
            color.a = 0.05f;
            myMaterial.color = color;
        }
    }
}
