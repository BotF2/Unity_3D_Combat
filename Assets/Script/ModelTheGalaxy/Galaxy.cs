using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class Galaxy
    {
        public Galaxy()
        {
            // not procedurally generate in constructor
            SolarSystems = new List<SolarSystem>();
        }
        public List<SolarSystem> SolarSystems;
        public GalaxyType GalaxyEnum;

        public void Generate(int numStars, GalaxyType galaxyType)
        {
            for (int i = 0; i < numStars; i++)
            {
                SolarSystem ss = new SolarSystem();
                ss.Generate();
                SolarSystems.Add(ss);
            }
            // ToDo: use numStars and GalaxyType

        }

        public void LoadFromFile(string fileName)
        {
            // may not use this
        }
    }
}
