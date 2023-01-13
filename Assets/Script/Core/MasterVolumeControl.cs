using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BOTF3D_GalaxyMap;
using Assets.Script;
using BOTF3D_Combat;

namespace BOTF3D_Core
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
