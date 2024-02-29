using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Core;

public class StarSysManager : MonoBehaviour
{

    public List<StarSysSO> starSysSOListSmall;

    public List<StarSysSO> starSysSOListMedium;

    public List<StarSysSO> starSysSOListLarge;



    public void CreateNewGame(int sizeGame)
    {
        if (sizeGame == 1)
        {
            CreateGame(starSysSOListSmall);
        }
        if (sizeGame == 2)
        {
            CreateGame(starSysSOListMedium);
        }
        if (sizeGame == 3)
        {
            CreateGame(starSysSOListLarge);
        }
    }


    public List<StarSysData> starSysDataList;

    public void CreateGame(List<StarSysSO> starSysSOList)
    {

        foreach (var starSysSO in starSysSOList)
        {

            StarSysData data = new StarSysData();
            //data.CivEnum = starSysSO.CivEnum;
            //data.CivImage = starSysSO.CivImage;
            //data.CivLongName = starSysSO.CivLongName;
            //data.CivShortName = starSysSO.CivShortName;


            starSysDataList.Add(data);

        }
    }

    public StarSysData resultInGameStarSysData;


    public StarSysData GetStarSysDataByName(string name)
    {

        StarSysData result = null;


        foreach (var sysData in starSysDataList)
        {

            if (sysData.SysName.Equals(name))
            {
                result = sysData;
            }


        }
        return result;

    }
    public void OnNewGameButtonClicked(int gameSize)
    {
        CreateNewGame(gameSize);

    }

    public void GetStarSysByName(string sysName)
    {
        resultInGameStarSysData = GetStarSysDataByName(sysName);

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

