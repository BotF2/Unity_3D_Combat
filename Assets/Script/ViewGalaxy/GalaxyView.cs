using System;
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
        public Canvas canvasGalactic;
        public Sprite[] Sprites;
        public ulong zoomLevels = 150000000000; // times 1 billion zoom
        // float planetMoonScale = 0.2f;
        //Dictionary<OrbitalGalactic, GameObject> orbitalGameObjectMap; // put in the orbital sprit and get the game object
        Dictionary<SolarSystem, GameObject> solarSystemGameObjectMap; // put in the ss sprit and get the ss game object

        // private OrbitalGalactic mySolarSystem; // star and planets
        void Start()
        {
            gameManager = GameManager.Instance;
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
                    GameObject starSystemNewGameOb = Instantiate(GameManager.PrefabStarSystemDitionary[keysForSytemDictioanry[i]],
                        new Vector3(VectorValue(ourKey,'x'), VectorValue(ourKey,'y'), VectorValue(ourKey,'z')), Quaternion.identity);
                    starSystemNewGameOb.transform.SetParent(canvasGalactic.transform);
                    starSystemNewGameOb.transform.localScale = new Vector3(10, 10, 10);
                    starSystemNewGameOb.SetActive(true);
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
            switch (GameManager._galaxySize)
            {
                case GalaxySize.SMALL:
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
            string[] ourMap = new string[] { "FED", "ROM", "KLING" };
            // keys for a the map we want out of the GameManager.PrefabStarSystemDitionary;
            return ourMap;
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