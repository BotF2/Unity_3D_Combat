using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BOTF3D_GalaxyMap;
using BOTF3D_Core;
using BOTF3D_Combat;

namespace Assets.Script
{
    public interface IZoomStrategy

    {
        void ZoomIn(Camera cam, float delta, float nearZoomLimit);
        void ZoomOut(Camera cam, float delta, float farZoomLimit);
    }
}
