using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using BOTF3D_Core;
using BOTF3D_Combat;
using Assets.Script;
using Unity.VisualScripting;

namespace BOTF3D_GalaxyMap
{
    public class GalaxyView : MonoBehaviour // !!! INSIDE PanelGalactic_Map IN UNITY HIERARCHY - GALAXYSCEEN !!!
    {
        public GameManager gameManager;
        public SolarSystemView solarSystemView;
        [SerializeField]
        public HoverTips hoverTips;
        public HoverTipManager hoverTipManager;
        [SerializeField]
        public Canvas canvasGalactic;
        //public Pane canvasGalaxy;
        //public PanelGalactic_Map 
        //public CivilizationData civilizationDate;
        public Galaxy ourGalaxy;
        public static GameObject buttonStopGalacticPlay;
        public static Button _buttonPlayGalacticPlay;
        private GameObject FEDSysEmpty;
        private GameObject ROMSysEmpty;
        private GameObject KLINGSysEmpty;
        private GameObject CARDSysEmpty;
        private GameObject DOMSysEmpty;
        private GameObject BORGSysEmpty;
        #region The Minor Race Empties
        private GameObject ACAMARIANSSysEmpty;
        private GameObject AKAALISysEmpty;
        private GameObject AKRITIRIANSSysEmpty;
        private GameObject ALDEANSSysEmpty;
        private GameObject ALGOLIANSSysEmpty;
        private GameObject ALSAURIANSSysEmpty;
        private GameObject ANDORIANSSysEmpty;
        private GameObject ANGOSIANSSysEmpty;
        private GameObject ANKARISysEmpty;
        private GameObject ANTEDEANSSysEmpty;
        private GameObject ANTICANSSysEmpty;
        private GameObject ARBAZANSysEmpty;
        private GameObject ARDANANSSysEmpty;
        private GameObject ARGRATHISysEmpty;
        private GameObject ARKARIANSSysEmpty;
        private GameObject ATREANSSysEmpty;
        private GameObject AXANARSysEmpty;
        private GameObject BAJORANSSysEmpty;
        private GameObject BAKUSysEmpty;
        private GameObject BANDISysEmpty;
        private GameObject BANEANSSysEmpty;
        private GameObject BARZANSSysEmpty;
        private GameObject BENZITESSysEmpty;
        private GameObject BETAZOIDSSysEmpty;
        private GameObject BILANAIANSSysEmpty;
        private GameObject BOLIANSSysEmpty;
        private GameObject BOMARSysEmpty;
        private GameObject BOSLICSSysEmpty;
        private GameObject BOTHASysEmpty;
        private GameObject BREELLIANSSysEmpty;
        private GameObject BREENSysEmpty;
        private GameObject BREKKIANSSysEmpty;
        private GameObject BYNARSSysEmpty;
        private GameObject CAIRNSysEmpty;
        private GameObject CALDONIANSSysEmpty;
        private GameObject CAPELLANSSysEmpty;
        private GameObject CHALNOTHSysEmpty;
        private GameObject CORIDANSysEmpty;
        private GameObject CORVALLENSSysEmpty;
        private GameObject CYTHERIANSSysEmpty;
        private GameObject DELTANSSysEmpty;
        private GameObject DENOBULANSSysEmpty;
        private GameObject DEVORESysEmpty;
        private GameObject DOPTERIANSSysEmpty;
        private GameObject DOSISysEmpty;
        private GameObject DRAISysEmpty;
        private GameObject DREMANSSysEmpty;
        private GameObject EDOSysEmpty;
        private GameObject ELAURIANSSysEmpty;
        private GameObject ELAYSIANSSysEmpty;
        private GameObject ENTHARANSSysEmpty;
        private GameObject EVORASysEmpty;
        private GameObject EXCALBIANSSysEmpty;
        private GameObject FERENGISysEmpty;
        private GameObject FLAXIANSSysEmpty;
        private GameObject GORNSysEmpty;
        private GameObject GRAZERITESSysEmpty;
        private GameObject HAAKONIANSSysEmpty;
        private GameObject HALKANSSysEmpty;
        private GameObject HAZARISysEmpty;
        private GameObject HEKARANSSysEmpty;
        private GameObject HIROGENSysEmpty;
        private GameObject HORTASysEmpty;
        private GameObject IYAARANSSysEmpty;
        private GameObject JNAIISysEmpty;
        private GameObject KAELONSysEmpty;
        private GameObject KAREMMASysEmpty;
        private GameObject KAZONSysEmpty;
        private GameObject KELLERUNSysEmpty;
        private GameObject KESPRYTTSysEmpty;
        private GameObject KLAESTRONIANSSysEmpty;
        private GameObject KRADINSysEmpty;
        private GameObject KREETASSANSSysEmpty;
        private GameObject KRIOSIANSSysEmpty;
        private GameObject KTARIANSSysEmpty;
        private GameObject LEDOSIANSSysEmpty;
        private GameObject LISSEPIANSSysEmpty;
        private GameObject LOKIRRIMSysEmpty;
        private GameObject LURIANSSysEmpty;
        private GameObject MALCORIANSSysEmpty;
        private GameObject MALONSysEmpty;
        private GameObject MAQUISSysEmpty;
        private GameObject MARKALIANSSysEmpty;
        private GameObject MERIDIANSSysEmpty;
        private GameObject MINTAKANSSysEmpty;
        private GameObject MIRADORNSysEmpty;
        private GameObject MIZARIANSSysEmpty;
        private GameObject MOKRASysEmpty;
        private GameObject MONEANSSysEmpty;
        private GameObject NAUSICAANSSysEmpty;
        private GameObject NECHANISysEmpty;
        private GameObject NEZUSysEmpty;
        private GameObject NORCADIANSSysEmpty;
        private GameObject NUMIRISysEmpty;
        private GameObject NUUBARISysEmpty;
        private GameObject NYRIANSSysEmpty;
        private GameObject OCAMPASysEmpty;
        private GameObject ORIONSSysEmpty;
        private GameObject ORNARANSSysEmpty;
        private GameObject PAKLEDSysEmpty;
        private GameObject PARADANSSysEmpty;
        private GameObject QUARRENSysEmpty;
        private GameObject RAKHARISysEmpty;
        private GameObject RAKOSANSSysEmpty;
        private GameObject RAMATIANSSysEmpty;
        private GameObject HELIOSSysEmpty;
        private GameObject RIGELIANSSysEmpty;
        private GameObject RISIANSSysEmpty;
        private GameObject RUTIANSSysEmpty;
        private GameObject SELAYSysEmpty;
        private GameObject SHELIAKSysEmpty;
        private GameObject SIKARIANSSysEmpty;
        private GameObject SKRREEASysEmpty;
        private GameObject SONASysEmpty;
        private GameObject SULIBANSysEmpty;
        private GameObject TAKARANSSysEmpty;
        private GameObject TAKARIANSSysEmpty;
        private GameObject TAKTAKSysEmpty;
        private GameObject TALARIANSSysEmpty;
        private GameObject TALAXIANSSysEmpty;
        private GameObject TALOSIANSSysEmpty;
        private GameObject TAMARIANSSysEmpty;
        private GameObject TANUGANSSysEmpty;
        private GameObject TELLARITESSysEmpty;
        private GameObject TEPLANSSysEmpty;
        private GameObject THOLIANSSysEmpty;
        private GameObject TILONIANSSysEmpty;
        private GameObject TLANISysEmpty;
        private GameObject TRABESysEmpty;
        private GameObject TRILLSysEmpty;
        private GameObject TROGORANSSysEmpty;
        private GameObject TZENKETHISysEmpty;
        private GameObject ULLIANSSysEmpty;
        private GameObject VAADWAURSysEmpty;
        private GameObject VENTAXIANSSysEmpty;
        private GameObject VHNORISysEmpty;
        private GameObject VIDIIANSSysEmpty;
        private GameObject VISSIANSSysEmpty;
        private GameObject VORGONSSysEmpty;
        private GameObject VORISysEmpty;
        private GameObject VULCANSSysEmpty;
        private GameObject WADISysEmpty;
        private GameObject XANTHANSSysEmpty;
        private GameObject XEPOLITESSysEmpty;
        private GameObject XINDISysEmpty;
        private GameObject XYRILLIANSSysEmpty;
        private GameObject YADERANSSysEmpty;
        private GameObject YRIDIANSSysEmpty;
        private GameObject ZAHLSysEmpty;
        private GameObject ZAKDORNSysEmpty;
        private GameObject ZALKONIANSSysEmpty;
        private GameObject ZIBALIANSSysEmpty;
        #endregion

