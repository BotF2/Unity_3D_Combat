using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Core;
//using BOTF3D_Core;
//using BOTF3D_Combat;

namespace GalaxyMap
{

    public class InSysSphereCheck : MonoBehaviour
    { // 
        public StarSystemData starSystemData;
        private StarSystemEnum sysEnum;
        private List<Collider> inSysList = new List<Collider>();
        public GameObject sysSphere; // name sphere for system int value
        public Collider sysCollider;
        private GameObject placeHolderForFleet;
 
        public void Start()
        {
            sysSphere = this.gameObject; // the system sphere, not the system/button
            sysCollider = sysSphere.GetComponent<Collider>();
            int number;
            bool foundOne = int.TryParse(gameObject.name, out number);//did we read an int into number?
            if (foundOne)
             sysEnum = (StarSystemEnum)int.Parse(gameObject.name);
           // too early //starSystemData.AddSystemSphere(sysEnum, sysSphere);// load sysSphere into system in Star System Dictionary
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!inSysList.Contains(other))
            {
                inSysList.Add(other);
                starSystemData.AddFleet(sysEnum, (other.gameObject));
                var fleet = other.gameObject.GetComponent<FleetData>();
                fleet._inDeepSpace = false;
            }
        } 
        private void OnTriggerExit(Collider other)
        {
            if (inSysList.Contains(other))
            {
                inSysList.Remove(other);
                starSystemData.RemoveFleet(sysEnum, (other.gameObject));
                var fleet = other.gameObject.GetComponent<FleetData>();
                fleet._inDeepSpace = true;
            }
        }
        public void AddSystemSphere(StarSystemEnum systemKey) // Use the Ditoinary
        {
            //starSystemData.[systemKey]._systemSphere = sysSphere;

        }
    }
}
