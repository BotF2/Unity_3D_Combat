using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Core;

namespace GalaxyMap
{

    public class SolarSystem : OrbitalGalactic
    {
        public int SystemGraphicID;
        public GameManager gameManager; // grant access to GameManager by assigning it in the Unit inspector field for public gameManager
        public int sysID;
        public Vector3 sysLocation;
        public string sysName;
        public string sysOwner;
        public int sysPop;
        public SystemType sysType;
        public StarType sysStarType;
        public Planet[] sysPlanets;
        public Sprite spriteForOwnerCiv;
        public Sprite spriteForOwnerInsignia;

        public SolarSystem LoadSystem(string[] systemData, int whatButton)
        {
            OrbitalGalactic myStar = new OrbitalGalactic(); // empty for our planets to orbit
            myStar.GraphicID = 0; // StarGraphicID;
            this.sysID = whatButton;
            this.sysLocation = new Vector3(int.Parse(systemData[1]), int.Parse(systemData[2]), int.Parse(systemData[3]));
            this.sysName = systemData[4];
            //this.sysCivOwner = GetCivOwnerEnum(systemData[5]);
            this.sysPop = int.Parse(systemData[6]);
            this.sysType = GetSystemType(systemData[7]);
            this.sysStarType = GetStarTypeEnum(systemData[8]);
            this.sysPlanets = GetPlanetArray(systemData);
            this.AddChild(myStar);
            this.spriteForOwnerInsignia = Resources.Load<Sprite>("Insignias/" + systemData[5]); // using name of original civ of system 
            this.spriteForOwnerCiv = Resources.Load<Sprite>("Civilizations/" + systemData[5].ToLower());
            this.sysName = systemData[4];
            this.sysOwner = systemData[5];
            if (systemData[7] == "Nebula" || systemData[7] == "Complex")
            {
                // ToDo sprite sheet animation / nebula background too
            }
            else
            {
                for (int i = 0; i < 8; i++) // all systems have 8 planets for now, setting up the orbitals for display
                {
                    Planet planet = new Planet();
                    planet.LoadPlanet(planet, systemData, i);
                    myStar.AddChild(planet);
                    int numMoons = int.Parse(systemData[10 + (i * 3)]);
                    switch (numMoons)
                    {
                        case 0:
                            break;
                        case 1:
                            planet.LoadMoons(planet, 1);
                            break;
                        case 2:
                            planet.LoadMoons(planet, 2);
                            break;
                        case 3:
                            planet.LoadMoons(planet, 3);
                            break;
                    }
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
            return this;
        }
        public Planet[] GetPlanetArray(string[] planets)
        {
            List<Planet> planetList = new List<Planet>();
            for (int i = 0; i < 8; i++)
            {
                Planet p = new Planet();
                p.planteType = GetPlanetType(planets[8 + (i * 3)]);
                p.planetImageNum = int.Parse(planets[9 + (i * 3)]);
                p.numMoons = int.Parse(planets[10 + (i * 3)]);
                planetList.Add(p);
            }
            return planetList.ToArray();
        }
        public PlanetType GetPlanetType(string type)
        {
            PlanetType theType = PlanetType.H_uninhabitable;
            switch (type)
            {
                case "H":
                    theType = PlanetType.H_uninhabitable;
                    break;
                case "J":
                    theType = PlanetType.J_gasGiant;
                    break;
                case "K":
                    theType = PlanetType.K_marsLike;
                    break;
                case "M":
                    theType = PlanetType.M_habitable;
                    break;
                // we are not doing moon here at this time
                default:
                    break;
            }
            return theType;
        }
        public SystemType GetSystemType(string sysType)
        {
            SystemType theSys = SystemType.YellowStarSystem;
            switch (sysType)
            {
                case "YellowStarSystem":
                    theSys = SystemType.YellowStarSystem;
                    break;
                case "OrnageStarSystem":
                    theSys = SystemType.OrangeStarSystem;
                    break;
                case "WhiteStarSystem":
                    theSys = SystemType.WhiteStarSystem;
                    break;
                case "RedStarSystem":
                    theSys = SystemType.RedStarSystem;
                    break;
                case "NebulaSystem":
                    theSys = SystemType.NebulaSystem;
                    break;
                case "ComplexSystem":
                    theSys = SystemType.ComplexSystem;
                    break;
                case "BlackHoleSystem":
                    theSys = SystemType.BlackHoleSystem;
                    break;
                case "WormHoleSystem":
                    theSys = SystemType.WormHoleSystem;
                    break;
                case "TranWarpHub":
                    theSys = SystemType.TranWarpHubSystem;
                    break;
                default:
                    break;
            }
            return theSys;
        }
        public StarType GetStarTypeEnum(string star)
        {
            StarType thisStar = new StarType();
            switch (star)
            {
                case "Blue":
                    thisStar = StarType.Blue;
                    break;
                case "White":
                    thisStar = StarType.White;
                    break;
                case "Yellow":
                    thisStar = StarType.Yellow;
                    break;
                case "Orange":
                    thisStar = StarType.Orange;
                    break;
                case "Red":
                    thisStar = StarType.Red;
                    break;
                case "Nebula":
                    thisStar = StarType.Nebula;
                    break;
                case "Complex":
                    thisStar = StarType.Complex;
                    break;
                case "BlackHole":
                    thisStar = StarType.BlackHole;
                    break;
                case "WormHole":
                    thisStar = StarType.WormHole;
                    break;
                default:
                    break;
            }
            return thisStar;
        }
    }
}

