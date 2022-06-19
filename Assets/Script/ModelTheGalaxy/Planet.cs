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
            TimeToOrbit = 365 * 24 * 60 * 60; // ToDo: use real physics 
            GraphicID = UnityEngine.Random.Range(1, 12);
            int m = UnityEngine.Random.Range(1, maxMoons + 1);
            for (int i= 0; i < m; i++)
            {
                OrbitalGalactic moon = new OrbitalGalactic();
                this.AddChild(moon);
                moon.OrbitalDistance = 1000000; // fix me
                TimeToOrbit = 36 * 24 * 60 * 60;
            }
        }
        public void MakeEarth()
        {
            Angle = 0; // North of star
            OrbitalDistance = 150000000000; // 150 million KM
            TimeToOrbit = 365 * 24 * 60 * 60; // for Earth, days * hours * min * sec (in sec)
        }
        public void LoadPlanet(string planetName)
        {

        }
    }
}
