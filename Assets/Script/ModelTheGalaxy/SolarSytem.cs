using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Script
{
    public class SolarSystem : OrbitalGalactic
    {

        public void Generate()
        {
            // make a system
            OrbitalGalactic myStar = new OrbitalGalactic();
            myStar.graphicID = 0;
            this.Addchild(myStar);

            OrbitalGalactic planet = new OrbitalGalactic();
            planet.MakeOrbital();
            planet.graphicID = 1;
            myStar.Addchild(planet);

        }
    }
}
