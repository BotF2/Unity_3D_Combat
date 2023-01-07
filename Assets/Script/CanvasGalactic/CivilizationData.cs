using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Assets.Script;
using BOTF3D_Core;
using BOTF3D_Combat;
using UnityEngine.XR;
using static UnityEngine.ParticleSystem;
using UnityEngine.Rendering;
using System.Runtime.CompilerServices;

namespace BOTF3D_GalaxyMap
{
    public class CivilizationData : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        public static Dictionary<int, string[]> CivDataDictionary;
        #region Fields
        public HoverTipManager hoverTipManager;
        // public GalaxyView galaxyView;
        //[SerializeField]
        //public Civilization FED;
        //public Civilization ROM;
        //public Civilization KLING;
        //public Civilization CARD;
        //public Civilization DOM;
        //public Civilization BORG;
        #region More Fields

        //public Civilization ACAMARIANS;
        //public Civilization AKAALI;
        //public Civilization AKRITIRIANS;
        //public Civilization ALDEANS;
        //public Civilization ALGOLIANS;
        //public Civilization ALSAURIANS;
        //public Civilization ANDORIANS;
        //public Civilization ANGOSIANS;
        //public Civilization ANKARI;
        //public Civilization ANTEDEANS;
        //public Civilization ANTICANS;
        //public Civilization ARBAZAN;
        //public Civilization ARDANANS;
        //public Civilization ARGRATHI;
        //public Civilization ARKARIANS;
        //public Civilization ATREANS;
        //public Civilization AXANAR;
        //public Civilization BAJORANS;
        //public Civilization BAKU;
        //public Civilization BANDI;
        //public Civilization BANEANS;
        //public Civilization BARZANS;
        //public Civilization BENZITES;
        //public Civilization BETAZOIDS;
        //public Civilization BILANAIANS;
        //public Civilization BOLIANS;
        //public Civilization BOMAR;
        //public Civilization BOSLICS;
        //public Civilization BOTHA;
        //public Civilization BREELLIANS;
        //public Civilization BREEN;
        //public Civilization BREKKIANS;
        //public Civilization BYNARS;
        //public Civilization CAIRN;
        //public Civilization CALDONIANS;
        //public Civilization CAPELLANS;
        //public Civilization CHALNOTH;
        //public Civilization CORIDAN;
        //public Civilization CORVALLENS;
        //public Civilization CYTHERIANS;
        //public Civilization DELTANS;
        //public Civilization DENOBULANS;
        //public Civilization DEVORE;
        //public Civilization DOPTERIANS;
        //public Civilization DOSI;
        //public Civilization DRAI;
        //public Civilization DREMANS;
        //public Civilization EDO;
        //public Civilization ELAURIANS;
        //public Civilization ELAYSIANS;
        //public Civilization ENTHARANS;
        //public Civilization EVORA;
        //public Civilization EXCALBIANS;
        //public Civilization FERENGI;
        //public Civilization FLAXIANS;
        //public Civilization GORN;
        //public Civilization GRAZERITES;
        //public Civilization HAAKONIANS;
        //public Civilization HALKANS;
        //public Civilization HAZARI;
        //public Civilization HEKARANS;
        //public Civilization HIROGEN;
        //public Civilization HORTA;
        //public Civilization IYAARANS;
        //public Civilization JNAII;
        //public Civilization KAELON;
        //public Civilization KAREMMA;
        //public Civilization KAZON;
        //public Civilization KELLERUN;
        //public Civilization KESPRYTT;
        //public Civilization KLAESTRON;
        //public Civilization KRADIN;
        //public Civilization KREETASSANS;
        //public Civilization KRIOSIANS;
        //public Civilization KTARIANS;
        //public Civilization LEDOSIANS;
        //public Civilization LISSEPIANS;
        //public Civilization LOKIRRIM;
        //public Civilization LURIANS;
        //public Civilization MALCORIANS;
        //public Civilization MALON;
        //public Civilization MAQUIS;
        //public Civilization MARKALIANS;
        //public Civilization MERIDIANS;
        //public Civilization MINTAKANS;
        //public Civilization MIRADORN;
        //public Civilization MIZARIANS;
        //public Civilization MOKRA;
        //public Civilization MONEANS;
        //public Civilization NAUSICAANS;
        //public Civilization NECHANI;
        //public Civilization NEZU;
        //public Civilization NORCADIANS;
        //public Civilization NUMIRI;
        //public Civilization NUUBARI;
        //public Civilization NYRIANS;
        //public Civilization OCAMPA;
        //public Civilization ORIONS;
        //public Civilization ORNARANS;
        //public Civilization PAKLED;
        //public Civilization PARADANS;
        //public Civilization QUARREN;
        //public Civilization RAKHARI;
        //public Civilization RAKOSANS;
        //public Civilization RAMATIANS;
        //public Civilization REMAN;
        //public Civilization RIGELIANS;
        //public Civilization RISIANS;
        //public Civilization RUTIANS;
        //public Civilization SELAY;
        //public Civilization SHELIAK;
        //public Civilization SIKARIANS;
        //public Civilization SKRREEA;
        //public Civilization SONA;
        //public Civilization SULIBAN;
        //public Civilization TAKARANS;
        //public Civilization TAKARIANS;
        //public Civilization TAKTAK;
        //public Civilization TALARIANS;
        //public Civilization TALAXIANS;
        //public Civilization TALOSIANS;
        //public Civilization TAMARIANS;
        //public Civilization TANUGANS;
        //public Civilization TELLARITES;
        //public Civilization TEPLANS;
        //public Civilization THOLIANS;
        //public Civilization TILONIANS;
        //public Civilization TLANI;
        //public Civilization TRABE;
        //public Civilization TRILL;
        //public Civilization TROGORANS;
        //public Civilization TZENKETHI;
        //public Civilization ULLIANS;
        //public Civilization VAADWAUR;
        //public Civilization VENTAXIANS;
        //public Civilization VHNORI;
        //public Civilization VIDIIANS;
        //public Civilization VISSIANS;
        //public Civilization VORGONS;
        //public Civilization VORI;
        //public Civilization VULCANS;
        //public Civilization WADI;
        //public Civilization XANTHANS;
        //public Civilization XEPOLITES;
        //public Civilization XINDI;
        //public Civilization XYRILLIANS;
        //public Civilization YADERANS;
        //public Civilization YRIDIANS;
        //public Civilization ZAHL;
        //public Civilization ZAKDORN;
        //public Civilization ZALKONIANS;
        //public Civilization ZIBALIANS;
        //public Civilization TEMPLATE;
        #endregion
        #endregion

