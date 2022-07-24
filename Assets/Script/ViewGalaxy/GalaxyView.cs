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
        //public SolarSystem solarSystem;
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
        public void GenerateGalaxy(int numStars, GalaxyType galaxyType)
        {
            if (gameManager.galaxy == null)
            {
                Galaxy galaxy = new Galaxy(gameManager, galaxyType, numStars);
                gameManager.galaxy = galaxy;
            }
            //if (this.solarSystems.Count == 0)
            //{
            //    //Galaxy galaxy = new Galaxy();
            //    NumberOfStars = numStars;
            //    for (int i = 0; i < numStars; i++)
            //    {
            //        SolarSystem ss = new SolarSystem();
            //        ss.Generate();
            //        SolarSystems.Add(ss);
            //        // galaxy.AddChild(ss);
            //    }
            //    //gameManager.Galaxy = galaxy;

            //    // ToDo: use numStars and GalaxyType
            //}
        }
        //public void GenerateGalaxy(Galaxy galaxy) // called from gameManager with the input galaxy
        //{

        //    ourGalaxy = galaxy; 
        //    // Think this is only for deleting sprites as in SolarSystem and not part of Galaxy view
        //    //while (transform.childCount > 0) // delelt old systems from prior update
        //    //{
        //    //    Transform child = transform.GetChild(0);
        //    //    child.SetParent(null); // decreases number of children in while loop
        //    //    Destroy(child.gameObject);
        //    //}
        //    solarSystemGameObjectMap = new Dictionary<SolarSystem, GameObject>();
        //    //solarSystem = ourGalaxy.SolarSystems[0]; // take the first one for now, for display but use solarSystemID later for civ...
        //    //solarSystem = ourGalaxy; // display this galaxy
        //    for (int i = 0; i < ourGalaxy.SolarSystems.Count; i++)
        //    {
        //        //ToDo: make buttons here
        //        //this.MakeSpritesForSolarSystems(this.transform, ourGalaxy.SolarSystems[i]);
        //    }
            
        //}
        public void ShowASolarSystemView(int buttonSystemID)
        {
            while (transform.childCount > 0) // delelt old systems from prior update
            {
                Transform child = transform.GetChild(0);
                child.SetParent(null); // decreases number of children in while loop
                Destroy(child.gameObject);

            }
            solarSystemGameObjectMap = new Dictionary<SolarSystem, GameObject>();
            solarSystemView.ShowNextSolarSystemView(buttonSystemID);
           // gameManager.ChangeSystemClicked(buttonSystemID); // (solarSystemView);

            //solarSystem = ourGalaxy.SolarSystems[buttonSystemID]; // take the system button ID to show
            //for (int i = 0; i < solarSystem.Children.Count; i++)
            //{
            //    this.MakeSpritesForOrbital(this.transform, solarSystem.Children[i]);
            //}
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