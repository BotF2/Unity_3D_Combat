using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script
{
    public class FriendFormation : MonoBehaviour
    {
        public GameObject friend_0; // parent empty gameobjects
        public GameObject friend_1; // can use one parent for all or multiple parents 
        public GameObject friend_2;
        public GameObject friend_3;
        public GameObject friend_4;
        public GameObject friend_5;

        //public GameObject fed_Cruiser_i_Prefab;
        //public GameObject fed_Scout_i_Prefab;
        private GameObject Fed_Cruiser_i_0;
        private GameObject Fed_Cruiser_i_1;
        private GameObject Fed_Cruiser_i_2;
        private GameObject Fed_Scout_i_3;
        private GameObject Fed_Scout_i_4;
        private GameObject Fed_Scout_i_5;
        private void Awake()
        {             
            //Fed_Cruiser_i_0 = (GameObject)Instantiate(fed_Cruiser_i_Prefab, friend_0.transform.position, friend_0.transform.rotation, friend_0.transform);
            //Fed_Cruiser_i_1 = (GameObject)Instantiate(fed_Cruiser_i_Prefab, friend_1.transform.position, friend_1.transform.rotation, friend_1.transform);
            //Fed_Cruiser_i_2 = (GameObject)Instantiate(fed_Cruiser_i_Prefab, friend_2.transform.position, friend_2.transform.rotation, friend_2.transform);
            //Fed_Scout_i_3 = (GameObject)Instantiate(fed_Scout_i_Prefab, friend_3.transform.position, friend_3.transform.rotation, friend_3.transform);
            //Fed_Scout_i_4 = (GameObject)Instantiate(fed_Scout_i_Prefab, friend_4.transform.position, friend_4.transform.rotation, friend_4.transform);
            //Fed_Scout_i_5 = (GameObject)Instantiate(fed_Scout_i_Prefab, friend_5.transform.position, friend_5.transform.rotation, friend_5.transform);

            Fed_Cruiser_i_0.transform.SetParent(friend_0.transform, true);
            Fed_Cruiser_i_1.transform.SetParent(friend_1.transform, true);
            Fed_Cruiser_i_2.transform.SetParent(friend_2.transform, true);
            Fed_Scout_i_3.transform.SetParent(friend_3.transform, true);
            Fed_Scout_i_4.transform.SetParent(friend_4.transform, true);
            Fed_Scout_i_5.transform.SetParent(friend_5.transform, true);

            Ship.SetLayerRecursively(friend_0, 10); 
            Ship.SetLayerRecursively(friend_1, 10);
            Ship.SetLayerRecursively(friend_2, 10);
            Ship.SetLayerRecursively(friend_3, 10);
            Ship.SetLayerRecursively(friend_4, 10);
            Ship.SetLayerRecursively(friend_5, 10);
        }
    }
}
