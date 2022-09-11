﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{

    public class GalaxyView : MonoBehaviour // !!! INSIDE PanelGalactic_Map IN UNITY HIERARCHY - GALAXYSCEEN !!!
    {
        public GameManager gameManager;
        public SolarSystemView solarSystemView;
        public Galaxy ourGalaxy;
        // public Canvas canvasGalactic;
        public GameObject FEDSysEmpty;
        public GameObject ROMSysEmpty;
        public GameObject KLINGSysEmpty;
        public GameObject CARDSysEmpty;
        public GameObject DOMSysEmpty;
        public GameObject BORGSysEmpty;
        #region The Minor Race Empties
        public GameObject ACAMARIANSSysEmpty;
        public GameObject AKAALISysEmpty;
        public GameObject AKRITIRIANSSysEmpty;
        public GameObject ALDEANSSysEmpty;
        public GameObject ALGOLIANSSysEmpty;
        public GameObject ALSAURIANSSysEmpty;
        public GameObject ANDORIANSSysEmpty;
        public GameObject ANGOSIANSSysEmpty;
        public GameObject ANKARISysEmpty;
        public GameObject ANTEDEANSSysEmpty;
        public GameObject ANTICANSSysEmpty;
        public GameObject ARBAZANSysEmpty;
        public GameObject ARDANANSSysEmpty;
        public GameObject ARGRATHISysEmpty;
        public GameObject ARKARIANSSysEmpty;
        public GameObject ATREANSSysEmpty;
        public GameObject AXANARSysEmpty;
        public GameObject BAJORANSSysEmpty;
        public GameObject BAKUSysEmpty;
        public GameObject BANDISysEmpty;
        public GameObject BANEANSSysEmpty;
        public GameObject BARZANSSysEmpty;
        public GameObject BENZITESSysEmpty;
        public GameObject BETAZOIDSSysEmpty;
        public GameObject BILANAIANSSysEmpty;
        public GameObject BOLIANSSysEmpty;
        public GameObject BOMARSysEmpty;
        public GameObject BOSLICSSysEmpty;
        public GameObject BOTHASysEmpty;
        public GameObject BREELLIANSSysEmpty;
        public GameObject BREENSysEmpty;
        public GameObject BREKKIANSSysEmpty;
        public GameObject BYNARSSysEmpty;
        public GameObject CAIRNSysEmpty;
        public GameObject CALDONIANSSysEmpty;
        public GameObject CAPELLANSSysEmpty;
        public GameObject CHALNOTHSysEmpty;
        public GameObject CORIDANSysEmpty;
        public GameObject CORVALLENSSysEmpty;
        public GameObject CYTHERIANSSysEmpty;
        public GameObject DELTANSSysEmpty;
        public GameObject DENOBULANSSysEmpty;
        public GameObject DEVORESysEmpty;
        public GameObject DOPTERIANSSysEmpty;
        public GameObject DOSISysEmpty;
        public GameObject DRAISysEmpty;
        public GameObject DREMANSSysEmpty;
        public GameObject EDOSysEmpty;
        public GameObject ELAURIANSSysEmpty;
        public GameObject ELAYSIANSSysEmpty;
        public GameObject ENTHARANSSysEmpty;
        public GameObject EVORASysEmpty;
        public GameObject EXCALBIANSSysEmpty;
        public GameObject FERENGISysEmpty;
        public GameObject FLAXIANSSysEmpty;
        public GameObject GORNSysEmpty;
        public GameObject GRAZERITESSysEmpty;
        public GameObject HAAKONIANSSysEmpty;
        public GameObject HALKANSSysEmpty;
        public GameObject HAZARISysEmpty;
        public GameObject HEKARANSSysEmpty;
        public GameObject HIROGENSysEmpty;
        public GameObject HORTASysEmpty;
        public GameObject IYAARANSSysEmpty;
        public GameObject JNAIISysEmpty;
        public GameObject KAELONSysEmpty;
        public GameObject KAREMMASysEmpty;
        public GameObject KAZONSysEmpty;
        public GameObject KELLERUNSysEmpty;
        public GameObject KESPRYTTSysEmpty;
        public GameObject KLAESTRONIANSSysEmpty;
        public GameObject KRADINSysEmpty;
        public GameObject KREETASSANSSysEmpty;
        public GameObject KRIOSIANSSysEmpty;
        public GameObject KTARIANSSysEmpty;
        public GameObject LEDOSIANSSysEmpty;
        public GameObject LISSEPIANSSysEmpty;
        public GameObject LOKIRRIMSysEmpty;
        public GameObject LURIANSSysEmpty;
        public GameObject MALCORIANSSysEmpty;
        public GameObject MALONSysEmpty;
        public GameObject MAQUISSysEmpty;
        public GameObject MARKALIANSSysEmpty;
        public GameObject MERIDIANSSysEmpty;
        public GameObject MINTAKANSSysEmpty;
        public GameObject MIRADORNSysEmpty;
        public GameObject MIZARIANSSysEmpty;
        public GameObject MOKRASysEmpty;
        public GameObject MONEANSSysEmpty;
        public GameObject NAUSICAANSSysEmpty;
        public GameObject NECHANISysEmpty;
        public GameObject NEZUSysEmpty;
        public GameObject NORCADIANSSysEmpty;
        public GameObject NUMIRISysEmpty;
        public GameObject NUUBARISysEmpty;
        public GameObject NYRIANSSysEmpty;
        public GameObject OCAMPASysEmpty;
        public GameObject ORIONSSysEmpty;
        public GameObject ORNARANSSysEmpty;
        public GameObject PAKLEDSysEmpty;
        public GameObject PARADANSSysEmpty;
        public GameObject QUARRENSysEmpty;
        public GameObject RAKHARISysEmpty;
        public GameObject RAKOSANSSysEmpty;
        public GameObject RAMATIANSSysEmpty;
        public GameObject REMANSSysEmpty;
        public GameObject RIGELIANSSysEmpty;
        public GameObject RISIANSSysEmpty;
        public GameObject RUTIANSSysEmpty;
        public GameObject SELAYSysEmpty;
        public GameObject SHELIAKSysEmpty;
        public GameObject SIKARIANSSysEmpty;
        public GameObject SKRREEASysEmpty;
        public GameObject SONASysEmpty;
        public GameObject SULIBANSysEmpty;
        public GameObject TAKARANSSysEmpty;
        public GameObject TAKARIANSSysEmpty;
        public GameObject TAKTAKSysEmpty;
        public GameObject TALARIANSSysEmpty;
        public GameObject TALAXIANSSysEmpty;
        public GameObject TALOSIANSSysEmpty;
        public GameObject TAMARIANSSysEmpty;
        public GameObject TANUGANSSysEmpty;
        public GameObject TELLARITESSysEmpty;
        public GameObject TEPLANSSysEmpty;
        public GameObject THOLIANSSysEmpty;
        public GameObject TILONIANSSysEmpty;
        public GameObject TLANISysEmpty;
        public GameObject TRABESysEmpty;
        public GameObject TRILLSysEmpty;
        public GameObject TROGORANSSysEmpty;
        public GameObject TZENKETHISysEmpty;
        public GameObject ULLIANSSysEmpty;
        public GameObject VAADWAURSysEmpty;
        public GameObject VENTAXIANSSysEmpty;
        public GameObject VHNORISysEmpty;
        public GameObject VIDIIANSSysEmpty;
        public GameObject VISSIANSSysEmpty;
        public GameObject VORGONSSysEmpty;
        public GameObject VORISysEmpty;
        public GameObject VULCANSSysEmpty;
        public GameObject WADISysEmpty;
        public GameObject XANTHANSSysEmpty;
        public GameObject XEPOLITESSysEmpty;
        public GameObject XINDISysEmpty;
        public GameObject XYRILLIANSSysEmpty;
        public GameObject YADERANSSysEmpty;
        public GameObject YRIDIANSSysEmpty;
        public GameObject ZAHLSysEmpty;
        public GameObject ZAKDORNSysEmpty;
        public GameObject ZALKONIANSSysEmpty;
        public GameObject ZIBALIANSSysEmpty;
        #endregion

        private List<GameObject> SysEmptyList;
        public Sprite[] Sprites;
        public ulong zoomLevels = 150000000000; // times 1 billion zoom
        // float planetMoonScale = 0.2f;
        //Dictionary<OrbitalGalactic, GameObject> orbitalGameObjectMap; // put in the orbital sprit and get the game object
        Dictionary<SolarSystem, GameObject> solarSystemGameObjectMap; // put in the ss sprit and get the ss game object

        // private OrbitalGalactic mySolarSystem; // star and planets
        void Start()
        {
            gameManager = GameManager.Instance;
            SysEmptyList = new List<GameObject> { FEDSysEmpty,
                ROMSysEmpty,
                KLINGSysEmpty,
                CARDSysEmpty,
                DOMSysEmpty,
                BORGSysEmpty,
                #region Minor Race Entries
                ACAMARIANSSysEmpty,
                AKAALISysEmpty,
                AKRITIRIANSSysEmpty,
                ALDEANSSysEmpty,
                ALGOLIANSSysEmpty,
                ALSAURIANSSysEmpty,
                ANDORIANSSysEmpty,
                ANGOSIANSSysEmpty,
                ANKARISysEmpty,
                ANTEDEANSSysEmpty,
                ANTICANSSysEmpty,
                ARBAZANSysEmpty,
                ARDANANSSysEmpty,
                ARGRATHISysEmpty,
                ARKARIANSSysEmpty,
                ATREANSSysEmpty,
                AXANARSysEmpty,
                BAJORANSSysEmpty,
                BAKUSysEmpty,
                BANDISysEmpty,
                BANEANSSysEmpty,
                BARZANSSysEmpty,
                BENZITESSysEmpty,
                BETAZOIDSSysEmpty,
                BILANAIANSSysEmpty,
                BOLIANSSysEmpty,
                BOMARSysEmpty,
                BOSLICSSysEmpty,
                BOTHASysEmpty,
                BREELLIANSSysEmpty,
                BREENSysEmpty,
                BREKKIANSSysEmpty,
                BYNARSSysEmpty,
                CAIRNSysEmpty,
                CALDONIANSSysEmpty,
                CAPELLANSSysEmpty,
                CHALNOTHSysEmpty,
                CORIDANSysEmpty,
                CORVALLENSSysEmpty,
                CYTHERIANSSysEmpty,
                DELTANSSysEmpty,
                DENOBULANSSysEmpty,
                DEVORESysEmpty,
                DOPTERIANSSysEmpty,
                DOSISysEmpty,
                DRAISysEmpty,
                DREMANSSysEmpty,
                EDOSysEmpty,
                ELAURIANSSysEmpty,
                ELAYSIANSSysEmpty,
                ENTHARANSSysEmpty,
                EVORASysEmpty,
                EXCALBIANSSysEmpty,
                FERENGISysEmpty,
                FLAXIANSSysEmpty,
                GORNSysEmpty,
                GRAZERITESSysEmpty,
                HAAKONIANSSysEmpty,
                HALKANSSysEmpty,
                HAZARISysEmpty,
                HEKARANSSysEmpty,
                HIROGENSysEmpty,
                HORTASysEmpty,
                IYAARANSSysEmpty,
                JNAIISysEmpty,
                KAELONSysEmpty,
                KAREMMASysEmpty,
                KAZONSysEmpty,
                KELLERUNSysEmpty,
                KESPRYTTSysEmpty,
                KLAESTRONIANSSysEmpty,
                KRADINSysEmpty,
                KREETASSANSSysEmpty,
                KRIOSIANSSysEmpty,
                KTARIANSSysEmpty,
                LEDOSIANSSysEmpty,
                LISSEPIANSSysEmpty,
                LOKIRRIMSysEmpty,
                LURIANSSysEmpty,
                MALCORIANSSysEmpty,
                MALONSysEmpty,
                MAQUISSysEmpty,
                MARKALIANSSysEmpty,
                MERIDIANSSysEmpty,
                MINTAKANSSysEmpty,
                MIRADORNSysEmpty,
                MIZARIANSSysEmpty,
                MOKRASysEmpty,
                MONEANSSysEmpty,
                NAUSICAANSSysEmpty,
                NECHANISysEmpty,
                NEZUSysEmpty,
                NORCADIANSSysEmpty,
                NUMIRISysEmpty,
                NUUBARISysEmpty,
                NYRIANSSysEmpty,
                OCAMPASysEmpty,
                ORIONSSysEmpty,
                ORNARANSSysEmpty,
                PAKLEDSysEmpty,
                PARADANSSysEmpty,
                QUARRENSysEmpty,
                RAKHARISysEmpty,
                RAKOSANSSysEmpty,
                RAMATIANSSysEmpty,
                REMANSSysEmpty,
                RIGELIANSSysEmpty,
                RISIANSSysEmpty,
                RUTIANSSysEmpty,
                SELAYSysEmpty,
                SHELIAKSysEmpty,
                SIKARIANSSysEmpty,
                SKRREEASysEmpty,
                SONASysEmpty,
                SULIBANSysEmpty,
                TAKARANSSysEmpty,
                TAKARIANSSysEmpty,
                TAKTAKSysEmpty,
                TALARIANSSysEmpty,
                TALAXIANSSysEmpty,
                TALOSIANSSysEmpty,
                TAMARIANSSysEmpty,
                TANUGANSSysEmpty,
                TELLARITESSysEmpty,
                TEPLANSSysEmpty,
                THOLIANSSysEmpty,
                TILONIANSSysEmpty,
                TLANISysEmpty,
                TRABESysEmpty,
                TRILLSysEmpty,
                TROGORANSSysEmpty,
                TZENKETHISysEmpty,
                ULLIANSSysEmpty,
                VAADWAURSysEmpty,
                VENTAXIANSSysEmpty,
                VHNORISysEmpty,
                VIDIIANSSysEmpty,
                VISSIANSSysEmpty,
                VORGONSSysEmpty,
                VORISysEmpty,
                VULCANSSysEmpty,
                WADISysEmpty,
                XANTHANSSysEmpty,
                XEPOLITESSysEmpty,
                XINDISysEmpty,
                XYRILLIANSSysEmpty,
                YADERANSSysEmpty,
                YRIDIANSSysEmpty,
                ZAHLSysEmpty,
                ZAKDORNSysEmpty,
                ZALKONIANSSysEmpty,
                ZIBALIANSSysEmpty
            #endregion
            };
        }
        void Update()
        {
            if (ourGalaxy == null)
                return;
            // loop systems and updating data 
            else
            {
                // ToDo: update system buttons features, owner color
                // UpdateSystemButtons(SolarSystem)
            }

        }
        public void GenerateGalaxy(int numStars)
        {
            string [] keysForSytemDictioanry = WhatMapWasSelected();
            if (gameManager.galaxy == null)
            {
                numStars = 3; // use numStars, without this reset, when we have enough system-button prefabs built and loaded 
                Galaxy galaxy = new Galaxy(gameManager, numStars);
                for (int i = 0; i < numStars; i++)
                {
                    string ourKey = keysForSytemDictioanry[i];
                    if (keysForSytemDictioanry[i].Length != 0)
                    {
                        GameObject starSystemNewGameOb = Instantiate(GameManager.PrefabStarSystemDitionary[keysForSytemDictioanry[i]],
                            new Vector3(0, 0, 0), Quaternion.identity); //VectorValue(ourKey,'z')
                        starSystemNewGameOb.transform.SetParent(SysEmptyList[i].transform, false);
                        starSystemNewGameOb.transform.localScale = new Vector3(1, 1, 1);
                        starSystemNewGameOb.SetActive(true);
                    }
                }
                //var theCameras = GameManager.FindObjectsOfType<Camera>();
                //foreach (var item in theCameras)
                //{
                //    var original = item.transform;
                //    item.transform.Rotate(new Vector3(0, 0, 0), Space.World);
                //    var originalRotation = original.rotation;
                //    item.transform.rotation = originalRotation;
                //}
               //GameObject starSystemGameOb = Instantiate(GameManager.PrefabStarSystemDitionary["KLING_SYSTEM"], new Vector3(1, 2, 2), Quaternion.identity);
                //starSystemGameOb.transform.SetParent(canvasGalactic.transform);
                //starSystemGameOb.transform.localScale = new Vector3(1,1,1);
                gameManager.galaxy = galaxy;
            }
        }
         
        private string[] WhatMapWasSelected()
        {
            String[] _systemData;
            List<String> ourCivs = new List<string>();
            switch (GameManager._galaxySize)
            {
               case GalaxySize.SMALL:
                    
                 foreach (KeyValuePair<String, String[]> elements in GameManager.SystemDataDictionary)
                    {
                        _systemData = elements.Value;
                        ourCivs.Add(_systemData[5]);
                    }            
                    break;
                case GalaxySize.MEDIUM:
                    break;
                case GalaxySize.LARGE:
                    break;
            }
            switch (GameManager._galaxyType)
            {
                case GalaxyType.CANON:
                    break;
                case GalaxyType.RANDOM:
                    break;
            }
            //ToDo: use this to get the right kind of map 
           // string[] ourMap = new string[] { "FED", "ROM", "KLING" };
            // keys for a the map we want out of the GameManager.PrefabStarSystemDitionary;
            return ourCivs.ToArray();
        }
        private int VectorValue(string theKey, char axis)
        {
            int number;
            switch (axis)
            {
                case 'x':
                    number = int.Parse(GameManager.SystemDataDictionary[theKey][1]);
                    break;
                case 'y':
                    number = int.Parse(GameManager.SystemDataDictionary[theKey][2]);
                    break;
                case 'z':
                    number = int.Parse(GameManager.SystemDataDictionary[theKey][3]);
                    break;
                default:
                    number = 1000;
                    break;
            }
            return number;
        }

        public void ShowASolarSystemView(int buttonSystemID)
        {
            while (transform.childCount > 0) // delelt old systems from prior update
            {
                Transform child = transform.GetChild(0);
                child.SetParent(null); // decreases number of children in while loop
                Destroy(child.gameObject);

            }
            solarSystemGameObjectMap = new Dictionary<SolarSystem, GameObject>();
            solarSystemView.ShowNextSolarSystemView(buttonSystemID); // the number is found in Unity Inspector, button On Click 
        }

        private void MakeButtonsForSolarSystems(Transform transformParent, SolarSystem ss)
        {
            //CameraManagerGalactica cameraManagerGalactic = new CameraManagerGalactica();
            GameObject gameObject = new GameObject();
            solarSystemGameObjectMap[ss] = gameObject; // update map
            gameObject.layer = 30; // galactic
            gameObject.transform.SetParent(transformParent, false);
            // set position in 3D
            gameObject.transform.position = ss.Position / zoomLevels; // cut down scale of system to view
                                                                      // ToDo: make buttons here
                                                                      //SpriteRenderer spritView = gameObject.AddComponent<SpriteRenderer>();
                                                                      //spritView.transform.localScale = new Vector3(planetMoonScale, planetMoonScale, planetMoonScale);
                                                                      //spritView.sprite = Sprites[ss.GraphicID];

            //if(galacticCamera != null) // NO LUCK SO FAR BRINGING IN THE GALACTIC CAMERA FOR A LookAt(camera);
            //    spritView.transform.LookAt(galacticCamera.transform);
            //StupidInt += 1;
            //for (int i = 0; i < ss.Children.Count; i++)
            //{
            //    MakeSpritesForOrbital(gameObject.transform, ss.Children[i]);
            //    //spritView.transform.LookAt();
            //}
        }
        void UpdateSystemButtons(SolarSystem ss)
        {
            GameObject gameObject = solarSystemGameObjectMap[ss];
           // gameObject.transform.position = ss.Position / zoomLevels;
            //for (int i = 0; i < ss.Children.Count; i++)
            //{
            //    UpdateSprites(ss.Children[i]);
            //}
        }
        public void SetZoomLevel(ulong zl)
        {
            zoomLevels = zl;
            //Update planet postions and scale graphics to still see planet sprites as a few pix
        }
    }
}