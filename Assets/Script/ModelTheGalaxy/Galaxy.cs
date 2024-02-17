using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
//using BOTF3D_Core;
using Assets.Core;
//using BOTF3D_Combat;

namespace GalaxyMap
{
    public class Galaxy
    {
        public static Galaxy theGalaxy;
        public List<SolarSystem> SolarSystems;
        public bool GalaxyNotNull = false;
        public int NumberOfStars;
        public SolarSystem galaxyCenter = new SolarSystem();
        public Dictionary<Vector3, SolarSystem> SolarSystemsMap;
        public Galaxy(GameManager gameManager)
        {
            gameManager.galaxy = this;
            theGalaxy = this;

            // For now, we set a SEED for the random number generator, so that it
            // starts from the same galaxy every time, see planet.cs random is now not so random
            //UnityEngine.Random.InitState(123);
            //NumberOfStars = numberOfStars;

            //SolarSystems = GenerateSystems(numberOfStars); // for solar system view

            //this.AddChild(myStar);

        }

        public void Update(UInt64 timeSinceStart)
        {
            // ToDo: Consider only updating the systems you are looking at
            foreach (SolarSystem ss in SolarSystems)
            {
                ss.Update(timeSinceStart); // solarsystem inherits from orbital with this Update()
            }
        }

        public SolarSystem LoadThisSystem(int systemButtonID) // Do we need this for just a single system to be shown by SolarSystemView??
        {

            SolarSystem ss = new SolarSystem();
            ss.Generate();
            //result.Add(ss);

            return ss;
        }
        public List<SolarSystem> GenerateSystems(int numberOfStars) // ToDo: load SystemDate.txt instead of generate
        {
            List<SolarSystem> result = new List<SolarSystem>();
            for (int i = 0; i < numberOfStars; i++)
            {
                if (i == 0)
                {
                    // ToDo: use GalaxyView (like a SolarSystem.cs but no moons, just solar systems as buttons in place of stars of a solcar system
                    // a GenerateGalaxyMap() that give buttons for solar systems form GalaxyMap class

                }
                SolarSystem ss = new SolarSystem();
                ss.Generate();
                result.Add(ss);
            }

            return result;
        }
        public bool DoWeHaveAGalaxy()
        {
            if (SolarSystems.Count != 0)
            {
                GalaxyNotNull = true;
            }
            return GalaxyNotNull;
        }
        public void Generate(int numStars) // non canon map generated
        {
            if (SolarSystems.Count == 0)
            {
                NumberOfStars = numStars;
                for (int i = 0; i < numStars; i++)
                {
                    SolarSystem ss = new SolarSystem();
                    ss.Generate();
                    SolarSystems.Add(ss);
                    // galaxy.AddChild(ss);
                }
                //gameManager.Galaxy = galaxy;

                // ToDo: use numStars and GalaxyType
            }
        }
    }
}
