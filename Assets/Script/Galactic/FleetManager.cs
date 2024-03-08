using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;


namespace Assets.Core
{
    public class FleetManager : MonoBehaviour
    {
        public List<FleetSO> fleetSOListSmall;

        public List<FleetSO> fleetSOListMedium;

        public List<FleetSO> fleetSOListLarge;

        public List<FleetData> fleetDataList;

        public static void CreateNewGameFleets(int gameSize)
        {
            if(gameSize == 1)
            {
                CreateGameFleets(fleetSOListSmall) ;
            }
            if (gameSize == 2)
            {
                CreateGameFleets(fleetSOListMedium);
            }
            if (gameSize == 3)
            {
                CreateGameFleets(fleetSOListLarge);
            }

            //FleetData myfleet = new FleetData();
            //myfleet.civOwnerEnum = civData.CivEnum;
            //myfleet.defaultWarp = 0f;
        }

        public void CreateGameFleets(List<FleetSO> listFleetSO)
        {
            foreach (var fleetSO in listFleetSO)
            {
                FleetData data = new FleetData();
                //data.CivInt = civSO.CivInt;
                data.civOwnerEnum = fleetSO.CivOwnerEnum;
                //data.CivLongName = civSO.CivLongName;
                //data.CivShortName = civSO.CivShortName;
                //data.TraitOne = civSO.TraitOne;
                //data.TraitTwo = civSO.TraitTwo;
                //data.CivImage = civSO.CivImage;
                //data.Insignia = civSO.Insignia;
                //data.Population = civSO.Population;
                //data.Credits = civSO.Credits;
                //data.TechPoints = civSO.TechPoints;
                fleetDataList.Add(data);
            }
        }
        public FleetData resultFleetData;


        public FleetData GetFleetDataByName(string fleetName)
        {

            FleetData result = null;


            foreach (var fleet in fleetDataList)
            {

                if (fleet.fleetName.Equals(fleetName))
                {
                    result = fleet;
                }
            }
            return result;

        }
        //public void OnNewGameButtonClicked(int gameSize)
        //{
        //    CreateNewGame(gameSize);

        //}

        public void GetFleetByName(string fleetName)
        {
            resultFleetData = GetFleetDataByName(fleetName);

        }

    }
}