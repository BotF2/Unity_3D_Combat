using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class Galaxy
    {
       // public GameManager _gameManager;
        public List<SolarSystem> SolarSystems;
        public GalaxyType GalaxyEnum;
        public int NumberOfStars;
        public Galaxy(GameManager gameM, GalaxyType galaxyEnum, int numberOfStars)
        {
            //this._gameManager = gameManager;
            GalaxyEnum = galaxyEnum;
            NumberOfStars = numberOfStars;
            SolarSystems = GenerateSystems(numberOfStars);
            gameM.galaxy = this;
        }
        public List<Galaxy> GenerateGalaxy(GalaxyType galaxyEnum, int numberOfStars)
        {
            //this._gameManager = gameManager;
            GalaxyEnum = galaxyEnum;
            NumberOfStars = numberOfStars;
            SolarSystems = GenerateSystems(numberOfStars);
            List<Galaxy> result = new List<Galaxy>();
            result.Add(this);
            return result;
        }

        //public Galaxy()
        //{
        //    // not procedurally generate in constructor
        //    SolarSystems = new List<SolarSystem>();
        //}


        //private void Awake()
        //{
        //    gameManager = GameManager.Instance;
        //}
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
