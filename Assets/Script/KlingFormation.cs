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
        public GameObject kling_0; // parent empty gameobjects
        public GameObject kling_1; // can use one parent for all or multiple parents 
        public GameObject kling_2;
        public GameObject kling_3;
        public GameObject kling_4;
        public GameObject kling_5;
        //public List<GameObject> parentArray = new GameObject(){kling_0, kling_1, kling_2, kling_3, kling_4, kling_5 }; // not working
        //public Animation anim;
        public GameObject kling_Cruiser_i_Prefab;
        public GameObject kling_Scout_i_Prefab;
        private GameObject kling_Cruiser_i_0;
        private GameObject kling_Cruiser_i_1;
        private GameObject kling_Cruiser_i_2;
        private GameObject kling_Scout_i_3;
        private GameObject kling_Scout_i_4;
        private GameObject kling_Scout_i_5;
        private void Awake()
        {
            //kling_Cruiser_i_0 = (GameObject)Instantiate(kling_Cruiser_i_Prefab, kling_0.transform.position, Quaternion.identity, kling_Cruiser_i_Prefab.transform);
            kling_Cruiser_i_0 = (GameObject)Instantiate(kling_Cruiser_i_Prefab, kling_0.transform.position, kling_0.transform.rotation);
            kling_Cruiser_i_1 = (GameObject)Instantiate(kling_Cruiser_i_Prefab, kling_1.transform.position, kling_1.transform.rotation);
            kling_Cruiser_i_2 = (GameObject)Instantiate(kling_Cruiser_i_Prefab, kling_2.transform.position, kling_2.transform.rotation);
            kling_Scout_i_3 = (GameObject)Instantiate(kling_Scout_i_Prefab, kling_3.transform.position, kling_3.transform.rotation);
            kling_Scout_i_4 = (GameObject)Instantiate(kling_Scout_i_Prefab, kling_4.transform.position, kling_4.transform.rotation);
            kling_Scout_i_5 = (GameObject)Instantiate(kling_Scout_i_Prefab, kling_5.transform.position, kling_5.transform.rotation);
          
            kling_Cruiser_i_0.transform.SetParent(kling_0.transform, true);
            kling_Cruiser_i_1.transform.SetParent(kling_1.transform, true);
            kling_Cruiser_i_2.transform.SetParent(kling_2.transform, true);
            kling_Scout_i_3.transform.SetParent(kling_3.transform, true);
            kling_Scout_i_4.transform.SetParent(kling_4.transform, true);
            kling_Scout_i_5.transform.SetParent(kling_5.transform, true);

            //kling_Cruiser_i_0.AddComponent<Rigidbody>();
            //kling_Cruiser_i_1.AddComponent<Rigidbody>();
            //kling_Cruiser_i_2.AddComponent<Rigidbody>();
            //kling_Scout_i_3.AddComponent<Rigidbody>();
            //kling_Scout_i_4.AddComponent<Rigidbody>();
            //kling_Scout_i_5.AddComponent<Rigidbody>();

            //StartHelper.GetKlingTrans(kling_0); // turn -90 and scale up 500
            //StartHelper.GetKlingTrans(kling_1);
            //StartHelper.GetKlingTrans(kling_2);
            //StartHelper.GetKlingTrans(kling_3);
            //StartHelper.GetKlingTrans(kling_4);
            //StartHelper.GetKlingTrans(kling_5);
        }
        void Start()
        {

        }
        private void Update()
        {

        }
    }
}