        private List<GameObject> SysEmptyList;
        public List<int> NumbersForSystem;
        public ulong zoomLevels = 150000000000; // times 1 billion zoom
        Dictionary<SolarSystem, GameObject> solarSystemGameObjectMap; // put in the ss sprit and get the ss game object
        private char separator = ',';
        public static Dictionary<int, string[]> SystemDataDictionary = new Dictionary<int, string[]>();
        // private OrbitalGalactic mySolarSystem; // star and planets
        void Awake()
        {
            //gameManager = GameManager.Instance;
            SysEmptyList = new List<GameObject>
            {
                FEDSysEmpty,
                ROMSysEmpty,
                KLINGSysEmpty,
                CARDSysEmpty,
                DOMSysEmpty,
                BORGSysEmpty,
                #region Minor Race Entries
                ACAMARIANSSysEmpty,
                AKAALISysEmpty,
                AKRITIRIANSSysEmpty,
                ALDEANSSysEmpty,
                ALGOLIANSSysEmpty,
                ALSAURIANSSysEmpty,
                ANDORIANSSysEmpty,
                ANGOSIANSSysEmpty,
                ANKARISysEmpty,
                ANTEDEANSSysEmpty,
                ANTICANSSysEmpty,
                ARBAZANSysEmpty,
                ARDANANSSysEmpty,
                ARGRATHISysEmpty,
                ARKARIANSSysEmpty,
                ATREANSSysEmpty,
                AXANARSysEmpty,
                BAJORANSSysEmpty,
                BAKUSysEmpty,
                BANDISysEmpty,
                BANEANSSysEmpty,
                BARZANSSysEmpty,
                BENZITESSysEmpty,
                BETAZOIDSSysEmpty,
                BILANAIANSSysEmpty,
                BOLIANSSysEmpty,
                BOMARSysEmpty,
                BOSLICSSysEmpty,
                BOTHASysEmpty,
                BREELLIANSSysEmpty,
                BREENSysEmpty,
                BREKKIANSSysEmpty,
                BYNARSSysEmpty,
                CAIRNSysEmpty,
                CALDONIANSSysEmpty,
                CAPELLANSSysEmpty,
                CHALNOTHSysEmpty,
                CORIDANSysEmpty,
                CORVALLENSSysEmpty,
                CYTHERIANSSysEmpty,
                DELTANSSysEmpty,
                DENOBULANSSysEmpty,
                DEVORESysEmpty,
                DOPTERIANSSysEmpty,
                DOSISysEmpty,
                DRAISysEmpty,
                DREMANSSysEmpty,
                EDOSysEmpty,
                ELAURIANSSysEmpty,
                ELAYSIANSSysEmpty,
                ENTHARANSSysEmpty,
                EVORASysEmpty,
                EXCALBIANSSysEmpty,
                FERENGISysEmpty,
                FLAXIANSSysEmpty,
                GORNSysEmpty,
                GRAZERITESSysEmpty,
                HAAKONIANSSysEmpty,
                HALKANSSysEmpty,
                HAZARISysEmpty,
                HEKARANSSysEmpty,
                HIROGENSysEmpty,
                HORTASysEmpty,
                IYAARANSSysEmpty,
                JNAIISysEmpty,
                KAELONSysEmpty,
                KAREMMASysEmpty,
                KAZONSysEmpty,
                KELLERUNSysEmpty,
                KESPRYTTSysEmpty,
                KLAESTRONIANSSysEmpty,
                KRADINSysEmpty,
                KREETASSANSSysEmpty,
                KRIOSIANSSysEmpty,
                KTARIANSSysEmpty,
                LEDOSIANSSysEmpty,
                LISSEPIANSSysEmpty,
                LOKIRRIMSysEmpty,
                LURIANSSysEmpty,
                MALCORIANSSysEmpty,
                MALONSysEmpty,
                MAQUISSysEmpty,
                MARKALIANSSysEmpty,
                MERIDIANSSysEmpty,
                MINTAKANSSysEmpty,
                MIRADORNSysEmpty,
                MIZARIANSSysEmpty,
                MOKRASysEmpty,
                MONEANSSysEmpty,
                NAUSICAANSSysEmpty,
                NECHANISysEmpty,
                NEZUSysEmpty,
                NORCADIANSSysEmpty,
                NUMIRISysEmpty,
                NUUBARISysEmpty,
                NYRIANSSysEmpty,
                OCAMPASysEmpty,
                ORIONSSysEmpty,
                ORNARANSSysEmpty,
                PAKLEDSysEmpty,
                PARADANSSysEmpty,
                QUARRENSysEmpty,
                RAKHARISysEmpty,
                RAKOSANSSysEmpty,
                RAMATIANSSysEmpty,
                HELIOSSysEmpty,
                RIGELIANSSysEmpty,
                RISIANSSysEmpty,
                RUTIANSSysEmpty,
                SELAYSysEmpty,
                SHELIAKSysEmpty,
                SIKARIANSSysEmpty,
                SKRREEASysEmpty,
                SONASysEmpty,
                SULIBANSysEmpty,
                TAKARANSSysEmpty,
                TAKARIANSSysEmpty,
                TAKTAKSysEmpty,
                TALARIANSSysEmpty,
                TALAXIANSSysEmpty,
                TALOSIANSSysEmpty,
                TAMARIANSSysEmpty,
                TANUGANSSysEmpty,
                TELLARITESSysEmpty,
                TEPLANSSysEmpty,
                THOLIANSSysEmpty,
                TILONIANSSysEmpty,
                TLANISysEmpty,
                TRABESysEmpty,
                TRILLSysEmpty,
                TROGORANSSysEmpty,
                TZENKETHISysEmpty,
                ULLIANSSysEmpty,
                VAADWAURSysEmpty,
                VENTAXIANSSysEmpty,
                VHNORISysEmpty,
                VIDIIANSSysEmpty,
                VISSIANSSysEmpty,
                VORGONSSysEmpty,
                VORISysEmpty,
                VULCANSSysEmpty,
                WADISysEmpty,
                XANTHANSSysEmpty,
                XEPOLITESSysEmpty,
                XINDISysEmpty,
                XYRILLIANSSysEmpty,
                YADERANSSysEmpty,
                YRIDIANSSysEmpty,
                ZAHLSysEmpty,
                ZAKDORNSysEmpty,
                ZALKONIANSSysEmpty,
                ZIBALIANSSysEmpty
            #endregion
            };
            LoadSystemData(Environment.CurrentDirectory + "\\Assets\\" + "SystemData.txt");
            //LoadCivData

        }
        void Update()
        {
            if (ourGalaxy == null)
                return;
            // loop systems and updating data 
            else
            {
                // ToDo: update system buttons features, owner color
                // UpdateSystemButtons(SolarSystem)
            }
        }

