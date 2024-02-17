using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Core;
//using BOTF3D_Combat;
//using BOTF3D_Core;
using UnityEngine.UI;
using System;

namespace GalaxyMap
{

    public class SliderLock : MonoBehaviour
    {
        public Sprite unlocked;
        public Sprite locked;
        public Button button;

        public void ClickLock()
        {
            if (button.image.sprite == unlocked)
            {
                button.image.sprite = locked;
            }

            else
            {
                button.image.sprite = unlocked;
            }
        }
    }
}
