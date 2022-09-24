using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class SolarSystemView : MonoBehaviour // !!! INSIDE PanelGalactic_Play IN UNITY HIERARCHY - GALAXYSCEEN !!!
    {
        public GameManager gameManager;
        public SolarSystem solarSystem;
        public Sprite[] Sprites;
        public ulong zoomLevels = 150000000000; // times 1 billion zoom
        float planetMoonScale = 0.2f;
        Galaxy ourGalaxy;
        Dictionary<OrbitalGalactic, GameObject> orbitalGameObjectMap; // put in the orbital sprit and get the game object

        // private OrbitalGalactic mySolarSystem; // star and planets
        void Start()
        {
            gameManager = GameManager.Instance;
        }
        void Update()
        {
            if (solarSystem == null)
                return;
            // loop orbitals updating position base on zoomlevel
            else
                for (int i = 0; i < solarSystem.Children.Count; i++)
                {
                    UpdateSprites(solarSystem.Children[i]);
                }
        }

        public void TurnOffSolarSystemview(Galaxy galaxy, int solarSystemID)
        {
            ourGalaxy = galaxy;
            while (transform.childCount > 0) // delelt old systems from prior update
            {
                Transform child = transform.GetChild(0);
                child.SetParent(null); // decreases number of children in while loop
                Destroy(child.gameObject);
            }
            solarSystem = null;
        }
        public void ShowSolarSystemView(Galaxy galaxy, int solarSystemID) // called from gameManager with the input galaxy
        {
            while (transform.childCount > 0) // delelt old systems from prior update
            {
                Transform child = transform.GetChild(0);
                child.SetParent(null); // decreases number of children in while loop
                Destroy(child.gameObject);
            }
            orbitalGameObjectMap = new Dictionary<OrbitalGalactic, GameObject>();
            //solarSystem = SolarSystems[0];
            solarSystem = ourGalaxy.SolarSystems[solarSystemID];
            for (int i = 0; i < solarSystem.Children.Count; i++)
            {
                this.MakeSpritesForOrbital(this.transform, solarSystem.Children[i]);
            }
        }
        public void ShowNextSolarSystemView(int buttonSystemID)
        {
            while (transform.childCount > 0) // delelt old systems from prior update
            {
                Transform child = transform.GetChild(0);
                child.SetParent(null); // decreases number of children in while loop
                Destroy(child.gameObject);
            }
            gameManager.ChangeSystemClicked(buttonSystemID, this);
            orbitalGameObjectMap = new Dictionary<OrbitalGalactic, GameObject>();
            solarSystem = gameManager.galaxy.SolarSystems[buttonSystemID]; // take the system button ID to show
            for (int i = 0; i < solarSystem.Children.Count; i++)
            {
                this.MakeSpritesForOrbital(this.transform, solarSystem.Children[i]);
            }
        }

        private void MakeSpritesForOrbital(Transform transformParent, OrbitalGalactic orbitalG)
        {
            //CameraManagerGalactica cameraManagerGalactic = new CameraManagerGalactica();
            GameObject gameObject = new GameObject();
            orbitalGameObjectMap[orbitalG] = gameObject; // update map
            gameObject.layer = 30; // galactic
            gameObject.transform.SetParent(transformParent, false);
            // set position in 3D
            gameObject.transform.position = orbitalG.Position / zoomLevels; // cut down scale of system to view
            SpriteRenderer spritView = gameObject.AddComponent<SpriteRenderer>();
            spritView.transform.localScale = new Vector3(planetMoonScale, planetMoonScale, planetMoonScale);
            spritView.sprite = Sprites[orbitalG.GraphicID];
            //if(galacticCamera != null) // NO LUCK SO FAR BRINGING IN THE GALACTIC CAMERA FOR A LookAt(camera);
            //    spritView.transform.LookAt(galacticCamera.transform);
            //StupidInt += 1;
            for (int i = 0; i < orbitalG.Children.Count; i++)
            {
                MakeSpritesForOrbital(gameObject.transform, orbitalG.Children[i]);
                //spritView.transform.LookAt();
            }
        }
        void UpdateSprites(OrbitalGalactic orbital)
        {
            GameObject gameObject = orbitalGameObjectMap[orbital];
            gameObject.transform.position = orbital.Position / zoomLevels;
            for (int i = 0; i < orbital.Children.Count; i++)
            {
                UpdateSprites(orbital.Children[i]);
            }
        }
        public void SetZoomLevel(ulong zl)
        {
            zoomLevels = zl;
            //Update planet postions and scale graphics to still see planet sprites as a few pix
        }
    }
}