        public void InstantiateSystemButtons(int[] numStars, GalaxyType canonOrRandom)
        {
            // ToDo Implement both cannon and radome based on incoming GalaxyType seletection
            string[] keysForSytemDictioanry = ReadSystemNames(); // all the system names in string[]

            //We are currently only numStars = 6; use numStars, without this reset, when we have enough system-button prefabs built and loaded 

            Galaxy galaxy = new Galaxy(gameManager);
            if (canonOrRandom == GalaxyType.CANON)
            for (int i = 0; i < numStars.Length; i++)
            {
                int sysIndex = numStars[i];
                string ourKey = keysForSytemDictioanry[sysIndex];
                if (keysForSytemDictioanry[sysIndex].Length != 0)
                {
                    GameObject tempObject = GameObject.Find("CanvasGalactic");
                    if (tempObject != null)
                    {
                        canvasGalactic = tempObject.GetComponent<Canvas>();

                        SysEmptyList[sysIndex] = new GameObject();

                        SysEmptyList[sysIndex].name = SystemDataDictionary[sysIndex][4];
                        int x = int.Parse(SystemDataDictionary[sysIndex][1]);
                        int y = int.Parse(SystemDataDictionary[sysIndex][2]);
                        int z = int.Parse(SystemDataDictionary[sysIndex][3]);
                        Vector3 worldSpace = new Vector3(x, y, z);
                        SysEmptyList[sysIndex].transform.Translate(worldSpace, Space.World);
                        SysEmptyList[sysIndex].transform.SetParent(canvasGalactic.transform, false);
                        SysEmptyList[sysIndex].layer = 6;
                        var hTips = SysEmptyList[sysIndex].AddComponent<HoverTips>();
                        hTips._hoverTipManager = hoverTipManager;
                        hTips._starSysEnum = (StarSystemEnum)sysIndex;
                        hTips._sysLocation = worldSpace;
                        hTips._hoverTipManager = hoverTipManager;

                        SysEmptyList[sysIndex].SetActive(true);
                    }

                    GameObject starSystemNewGameOb = Instantiate(GameManager.PrefabStarSystemDitionary[ourKey],
                    new Vector3(0, 0, 0), Quaternion.identity); //VectorValue(ourKey,'z')
                    starSystemNewGameOb.transform.SetParent(SysEmptyList[sysIndex].transform, false);
                    starSystemNewGameOb.transform.localScale = new Vector3(1, 1, 1);

                    var theCiv = CivilizationData.Create(sysIndex); // and civs make systems

                    starSystemNewGameOb.SetActive(true);
                    //Button myButton = starSystemNewGameOb.GetComponentInChildren<Button>();
                    //myButton.image.sprite.
                }
            }
            else
            { 
                // do random galaxy here
            }

            gameManager.galaxy = galaxy;
            SolarSystemView view = new SolarSystemView();
        }
         
