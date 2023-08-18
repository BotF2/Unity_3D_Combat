using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BOTF3D_Core;
using BOTF3D_Combat;
using Assets.Script;

namespace BOTF3D_GalaxyMap
{

    public class GalaxyDropLine : MonoBehaviour
    {
        private LineRenderer lineRenderer;
        private Transform[] points;

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
        public void SetUpLine(Transform[] points)
        {
            lineRenderer.positionCount = points.Length;
            this.points = points;
        }
    }
}
