using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;
using BOTF3D_GalaxyMap;
using BOTF3D_Combat;
using BOTF3D_Core;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;

namespace BOTF3D_Core
{
    public class ProductionSliders : MonoBehaviour
    {       
        [SerializeField] private Sprite locked;
        [SerializeField] private Sprite unlocked;

        private float[] values; 
        [SerializeField] private Slider[] sliders;
        //private List<Slider> activeSlidersList;
        [SerializeField] private TextMeshProUGUI[] slideText;
        [SerializeField] private Button[] locks;

        void Start()
        {
            if (sliders.Length > 1)
            {
                for (int sliderIndex = 0; sliderIndex < sliders.Length; sliderIndex++)
                {
                    {
                        int i = sliderIndex;
                        Slider slider = sliders[sliderIndex];
                        SetRatio(slider, 1f / sliders.Length);
                        slider.onValueChanged.AddListener(_ => BalanceSliders(i));
                    }
                }
                values = Array.ConvertAll(sliders, GetRatio);
            }
            //activeSlidersList = sliders.ToList();
        }
        private void Update()
        {
            int lockCount = 0;
            for (int i = 0; i < sliders.Length; i++)
            {
                if (locks[i].image.sprite == locked)
                {
                    sliders[i].gameObject.SetActive(false);
                    lockCount++;
                }
                else if (locks[i].image.sprite == unlocked) // && activeSlidersList.Count() > 1)
                {
                    sliders[i].gameObject.SetActive(true);
                    lockCount--;
                }
                if (lockCount == 1)
                    for (int k = 0; k < sliders.Length; k++)
                    {
                        sliders[k].gameObject.SetActive(false);
                    }
                double j;
                j = Math.Round((double)sliders[i].value, 1);
                slideText[i].text = j.ToString();
            }
        }

        private void BalanceSliders(int updatedSliderIndex)
        {
            Slider updatedSlider = sliders[updatedSliderIndex];

            for (int sliderIndex = 0; sliderIndex < sliders.Length; sliderIndex++)
            {
                if (sliderIndex != updatedSliderIndex)
                {
                    if (locks[sliderIndex].image.sprite == locked)
                    {
                        continue;
                    }
                    Slider slider = sliders[sliderIndex];

                    float ratio = values[updatedSliderIndex] >= 1f - Mathf.Epsilon
                    ? 0
                    : values[sliderIndex] / (1 - values[updatedSliderIndex]);
                    float value = (1 - GetRatio(updatedSlider)) * ratio;

                    SetRatio(slider, value);
                }
            }

            for (int sliderIndex = 0; sliderIndex < sliders.Length; sliderIndex++)
            {
                values[sliderIndex] = GetRatio(sliders[sliderIndex]);
            }
        }

        private float GetRatio(Slider slider)
        {
            return Mathf.InverseLerp(slider.minValue, slider.maxValue, slider.value);
        }

        private void SetRatio(Slider slider, float ratio)
        {
            slider.SetValueWithoutNotify(Mathf.Lerp(slider.minValue, slider.maxValue, ratio));
        }
    }
}

