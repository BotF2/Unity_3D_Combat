using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Assets.Script
{
    internal class Planet : OrbitalGalactic
    {
        public Planet()
        {

        }
        public void Generate(int maxMoons)
        {
            this.OrbitalDistance = (ulong)UnityEngine.Random.Range(100, 800) * 1000000 * 1000;
            TimeToOrbit = this.OrbitTimeForDistance(); // ToDo: use real physics 
            GraphicID = UnityEngine.Random.Range(1, 12);
            int moons = UnityEngine.Random.Range(1, maxMoons + 1);
            for (int i= 0; i < moons; i++)
            {
                OrbitalGalactic moon = new OrbitalGalactic();
                this.AddChild(moon);
                moon.OrbitalDistance = 100000000000/2; // fix me
                moon.TimeToOrbit = moon.OrbitTimeForDistance()/10; // fix with real physics (orbital version)
            }
        }
        ulong OrbitTimeForDistance() // for planet
        {
            // Fix this with real orbital math
            return 365 * 24 * 60 * 60;
        }
        public void MakeEarth()
        {
            OffsetAngle = 0; // North of star
            OrbitalDistance = 150000000000; // 150 million KM
            TimeToOrbit = 365 * 24 * 60 * 60; // for Earth, days * hours * min * sec (in sec)
        }
        public void LoadPlanet(string planetName)
        {

        }
    }
}
