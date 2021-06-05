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
        //public List<GameObject> parentArray = new GameObject(){fed_0, fed_1, fed_2, fed_3, fed_4, fed_5 }; // not working
        //public Animation anim;
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
            Fed_Cruiser_i_0 = (GameObject)Instantiate(fed_Cruiser_i_Prefab, fed_0.transform.position, fed_0.transform.rotation);
            Fed_Cruiser_i_1 = (GameObject)Instantiate(fed_Cruiser_i_Prefab, fed_1.transform.position, fed_1.transform.rotation);
            Fed_Cruiser_i_2 = (GameObject)Instantiate(fed_Cruiser_i_Prefab, fed_2.transform.position, fed_2.transform.rotation);
            Fed_Scout_i_3 = (GameObject)Instantiate(fed_Scout_i_Prefab, fed_3.transform.position, fed_3.transform.rotation);
            Fed_Scout_i_4 = (GameObject)Instantiate(fed_Scout_i_Prefab, fed_4.transform.position, fed_4.transform.rotation);
            Fed_Scout_i_5 = (GameObject)Instantiate(fed_Scout_i_Prefab, fed_5.transform.position, fed_5.transform.rotation);

            Fed_Cruiser_i_0.transform.SetParent(fed_0.transform, true);
            Fed_Cruiser_i_1.transform.SetParent(fed_1.transform, true);
            Fed_Cruiser_i_2.transform.SetParent(fed_2.transform, true);
            Fed_Scout_i_3.transform.SetParent(fed_3.transform, true);
            Fed_Scout_i_4.transform.SetParent(fed_4.transform, true);
            Fed_Scout_i_5.transform.SetParent(fed_5.transform, true);

            // How to set position of Child relative to Parent
            //fed_Cruiser_i_0.transform.localPosition = new Vector3(0, 0, 0);
            //fed_Cruiser_i_1.transform.localPosition = new Vector3(0, 0, 200);
            //fed_Cruiser_i_2.transform.localPosition = new Vector3(0, 0, 400);
            //fed_Cruiser_i_0.transform.localScale = new Vector3(500, 500, 500);

            StartHelper.GetFedTrans(fed_0); // turn -90 and scale 1
            StartHelper.GetFedTrans(fed_1);
            StartHelper.GetFedTrans(fed_2);
            StartHelper.GetFedTrans(fed_3);
            StartHelper.GetFedTrans(fed_4);
            StartHelper.GetFedTrans(fed_5);

        }
    }
}
