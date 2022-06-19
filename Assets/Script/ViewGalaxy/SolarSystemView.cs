using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{

    public class SolarSystemView : MonoBehaviour  // !!! INSIDE PanelGalactic_Play IN UNITY HIERARCHY - GALAXYSCEEN !!!
    {
        public GameManager gameManager;
        public SolarSystem solarSystem;
        public Sprite[] sprites;
        public ulong zoomLevels = 150000000000; // times 1 billion zoom
        float planetMoonScale = 0.2f;
        //public int StupidInt = 0;

        // private OrbitalGalactic mySolarSystem; // star and planets
        void Start()
        {
            gameManager = GameManager.Instance;
        }
        //public void MakeSolarSystemView(Galaxy galaxy)
        //{
        //    while (transform.childCount > 0) // delelt old systems from prior update
        //    {
        //        Transform child = transform.GetChild(0);
        //        child.SetParent(null); // decreases number of children in while loop
        //        Destroy(child.gameObject);
                
        //    }
        //    //gameManager = GameObject.FindObjectOfType<GameManager>();
        //    solarSystem = galaxy.SolarSystems[0]; // take the first one for now for display
        //    for (int i = 0; i < solarSystem.Children.Count; i++)
        //    {
        //        MakeSpritesForOrbital(this.transform, solarSystem.Children[i]);
        //    }
        //}
        public void ShowSolarSystemView(Galaxy galaxy)
        {
            while (transform.childCount > 0) // delelt old systems from prior update
            {
                Transform child = transform.GetChild(0);
                child.SetParent(null); // decreases number of children in while loop
                Destroy(child.gameObject);

            }
            //gameManager = GameObject.FindObjectOfType<GameManager>();
            //solarSystem = SolarSystems[0];
            solarSystem = galaxy.SolarSystems[0]; // take the first one for now for display
            for (int i = 0; i < solarSystem.Children.Count; i++)
            {
                MakeSpritesForOrbital(this.transform, solarSystem.Children[i]);
            }
        }

        private void MakeSpritesForOrbital(Transform transformParent, OrbitalGalactic orbitalG)
        {
            GameObject gameObject = new GameObject();
            gameObject.layer = 30; // galactic
            gameObject.transform.SetParent(transformParent, false);
            // set position in 3D
            gameObject.transform.position = orbitalG.Position/ zoomLevels; // cut down scale of system to view
            SpriteRenderer spritView = gameObject.AddComponent<SpriteRenderer>();
            spritView.transform.localScale = new Vector3(planetMoonScale, planetMoonScale, planetMoonScale);
            spritView.sprite = sprites[orbitalG.GraphicID];
            //StupidInt += 1;
            for (int i = 0; i < orbitalG.Children.Count; i++)
            {
                MakeSpritesForOrbital(gameObject.transform, orbitalG.Children[i]);
            }
        }
        public void SetZoomLevel(ulong zl)
        {
            zoomLevels = zl;
            //Update planet postions and scale graphics to still see planet sprites as a few pix
        }
    }
}