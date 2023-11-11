using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BOTF3D_Core;
using BOTF3D_Combat;
using Assets.Script;
using System;

namespace BOTF3D_GalaxyMap
{

    public class GalaxyDropLine : MonoBehaviour
    {
        //private GameObject gameObject;
        private LineRenderer lineRenderer;
        private Transform[] points;

        private void Awake()
        {       
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.gameObject.layer = 6; 
        }

        public void SetUpLine(Transform[] points)
        {     
            //lineRenderer.alignment = LineAlignment.TransformZ;
            lineRenderer.positionCount = points.Length;
            this.points = points;
        }
        private void Update()
        {
            if (lineRenderer != null && points != null)
            {
                for (int i = 0; i < points.Length; i++ )
                {
                    lineRenderer.SetPosition(i, points[i].position);
                }
            }
        }
    }
}
