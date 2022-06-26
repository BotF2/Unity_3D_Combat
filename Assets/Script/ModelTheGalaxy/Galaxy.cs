using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


namespace Assets.Script
{
    public class Galaxy
    {
       // public GameManager _gameManager;
        public List<SolarSystem> SolarSystems;
        public GalaxyType GalaxyEnum;
        public int NumberOfStars;
        public Galaxy(GameManager gameManager, GalaxyType galaxyEnum, int numberOfStars)
        {
            // For now, we set a SEED for the random number generator, so that it
            // starts from the same galaxy every time, see planet.cs random now not so random
            UnityEngine.Random.InitState(123);
            
            //this._gameManager = gameManager;
            GalaxyEnum = galaxyEnum;
            NumberOfStars = numberOfStars;
            SolarSystems = GenerateSystems(numberOfStars);
            gameManager.galaxy = this;
        }

        public void Update(UInt64 timeSinceStart) 
        {
            // ToDo: Consider only updating the systems you are looking at
            foreach (SolarSystem ss in SolarSystems)
            {
                ss.Update(timeSinceStart); // solarsystem inherits from orbital with this Update()
            }
        }

        public List<SolarSystem> GenerateSystems(int numberOfStars)
        {
            List<SolarSystem> result = new List<SolarSystem>();
            for (int i = 0; i < numberOfStars; i++)
            {
                SolarSystem ss = new SolarSystem();
                ss.Generate();
                result.Add(ss);
            }
     
            return result;
        }
        public void Generate(int numStars, GalaxyType galaxyType)
        {
            //Galaxy galaxy = new Galaxy();
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

        public void LoadFromFile(string fileName)
        {
            // may not use this
        }
    }
}
