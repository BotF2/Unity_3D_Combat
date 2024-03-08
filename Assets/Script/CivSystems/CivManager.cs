using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

namespace Assets.Core
{
    public enum CivEnum
    {
        FED,
        ROM,
        KLING,
        CARD,
        DOM,
        BORG,
        #region minors
        ACAMARIANS,
        AKAALI,
        AKRITIRIANS,
        ALDEANS,
        ALGOLIANS,
        ALSAURIANS,
        ANDORIANS,
        ANGOSIANS,
        ANKARI,
        ANTEDEANS,
        ANTICANS,
        ARBAZAN,
        ARDANANS,
        ARGRATHI,
        ARKARIANS,
        ATREANS,
        AXANAR,
        BAJORANS,
        BAKU,
        BANDI,
        BANEANS,
        BARZANS,
        BENZITES,
        BETAZOIDS,
        BILANAIANS,
        BOLIANS,
        BOMAR,
        BOSLICS,
        BOTHA,
        BREELLIANS,
        BREEN,
        BREKKIANS,
        BYNARS,
        CAIRN,
        CALDONIANS,
        CAPELLANS,
        CHALNOTH,
        CORIDAN,
        CORVALLENS,
        CYTHERIANS,
        DELTANS,
        DENOBULANS,
        DEVORE,
        DOPTERIANS,
        DOSI,
        DRAI,
        DREMANS,
        EDO,
        ELAURIANS,
        ELAYSIANS,
        ENTHARANS,
        EVORA,
        EXCALBIANS,
        FERENGI,
        FLAXIANS,
        GORN,
        GRAZERITES,
        HAAKONIANS,
        HALKANS,
        HAZARI,
        HEKARANS,
        HIROGEN,
        HORTA,
        IYAARANS,
        JNAII,
        KAELON,
        KAREMMA,
        KAZON,
        KELLERUN,
        KESPRYTT,
        KLAESTRONIANS,
        KRADIN,
        KREETASSANS,
        KRIOSIANS,
        KTARIANS,
        LEDOSIANS,
        LISSEPIANS,
        LOKIRRIM,
        LURIANS,
        MALCORIANS,
        MALON,
        MAQUIS,
        MARKALIANS,
        MERIDIANS,
        MINTAKANS,
        MIRADORN,
        MIZARIANS,
        MOKRA,
        MONEANS,
        NAUSICAANS,
        NECHANI,
        NEZU,
        NORCADIANS,
        NUMIRI,
        NUUBARI,
        NYRIANS,
        OCAMPA,
        ORIONS,
        ORNARANS,
        PAKLED,
        PARADANS,
        QUARREN,
        RAKHARI,
        RAKOSANS,
        RAMATIANS,
        REMANS,
        RIGELIANS,
        RISIANS,
        RUTIANS,
        SELAY,
        SHELIAK,
        SIKARIANS,
        SKRREEA,
        SONA,
        SULIBAN,
        TAKARANS,
        TAKARIANS,
        TAKTAK,
        TALARIANS,
        TALAXIANS,
        TALOSIANS,
        TAMARIANS,
        TANUGANS,
        TELLARITES,
        TEPLANS,
        THOLIANS,
        TILONIANS,
        TLANI,
        TRABE,
        TRILL,
        TROGORANS,
        TZENKETHI,
        ULLIANS,
        VAADWAUR,
        VENTAXIANS,
        VHNORI,
        VIDIIANS,
        VISSIANS,
        VORGONS,
        VORI,
        VULCANS,
        WADI,
        XANTHANS,
        XEPOLITES,
        XINDI,
        XYRILLIANS,
        YADERANS,
        YRIDIANS,
        ZAHL,
        ZAKDORN,
        ZALKONIANS,
        ZIBALIANS,
        #endregion
        TERRAN,
        ZZUNINHABITED1,
        #region More Uninhabited
        ZZUNINHABITED2,
        ZZUNINHABITED3,
        ZZUNINHABITED4,
        ZZUNINHABITED5,
        ZZUNINHABITED6,
        ZZUNINHABITED7,
        ZZUNINHABITED8,
        ZZUNINHABITED9,
        ZZUNINHABITED10,
        #endregion
    }

    public class CivManager : MonoBehaviour
    {

        public List<CivSO> civSOListSmall;

        public List<CivSO> civSOListMedium;

        public List<CivSO> civSOListLarge;

        public List<CivData> civDataList;

        public void CreateNewGame(int sizeGame)
        {
            if (sizeGame == 1)
            {
                CreateGameCivs(civSOListSmall);
                FleetManager.CreateNewGameFleets(1);
            }
            if (sizeGame == 2)
            {
                CreateGameCivs(civSOListMedium);
                //FleetManager.CreateNewGameFleets(2);
            }
            if (sizeGame == 3)
            {
                CreateGameCivs(civSOListLarge);
                //FleetManager.CreateNewGameFleets(3);
            }
        }

        public void CreateGameCivs(List<CivSO> civSOList)
        {

            foreach (var civSO in civSOList)
            {
                CivData data = new CivData();
                data.CivInt = civSO.CivInt;
                data.CivEnum = civSO.CivEnum;
                data.CivLongName = civSO.CivLongName;
                data.CivShortName = civSO.CivShortName;
                data.TraitOne = civSO.TraitOne;
                data.TraitTwo = civSO.TraitTwo;
                data.CivImage = civSO.CivImage;
                data.Insignia = civSO.Insignia;
                data.Population = civSO.Population;
                data.Credits = civSO.Credits;
                data.TechPoints = civSO.TechPoints;
                civDataList.Add(data);
            }


        }

        public CivData resultInGameCivData;

        public CivData GetCivDataByName(string shortName)
        {

            CivData result = null;


            foreach (var civ in civDataList)
            {

                if (civ.CivShortName.Equals(shortName))
                {
                    result = civ;
                }


            }
            return result;

        }
        public void OnNewGameButtonClicked(int gameSize)
        {
            CreateNewGame(gameSize);

        }

        public void GetCivByName(string civname)
        {
            resultInGameCivData = GetCivDataByName(civname);

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
}