        #endregion
        public void Awake()
        {
            #region Read Civilization Data.txt 
            char separator = ',';
            Dictionary<int, string[]> _civDataDictionary = new Dictionary<int, string[]>();
            var file = new FileStream(Environment.CurrentDirectory + "\\Assets\\" + "Civilizations.txt", FileMode.Open, FileAccess.Read);

            var _dataPoints = new List<string>();
            using (var reader = new StreamReader(file))
            {

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();
                    if (line == null)
                        continue;
                    _dataPoints.Add(line.Trim());

                    if (line.Length > 0)
                    {
                        var civDataStringArray = line.Split(separator);

                        _civDataDictionary.Add(int.Parse(civDataStringArray[0]), civDataStringArray);
                    }
                }

                reader.Close();
                CivDataDictionary = _civDataDictionary;
                //StaticStuff staticStuffToLoad = new StaticStuff();
                //staticStuffToLoad.LoadStaticShipData(_shipDataDictionary);
            }
            #endregion
        }
        public static Civilization Create(int systemInt)
        {
            Civilization daCiv = new Civilization(systemInt);
            var sysStrings = CivilizationData.CivDataDictionary[systemInt];
            daCiv._shortName = sysStrings[2];
            daCiv._longName = sysStrings[3];
            daCiv._homeSystem = StarSystemData.Create(systemInt);
            daCiv._homeSystem._ownerCiv = daCiv;
            string holdInsigniaName = CivDataDictionary[systemInt][8];
            string nameInsignia = "Insignias/" + holdInsigniaName; // + ".png";
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Plane); // (nameInsginia);
            var rend = go.GetComponent<Renderer>();
            rend.material.mainTexture = Resources.Load(nameInsignia) as Texture;
            daCiv._insignia = Sprite.Create((Texture2D)rend.material.mainTexture, new Rect(0,0,rend.material.mainTexture.width, rend.material.mainTexture.height), new Vector2(0.5f, 0.5f));
            daCiv._civResearch = int.Parse(sysStrings[10]);
            daCiv._civCredits = int.Parse(sysStrings[9]);
            return daCiv;
        }
    }
}
