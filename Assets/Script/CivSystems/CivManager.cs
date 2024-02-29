using System;
using System.Collections;
using System.Collections.Generic;
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
        ZIBALIANS
        #endregion
    }

    public class CivManager : MonoBehaviour
    {

        public List<CivSO> civSOListSmall;

        public List<CivSO> civSOListMedium;

        public List<CivSO> civSOListLarge;



        public void CreateNewGame(int sizeGame)
        {
            if (sizeGame == 1)
            {
                CreateGame(civSOListSmall);
            }
            if (sizeGame == 2)
            {
                CreateGame(civSOListMedium);
            }
            if (sizeGame == 3)
            {
                CreateGame(civSOListLarge);
            }
        }


        public List<CivData> civDataList;

        public void CreateGame(List<CivSO> civSOList)
        {

            foreach (var civSO in civSOList)
            {

                CivData data = new CivData();
                data.CivEnum = civSO.CivEnum;
                data.CivImage = civSO.CivImage;
                data.CivLongName = civSO.CivLongName;
                data.CivShortName = civSO.CivShortName;


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
        //public static CivEnum GetMyEnum(string title)
        //{
        //    CivEnum st;
        //    Enum.TryParse(title, out st);
        //    return st;
        //}

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
