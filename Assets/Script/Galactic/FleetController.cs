
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Core;

namespace GalaxyMap
{
    public class FleetController: MonoBehaviour
    {
        public FleetData fleetData;
        public Camera camGalactica;
        [SerializeField, Tooltip("Warp Factor.")]
        private float warpFactor;
        private float maxWarp;
        private Transform cameraGalacticTransform;

        private void Awake()
        {
            warpFactor = fleetData.warpFactor;   
            maxWarp =   fleetData.maxWarpFactor;
        }
        private void Start()
        {
            cameraGalacticTransform = camGalactica.transform;
        }
        private void Update()
        {
            if(Physics.Raycast(new Ray(transform.position, transform.forward), out RaycastHit hitInfo, fleetData.warpFactor *Time.deltaTime))
            {
                transform.position = hitInfo.point;
                //hitInfo.collider.SendMessage("IntersectingFleets", fleetData.IntersectingFleet, SendMessageOptions.DontRequireReceiver);
                //GetComponent<MeshRenderer>().enabled = false;
                //fleetData.IntersectingFleets(hitInfo.transform.gameObject);
            }
        }
        public void UpdateShipList()
        {
            
        }

    }
}

