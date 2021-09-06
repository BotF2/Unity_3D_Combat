using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class MasterVolumeControl : MonoBehaviour
    {
        public Slider slider;
        private void Start()
        {
            transform.GetComponentInChildren<AudioListener>().enabled = true;
            slider.value = 0.5f;
        }

        void Update()
        {
            AudioListener.volume = slider.value;
        }
    }
}
