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
using TMPro;
using UnityEditor.Rendering;
using UnityEngine.EventSystems;

namespace BOTF3D_GalaxyMap
{
    public class GalaxyView : MonoBehaviour // !!! INSIDE PanelGalactic_Map IN UNITY HIERARCHY - GALAXYSCEEN !!!
    {
        public GameManager gameManager;
        public GameObject prefabForGalaxyShip;
        //public CivilizationData civilizationData;
        public CameraManagerGalactica cameraManagerGalactica;
        public StarSystemData starSystemData;
        public MoveGalacticObjects thisMovingObject;
        public NextSolarSystem nextSolarSystem;
        //public GridManager gridManager;
        public SolarSystemView solarSystemView;
        public GalaxyDropLine systemDropLine;
        public GalaxyDropLine fleetDropLine;
        [SerializeField]
        public HoverTips hoverTips;
        public HoverTipManager hoverTipManager;
        [SerializeField]
        public Canvas canvasGalactic;
        public GameObject PanelFleetManager;
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
        #region The Minor Race System Empties
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
        private GameObject FEDFleetEmpty;
        private GameObject ROMFleetEmpty;
        private GameObject KLINGFleetEmpty;
        private GameObject CARDFleetEmpty;
        private GameObject DOMFleetEmpty;
        private GameObject BORGFleetEmpty;
        #region The Minor Race fleet Empties
        private GameObject ACAMARIANSFleetEmpty;
        private GameObject AKAALIFleetEmpty;
        private GameObject AKRITIRIANSFleetEmpty;
        private GameObject ALDEANSFleetEmpty;
        private GameObject ALGOLIANSFleetEmpty;
        private GameObject ALSAURIANSFleetEmpty;
        private GameObject ANDORIANSFleetEmpty;
        private GameObject ANGOSIANSFleetEmpty;
        private GameObject ANKARIFleetEmpty;
        private GameObject ANTEDEANSFleetEmpty;
        private GameObject ANTICANSFleetEmpty;
        private GameObject ARBAZANFleetEmpty;
        private GameObject ARDANANSFleetEmpty;
        private GameObject ARGRATHIFleetEmpty;
        private GameObject ARKARIANSFleetEmpty;
        private GameObject ATREANSFleetEmpty;
        private GameObject AXANARFleetEmpty;
        private GameObject BAJORANSFleetEmpty;
        private GameObject BAKUFleetEmpty;
        private GameObject BANDIFleetEmpty;
        private GameObject BANEANSFleetEmpty;
        private GameObject BARZANSFleetEmpty;
        private GameObject BENZITESFleetEmpty;
        private GameObject BETAZOIDSFleetEmpty;
        private GameObject BILANAIANSFleetEmpty;
        private GameObject BOLIANSFleetEmpty;
        private GameObject BOMARFleetEmpty;
        private GameObject BOSLICSFleetEmpty;
        private GameObject BOTHAFleetEmpty;
        private GameObject BREELLIANSFleetEmpty;
        private GameObject BREENFleetEmpty;
        private GameObject BREKKIANSFleetEmpty;
        private GameObject BYNARSFleetEmpty;
        private GameObject CAIRNFleetEmpty;
        private GameObject CALDONIANSFleetEmpty;
        private GameObject CAPELLANSFleetEmpty;
        private GameObject CHALNOTHFleetEmpty;
        private GameObject CORIDANFleetEmpty;
        private GameObject CORVALLENSFleetEmpty;
        private GameObject CYTHERIANSFleetEmpty;
        private GameObject DELTANSFleetEmpty;
        private GameObject DENOBULANSFleetEmpty;
        private GameObject DEVOREFleetEmpty;
        private GameObject DOPTERIANSFleetEmpty;
        private GameObject DOSIFleetEmpty;
        private GameObject DRAIFleetEmpty;
        private GameObject DREMANSFleetEmpty;
        private GameObject EDOFleetEmpty;
        private GameObject ELAURIANSFleetEmpty;
        private GameObject ELAYSIANSFleetEmpty;
        private GameObject ENTHARANSFleetEmpty;
        private GameObject EVORAFleetEmpty;
        private GameObject EXCALBIANSFleetEmpty;
        private GameObject FERENGIFleetEmpty;
        private GameObject FLAXIANSFleetEmpty;
        private GameObject GORNFleetEmpty;
        private GameObject GRAZERITESFleetEmpty;
        private GameObject HAAKONIANSFleetEmpty;
        private GameObject HALKANSFleetEmpty;
        private GameObject HAZARIFleetEmpty;
        private GameObject HEKARANSFleetEmpty;
        private GameObject HIROGENFleetEmpty;
        private GameObject HORTAFleetEmpty;
        private GameObject IYAARANSFleetEmpty;
        private GameObject JNAIIFleetEmpty;
        private GameObject KAELONFleetEmpty;
        private GameObject KAREMMAFleetEmpty;
        private GameObject KAZONFleetEmpty;
        private GameObject KELLERUNFleetEmpty;
        private GameObject KESPRYTTFleetEmpty;
        private GameObject KLAESTRONIANSFleetEmpty;
        private GameObject KRADINFleetEmpty;
        private GameObject KREETASSANSFleetEmpty;
        private GameObject KRIOSIANSFleetEmpty;
        private GameObject KTARIANSFleetEmpty;
        private GameObject LEDOSIANSFleetEmpty;
        private GameObject LISSEPIANSFleetEmpty;
        private GameObject LOKIRRIMFleetEmpty;
        private GameObject LURIANSFleetEmpty;
        private GameObject MALCORIANSFleetEmpty;
        private GameObject MALONFleetEmpty;
        private GameObject MAQUISFleetEmpty;
        private GameObject MARKALIANSFleetEmpty;
        private GameObject MERIDIANSFleetEmpty;
        private GameObject MINTAKANSFleetEmpty;
        private GameObject MIRADORNFleetEmpty;
        private GameObject MIZARIANSFleetEmpty;
        private GameObject MOKRAFleetEmpty;
        private GameObject MONEANSFleetEmpty;
        private GameObject NAUSICAANSFleetEmpty;
        private GameObject NECHANIFleetEmpty;
        private GameObject NEZUFleetEmpty;
        private GameObject NORCADIANSFleetEmpty;
        private GameObject NUMIRIFleetEmpty;
        private GameObject NUUBARIFleetEmpty;
        private GameObject NYRIANSFleetEmpty;
        private GameObject OCAMPAFleetEmpty;
        private GameObject ORIONSFleetEmpty;
        private GameObject ORNARANSFleetEmpty;
        private GameObject PAKLEDFleetEmpty;
        private GameObject PARADANSFleetEmpty;
        private GameObject QUARRENFleetEmpty;
        private GameObject RAKHARIFleetEmpty;
        private GameObject RAKOSANSFleetEmpty;
        private GameObject RAMATIANSFleetEmpty;
        private GameObject HELIOSFleetEmpty;
        private GameObject RIGELIANSFleetEmpty;
        private GameObject RISIANSFleetEmpty;
        private GameObject RUTIANSFleetEmpty;
        private GameObject SELAYFleetEmpty;
        private GameObject SHELIAKFleetEmpty;
        private GameObject SIKARIANSFleetEmpty;
        private GameObject SKRREEAFleetEmpty;
        private GameObject SONAFleetEmpty;
        private GameObject SULIBANFleetEmpty;
        private GameObject TAKARANSFleetEmpty;
        private GameObject TAKARIANSFleetEmpty;
        private GameObject TAKTAKFleetEmpty;
        private GameObject TALARIANSFleetEmpty;
        private GameObject TALAXIANSFleetEmpty;
        private GameObject TALOSIANSFleetEmpty;
        private GameObject TAMARIANSFleetEmpty;
        private GameObject TANUGANSFleetEmpty;
        private GameObject TELLARITESFleetEmpty;
        private GameObject TEPLANSFleetEmpty;
        private GameObject THOLIANSFleetEmpty;
        private GameObject TILONIANSFleetEmpty;
        private GameObject TLANIFleetEmpty;
        private GameObject TRABEFleetEmpty;
        private GameObject TRILLFleetEmpty;
        private GameObject TROGORANSFleetEmpty;
        private GameObject TZENKETHIFleetEmpty;
        private GameObject ULLIANSFleetEmpty;
        private GameObject VAADWAURFleetEmpty;
        private GameObject VENTAXIANSFleetEmpty;
        private GameObject VHNORIFleetEmpty;
        private GameObject VIDIIANSFleetEmpty;
        private GameObject VISSIANSFleetEmpty;
        private GameObject VORGONSFleetEmpty;
        private GameObject VORIFleetEmpty;
        private GameObject VULCANSFleetEmpty;
        private GameObject WADIFleetEmpty;
        private GameObject XANTHANSFleetEmpty;
        private GameObject XEPOLITESFleetEmpty;
        private GameObject XINDIFleetEmpty;
        private GameObject XYRILLIANSFleetEmpty;
        private GameObject YADERANSFleetEmpty;
        private GameObject YRIDIANSFleetEmpty;
        private GameObject ZAHLFleetEmpty;
        private GameObject ZAKDORNFleetEmpty;
        private GameObject ZALKONIANSFleetEmpty;
        private GameObject ZIBALIANSFleetEmpty;
        #endregion
        private List<GameObject> sysEmptyList;
        private List<GameObject> fleetEmptyList;
        public static GameObject galaxyTile;
        public List<int> NumbersForSystem;
        public ulong zoomLevels = 150000000000; // times 1 billion zoom
       // Dictionary<SolarSystem, GameObject> solarSystemGameObjectMap; // put in the ss sprit and get the ss game object
        private char separator = ',';
        public static Dictionary<int, string[]> SystemDataDictionary = new Dictionary<int, string[]>();
        public static List<GameObject> _objectsInGalaxy = new List<GameObject>();
        public static List<GameObject> _movingGalaxyObjects = new List<GameObject>();
        public static List<GameObject> _starSystemObjects = new List<GameObject>();
        
