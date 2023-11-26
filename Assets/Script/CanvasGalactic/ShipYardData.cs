using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using Assets.Script;
using BOTF3D_Core;
using BOTF3D_Combat;
using TMPro;

namespace BOTF3D_GalaxyMap
{
    //[System.Serializable]
    public class ShipYardData : MonoBehaviour 
    {
        public List<GalaxyShip> shipsUnderConstruction = new List<GalaxyShip>();
        public CivEnum _civEnum;
        public float _techPoints;
        private Rigidbody _rigidbody;// in prefab

        public Transform _loca; // get this from system we are in
        public Canvas canvasGalactic;
        public Sprite _insigniaSprite;

        public void Awake()
        {
            GameObject canvasObject = GameObject.Find("CanvasGalactic");
            canvasGalactic = canvasObject.GetComponent<Canvas>();
            //this.civilizationData = game
            
        }
        //public ShipYardData(List<GalaxyShip> ships) 
        //{
        //    shipsUnderConstruction = ships;

        //}
        public static FleetData LoadFeetData(int systemInt, FleetData daFleet)
        {
           
            //Fleet daFleet = new Fleet(systemInt);
            string[] sysStrings = GalaxyView.SystemDataDictionary[systemInt];

            daFleet._fleetCivID = systemInt;
            daFleet._x = int.Parse(sysStrings[1]);
            daFleet._y = int.Parse(sysStrings[2]);
            daFleet._z = int.Parse(sysStrings[3]);
            daFleet._civEnum = (CivEnum)systemInt;
            daFleet._name = sysStrings[4];

            //if (Enum.TryParse(sysStrings[7], out star))
            //    daFleet_starType = star;
            //daFleet_ownerCiv = CivilizationData.CivilizationDictionary[(CivEnum)systemInt];

            daFleet._insignia = Resources.Load<Sprite>("Insignias/"); //+ daFleet._originalOwnerName);
                                                                      // daFleet_ownerCivSprite = Resources.Load<Sprite>("Civilizations/" + daFleet_originalOwnerName.ToLower());

            //_civInsignia leave for CivilizationData to do
            daFleet._buildCost = 1; // int.Parse(sysStrings[6]); ToDo: where do we have build cost of a single ship/GalaxyShip fleet?

            //daFleet_text = "blah, blah, blah";
            //SetSystemOwner(daSystem);
            //civOwnerSprite = daFleet_ownerCivSprite;
            //civOwnerName = daFleet_ownerName;

            return daFleet;
        }
        private void OnCollisionEnter(Collision collision)
        {
 
            //if (collision.gameObject.GetComponent<FleetData>() != null)
            //{
            //    FleetData fleetOne = collision.gameObject.GetComponent<FleetData>();
            //    FleetData fleetTwo = collision.contacts[0].thisCollider.gameObject.GetComponent<FleetData>();
            //    //var systemSomething = collision.contacts[0].thisCollider.gameObject.GetComponent<>();
            //    if (fleetTwo != null)
            //    {
            //        Civilization civOne = CivilizationData.CivilizationDictionary[fleetOne._civEnum];
            //        Civilization civTwo = CivilizationData.CivilizationDictionary[fleetTwo._civEnum];
            //        if (!civOne._contactList.Contains(civTwo))
            //        //if (!civTwo._contactList.Contains(civOne))
            //        {
            //            civOne._contactList.Add(civTwo);
            //            civTwo._contactList.Add(civOne);
            //            for (int i = 0; i < GalaxyView._starSystemObjects.Count(); i++)
            //            {
            //                GameObject sysObject = GalaxyView._starSystemObjects[i];
            //                for (global::System.Int32 j = 0; j < civOne._ownedSystemEnums.Count(); j++)
            //                {
            //                    var someSysEnum = civOne._ownedSystemEnums[j];
            //                    if (sysObject.name == someSysEnum.ToString())
            //                    {
            //                        sysObject.GetComponentInChildren<TMP_Text>().text = sysObject.name;
            //                    }
            //                }
            //                for (global::System.Int32 j = 0; j < civTwo._ownedSystemEnums.Count(); j++)
            //                {
            //                    var someOtherSysEnum = civTwo._ownedSystemEnums[j];
            //                    if (sysObject.name == someOtherSysEnum.ToString())
            //                    {
            //                        sysObject.GetComponentInChildren<TMP_Text>().text = sysObject.name;
            //                    }
            //                }
            //            }

            //        }
            //    }
       
            //}
            
        }
    }
}
