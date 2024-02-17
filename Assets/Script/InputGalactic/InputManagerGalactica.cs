using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using BOTF3D_Combat;
//using BOTF3D_Core;
using GalaxyMap;

namespace Assets.Core
{
    public abstract class InputManagerGalactica : MonoBehaviour
    {
        public delegate void MoveInputHandler(Vector3 moveVector);
        public delegate void RotateInputHandler(float rotateAmount);
        public delegate void ZoomInputHandler(float zomeAmount);

    }
}
