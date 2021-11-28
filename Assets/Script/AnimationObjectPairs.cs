﻿using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Script
{
    public class AnimationObjectPair :MonoBehaviour
    {
        public GameObject[] _objectPair = new  GameObject[2];
        public AnimationObjectPair(GameObject child, GameObject parent)
        {
            this._objectPair = new GameObject[] { child, parent };
        }
    }
}