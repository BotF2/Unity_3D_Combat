using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class SolarSystem : OrbitalGalactic
    {
        public int SystemGraphicID;
        public GameManager gameManager; // grant access to GameManager by assigning it in the Unit inspector field for public gameManager
        //public Civilization _civOwner;
        //public StarType _starType;
        //public int _planets; // set in SystemData.txt


        public SolarSystem Generate()
        {
            // make a solar system, myStar is a child of the system and myStar has child planets...
            // That is all we do here so far, consider random generate locations 
            
            OrbitalGalactic myStar = new OrbitalGalactic();
            myStar.GraphicID = 0; // StarGraphicID;          
           
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
            
        //    Sys_Int,
        //X_Vector3,
        //Y_Vector3,
        //Z_Vector3,
        //Name,
        //Civ_Owner,
        //Sys_Type,
        //Star_Type,
        //Planet_1,
        //Moons_1,
        //Planet_2,
        //Moons_2,
        //Planet_3,
        //Moons_3,
        //Planet_4,
        //Moons_4,
        //Planet_5,
        //Moons_5,
        //Planet_6,
        //Moons_6,
        //Planet_7,
        //Moons_7,
        //Planet_8,
        //Moons_8
            return this;
        }
    }
}
