using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{

    public class SolarSystemView : MonoBehaviour  // !!! INSIDE PanelGalactic_Play IN UNITY HIERARCHY - GALAXYSCEEN !!!
    {
        //public GameManager gameManager; // grant access to GameManager by assigning it in the Unit inspector field for public gameManager
        public GameManager gameManger;
        SolarSystem solarSystem;
        public Sprite[] sprites; // = new Sprite[100];
        //public int StupidInt = 0;

        // private OrbitalGalactic mySolarSystem; // star and planets
        void Start()
        {
            gameManger = GameManager.Instance;
        }
        public void ViewSolarSystem(Galaxy galaxy)
        { 
             //int numStars = galaxy.NumberOfStars; 
            //gameManager = GameObject.FindObjectOfType<GameManager>();
            solarSystem = galaxy.SolarSystems[0]; // take the first one for now for display  
            ShowSolarSystem(0);
        }

        public void ShowSolarSystem(int solarSystemID)
        {
           // solarSystem = GameManager.Instance._galaxy.SolarSystems[solarSystemID];
            // spawn grapic for each object in solar system
            for (int i = 0; i < solarSystem.Children.Count; i++)
            {
                OrbitalGalactic orbital = solarSystem.Children[i];
                MakeSpritesForOrbitals(solarSystem.Children[i]);
            }
        }
        private void MakeSpritesForOrbitals(OrbitalGalactic orbitalG)
        {
            GameObject gameObject = new GameObject();
            gameObject.layer = 30; // galactic
            gameObject.transform.SetParent(this.transform, false);

            SpriteRenderer spritView = gameObject.AddComponent<SpriteRenderer>();

            spritView.sprite = sprites[orbitalG.graphicID];
            //StupidInt += 1;
        }
    }
}