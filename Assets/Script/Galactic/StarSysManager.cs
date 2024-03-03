using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Core;

public class StarSysManager : MonoBehaviour
{

    public List<StarSysSO> starSysSOListSmall;

    public List<StarSysSO> starSysSOListMedium;

    public List<StarSysSO> starSysSOListLarge;

    public List<StarSysData> starSysDataList;


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

    public void CreateGame(List<StarSysSO> starSysSOList)
    {

        foreach (var starSysSO in starSysSOList)
        {

            StarSysData SysData = new StarSysData();
            SysData.Position = starSysSO.Position;
            SysData.SysName = starSysSO.SysName;
            SysData.FirstOwner = starSysSO.FirstOwner;
            SysData.StarType = starSysSO.StarType;
            SysData.StarSprit = starSysSO.StarSprit;
            SysData.CurrentOwner = starSysSO.FirstOwner;
            SysData.Population = starSysSO.Population;
            // more stuff
            //public float _sysCredits;
            //public float _sysTaxRate; Set it at civ level
            //public float _sysPopLimit;
            //public float _currentSysPop;
            //public float _systemFactoryLimit; Do it all with pop limit??
            //public float _currentSysFactories;
            //public float _production;
            //private int _maintenanceCostLastTurn;
            //private int _rankCredits;
            //public List<CivHistory> _civHist_List = new List<CivHistory>();
            // public bool _homeColony;
            //public string _text;
            //public GameObject _systemSphere;
            //public List<GameObject> _fleetsInSystem;
            starSysDataList.Add(SysData);
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

