using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using Assets.Script;
using BOTF3D_Core;
using BOTF3D_Combat;

namespace BOTF3D_GalaxyMap
{
    public class GalaxyShip : MonoBehaviour // Do We Need this as well as Fleet?????
    {
        //public GameManager gameManager; // grant access to GameManager by assigning it in the Unit inspector field for public gameManager
        //public GameObject prefabGalaxyShip;                                //public Combat combat;
        public CivEnum _civilization;
        public string _shipName;
        public TechLevel _techLeve;
        public float _techPoints; // this comes from the owner civ so fill it in once in combat, not here

        public GalaxyShip LoadGalaxyShip(CivEnum civEnum, string shipName, TechLevel techLevel) //float techPoints)
        {
            this._civilization = civEnum;
            this._shipName = shipName;
            this._techLeve = techLevel;
            //this._techPoints = techPoints;
            return this;
        }
        public List<GalaxyShip> LoadListGalaxyShips(int[] numGalaxyShips, GalaxyShip[] galaxyShips)
        {
            List<GalaxyShip> galayShipList = new List<GalaxyShip>();
            for (int i = 0; i < numGalaxyShips.Count(); i++)
            {
                for (int j = 0; j < numGalaxyShips[i]; j++)
                {
                    galayShipList.Add(galayShipList[i]);
                }
            }
            return galayShipList;
            //GalaxyShip galaxyShip = new GalaxyShip();
            //return new List<GalaxyShip> {galaxyShip};
        }
        //public CivEnum CivEnumFromName(string name)
        //{
        //    var file = new FileStream(name, FileMode.Open, FileAccess.Read);

        //    var _dataPoints = new List<string>();
        //    using (var reader = new StreamReader(file))
        //    {

        //        while (!reader.EndOfStream)
        //        {
        //            var line = reader.ReadLine();
        //            if (line == null)
        //                continue;
        //            _dataPoints.Add(line.Trim());
        //            if (line.Length > 0)
        //            {
        //                var coll = line.Split("-");
        //                if (Enum.TryParse<CivEnum>(coll[0], out CivEnum civEnum))
        //                {
        //                    return civEnum;
        //                }

        //            }
        //        }
        //        return CivEnum.UNINHABITED;
        //    }
        //}


        private void Awake()
        {
            //string[] nameArray = new string[3] { "civilization", "shipType", "era" };
            //if (this.name != "Ship")
            //{
            //    nameArray = this.name.Split('_');
            //}
            //string typeOfShip = nameArray[1];

            //switch (typeOfShip.ToUpper())
            //{
            //    case "SCOUT":
            //        _shipType = ShipType.Scout;
            //        break;
            //    case "DESTROYER":
            //        _shipType = ShipType.Destroyer;
            //        break;
            //    case "CURISER":
            //        _shipType = ShipType.Cruiser;
            //        break;
            //    case "LTCURISER":
            //        _shipType = ShipType.LtCruiser;
            //        break;
            //    case "HVYCURISER":
            //        _shipType = ShipType.HvyCruiser;
            //        break;
            //    case "TRANSPORT":
            //        _shipType = ShipType.Transport;
            //        break;
            //    case "ONEMORE":
            //        _shipType = ShipType.OneMore;
            //        break;
            //    default:
            //        break;
            //}
            //string civ = nameArray[0];
            //switch (civ.ToUpper())
            //{
            //    case "FED":
            //        _civilization = CivEnum.FED;
            //        break;
            //    //case "TERRAN":
            //    //    _civilization = Civilization.TERRAN;
            //    //    break;
            //    case "ROM":
            //        _civilization = CivEnum.ROM;
            //        break;
            //    case "KLING":
            //        _civilization = CivEnum.KLING;
            //        break;
            //    case "CARD":
            //        _civilization = CivEnum.CARD;
            //        break;
            //    case "DOM":
            //        _civilization = CivEnum.DOM;
            //        break;
            //    case "BORG":
            //        _civilization = CivEnum.BORG;
            //        break;
            //    default:
            //        //_civilization = CivEnum.ACAMARIANS;
            //        break;
            //}
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
