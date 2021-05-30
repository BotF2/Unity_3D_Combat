using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script
{
    class KlingFormation : MonoBehaviour
    {
        public GameObject kling_Cruiser_i;
        public GameObject kling_Scout_i;
        public static float increamentX = 1155f;
        public static float increamentY = 200f;
        public static float increamentZ = 400f;
        public int columns = 3;
        public List<GameObject> ships_Kling;
        private bool _justOnce = true;
        
        void Start()
        {
            StartHelper.Scale1000(kling_Cruiser_i);
            StartHelper.Scale1000(kling_Scout_i);
        }
        private void Update()
        {            
            if (_justOnce && GameManager.Instance.StatePassedInit)
            {
                for (int z = 0; z < columns; z++)
                {
                    GameObject newGameObject0 = Instantiate(kling_Cruiser_i, new Vector3(increamentX, 0, z * increamentZ), Quaternion.identity);
                    StartHelper.RotateNegative90(newGameObject0);
                    ships_Kling.Add(newGameObject0);

                    GameObject newGameObject1 = Instantiate(kling_Scout_i, new Vector3(increamentX, increamentY, z * increamentZ), Quaternion.identity);
                    StartHelper.RotateNegative90(newGameObject1);
                    ships_Kling.Add(newGameObject1);
                }
                _justOnce = false;
            }
        }

        //public List<GameObject> KlingShips()
        //{
        //    return ships_Kling;
        //}
    }
}
