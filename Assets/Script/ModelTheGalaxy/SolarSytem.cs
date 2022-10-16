using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class SolarSystem : OrbitalGalactic
    {
        public int SystemGraphicID;
        public GameManager gameManager; // grant access to GameManager by assigning it in the Unit inspector field for public gameManager

        public SolarSystem LoadSystem(string[] systemData)
        {
            OrbitalGalactic myStar = new OrbitalGalactic(); // empty for our planets to orbit
            myStar.GraphicID = 0; // StarGraphicID;
            this.AddChild(myStar);           
            for (int i = 0; i < 8; i++) // all systems have 8 planets for now
            {
                Planet planet = new Planet();
                planet.LoadPlanet(planet, systemData, i);
                myStar.AddChild(planet);
                int numMoons = int.Parse(systemData[9 + (i*2)]);
                switch (numMoons)
                {
                    case 0:
                        break; 
                    case 1:
                        planet.LoadMoons(planet,1);
                        break;
                    case 2:
                        planet.LoadMoons(planet, 2);
                        break;
                    case 3:
                        planet.LoadMoons(planet,3);
                        break;
                }

            }
            return this;
        }
        public SolarSystem Generate()
        {
            // make a solar system, myStar is a child of the system and myStar has child planets...
            // That is all we do here so far, consider random generate locations 
            
            OrbitalGalactic myStar = new OrbitalGalactic();
            myStar.GraphicID = 0; // StarGraphicID;
            this.AddChild(myStar);
            // dealing with planets and moon in SolarSystemView and from SystemData.csv
            //for (int i = 0; i < 8; i++) // all systems have 8 planets for now
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
