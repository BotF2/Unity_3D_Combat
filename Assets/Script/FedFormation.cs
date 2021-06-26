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
        public GameObject fed_0; // parent empty gameobjects
        public GameObject fed_1; // can use one parent for all or multiple parents 
        public GameObject fed_2;
        public GameObject fed_3;
        public GameObject fed_4;
        public GameObject fed_5;

        public GameObject fed_Cruiser_i_Prefab;
        public GameObject fed_Scout_i_Prefab;
        private GameObject Fed_Cruiser_i_0;
        private GameObject Fed_Cruiser_i_1;
        private GameObject Fed_Cruiser_i_2;
        private GameObject Fed_Scout_i_3;
        private GameObject Fed_Scout_i_4;
        private GameObject Fed_Scout_i_5;
        private void Awake()
        {
            //fed_Cruiser_i_0 = (GameObject)Instantiate(fed_Cruiser_i_Prefab, fed_0.transform.position, Quaternion.identity, fed_Cruiser_i_Prefab.transform);
            Fed_Cruiser_i_0 = (GameObject)Instantiate(fed_Cruiser_i_Prefab, fed_0.transform.position, fed_0.transform.rotation, fed_0.transform);
            Fed_Cruiser_i_1 = (GameObject)Instantiate(fed_Cruiser_i_Prefab, fed_1.transform.position, fed_1.transform.rotation, fed_1.transform);
            Fed_Cruiser_i_2 = (GameObject)Instantiate(fed_Cruiser_i_Prefab, fed_2.transform.position, fed_2.transform.rotation, fed_2.transform);
            Fed_Scout_i_3 = (GameObject)Instantiate(fed_Scout_i_Prefab, fed_3.transform.position, fed_3.transform.rotation, fed_3.transform);
            Fed_Scout_i_4 = (GameObject)Instantiate(fed_Scout_i_Prefab, fed_4.transform.position, fed_4.transform.rotation, fed_4.transform);
            Fed_Scout_i_5 = (GameObject)Instantiate(fed_Scout_i_Prefab, fed_5.transform.position, fed_5.transform.rotation, fed_5.transform);

            Fed_Cruiser_i_0.transform.SetParent(fed_0.transform, true);
            Fed_Cruiser_i_1.transform.SetParent(fed_1.transform, true);
            Fed_Cruiser_i_2.transform.SetParent(fed_2.transform, true);
            Fed_Scout_i_3.transform.SetParent(fed_3.transform, true);
            Fed_Scout_i_4.transform.SetParent(fed_4.transform, true);
            Fed_Scout_i_5.transform.SetParent(fed_5.transform, true);
            Ships.SetLayerRecursively(fed_0, 10); 
            Ships.SetLayerRecursively(fed_1, 10);
            Ships.SetLayerRecursively(fed_2, 10);
            Ships.SetLayerRecursively(fed_3, 10);
            Ships.SetLayerRecursively(fed_4, 10);
            Ships.SetLayerRecursively(fed_5, 10);
        }
    }
}
