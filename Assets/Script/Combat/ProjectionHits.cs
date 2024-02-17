﻿using System;
using GalaxyMap;
//using BOTF3D_Core;
//using Assets.Script;

namespace Assets.Core
{
    class ProjectionHits
    {
        public float Max { get; private set; }
        public float Min { get; private set; }

        public ProjectionHits(float max, float min)
        {
            Min = min;
            Max = max;
        }

        public ProjectionHits AddPadding(float paddingToMax, float paddingToMin)
        {
            return new ProjectionHits(Max + paddingToMax, Min - paddingToMin);
        }
    }
}