        public Mesh _mesh;
        public Material _material;
        public GameObject _lineEndpointPrefab;
        public GameObject _fleetLineEndpointPrefab; 
        public GameObject _systemSpherePrefab;
        public Vector3 _systemPosition;
   

        void Awake()
        {
            //fleetManager = cameraManagerGalactica.FleetManagerEmpty;
            //fleetManager.SetActive(false);
            sysEmptyList = new List<GameObject>
            {
                FEDSysEmpty,
                ROMSysEmpty,
                KLINGSysEmpty,
                CARDSysEmpty,
                DOMSysEmpty,
                BORGSysEmpty,
                #region Minor Race System Entries
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
            fleetEmptyList = new List<GameObject>
            {
                FEDFleetEmpty,
                ROMFleetEmpty,
                KLINGFleetEmpty,
                CARDFleetEmpty,
                DOMFleetEmpty,
                BORGFleetEmpty,
                #region Minor Race Fleet Entries
                ACAMARIANSFleetEmpty,
                AKAALIFleetEmpty,
                AKRITIRIANSFleetEmpty,
                ALDEANSFleetEmpty,
                ALGOLIANSFleetEmpty,
                ALSAURIANSFleetEmpty,
                ANDORIANSFleetEmpty,
                ANGOSIANSFleetEmpty,
                ANKARIFleetEmpty,
                ANTEDEANSFleetEmpty,
                ANTICANSFleetEmpty,
                ARBAZANFleetEmpty,
                ARDANANSFleetEmpty,
                ARGRATHIFleetEmpty,
                ARKARIANSFleetEmpty,
                ATREANSFleetEmpty,
                AXANARFleetEmpty,
                BAJORANSFleetEmpty,
                BAKUFleetEmpty,
                BANDIFleetEmpty,
                BANEANSFleetEmpty,
                BARZANSFleetEmpty,
                BENZITESFleetEmpty,
                BETAZOIDSFleetEmpty,
                BILANAIANSFleetEmpty,
                BOLIANSFleetEmpty,
                BOMARFleetEmpty,
                BOSLICSFleetEmpty,
                BOTHAFleetEmpty,
                BREELLIANSFleetEmpty,
                BREENFleetEmpty,
                BREKKIANSFleetEmpty,
                BYNARSFleetEmpty,
                CAIRNFleetEmpty,
                CALDONIANSFleetEmpty,
                CAPELLANSFleetEmpty,
                CHALNOTHFleetEmpty,
                CORIDANFleetEmpty,
                CORVALLENSFleetEmpty,
                CYTHERIANSFleetEmpty,
                DELTANSFleetEmpty,
                DENOBULANSFleetEmpty,
                DEVOREFleetEmpty,
                DOPTERIANSFleetEmpty,
                DOSIFleetEmpty,
                DRAIFleetEmpty,
                DREMANSFleetEmpty,
                EDOFleetEmpty,
                ELAURIANSFleetEmpty,
                ELAYSIANSFleetEmpty,
                ENTHARANSFleetEmpty,
                EVORAFleetEmpty,
                EXCALBIANSFleetEmpty,
                FERENGIFleetEmpty,
                FLAXIANSFleetEmpty,
                GORNFleetEmpty,
                GRAZERITESFleetEmpty,
                HAAKONIANSFleetEmpty,
                HALKANSFleetEmpty,
                HAZARIFleetEmpty,
                HEKARANSFleetEmpty,
                HIROGENFleetEmpty,
                HORTAFleetEmpty,
                IYAARANSFleetEmpty,
                JNAIIFleetEmpty,
                KAELONFleetEmpty,
                KAREMMAFleetEmpty,
                KAZONFleetEmpty,
                KELLERUNFleetEmpty,
                KESPRYTTFleetEmpty,
                KLAESTRONIANSFleetEmpty,
                KRADINFleetEmpty,
                KREETASSANSFleetEmpty,
                KRIOSIANSFleetEmpty,
                KTARIANSFleetEmpty,
                LEDOSIANSFleetEmpty,
                LISSEPIANSFleetEmpty,
                LOKIRRIMFleetEmpty,
                LURIANSFleetEmpty,
                MALCORIANSFleetEmpty,
                MALONFleetEmpty,
                MAQUISFleetEmpty,
                MARKALIANSFleetEmpty,
                MERIDIANSFleetEmpty,
                MINTAKANSFleetEmpty,
                MIRADORNFleetEmpty,
                MIZARIANSFleetEmpty,
                MOKRAFleetEmpty,
                MONEANSFleetEmpty,
                NAUSICAANSFleetEmpty,
                NECHANIFleetEmpty,
                NEZUFleetEmpty,
                NORCADIANSFleetEmpty,
                NUMIRIFleetEmpty,
                NUUBARIFleetEmpty,
                NYRIANSFleetEmpty,
                OCAMPAFleetEmpty,
                ORIONSFleetEmpty,
                ORNARANSFleetEmpty,
                PAKLEDFleetEmpty,
                PARADANSFleetEmpty,
                QUARRENFleetEmpty,
                RAKHARIFleetEmpty,
                RAKOSANSFleetEmpty,
                RAMATIANSFleetEmpty,
                HELIOSFleetEmpty,
                RIGELIANSFleetEmpty,
                RISIANSFleetEmpty,
                RUTIANSFleetEmpty,
                SELAYFleetEmpty,
                SHELIAKFleetEmpty,
                SIKARIANSFleetEmpty,
                SKRREEAFleetEmpty,
                SONAFleetEmpty,
                SULIBANFleetEmpty,
                TAKARANSFleetEmpty,
                TAKARIANSFleetEmpty,
                TAKTAKFleetEmpty,
                TALARIANSFleetEmpty,
                TALAXIANSFleetEmpty,
                TALOSIANSFleetEmpty,
                TAMARIANSFleetEmpty,
                TANUGANSFleetEmpty,
                TELLARITESFleetEmpty,
                TEPLANSFleetEmpty,
                THOLIANSFleetEmpty,
                TILONIANSFleetEmpty,
                TLANIFleetEmpty,
                TRABEFleetEmpty,
                TRILLFleetEmpty,
                TROGORANSFleetEmpty,
                TZENKETHIFleetEmpty,
                ULLIANSFleetEmpty,
                VAADWAURFleetEmpty,
                VENTAXIANSFleetEmpty,
                VHNORIFleetEmpty,
                VIDIIANSFleetEmpty,
                VISSIANSFleetEmpty,
                VORGONSFleetEmpty,
                VORIFleetEmpty,
                VULCANSFleetEmpty,
                WADIFleetEmpty,
                XANTHANSFleetEmpty,
                XEPOLITESFleetEmpty,
                XINDIFleetEmpty,
                XYRILLIANSFleetEmpty,
                YADERANSFleetEmpty,
                YRIDIANSFleetEmpty,
                ZAHLFleetEmpty,
                ZAKDORNFleetEmpty,
                ZALKONIANSFleetEmpty,
                ZIBALIANSFleetEmpty
            #endregion
            };
            LoadSystemData(Environment.CurrentDirectory + "\\Assets\\" + "SystemData.txt");
            //LoadCivData

        }
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                //Collider targetObject = Physics.OverlapCapsule(mousePosition);
            }
        }

