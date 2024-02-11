using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Core;

namespace GalaxyMap
{
    public class StarSystem : MonoBehaviour
    {
        public StarSystemData starSystemData;
        public Text nameText;
        public Text descriptionText;
        public Image artworkImage;

        private void Start()
        {
            if (starSystemData == null)
            {
                nameText.text = starSystemData.name;
                descriptionText.text = starSystemData.description;
                artworkImage.sprite = starSystemData.starSprit;
            }
        }
        private void OnEnable()
        {
            if (starSystemData != null)
            {
                starSystemData.location = transform.position;
            }
        }

        void Update()
        {
            if (starSystemData != null)
            {
                starSystemData.location = transform.position;
            }
        }
        private void OnDisable()
        {
            starSystemData.ResetData();
        }
    }
}