        private string[] ReadSystemNames() // get names of civ in an array
        {
            //SolarSystem.LoadSystemData(Environment.CurrentDirectory + "\\Assets\\" + "SystemData.txt");
            String[] _systemCivData;
            List<string> ourCivNames = new List<string>();
            foreach (KeyValuePair<int, String[]> elements in SystemDataDictionary)
            {
                _systemCivData = elements.Value;
                ourCivNames.Add(_systemCivData[5]); // civ name is element five
            }
            return ourCivNames.ToArray();
        }
        private int VectorValue(int systemID, char axis)
        {
            int number;
            switch (axis)
            {
                case 'x':
                    number = int.Parse(SystemDataDictionary[systemID][1]);// int key to get sting[] and index of x value
                    break;
                case 'y':
                    number = int.Parse(SystemDataDictionary[systemID][2]);
                    break;
                case 'z':
                    number = int.Parse(SystemDataDictionary[systemID][3]);
                    break;
                default:
                    number = 1000;
                    break;
            }
            return number;
        }

        public void ShowASolarSystemView(int buttonSystemID) // The 3D view of system, THE BACKGROUND EYE CANDY
        {
            while (transform.childCount > 0) // delelt old systems from prior update
            {
                Transform child = transform.GetChild(0);
                child.SetParent(null); // decreases number of children in while loop
                Destroy(child.gameObject);

            }
            solarSystemGameObjectMap = new Dictionary<SolarSystem, GameObject>();
            solarSystemView.ShowNextSolarSystemView(buttonSystemID); // the number is found in Unity Inspector, button On Click 
        }

        public void SetZoomLevel(ulong zl)
        {
            zoomLevels = zl;
            //Update planet postions and scale graphics to still see planet sprites as a few pix
        }
        public void LoadSystemData(string filename)
        {
            #region Read SystemData.txt 
            //int entryNum = 0;
            Dictionary<int, string[]> _systemDataDictionary = new Dictionary<int, string[]>();
            var file = new FileStream(filename, FileMode.Open, FileAccess.Read);

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
                        var sysDataStringArray = line.Split(separator);

                        _systemDataDictionary.Add(int.Parse(sysDataStringArray[0]), sysDataStringArray);
                        NumbersForSystem.Add(int.Parse(sysDataStringArray[0]));
                    }
                }

                reader.Close();
                SystemDataDictionary = _systemDataDictionary;
                //StaticStuff staticStuffToLoad = new StaticStuff();
                //staticStuffToLoad.LoadStaticShipData(_shipDataDictionary);
            }
            #endregion
        }
    }
}