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
        public Sprite[] sprites;
        //private GameManager gameManager;

        //public GameManager GameManger => gameManger;

        // private OrbitalGalactic mySolarSystem; // star and planets
        void Start()
        {
            gameManger = GameManager.Instance;
            int numStars = gameManger.galaxyStarCount; // !!!!!!!!! This is called too soon, maybe lateUpdate or if on Main Menu
            //gameManager = GameObject.FindObjectOfType<GameManager>();
            if(gameManger.Galaxy != null)
            {
                solarSystem = gameManger.Galaxy.SolarSystems[0]; // take the first one for now for display
                ShowSolarSystem(0);
            }

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
        }
    }
}