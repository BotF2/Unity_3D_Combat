using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{

    public class SolarSystemView : MonoBehaviour
    {
        //public GameManager gameManager; // grant access to GameManager by assigning it in the Unit inspector field for public gameManager
        GameManager gameManger;
        SolarSystem solarSystem;
        public Sprite[] sprites;
        private GameManager gameManager;

        // private OrbitalGalactic mySolarSystem; // star and planets
        void Start()
        {
           // int numStars = gameManager.galaxyStarCount; // !!!!!!!!! This is called too soon, maybe lateUpdate or if on Main Menu
           gameManager = GameObject.FindObjectOfType<GameManager>();
            //solarSystem = gameManager.Galaxy.SolarSystems[1]; // take the first one for now for display

            ShowSolarSystem(0);
        }
        public void ShowSolarSystem(int solarSystemID)
        {
            solarSystem = gameManager._galaxy.SolarSystems[solarSystemID];
            // spawn grapic for each object in solar system
            for (int i = 0; i < solarSystem.Children.Count; i++)
            {
                OrbitalGalactic orbital = solarSystem.Children[i];
                
                GameObject gameObject = new GameObject();
                gameObject.layer = 30; // galactic
                gameObject.transform.SetParent(this.transform, false);

                SpriteRenderer spritView = gameObject.AddComponent<SpriteRenderer>();
               
                spritView.sprite = sprites[orbital.graphicID];
         
            }
        }

    }
}
