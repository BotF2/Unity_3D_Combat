using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;


namespace Assets.Core
{
    public class FleetManager : MonoBehaviour
    {

        public List<FleetData> fleetDataList;

        public static void CreateFirstFleets(List<CivData> gameCivDataList)
        {

            foreach (var CivSO in gameCivDataList)
            {
                // starter Fleet
                //    public string fleetName;
                //public string description;
                //public Sprite insign;
                //public Civilization civOwnerEnum;
                //public Vector3 location;
                //public List<Ship> ships;
                //public float warpFactor;
                //public GameObject destination;
                //public GameObject origin;
                //public float defaultWarp = 0;

            }
        }

        public CivData resultInGameCivData;


        public CivData GetCivDataByName(string shortName)
        {

            CivData result = null;


            foreach (var civ in fleetDataList)
            {

                //if (civ.CivShortName.Equals(shortName))
                //{
                //    result = civ;
                //}


            }
            return result;

        }
        //public void OnNewGameButtonClicked(int gameSize)
        //{
        //    CreateNewGame(gameSize);

        //}

        public void GetCivByName(string civname)
        {
            resultInGameCivData = GetCivDataByName(civname);

        }

    }
}
