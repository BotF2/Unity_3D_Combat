using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Script
{
    public class SolarSystem : OrbitalGalactic
    {
        public int StarGraphicID = 0; // even
        public int PlanetGraphicID = 1; // odd

        public void Generate()
        {
            // make a system
            
            OrbitalGalactic myStar = new OrbitalGalactic();
            myStar.graphicID = StarGraphicID;
            this.Addchild(myStar);
            StarGraphicID += 2;

            OrbitalGalactic planet = new OrbitalGalactic();
            planet.MakeOrbital();
            planet.graphicID = PlanetGraphicID;
            myStar.Addchild(planet);
            PlanetGraphicID += 2;

        }
    }
}
