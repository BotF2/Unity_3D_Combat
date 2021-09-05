using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class MasterVolumeControl : MonoBehaviour
    {
        [Range(0.0f, 1.0f)]
        [SerializeField]
        public Slider slider;

        void Update()
        {
            AudioListener.volume = slider.value;
            slider.value = 0.5f;

        }
    }
}