        public void InstantiateSystemButtons(int[] numStars, GalaxyType canonOrRandom)
        {
            // ToDo Implement both cannon and readme based on incoming GalaxyType selection
            string[] keysForSystemDictionary = ReadSystemNames(); // all the system names in string[]

            //We are currently only numStars = 6; use numStars, without this reset, when we have enough system-button prefabs built and loaded 

            Galaxy galaxy = new Galaxy(gameManager);
            //if (canonOrRandom == GalaxyType.CANON)
            GameObject tempObject = GameObject.Find("CanvasGalactic");
            canvasGalactic = tempObject.GetComponent<Canvas>();
            for (int i = 0; i < numStars.Length; i++)
            {
                Civilization civy;
                int sysIndex = numStars[i];
                string ourKey = keysForSystemDictionary[sysIndex];
                if (keysForSystemDictionary[sysIndex].Length != 0)
                {
                    
                    sysEmptyList[sysIndex] = new GameObject(); // object no longer null

                    if (tempObject != null)
                    {
                        sysEmptyList[sysIndex].name = SystemDataDictionary[sysIndex][4];
                        int x = int.Parse(SystemDataDictionary[sysIndex][1]);
                        int y = int.Parse(SystemDataDictionary[sysIndex][2]);
                        int z = int.Parse(SystemDataDictionary[sysIndex][3]);
                        Vector3 worldSpace = new Vector3(x, y, z);
                        sysEmptyList[sysIndex].transform.Translate(worldSpace, Space.World);
                        sysEmptyList[sysIndex].transform.SetParent(canvasGalactic.transform, false);
                        sysEmptyList[sysIndex].layer = 6;
                        
                        GalaxyDropLine line = Instantiate(systemDropLine, new Vector3(0, 0, 0), Quaternion.identity);
                        line.name = sysEmptyList[sysIndex].name + "_SystemLine";

                        GameObject emptyForPlanePoint = Instantiate(_lineEndpointPrefab, new Vector3(x, y, 600f), Quaternion.identity);
                        emptyForPlanePoint.name = sysEmptyList[sysIndex].name + "_SystemPlanePoint";

                        emptyForPlanePoint.transform.SetParent(canvasGalactic.transform, false );
                        emptyForPlanePoint.layer = 7;

                        Transform[] endPoints = new Transform[2] { sysEmptyList[sysIndex].transform, emptyForPlanePoint.transform}; 
                        line.SetUpLine(endPoints);

                        var hTips = sysEmptyList[sysIndex].AddComponent<HoverTips>();
                        hTips._hoverTipManager = hoverTipManager;
                        hTips._starSysEnum = (StarSystemEnum)sysIndex;
                        hTips._sysLocation = worldSpace;
                        //hTips._hoverTipManager = hoverTipManager;

                        sysEmptyList[sysIndex].SetActive(true);
                    }
                    // The PreFabStarSystemDictionary and PrefabFleetDictionary are setup in Unity, Hierarchy, GameManager, the public Prefab lists
                    GameObject starSystemNewGameOb = Instantiate(GameManager.PrefabStarSystemDictionary[ourKey], new Vector3(0, 0, 0), Quaternion.identity);
                    starSystemNewGameOb.transform.SetParent(sysEmptyList[sysIndex].transform, false);
                    starSystemNewGameOb.transform.localScale = new Vector3(1, 1, 1);
                    
                    _objectsInGalaxy.Add(starSystemNewGameOb);
                    _starSystemObjects.Add(starSystemNewGameOb);

                    civy = CivilizationData.CivilizationDictionary[(CivEnum)sysIndex];
                    civy._homeSystemEnum = (StarSystemEnum)sysIndex;
                    StarSystemEnum someEnum = (StarSystemEnum)sysIndex;
                    starSystemNewGameOb.name = someEnum.ToString();
                    
                    FogOfWarNaming(starSystemNewGameOb, civy); // Do not name unexpolored star, give only coordenants
                    //TMP_Text textMeshPro = starSystemNewGameOb.GetComponentInChildren<TMP_Text>();

                    GameObject sysSphere = Instantiate(_systemSpherePrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    sysSphere.transform.SetParent(sysEmptyList[sysIndex].transform, false); //starSystemNewGameOb.transform, false);
                    sysSphere.transform.localScale = new Vector3(27000, 27000, 27000);
                    sysSphere.name = someEnum + "_Sphere";
                    //sysSphere.layer = 2; // Ignore Raycast clicks on system button, only count fleets
                    StarSystem ourSystem = starSystemData.GetSystem((StarSystemEnum)sysIndex);

                    ourSystem._systemSphere = sysSphere;

                    Civilization theCiv = CivilizationData.CivilizationDictionary[(CivEnum)sysIndex]; // get civ out of Dictionary
                    if (i < 6 && GameManager.PrefabFleetDictionary[ourKey] != null) //now add fleet below, we do not see shipyards
                    {
                        /// We will Instantiate the shipyard with a model when entering combat, in system we will manage the yard 
                        //GameObject firstShipYard = Instantiate(GameManager.PrefabShipYardDictionary[theCiv._shortName],
                        //    new Vector3(0, 0, 0), Quaternion.identity);

                        GameObject firstFleetOfSystem = Instantiate(GameManager.PrefabFleetDictionary[ourKey],
                            new Vector3(0, 0, 0), Quaternion.identity);

                        firstFleetOfSystem.transform.SetParent(canvasGalactic.transform, false);  
                        firstFleetOfSystem.transform.position = sysEmptyList[sysIndex].transform.position;
                        firstFleetOfSystem.transform.Translate(0, -5, 15);
                        firstFleetOfSystem.transform.localScale = new Vector3(2, 2, 2);
                        firstFleetOfSystem.layer = 6;
                        firstFleetOfSystem.SetActive(true);
                        firstFleetOfSystem.name = sysEmptyList[sysIndex].name + "_fleet";
                        FleetData firstFleetData = firstFleetOfSystem.GetComponent<FleetData>();
                        List<GalaxyShip> starterGalaxyShips = new List<GalaxyShip>();
                        var techLevel = GameManager._techLevel;
                        foreach (var item in GameManager.GalaxyShipNameDictionary)
                        { 

                            if (item.Key.Contains(((CivEnum)sysIndex).ToString()))
                            {
                                for (int j = 0; j <item.Value; j++)
                                {
                                    GameObject currentGalaxyShip = Instantiate<GameObject>(prefabForGalaxyShip, new Vector3(1000, 1000, 1000), Quaternion.identity) as GameObject;
                                    GalaxyShip thisGShip = currentGalaxyShip.GetComponent<GalaxyShip>();
                                    thisGShip._shipName = item.Key + "_" + j.ToString();
                                    thisGShip._civilization = (CivEnum)sysIndex;
                                    thisGShip._techLeve = techLevel;
                                    currentGalaxyShip.transform.SetParent(firstFleetOfSystem.transform, false);
                                    starterGalaxyShips.Add(thisGShip);
                                }
                            }
                        }

                        firstFleetData.ShipsInFeet = starterGalaxyShips.ToArray();

                        firstFleetData._inDeepSpace = false;
                     
                        theCiv.civFleetList = new List<FleetData> { firstFleetData };
                        _objectsInGalaxy.Add(firstFleetData.gameObject);
                        _movingGalaxyObjects.Add(firstFleetData.gameObject);
                        float x = firstFleetOfSystem.transform.localPosition.x;
                        float y = firstFleetOfSystem.transform.localPosition.y;
                        GalaxyDropLine fleetLine = Instantiate(fleetDropLine, new Vector3(0,0,0), Quaternion.identity);
                        fleetLine.name = firstFleetOfSystem.name + "_FleetLine";
                        //fleetLine.gameObject.layer = 1;
                        GameObject fleetPlaneGameObj = Instantiate(_fleetLineEndpointPrefab,
                            new Vector3(x,y,600f), Quaternion.identity);
                        fleetPlaneGameObj.name = sysEmptyList[sysIndex].name + "_FleetPlanePoint";
                        fleetPlaneGameObj.transform.SetParent(canvasGalactic.transform, false);                    
                        fleetPlaneGameObj.layer = 7;
                        //firstFleet.galaxyPlaneGO = fleetPlaneGameObj;
                        // fleetPlaneGameObj.SetActive(true);

                        Transform[] endFleetPoints = new Transform[2] 
                            { firstFleetOfSystem.transform, fleetPlaneGameObj.transform };
                        fleetLine.SetUpLine(endFleetPoints);
                        // Temp get fleets moving to galatic center
                        GameObject targetWeMoveTo = new GameObject();
                        targetWeMoveTo.transform.position = new Vector3(0, 0, 0);
                        MoveGalacticObjects moveGalacticObject = firstFleetData.GetComponent<MoveGalacticObjects>();
                        thisMovingObject = moveGalacticObject;
                        thisMovingObject.BoldlyGo(firstFleetData, targetWeMoveTo, fleetPlaneGameObj, 200f);
                    }


                    starSystemNewGameOb.SetActive(true);

 
                }
                if (canonOrRandom == GalaxyType.RANDOM)
                {
                    // ToDo: random galaxy here
                    foreach (var sysEmpty in sysEmptyList)
                    {
                        // space out sysEmpties on Galaxy view in a random distribution
                        // call RandomizeMap to get random x, inputY and z for: Vector3 worldSpace = new Vector3(x, inputY, z);
                        // sysEmpty.transform.Translate(random values here x, inputY, z);
                    }
                }
            }
            //Build a travelPointMarker;
            gameManager.galaxy = galaxy;
            SolarSystemView view = new SolarSystemView();
        }

        private void RandomizeMap()
        {

        }
        private void FogOfWarNaming(GameObject sysObject, Civilization civy)
        {
            // minors we know at game start are loaded in CivilizationData.LoadOurStartingMinor()
            if (gameManager._localPlayer != (CivEnum)civy._civID) // cast int _civID to CivEnum
            {
                var civPlayer = gameManager.civilizationData.CivFromEnum(gameManager._localPlayer);
                if (!civPlayer._contactList.Contains(civy))
                    sysObject.GetComponentInChildren<TMP_Text>().text =
                    "x" + ((int)sysObject.transform.position.x).ToString() +
                    ",inputY" + ((int)sysObject.transform.position.y).ToString() +
                    ",z" + ((int)sysObject.transform.position.z).ToString();
            }

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
        private void StarterFleetForCivs(GalaxyShip[] fleetShips)
        {

            FleetData newFleet = new FleetData(fleetShips);

            GameObject tempObject = GameObject.Find("CanvasGalactic");
            if (tempObject != null)
            {
                canvasGalactic = tempObject.GetComponent<Canvas>();
            }
            //GameObject fleetNewGameOb = Instantiate(GameManager.PrefabFleetDitionary[civEnum.ToString()], new Vector3(0, 0, 0), Quaternion.identity);
            //fleetNewGameOb.transform.Translate(location.position.x, location.position.inputY, location.position.z, Space.World);
            //fleetNewGameOb.transform.SetParent(canvasGalactic.transform, false);
            //fleetNewGameOb.transform.localScale = new Vector3(1, 1, 1);

            //fleetNewGameOb.SetActive(true);
            //Fleet myfleet = fleetNewGameOb.GetComponent<Fleet>();
            //myfleet = newFleet;
            //_fleetObjInGalaxy.Add(fleetNewGameOb);           
        }

        public void UpdateTheFleet(FleetData fleet, List<GalaxyShip> newShipList)
        {

        }
        public void ShowASolarSystemView(int buttonSystemID) // The 3D view of system, THE BACKGROUND EYE CANDY
        {
            //if (fleetManager.active == true)
            //    return;
            while (transform.childCount > 0) // delelt old systems from prior update
            {
                Transform child = transform.GetChild(0);
                child.SetParent(null); // decreases number of children in while loop
                Destroy(child.gameObject);

            }
            //fleetManager.SetActive(false);
            //solarSystemGameObjectMap = new Dictionary<SolarSystem, GameObject>();
            //solarSystemView.ShowNextSolarSystemView(buttonSystemID); // the number is found in Unity Inspector, button On Click 
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
        //public void ExitFleetManager()
        //{
        //    fleetManager.SetActive(false);
        //}
        //public void EnterFleetManager()
        //{
        //    if (fleetManager.active == false)
        //    {
        //        //fleetManager.SetActive(true);
        //        fleetManager.SetActiveRecursively(true);
        //    }
        //    else fleetManager.SetActiveRecursively(false);
        //}
        //public static void DrawColliderMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera = null, int submeshindex = 0, MaterialPropertyBlock properties =null, bool castShadows)
        //{

        //}
    }
}