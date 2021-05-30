using System;
using UnityEngine;

namespace Assets.Script
{
    class PointerInstance : MonoBehaviour
    {
        // the FedPointerPrefab in scene has this code on it
        public GameObject PointPrefab;

        void Start()
        {          
           // Instantiate(PointPrefab, new Vector3(0,0,0), Quaternion.identity);
        }
    }
}
