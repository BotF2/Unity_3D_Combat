using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using Assets.Script;
using BOTF3D_Core;
using BOTF3D_Combat;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.Rendering;

namespace BOTF3D_GalaxyMap
{
    public class Fleet : MonoBehaviour // Should this be FleetData inheriting from MonoBehavior with a Fleet not inheriting but are the new instances?
    {
        public List<GalaxyShip> shipsInFeet = new List<GalaxyShip>();
        public CivEnum _civEnum;

        public float _techPoints;
        public float _techSpeed;
        private Rigidbody _rigidbody;
        //public Transform _origin;
        //public Transform _destination;
        //public Transform _loca;

        public Canvas canvasGalactic;

        public GameObject galaxyPlaneGO;
        //private LineRenderer _lineRenderer;
        private float counter;
        private float distance;

        public Sprite _insigniaSprite;
        //[SerializeField] Transform target;
        //public bool newTarget = false;
        public bool inDeepSpace = false;
        public float warpSpeed = 0f;
       // [SerializeField] float rotationalDamp = .5f;
        //public List<GameObject> destinationList;
       // public MoveGalacticObjects moveGalacticObjects;

        public void Awake()
        {
            GameObject canvasObject = GameObject.Find("CanvasGalactic");
            canvasGalactic = canvasObject.GetComponent<Canvas>();
            //this.civilizationData = game
            
        }
        public Fleet(List<GalaxyShip> ships) 
        {
            shipsInFeet = ships;

        }

        private void OnCollisionEnter(Collision collision)
        {
 
            if (collision.gameObject.GetComponent<Fleet>() != null)
            {
                Fleet fleetOne = collision.gameObject.GetComponent<Fleet>();
                Fleet fleetTwo = collision.contacts[0].thisCollider.gameObject.GetComponent<Fleet>();
                //var systemSomething = collision.contacts[0].thisCollider.gameObject.GetComponent<>();
                if (fleetTwo != null)
                {
                    Civilization civOne = CivilizationData.CivilizationDictionary[fleetOne._civEnum];
                    Civilization civTwo = CivilizationData.CivilizationDictionary[fleetTwo._civEnum];
                    if (!civOne._contactList.Contains(civTwo))
                    //if (!civTwo._contactList.Contains(civOne))
                    {
                        civOne._contactList.Add(civTwo);
                        civTwo._contactList.Add(civOne);
                        for (int i = 0; i < GalaxyView._starSystemObjects.Count(); i++)
                        {
                            GameObject sysObject = GalaxyView._starSystemObjects[i];
                            for (global::System.Int32 j = 0; j < civOne._ownedSystemEnums.Count(); j++)
                            {
                                var someSysEnum = civOne._ownedSystemEnums[j];
                                if (sysObject.name == someSysEnum.ToString())
                                {
                                    sysObject.GetComponentInChildren<TMP_Text>().text = sysObject.name;
                                }
                            }
                            for (global::System.Int32 j = 0; j < civTwo._ownedSystemEnums.Count(); j++)
                            {
                                var someOtherSysEnum = civTwo._ownedSystemEnums[j];
                                if (sysObject.name == someOtherSysEnum.ToString())
                                {
                                    sysObject.GetComponentInChildren<TMP_Text>().text = sysObject.name;
                                }
                            }
                        }

                    }
                }
       
            }
            
        }
        void SetTarget()
        {
            //newTarget = true;
            inDeepSpace = true;
        }

        void Pathfinding()
        {

        }
    }
}
