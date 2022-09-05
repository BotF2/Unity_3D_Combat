using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Script
{
    public class SolarSystem : OrbitalGalactic
    {
        public int SystemGraphicID;
        public GameManager gameManager; // grant access to GameManager by assigning it in the Unit inspector field for public gameManager
        public Civilization _civOwner;
        public StarType _starType;
        public int _planets; // set in SystemData.txt


        public SolarSystem Generate()
        {
            // make a solar system, myStar is a child of the system and myStar has child planets...
            
            OrbitalGalactic myStar = new OrbitalGalactic();
            myStar.GraphicID = 0; // StarGraphicID;          
            this.AddChild(myStar);
            // load a data file SystemData

            //for (int i = 0; i < 8; i++)
            //{
            //    Planet planet = new Planet();
            //    planet.Generate(3);
            //    //planet.GraphicID = PlanetGraphicID;
            //    myStar.AddChild(planet);
            //}
            return this;
        }
        public SolarSystem GenerateGalaxyCenter()
        {
            OrbitalGalactic myStar = new OrbitalGalactic();
            myStar.GraphicID = 0; // StarGraphicID; 
            return this;
        }
    }
}
