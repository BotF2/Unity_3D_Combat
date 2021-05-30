using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script
{
    static class ShipMoveHelper
    {
        private static int _xDepth = -900;
        private static int _yHeight = -900;
     
        internal static int XDepth()
        {
            _xDepth = _xDepth + 400;


            return _xDepth; 
        }
        internal static int YHeight()
        {
            _yHeight = _yHeight + 400;


            return _yHeight; 
        }

    }
}
