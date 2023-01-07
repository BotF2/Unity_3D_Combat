using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Assets.Script;
using BOTF3D_Combat;
using UnityEngine.XR;
using static UnityEngine.ParticleSystem;
using UnityEngine.Rendering;
using BOTF3D_GalaxyMap;

namespace BOTF3D_Core
{
    [System.Serializable]
    public class Civilization
    {
        #region Fields

        //ToDo: add 2 Traints for a civ
        public int _civID;
        public string _shortName;
        public string _longName;
        //public Race race -- try to leave this off, too complicated
        public StarSystem _homeSystem;
        //public Traits _traitOne;
        //public Traits _traitTwo;
        public Sprite _raceImage;
        public Sprite _insignia;
        //private readonly int _civId;
        public float _credits;
        //private List<Bonus> _globalBonuses;
        //private readonly CivilizationMapData _mapData;
        //private readonly ResearchPool _research;
        //private readonly ResourcePool _resources;
        //private readonly List<SitRepEntry> _sitRepEntries;
        //public int _totalPopulation;
        //private readonly Meter _totalValue;
        public float _civResearch;
        public float _civCredits;
        //private readonly Treasury _treasury;
        //private int _maintenanceCostLastTurn;
        //private int _rankCredits;
        //public List<CivHistory> _civHist_List = new List<CivHistory>();
        public List<Civilization> _contactList;
       // public StarSystem _homeColony;
        public List<StarSystem> _ownedSystem;
        //private List<int> _IntelIDs;
        //private MapLocation? _homeColonyLocation;
        //private int _seatOfGovernmentId = -1;
        //private readonly Meter _totalIntelligenceAttackingAccumulated;
        //private readonly Meter _totalIntelligenceDefenseAccumulated;
        public string _text;
        //private int _rankMaint;
        //private int _rankResearch;
        //private int _rankIntelAttack;
        //private readonly string newline = Environment.NewLine;
        //private readonly IPlayer _localPlayer;
        //private readonly AppContext _appContext;

        #endregion Fields

        #region Civs
        //public HoverTipManager hoverTipManager;
        // public GalaxyView galaxyView;
        //public Civilization FED;
        //public Civilization ROM;
        //public Civilization KLING;
        //public Civilization CARD;
        //public Civilization DOM;
        //public Civilization BORG;

