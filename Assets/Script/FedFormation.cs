using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script
{
    class FedFormation : MonoBehaviour
    {
        public GameObject ship_0;
        public GameObject ship_1;
        public static float increamentZ = 400f;
        public int columns = 3;
        public List<GameObject> ships_Fed;
        private bool _justOnce = true;

        void Start()
        {
            StartHelper.Scale1000(ship_0);
            StartHelper.Scale1000(ship_1);
        }
        private void Update()
        {
            if (_justOnce && GameManager.Instance.StatePassedInit)
            {
                for (int z = 0; z < columns; z++)
                {
                    var newGameObject0 = Instantiate(ship_0, new Vector3(0, 0, z * increamentZ), Quaternion.identity);
                    StartHelper.RotatePlues90(newGameObject0);
                    ships_Fed.Add(newGameObject0);

                    var newGameObject1 = Instantiate(ship_1, new Vector3(0, 200f, z * increamentZ), Quaternion.identity);
                    StartHelper.RotatePlues90(newGameObject1);
                    ships_Fed.Add(newGameObject1);
                }
                _justOnce = false;
            }
        }
    }
}
