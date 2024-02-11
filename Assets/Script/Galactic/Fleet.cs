
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Core;
using Unity.VisualScripting;

namespace GalaxyMap
{
    public class Fleet : MonoBehaviour
    {
        public FleetData fleetData;
        public Text nameText;
        public Text descriptionText;
        public Image artworkImage;
        public float warpFactor;

        private void Start()
        {
            if (fleetData != null)
            {
                nameText.text = fleetData.name;
                descriptionText.text = fleetData.description;
                artworkImage.sprite = fleetData.insign;
                warpFactor = fleetData.warpFactor;
            }
        }
        private void OnEnable()
        {
            if(fleetData != null)
                fleetData.location = transform.position;
        }
        void Update()
        {
            if (fleetData != null)
            {
                fleetData.location = transform.position;
            }
        }

    }
}
