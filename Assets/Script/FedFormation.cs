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
        public GameObject fed_Cruiser_i;
        public GameObject fed_Scout_i;
        public static float increamentZ = 400f;
        public int columns = 3;
        public List<GameObject> ships_Fed;
        private bool _justOnce = true;

        void Start()
        {
            StartHelper.Scale1000(fed_Cruiser_i);
            StartHelper.Scale1000(fed_Scout_i);
        }
        private void Update()
        {
            if (_justOnce && GameManager.Instance.StatePassedInit)
            {
                for (int z = 0; z < columns; z++)
                {
                    GameObject newGameObject0 = Instantiate(fed_Cruiser_i, new Vector3(0, 0, z * increamentZ), Quaternion.identity);
                    StartHelper.RotatePlues90(newGameObject0);
                    ships_Fed.Add(newGameObject0);

                    GameObject newGameObject1 = Instantiate(fed_Scout_i, new Vector3(0, 200f, z * increamentZ), Quaternion.identity);
                    StartHelper.RotatePlues90(newGameObject1);
                    ships_Fed.Add(newGameObject1);
                }
                _justOnce = false;
            }
        }
    }
}
