﻿using UnityEngine;
using System;
using GalaxyMap;
//using BOTF3D_Core;
//using BOTF3D_Combat;

namespace Assets.Core
{
    class PositionAndRotation
    {
        public Vector3 Position { get; private set; }
        public Quaternion Rotation { get; private set; }

        public PositionAndRotation(Vector3 position, Quaternion rotation)
        {
            Position = position;
            Rotation = rotation;
        }
    }
}