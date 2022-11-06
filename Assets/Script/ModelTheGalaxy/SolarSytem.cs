using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class SolarSystem : OrbitalGalactic
    {
        public int SystemGraphicID;
        public GameManager gameManager; // grant access to GameManager by assigning it in the Unit inspector field for public gameManager
        public int sysID;
        public Vector3 sysLocation;
        public string sysName;
        public Civilization sysCivOwner;
        public SystemType sysType;
        public StarType sysStarType;
        public Planet[] sysPlanets;
        
        public SolarSystem LoadSystem(string[] systemData, int whatButton)
        {
            OrbitalGalactic myStar = new OrbitalGalactic(); // empty for our planets to orbit
            myStar.GraphicID = 0; // StarGraphicID;
            this.sysID = whatButton;
            this.sysLocation = new Vector3(int.Parse(systemData[1]), int.Parse(systemData[2]), int.Parse(systemData[3]));
            this.sysName = systemData[4];
            this.sysCivOwner = GetCivOwnerEnum(systemData[5]);
            this.sysType = GetSystemType(systemData[6]);
            this.sysStarType = GetStarTypeEnum(systemData[7]);
            this.sysPlanets = GetPlanetArray(systemData);
            this.AddChild(myStar);
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
            return this;
        }
        public SolarSystem Generate()
        {
            // make a solar system, myStar is a child of the system and myStar has child planets...
            // That is all we do here so far, consider random generate locations 

            OrbitalGalactic myStar = new OrbitalGalactic();
            myStar.GraphicID = 0; // StarGraphicID;
            this.AddChild(myStar);
            // dealing with planets and moon in SolarSystemView and from SystemData.csv
            //for (int i = 0; i < 8; i++) // all systems have 8 planets for now
            //{
            //    Planet planet = new Planet();
            //    planet.Generate(3);
            //    //planet.GraphicID = PlanetGraphicID;
            //    myStar.AddChild(planet);
            //}
            return this;
        }
        //public SolarSystem GenerateGalaxyCenter()
        //{
        //    OrbitalGalactic myStar = new OrbitalGalactic();
        //    myStar.GraphicID = 0; // StarGraphicID; 

        //    return this;
        //}
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
        public Civilization GetCivOwnerEnum(string civ)
        {
            #region Geting Civ
            Civilization theCiv = Civilization.FED;
            switch (civ)
            {
                case "FED":
                    theCiv = Civilization.FED;
                    break;
                case "ROM":
                    theCiv = Civilization.ROM;
                    break;
                case "KLING":
                    theCiv = Civilization.KLING;
                    break;
                case "CARD":
                    theCiv = Civilization.CARD;
                    break;
                case "DOM":
                    theCiv = Civilization.DOM;
                    break;
                case "BORG":
                    theCiv = Civilization.BORG;
                    break;
                case "ACAMARIAN":
                    theCiv = Civilization.ACAMARIAN;
                    break;
                //case Civilization.AKAALI:
                //    break;
                //case Civilization.AKRITIRIAN:
                //    break;
                //case Civilization.ALDEAN:
                //    break;
                //case Civilization.ALGOLIAN:
                //    break;
                //case Civilization.ALSAURIAN:
                //    break;
                //case Civilization.ANDORIAN:
                //    break;
                //case Civilization.ANGOSIAN:
                //    break;
                //case Civilization.ANKARI:
                //    break;
                //case Civilization.ANTEDEAN:
                //    break;
                //case Civilization.ANTICAN:
                //    break;
                //case Civilization.ARBAZAN:
                //    break;
                //case Civilization.ARGRATHI:
                //    break;
                //case Civilization.AXANARIAN:
                //    break;
                //case Civilization.BAJORAN:
                //    break;
                //case Civilization.BAKU:
                //    break;
                //case Civilization.BANEAN:
                //    break;
                //case Civilization.BARZAN:
                //    break;
                //case Civilization.BENZIT:
                //    break;
                //case Civilization.BETAZOID:
                //    break;
                //case Civilization.BOLIAN:
                //    break;
                //case Civilization.BOMAR:
                //    break;
                //case Civilization.BOTHAN:
                //    break;
                //case Civilization.BREELLIAN:
                //    break;
                //case Civilization.BREEN:
                //    break;
                //case Civilization.BREKKIAN:
                //    break;
                //case Civilization.CALDONIAN:
                //    break;
                //case Civilization.CHALNOTHIAN:
                //    break;
                //case Civilization.CORIDAN:
                //    break;
                //case Civilization.CORVALLEN:
                //    break;
                //case Civilization.CYTHERIAN:
                //    break;
                //case Civilization.DENOBULAN:
                //    break;
                //case Civilization.DEVOREN:
                //    break;
                //case Civilization.DOSI:
                //    break;
                //case Civilization.DRAI:
                //    break;
                //case Civilization.ELAURIAN:
                //    break;
                //case Civilization.ENTHARAN:
                //    break;
                //case Civilization.EVORAN:
                //    break;
                //case Civilization.EXCALBIAN:
                //    break;
                //case Civilization.FERENGI:
                //    break;
                //case Civilization.FLAXIAN:
                //    break;
                //case Civilization.GORN:
                //    break;
                //case Civilization.HAAKONIAN:
                //    break;
                //case Civilization.HALKAN:
                //    break;
                //case Civilization.HAZARI:
                //    break;
                //case Civilization.HIROGEN:
                //    break;
                //case Civilization.IYAARAN:
                //    break;
                //case Civilization.KAELON:
                //    break;
                //case Civilization.KAREMMAN:
                //    break;
                //case Civilization.KAZON:
                //    break;
                //case Civilization.KELLERUN:
                //    break;
                //case Civilization.KESPRYTT:
                //    break;
                //case Civilization.KLAESTRONIAN:
                //    break;
                //case Civilization.KRADIN:
                //    break;
                //case Civilization.KREETASSAN:
                //    break;
                //case Civilization.LEDOSIAN:
                //    break;
                //case Civilization.LISSEPIAN:
                //    break;
                //case Civilization.LOKIRRIM:
                //    break;
                //case Civilization.LURIAN:
                //    break;
                //case Civilization.MALON:
                //    break;
                //case Civilization.MERIDIAN:
                //    break;
                //case Civilization.MINTAKAN:
                //    break;
                //case Civilization.MIRADORN:
                //    break;
                //case Civilization.MIZARIAN:
                //    break;
                //case Civilization.MOKRAN:
                //    break;
                //case Civilization.MONEAN:
                //    break;
                //case Civilization.NAUSICAAN:
                //    break;
                //case Civilization.NECHANI:
                //    break;
                //case Civilization.NEZU:
                //    break;
                //case Civilization.NORCADIAN:
                //    break;
                //case Civilization.NUMIRI:
                //    break;
                //case Civilization.NUUBARI:
                //    break;
                //case Civilization.NYRIAN:
                //    break;
                //case Civilization.OCAMPAN:
                //    break;
                //case Civilization.PARADAN:
                //    break;
                //case Civilization.QUARREN:
                //    break;
                //case Civilization.RAKHARI:
                //    break;
                //case Civilization.RAKOSAN:
                //    break;
                //case Civilization.RAMATIAN:
                //    break;
                //case Civilization.RIGELIAN:
                //    break;
                //case Civilization.RISIAN:
                //    break;
                //case Civilization.SELAY:
                //    break;
                //case Civilization.SIKARIAN:
                //    break;
                //case Civilization.SKRREEAN:
                //    break;
                //case Civilization.SONAN:
                //    break;
                //case Civilization.TAKARAN:
                //    break;
                //case Civilization.TAKARIAN:
                //    break;
                //case Civilization.TAKTAK:
                //    break;
                //case Civilization.TALARIAN:
                //    break;
                //case Civilization.TALAXIAN:
                //    break;
                //case Civilization.TALOSIAN:
                //    break;
                //case Civilization.TAMARIA:
                //    break;
                //case Civilization.TELLARITE:
                //    break;
                //case Civilization.TEPLAN:
                //    break;
                //case Civilization.THOLIAN:
                //    break;
                //case Civilization.TILONIAN:
                //    break;
                //case Civilization.TLANI:
                //    break;
                //case Civilization.TRABEN:
                //    break;
                //case Civilization.TRILL:
                //    break;
                //case Civilization.TROGORAN:
                //    break;
                //case Civilization.TZENKETHI:
                //    break;
                //case Civilization.ULLIAN:
                //    break;
                //case Civilization.VAADWAUR:
                //    break;
                //case Civilization.VENTAXIAN:
                //    break;
                //case Civilization.VHNORI:
                //    break;
                //case Civilization.VIDIIAN:
                //    break;
                //case Civilization.VISSIAN:
                //    break;
                //case Civilization.VORGON:
                //    break;
                //case Civilization.VORI:
                //    break;
                //case Civilization.VULCAN:
                //    break;
                //case Civilization.WADI:
                //    break;
                //case Civilization.XANTHAN:
                //    break;
                //case Civilization.XEPOLITES:
                //    break;
                //case Civilization.XINDI:
                //    break;
                //case Civilization.XYRILLIAN:
                //    break;
                //case Civilization.YADERAN:
                //    break;
                //case Civilization.YRIDIAN:
                //    break;
                //case Civilization.ZAHL:
                //    break;
                //case Civilization.ZALKONIAN:
                //    break;
                //case Civilization.ZIBAL:
                //    break;
                //case Civilization.TEMPLATE:
                    //break;
                default:
                    break;
            }
            return theCiv;
            #endregion GetCiv
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
