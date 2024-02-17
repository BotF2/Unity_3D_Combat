using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using Assets.Core;
//using BOTF3D_Core;
//using BOTF3D_Combat;
using TMPro;

namespace GalaxyMap
{
    //[Serializable]
    // attached to each new fleet gameObject in the prefab of civ specific fleets
    public class FleetData : MonoBehaviour // inheriting from MonoBehavior with a Fleet not inheriting but can have 'new' as instances
    {

        //[field:SerializeField]
        public GalaxyShip[] ShipsInFeet; // = new GalaxyShip[] { new GalaxyShip() };
        //public List<GalaxyShip> _galaxyShips = new List<GalaxyShip>();
        public static List<FleetData> fleetsInGalaxy = new List<FleetData>(); // should this be in GameManager
        public CivEnum _civEnum;
        public float _techPoints;
        public float _techSpeed;
        private Rigidbody _rigidbody;
        public int _fleetCivID;
        public int _x;
        public int _y;
        public int _z;
        public string _name;
        public Sprite _insignia;
        public float _buildCost;
        public Sprite _yardImage;// This is seen in system view and combat. The civ image for galaxy map is in the prefab
        public Transform _origin;
        public Transform _destination;
        public Transform _loca;

        public Canvas canvasGalactic;

        public GameObject galaxyPlaneGO;
        private float counter;
        private float distance;

        public Sprite _insigniaSprite;
        //[SerializeField] Transform target;
        //public bool newTarget = false;
        public bool _inDeepSpace = false;
        public float _warpSpeed = 0f;
       // [SerializeField] float rotationalDamp = .5f;
        //public List<GameObject> destinationList;
       // public MoveGalacticObjects moveGalacticObjects;

        public void Awake()
        {
            GameObject canvasObject = GameObject.Find("CanvasGalactic");
            canvasGalactic = canvasObject.GetComponent<Canvas>();
            //this.civilizationData = game
            
        }
        public FleetData(GalaxyShip[] ships) 
        {
            ShipsInFeet = ships;

        }
        public void LoadFleetData(int[] starArray) // First call this from GalaxyView.InstantiateSystemButtons??
        {
            for (int i = 0; i < starArray.Length; i++)
            {
                //var sys = StarSystemData.Create(starArray[i]); // fix this
                //this.civOwnerImage.sprite = sys._ownerCivSprite;
                //this.civInsigniaImage.sprite = sys._ownerInsigniaSprite;
                //this.currentCivOwnerName = sys._currentOwnerName;
                //this.originalCivOwnerName = sys._originalOwnerName;
                //this.sysDataName = sys._sysName;
                //StarSystemDictionary.Add(sys._sysEnum, sys);
            }
        }
        public void CreateOneShipFleet(string shipPrefab) // need the string name of GO in PrefabShipDictionary, like Fed_Scout_i;
        {
            //ToDo make some uninhabited systems to colonize
            //Fleet daFleet = new Fleet(1); //fix this
            GameObject fleetShipGO = GameManager.PrefabShipDitionary[shipPrefab]; // fix this
            //daFleet._fleetCivID = shipPrefab; // fix this
            //daFleet._x = int.Parse(fleetShipGO[1]); // ToDo, fix this
            //daFleet._y = int.Parse(fleetShipGO[2]);
            //daFleet._z = int.Parse(fleetShipGO[3]);
            //daFleet._civEnum = (CivEnum)shipPrefab;
            //daFleet._name = fleetShipGO[4];

            //daSystem._ownerCiv = CivilizationData.CivilizationDictionary[(CivEnum)systemInt]; // fix this
            //daFleet._buildCost = 10f; // Get from first ship

            //daFleet._name = fleetShipGO[5]; // fix this


            //_civInsignia leave for CivilizationData to do
            //daSystem._systemPopulation = int.Parse(sysStrings[6]);

            //daFleet._text = "blah, blah, blah";
            //SetSystemOwner(daSystem);
            //civOwnerSprite = daSystem._ownerCivSprite;
            //civOwnerName = daSystem._ownerName;

            //return daFleet;
        }
        private void OnCollisionEnter(Collision collision)
        {
 
            if (collision.gameObject.GetComponent<FleetData>() != null)
            {
                FleetData fleetOne = collision.gameObject.GetComponent<FleetData>();
                FleetData fleetTwo = collision.contacts[0].thisCollider.gameObject.GetComponent<FleetData>();
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
            _inDeepSpace = true;
        }

        void Pathfinding()
        {

        }
    }
}
