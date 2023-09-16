using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using BOTF3D_Core;
using BOTF3D_Combat;
using BOTF3D_GalaxyMap;
using Assets.Script;


namespace BOTF3D_GalaxyMap
{
    public class Planet : OrbitalGalactic
    {
        public PlanetType planteType;
        public int planetImageNum;
        private float priorAngle;
        public int numMoons;

        public void LoadPlanet(Planet myPlanet, string[] systemData, int i)
        {
            myPlanet.OrbitalDistance = (myPlanet.OrbitalDistance) + ((ulong)i * (myPlanet.OrbitalDistance * (ulong)2));//80000000000)/8);
            OrbitalGalactic myOrbital = new OrbitalGalactic();
            this.TimeToOrbit = myOrbital.OrbitTime() + ((ulong)i * myOrbital.OrbitTime());// 365 * 24 * 60 * 60/5);
            string pType = systemData[8 + (i * 3)];
            switch (pType)
            {
                case "H":
                    this.planteType = PlanetType.H_uninhabitable;
                    this.GraphicID = (int)PlanetType.H_uninhabitable + 1; // H planet type index = 0 so GraphicID = 1, Star is graphicID = 0
                    this.planetImageNum = int.Parse(systemData[9 + (i * 3)]);
                    this.numMoons = int.Parse(systemData[10 + (i * 3)]);
                    break;
                case "J":
                    this.planteType = PlanetType.J_gasGiant; // J planet type GraphicID = 2
                    this.GraphicID = (int)PlanetType.J_gasGiant + 1;
                    this.planetImageNum = int.Parse(systemData[9 + (i * 3)]);
                    this.numMoons = int.Parse(systemData[10 + (i * 3)]);
                    break;
                case "M":
                    this.planteType = PlanetType.M_habitable; // M planet type GraphicID = 3
                    if (systemData[0] == "000" && systemData[15] == "2") // earth has unique image 2 for habitalbe planets
                        this.GraphicID = 7;
                    else
                        this.GraphicID = (int)PlanetType.M_habitable + 1;
                    this.planetImageNum = int.Parse(systemData[9 + (i * 3)]);
                    this.numMoons = int.Parse(systemData[10 + (i * 3)]);
                    break;
                case "L":
                    // not used yet
                    this.planteType = PlanetType.L_marginalForLife;// L planet type GraphicID = 4
                    this.GraphicID = (int)PlanetType.L_marginalForLife + 1;
                    this.planetImageNum = int.Parse(systemData[9 + (i * 3)]);
                    this.numMoons = int.Parse(systemData[10 + (i * 3)]);
                    break;
                case "K":
                    this.planteType = PlanetType.K_marsLike; // K planet type GraphicID = 5
                    this.GraphicID = (int)PlanetType.K_marsLike + 1;
                    this.planetImageNum = int.Parse(systemData[9 + (i * 3)]);
                    this.numMoons = int.Parse(systemData[10 + (i * 3)]);
                    break;
                //case "Moon":
                //    this.planteType = PlanetType.Moon;
                //    this.GraphicID = (int)PlanetType.Moon + 1; // Moon planet type GraphicID = 6
                //    break;
                default:
                    this.planteType = PlanetType.K_marsLike;
                    this.GraphicID = (int)PlanetType.K_marsLike + 1;
                    this.planetImageNum = int.Parse(systemData[9 + (i * 3)]);
                    this.numMoons = int.Parse(systemData[10 + (i * 3)]);
                    break;
            }

        }
        public Planet()
        {

        }
        public void LoadMoons(OrbitalGalactic planet, int moons)
        {
            for (int i = 0; i < moons; i++)
            {
                OrbitalGalactic moon = new OrbitalGalactic();
                planet.AddChild(moon);
                moon.OrbitalDistance = 5000000000 + (ulong)(5000000000 * i / 5);
                moon.TimeToOrbit = (moon.OrbitTime() + ((ulong)i * moon.OrbitTime() / 4));
                moon.GraphicID = (int)PlanetType.Moon + 1; // graphic id (on the orbitalgalatic ) = 6 is a moon
            }
        }
        //public void Generate(int maxMoons)
        //{
        //    this.OrbitalDistance = (ulong)UnityEngine.Random.Range(100, 800) * 1000000 * 1000;
        //    TimeToOrbit = this.OrbitTimeForDistance(); // ToDo: use real physics 
        //    GraphicID = UnityEngine.Random.Range(1, 12);
        //    int moons = UnityEngine.Random.Range(1, maxMoons + 1);
        //    for (int i= 0; i < moons; i++)
        //    {
        //        OrbitalGalactic moon = new OrbitalGalactic();
        //        this.AddChild(moon);
        //        moon.OrbitalDistance = 100000000000; // fix me
        //        moon.TimeToOrbit = moon.OrbitTimeForDistance()/10; // fix with real physics (orbital version)
        //    }
        //}

        new ulong OrbitTimeForDistance() // for planet
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
    }
}