        //public Civilization ACAMARIANS;
        //public Civilization AKAALI;
        //public Civilization AKRITIRIANS;
        //public Civilization ALDEANS;
        //public Civilization ALGOLIANS;
        //public Civilization ALSAURIANS;
        //public Civilization ANDORIANS;
        //public Civilization ANGOSIANS;
        //#region More Civs
        ////public Civilization ANKARI;
        ////public Civilization ANTEDEANS;
        ////public Civilization ANTICANS;
        ////public Civilization ARBAZAN;
        ////public Civilization ARDANANS;
        ////public Civilization ARGRATHI;
        ////public Civilization ARKARIANS;
        ////public Civilization ATREANS;
        ////public Civilization AXANAR;
        ////public Civilization BAJORANS;
        ////public Civilization BAKU;
        ////public Civilization BANDI;
        ////public Civilization BANEANS;
        ////public Civilization BARZANS;
        ////public Civilization BENZITES;
        ////public Civilization BETAZOIDS;
        ////public Civilization BILANAIANS;
        ////public Civilization BOLIANS;
        ////public Civilization BOMAR;
        ////public Civilization BOSLICS;
        ////public Civilization BOTHA;
        ////public Civilization BREELLIANS;
        ////public Civilization BREEN;
        ////public Civilization BREKKIANS;
        ////public Civilization BYNARS;
        ////public Civilization CAIRN;
        ////public Civilization CALDONIANS;
        ////public Civilization CAPELLANS;
        ////public Civilization CHALNOTH;
        ////public Civilization CORIDAN;
        ////public Civilization CORVALLENS;
        ////public Civilization CYTHERIANS;
        ////public Civilization DELTANS;
        ////public Civilization DENOBULANS;
        ////public Civilization DEVORE;
        ////public Civilization DOPTERIANS;
        ////public Civilization DOSI;
        ////public Civilization DRAI;
        ////public Civilization DREMANS;
        ////public Civilization EDO;
        ////public Civilization ELAURIANS;
        ////public Civilization ELAYSIANS;
        ////public Civilization ENTHARANS;
        ////public Civilization EVORA;
        ////public Civilization EXCALBIANS;
        ////public Civilization FERENGI;
        ////public Civilization FLAXIANS;
        ////public Civilization GORN;
        ////public Civilization GRAZERITES;
        ////public Civilization HAAKONIANS;
        ////public Civilization HALKANS;
        ////public Civilization HAZARI;
        ////public Civilization HEKARANS;
        ////public Civilization HIROGEN;
        ////public Civilization HORTA;
        ////public Civilization IYAARANS;
        ////public Civilization JNAII;
        ////public Civilization KAELON;
        ////public Civilization KAREMMA;
        ////public Civilization KAZON;
        ////public Civilization KELLERUN;
        ////public Civilization KESPRYTT;
        ////public Civilization KLAESTRON;
        ////public Civilization KRADIN;
        ////public Civilization KREETASSANS;
        ////public Civilization KRIOSIANS;
        ////public Civilization KTARIANS;
        ////public Civilization LEDOSIANS;
        ////public Civilization LISSEPIANS;
        ////public Civilization LOKIRRIM;
        ////public Civilization LURIANS;
        ////public Civilization MALCORIANS;
        ////public Civilization MALON;
        ////public Civilization MAQUIS;
        ////public Civilization MARKALIANS;
        ////public Civilization MERIDIANS;
        ////public Civilization MINTAKANS;
        ////public Civilization MIRADORN;
        ////public Civilization MIZARIANS;
        ////public Civilization MOKRA;
        ////public Civilization MONEANS;
        ////public Civilization NAUSICAANS;
        ////public Civilization NECHANI;
        ////public Civilization NEZU;
        ////public Civilization NORCADIANS;
        ////public Civilization NUMIRI;
        ////public Civilization NUUBARI;
        ////public Civilization NYRIANS;
        ////public Civilization OCAMPA;
        ////public Civilization ORIONS;
        ////public Civilization ORNARANS;
        ////public Civilization PAKLED;
        ////public Civilization PARADANS;
        ////public Civilization QUARREN;
        ////public Civilization RAKHARI;
        ////public Civilization RAKOSANS;
        ////public Civilization RAMATIANS;
        ////public Civilization REMAN;
        ////public Civilization RIGELIANS;
        ////public Civilization RISIANS;
        ////public Civilization RUTIANS;
        ////public Civilization SELAY;
        ////public Civilization SHELIAK;
        ////public Civilization SIKARIANS;
        ////public Civilization SKRREEA;
        ////public Civilization SONA;
        ////public Civilization SULIBAN;
        ////public Civilization TAKARANS;
        ////public Civilization TAKARIANS;
        ////public Civilization TAKTAK;
        ////public Civilization TALARIANS;
        ////public Civilization TALAXIANS;
        ////public Civilization TALOSIANS;
        ////public Civilization TAMARIANS;
        ////public Civilization TANUGANS;
        ////public Civilization TELLARITES;
        ////public Civilization TEPLANS;
        ////public Civilization THOLIANS;
        ////public Civilization TILONIANS;
        ////public Civilization TLANI;
        ////public Civilization TRABE;
        ////public Civilization TRILL;
        ////public Civilization TROGORANS;
        ////public Civilization TZENKETHI;
        ////public Civilization ULLIANS;
        ////public Civilization VAADWAUR;
        ////public Civilization VENTAXIANS;
        ////public Civilization VHNORI;
        ////public Civilization VIDIIANS;
        ////public Civilization VISSIANS;
        ////public Civilization VORGONS;
        ////public Civilization VORI;
        ////public Civilization VULCANS;
        ////public Civilization WADI;
        ////public Civilization XANTHANS;
        ////public Civilization XEPOLITES;
        ////public Civilization XINDI;
        ////public Civilization XYRILLIANS;
        ////public Civilization YADERANS;
        ////public Civilization YRIDIANS;
        ////public Civilization ZAHL;
        ////public Civilization ZAKDORN;
        ////public Civilization ZALKONIANS;
        ////public Civilization ZIBALIANS;
        #endregion
        //#endregion
        public Civilization(int sysCivInt)
        {
            this._civID = sysCivInt;
        }
        private void Awake()
        {
            /*ReadCivilizationData(Environment.CurrentDirectory + "\\Assets\\" + "Civilization.txt")*/;
            #region Civs
            //Civilization FED = new Civilization();
            //Civilization ROM = new Civilization();
            //Civilization KLING = new Civilization();
            //Civilization CARD = new Civilization();
            //Civilization DOM = new Civilization();
            //Civilization BORG = new Civilization();

            //Civilization ACAMARIANS = new Civilization();
            //Civilization AKAALI = new Civilization();
            //Civilization AKRITIRIANS = new Civilization();
            //Civilization ALDEANS = new Civilization();
            //Civilization ALGOLIANS = new Civilization();
            //Civilization ALSAURIANS = new Civilization();
            //Civilization ANDORIANS = new Civilization();
            //Civilization ANGOSIANS = new Civilization();

            #region More System
            ////ANKARI = new Civilization();
            ////ANTEDEANS = new Civilization();
            ////ANTICANS = new Civilization();
            ////ARBAZAN = new Civilization();
            ////ARDANANS = new Civilization();
            ////ARGRATHI = new Civilization();
            ////ARKARIANS = new Civilization();
            ////ATREANS = new Civilization();
            ////AXANAR = new Civilization();
            ////BAJORANS = new Civilization();
            ////BAKU = new Civilization();
            ////BANDI = new Civilization();
            ////BANEANS = new Civilization();
            ////BARZANS = new Civilization();
            ////BENZITES = new Civilization();
            ////BETAZOIDS = new Civilization();
            ////BILANAIANS = new Civilization();
            ////BOLIANS = new Civilization();
            ////BOMAR = new Civilization();
            ////BOSLICS = new Civilization();
            ////BOTHA = new Civilization();
            ////BREELLIANS = new Civilization();
            ////BREEN = new Civilization();
            ////BREKKIANS = new Civilization();
            ////BYNARS = new Civilization();
            ////CAIRN = new Civilization();
            ////CALDONIANS = new Civilization();
            ////CAPELLANS = new Civilization();
            ////CHALNOTH = new Civilization();
            ////CORIDAN = new Civilization();
            ////CORVALLENS = new Civilization();
            ////CYTHERIANS = new Civilization();
            ////DELTANS = new Civilization();
            ////DENOBULANS = new Civilization();
            ////DEVORE = new Civilization();
            ////DOPTERIANS = new Civilization();
            ////DOSI = new Civilization();
            ////DRAI = new Civilization();
            ////DREMANS = new Civilization();
            ////EDO = new Civilization();
            ////ELAURIANS = new Civilization();
            ////ELAYSIANS = new Civilization();
            ////ENTHARANS = new Civilization();
            ////EVORA = new Civilization();
            ////EXCALBIANS = new Civilization();
            ////FERENGI = new Civilization();
            ////FLAXIANS = new Civilization();
            ////GORN = new Civilization();
            ////GRAZERITES = new Civilization();
            ////HAAKONIANS = new Civilization();
            ////HALKANS = new Civilization();
            ////HAZARI = new Civilization();
            ////HEKARANS = new Civilization();
            ////HIROGEN = new Civilization();
            ////HORTA = new Civilization();
            ////IYAARANS = new Civilization();
            ////JNAII = new Civilization();
            ////KAELON = new Civilization();
            ////KAREMMA = new Civilization();
            ////KAZON = new Civilization();
            ////KELLERUN = new Civilization();
            ////KESPRYTT = new Civilization();
            ////KLAESTRON = new Civilization();
            ////KRADIN = new Civilization();
            ////KREETASSANS = new Civilization();
            ////KRIOSIANS = new Civilization();
            ////KTARIANS = new Civilization();
            ////LEDOSIANS = new Civilization();
            ////LISSEPIANS = new Civilization();
            ////LOKIRRIM = new Civilization();
            ////LURIANS = new Civilization();
            ////MALCORIANS = new Civilization();
            ////MALON = new Civilization();
            ////MAQUIS = new Civilization();
            ////MARKALIANS = new Civilization();
            ////MERIDIANS = new Civilization();
            ////MINTAKANS = new Civilization();
            ////MIRADORN = new Civilization();
            ////MIZARIANS = new Civilization();
            ////MOKRA = new Civilization();
            ////MONEANS = new Civilization();
            ////NAUSICAANS = new Civilization();
            ////NECHANI = new Civilization();
            ////NEZU = new Civilization();
            ////NORCADIANS = new Civilization();
            ////NUMIRI = new Civilization();
            ////NUUBARI = new Civilization();
            ////NYRIANS = new Civilization();
            ////OCAMPA = new Civilization();
            ////ORIONS = new Civilization();
            ////ORNARANS = new Civilization();
            ////PAKLED = new Civilization();
            ////PARADANS = new Civilization();
            ////QUARREN = new Civilization();
            ////RAKHARI = new Civilization();
            ////RAKOSANS = new Civilization();
            ////RAMATIANS = new Civilization();
            ////REMAN = new Civilization();
            ////RIGELIANS = new Civilization();
            ////RISIANS = new Civilization();
            ////RUTIANS = new Civilization();
            ////SELAY = new Civilization();
            ////SHELIAK = new Civilization();
            ////SIKARIANS = new Civilization();
            ////SKRREEA = new Civilization();
            ////SONA = new Civilization();
            ////SULIBAN = new Civilization();
            ////TAKARANS = new Civilization();
            ////TAKARIANS = new Civilization();
            ////TAKTAK = new Civilization();
            ////TALARIANS = new Civilization();
            ////TALAXIANS = new Civilization();
            ////TALOSIANS = new Civilization();
            ////TAMARIANS = new Civilization();
            ////TANUGANS = new Civilization();
            ////TELLARITES = new Civilization();
            ////TEPLANS = new Civilization();
            ////THOLIANS = new Civilization();
            ////TILONIANS = new Civilization();
            ////TLANI = new Civilization();
            ////TRABE = new Civilization();
            ////TRILL = new Civilization();
            ////TROGORANS = new Civilization();
            ////TZENKETHI = new Civilization();
            ////ULLIANS = new Civilization();
            ////VAADWAUR = new Civilization();
            ////VENTAXIANS = new Civilization();
            ////VHNORI = new Civilization();
            ////VIDIIANS = new Civilization();
            ////VISSIANS = new Civilization();
            ////VORGONS = new Civilization();
            ////VORI = new Civilization();
            ////VULCANS = new Civilization();
            ////WADI = new Civilization();
            ////XANTHANS = new Civilization();
            ////XEPOLITES = new Civilization();
            ////XINDI = new Civilization();
            ////XYRILLIANS = new Civilization();
            ////YADERANS = new Civilization();
            ////YRIDIANS = new Civilization();
            ////ZAHL = new Civilization();
            ////ZAKDORN = new Civilization();
            ////ZALKONIANS = new Civilization();
            ////ZIBALIANS = new Civilization();

            #endregion end more Civs
            #endregion

            #region Build List
            ////_civListInstance.Add(FED);
            ////_civListInstance.Add(ROM);
            ////_civListInstance.Add(KLING);
            ////_civListInstance.Add(CARD);
            ////_civListInstance.Add(DOM);
            ////_civListInstance.Add(BORG);

            ////_civListInstance.Add(ACAMARIANS);
            ////_civListInstance.Add(AKAALI);
            ////_civListInstance.Add(AKRITIRIANS);
            ////_civListInstance.Add(ALDEANS);
            ////_civListInstance.Add(ALGOLIANS);
            ////_civListInstance.Add(ALSAURIANS);
            ////_civListInstance.Add(ANDORIANS);
            ////_civListInstance.Add(ANGOSIANS);
            ////#region More Civs
            //////_civListInstance.Add(ANKARI);
            //////_civListInstance.Add(ANTEDEANS);
            //////_civListInstance.Add(ANTICANS);
            //////_civListInstance.Add(ARBAZAN);
            //////_civListInstance.Add(ARDANANS);
            //////_civListInstance.Add(ARGRATHI);
            //////_civListInstance.Add(ARKARIANS);
            //////_civListInstance.Add(ATREANS);
            //////_civListInstance.Add(AXANAR);
            //////_civListInstance.Add(BAJORANS);
            //////_civListInstance.Add(BAKU);
            //////_civListInstance.Add(BANDI);
            //////_civListInstance.Add(BANEANS);
            //////_civListInstance.Add(BARZANS);
            //////_civListInstance.Add(BENZITES);
            //////_civListInstance.Add(BETAZOIDS);
            //////_civListInstance.Add(BILANAIANS);
            //////_civListInstance.Add(BOLIANS);
            //////_civListInstance.Add(BOMAR);
            //////_civListInstance.Add(BOSLICS);
            //////_civListInstance.Add(BOTHA);
            //////_civListInstance.Add(BREELLIANS);
            //////_civListInstance.Add(BREEN);
            //////_civListInstance.Add(BREKKIANS);
            //////_civListInstance.Add(BYNARS);
            //////_civListInstance.Add(CAIRN);
            //////_civListInstance.Add(CALDONIANS);
            //////_civListInstance.Add(CAPELLANS);
            //////_civListInstance.Add(CHALNOTH);
            //////_civListInstance.Add(CORIDAN);
            //////_civListInstance.Add(CORVALLENS);
            //////_civListInstance.Add(CYTHERIANS);
            //////_civListInstance.Add(DELTANS);
            //////_civListInstance.Add(DENOBULANS);
            //////_civListInstance.Add(DEVORE);
            //////_civListInstance.Add(DOPTERIANS);
            //////_civListInstance.Add(DOSI);
            //////_civListInstance.Add(DRAI);
            //////_civListInstance.Add(DREMANS);
            //////_civListInstance.Add(EDO);
            //////_civListInstance.Add(ELAURIANS);
            //////_civListInstance.Add(ELAYSIANS);
            //////_civListInstance.Add(ENTHARANS);
            //////_civListInstance.Add(EVORA);
            //////_civListInstance.Add(EXCALBIANS);
            //////_civListInstance.Add(FERENGI);
            //////_civListInstance.Add(FLAXIANS);
            //////_civListInstance.Add(GORN);
            //////_civListInstance.Add(GRAZERITES);
            //////_civListInstance.Add(HAAKONIANS);
            //////_civListInstance.Add(HALKANS);
            //////_civListInstance.Add(HAZARI);
            //////_civListInstance.Add(HEKARANS);
            //////_civListInstance.Add(HIROGEN);
            //////_civListInstance.Add(HORTA);
            //////_civListInstance.Add(IYAARANS);
            //////_civListInstance.Add(JNAII);
            //////_civListInstance.Add(KAELON);
            //////_civListInstance.Add(KAREMMA);
            //////_civListInstance.Add(KAZON);
            //////_civListInstance.Add(KELLERUN);
            //////_civListInstance.Add(KESPRYTT);
            //////_civListInstance.Add(KLAESTRON);
            //////_civListInstance.Add(KRADIN);
            //////_civListInstance.Add(KREETASSANS);
            //////_civListInstance.Add(KRIOSIANS);
            //////_civListInstance.Add(KTARIANS);
            //////_civListInstance.Add(LEDOSIANS);
            //////_civListInstance.Add(LISSEPIANS);
            //////_civListInstance.Add(LOKIRRIM);
            //////_civListInstance.Add(LURIANS);
            //////_civListInstance.Add(MALCORIANS);
            //////_civListInstance.Add(MALON);
            //////_civListInstance.Add(MAQUIS);
            //////_civListInstance.Add(MARKALIANS);
            //////_civListInstance.Add(MERIDIANS);
            //////_civListInstance.Add(MINTAKANS);
            //////_civListInstance.Add(MIRADORN);
            //////_civListInstance.Add(MIZARIANS);
            //////_civListInstance.Add(MOKRA);
            //////_civListInstance.Add(MONEANS);
            //////_civListInstance.Add(NAUSICAANS);
            //////_civListInstance.Add(NECHANI);
            //////_civListInstance.Add(NEZU);
            //////_civListInstance.Add(NORCADIANS);
            //////_civListInstance.Add(NUMIRI);
            //////_civListInstance.Add(NUUBARI);
            //////_civListInstance.Add(NYRIANS);
            //////_civListInstance.Add(OCAMPA);
            //////_civListInstance.Add(ORIONS);
            //////_civListInstance.Add(ORNARANS);
            //////_civListInstance.Add(PAKLED);
            //////_civListInstance.Add(PARADANS);
            //////_civListInstance.Add(QUARREN);
            //////_civListInstance.Add(RAKHARI);
            //////_civListInstance.Add(RAKOSANS);
            //////_civListInstance.Add(RAMATIANS);
            //////_civListInstance.Add(REMAN);
            //////_civListInstance.Add(RIGELIANS);
            //////_civListInstance.Add(RISIANS);
            //////_civListInstance.Add(RUTIANS);
            //////_civListInstance.Add(SELAY);
            //////_civListInstance.Add(SHELIAK);
            //////_civListInstance.Add(SIKARIANS);
            //////_civListInstance.Add(SKRREEA);
            //////_civListInstance.Add(SONA);
            //////_civListInstance.Add(SULIBAN);
            //////_civListInstance.Add(TAKARANS);
            //////_civListInstance.Add(TAKARIANS);
            //////_civListInstance.Add(TAKTAK);
            //////_civListInstance.Add(TALARIANS);
            //////_civListInstance.Add(TALAXIANS);
            //////_civListInstance.Add(TALOSIANS);
            //////_civListInstance.Add(TAMARIANS);
            //////_civListInstance.Add(TANUGANS);
            //////_civListInstance.Add(TELLARITES);
            //////_civListInstance.Add(TEPLANS);
            //////_civListInstance.Add(THOLIANS);
            //////_civListInstance.Add(TILONIANS);
            //////_civListInstance.Add(TLANI);
            //////_civListInstance.Add(TRABE);
            //////_civListInstance.Add(TRILL);
            //////_civListInstance.Add(TROGORANS);
            //////_civListInstance.Add(TZENKETHI);
            //////_civListInstance.Add(ULLIANS);
            //////_civListInstance.Add(VAADWAUR);
            //////_civListInstance.Add(VENTAXIANS);
            //////_civListInstance.Add(VHNORI);
            //////_civListInstance.Add(VIDIIANS);
            //////_civListInstance.Add(VISSIANS);
            //////_civListInstance.Add(VORGONS);
            //////_civListInstance.Add(VORI);
            //////_civListInstance.Add(VULCANS);
            //////_civListInstance.Add(WADI);
            //////_civListInstance.Add(XANTHANS);
            //////_civListInstance.Add(XEPOLITES);
            //////_civListInstance.Add(XINDI);
            //////_civListInstance.Add(XYRILLIANS);
            //////_civListInstance.Add(YADERANS);
            //////_civListInstance.Add(YRIDIANS);
            //////_civListInstance.Add(ZAHL);
            //////_civListInstance.Add(ZAKDORN);
            //////_civListInstance.Add(ZALKONIANS);
            //////_civListInstance.Add(ZIBALIANS);
            //////_civListInstance.Add(TEMPLATE);
            #endregion

            //CivilizationList = _civListInstance;
            //for (int i = 0; i < CivilizationList.Count; i++)
            //{
            //    CivilizationDictionary.Add((int)(Civ)i, CivilizationList[i]); // hope this keep civ values if some civs are not used
            //}


        }
        //public static Civilization Create(int systemInt)
        //{
        //    Civilization daCiv = new Civilization();
        //    string[] sysStrings = CivilizationData.CivDataDictionary[systemInt]; // CivilizationDictionary[systemInt];
        //    daCiv._shortName = sysStrings[2];
        //    daCiv._longName = sysStrings[3];
        //    //daCiv._homeSystem
        //    return daCiv;
        //}
        //public void ReadCivilizationData(string filename)
        //{
        //    #region Read Civilization Data.txt 
        //    char separator = ',';
        //    Dictionary<int, string[]> _civDataDictionary = new Dictionary<int, string[]>();
        //    var file = new FileStream(filename, FileMode.Open, FileAccess.Read);

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
        //                var civDataStringArray = line.Split(separator);

        //                _civDataDictionary.Add(int.Parse(civDataStringArray[0]), civDataStringArray);
        //            }
        //        }

        //        reader.Close();
        //        //SystemDataDictionary = _civDataDictionary;
        //        //StaticStuff staticStuffToLoad = new StaticStuff();
        //        //staticStuffToLoad.LoadStaticShipData(_shipDataDictionary);
        //    }
        //    #endregion
        //}
    }
}
