using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Script
{
    public class SolarSystem : OrbitalGalactic
    {
        //public int StarGraphicID = 0; // even
        //public int PlanetGraphicID = 1; // odd

        public SolarSystem Generate()
        {
            // make a solar system, myStar is a child of the system and myStar has child planets...
            
            OrbitalGalactic myStar = new OrbitalGalactic();
            myStar.GraphicID = 0; // StarGraphicID;          
            this.AddChild(myStar);
            //StarGraphicID += 2;

            for (int i = 0; i < 8; i++)
            {
                Planet planet = new Planet();
                planet.Generate(3);
                //planet.GraphicID = PlanetGraphicID;
                myStar.AddChild(planet);
                
            }
            return this;
        }
    }
}
