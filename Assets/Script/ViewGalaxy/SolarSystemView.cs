using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class SolarSystemView : MonoBehaviour // !!! INSIDE PanelGalactic_Play IN UNITY HIERARCHY - GALAXYSCEEN !!!
    {
        public GameManager gameManager;
        public SolarSystem solarSystem;
        public Sprite[] Sprites;
        public ulong zoomLevels = 150000000000; // times 1 billion zoom
        float planetMoonScale = 0.2f;
        Galaxy ourGalaxy;
        Dictionary<OrbitalGalactic, GameObject> orbitalGameObjectMap; // put in the orbital sprit and get the game object
        private char separator = ',';
        public static Dictionary<int, string[]> systemDataDictionary = new Dictionary<int, string[]>();
        // private OrbitalGalactic mySolarSystem; // star and planets
        //private void Awake()
        //{
        //    LoadSystemData(Environment.CurrentDirectory + "\\Assets\\" + "SystemData.txt");
        //}
        void Start()
        {
            gameManager = GameManager.Instance;
            systemDataDictionary = GalaxyView.SystemDataDictionary;
        }
        void Update()
        {
            if (solarSystem == null)
                return;
            // loop orbitals updating position base on zoomlevel
            else
                for (int i = 0; i < solarSystem.Children.Count; i++)
                {
                    UpdateSprites(solarSystem.Children[i]);
                }
            if (ourGalaxy == null && gameManager.galaxy != null)
                ourGalaxy = gameManager.galaxy;

        }

        public void TurnOffSolarSystemview(Galaxy galaxy, int solarSystemID)
        {
            ourGalaxy = galaxy;
            while (transform.childCount > 0) // delelt old systems from prior update
            {
                Transform child = transform.GetChild(0);
                child.SetParent(null); // decreases number of children in while loop
                Destroy(child.gameObject);
            }
            solarSystem = null;
        }
        public void ShowSolarSystemView(Galaxy galaxy, int solarSystemID) // called from gameManager with the input galaxy
        {
            while (transform.childCount > 0) // delelt old systems from prior update
            {
                Transform child = transform.GetChild(0);
                child.SetParent(null); // decreases number of children in while loop
                Destroy(child.gameObject);
            }
            //orbitalGameObjectMap = new Dictionary<OrbitalGalactic, GameObject>();
            //solarSystem = SolarSystems[0];
            solarSystem = ourGalaxy.SolarSystems[solarSystemID];
            for (int i = 0; i < solarSystem.Children.Count; i++)
            {
                this.MakeSpritesForOrbital(this.transform, solarSystem.Children[i]);
            }
        }
        public void ShowNextSolarSystemView(int buttonSystemID)
        {
            while (transform.childCount > 0) // transform is the SSView child of the solar system button, delelt old systems from prior update
            {
                Transform child = transform.GetChild(0);
                child.SetParent(null); // decreases number of children in while loop
                Destroy(child.gameObject);
            }
            gameManager.ChangeSystemClicked(buttonSystemID, this);
            gameManager.SwitchtState(GameManager.State.GALACTIC_MAP_INIT, 0);
            //ToDo need to generat the new SolarSystemView based on a buttonSystemID
           // LoadSystemData(Environment.CurrentDirectory + "\\Assets\\" + "SystemData.txt");
            string[] systemData = systemDataDictionary[buttonSystemID];

            //for (int i = 0; i < solarSystem.Children.Count; i++)
            //{
            //    this.MakeSpritesForOrbital(this.transform, solarSystem.Children[i]);
            //}
        }

        private void MakeSpritesForOrbital(Transform transformParent, OrbitalGalactic orbitalG)
        {
            //CameraManagerGalactica cameraManagerGalactic = new CameraManagerGalactica();
            GameObject gameObject = new GameObject();
            orbitalGameObjectMap[orbitalG] = gameObject; // update map
            gameObject.layer = 30; // galactic
            gameObject.transform.SetParent(transformParent, false);
            // set position in 3D
            gameObject.transform.position = orbitalG.Position / zoomLevels; // cut down scale of system to view
            SpriteRenderer spritView = gameObject.AddComponent<SpriteRenderer>();
            spritView.transform.localScale = new Vector3(planetMoonScale, planetMoonScale, planetMoonScale);
            spritView.sprite = Sprites[orbitalG.GraphicID];
            orbitalGameObjectMap.Add(orbitalG, gameObject);
            //if(galacticCamera != null) // NO LUCK SO FAR BRINGING IN THE GALACTIC CAMERA FOR A LookAt(camera);
            //    spritView.transform.LookAt(galacticCamera.transform);
            //StupidInt += 1;
            for (int i = 0; i < orbitalG.Children.Count; i++)
            {
                MakeSpritesForOrbital(gameObject.transform, orbitalG.Children[i]);
                //spritView.transform.LookAt();
            }
        }
        void UpdateSprites(OrbitalGalactic orbital)
        {
            GameObject gameObject = orbitalGameObjectMap[orbital];
            gameObject.transform.position = orbital.Position / zoomLevels;
            for (int i = 0; i < orbital.Children.Count; i++)
            {
                UpdateSprites(orbital.Children[i]);
            }
        }
        public void SetZoomLevel(ulong zl)
        {
            zoomLevels = zl;
            //Update planet postions and scale graphics to still see planet sprites as a few pix
        }
        //public void LoadSystemData(string filename)
        //{
        //    #region Read SystemData.txt 

        //    Dictionary<int, string[]> _systemDataDictionary = new Dictionary<int, string[]>();
        //    var file = new FileStream(filename, FileMode.Open, FileAccess.Read);

        //    var _dataPoints = new List<string>();
        //    using (var reader = new StreamReader(file))
        //    {

        //        while (!reader.EndOfStream)
        //        {
        //            int entryNum = 0;
        //            var line = reader.ReadLine();
        //            if (line == null)
        //                continue;
        //            _dataPoints.Add(line.Trim());

        //            if (line.Length > 0)
        //            {
        //                var coll = line.Split(separator);

        //                // _ = int.TryParse(coll[1], out int currentValueOne);
        //                // _ = int.TryParse(coll[2], out int currentValueTwo);
        //                // _ = int.TryParse(coll[3], out int currentValueThree);
        //                // _ = int.TryParse(coll[4], out int currentValueFour);
        //                // _ = int.TryParse(coll[5], out int currentValueFive);
        //                // _ = int.TryParse(coll[6], out int currentValueSix);
        //                // _ = int.TryParse(coll[7], out int currentValueSeven);
        //                // _ = int.TryParse(coll[8], out int currentValueEight);
        //                // _ = int.TryParse(coll[9], out int currentValueNine);
        //                // _ = int.TryParse(coll[10], out int currentValueTen);
        //                // _ = int.TryParse(coll[11], out int currentValueEleven);
        //                // _ = int.TryParse(coll[12], out int currentValueTweleve);
        //                // _ = int.TryParse(coll[13], out int currentValueThirteen);
        //                // _ = int.TryParse(coll[14], out int currentValueFourteen);
        //                // _ = int.TryParse(coll[15], out int currentValueFifteen);

        //                //string[] systemDataArray = new string[25]
        //                //{
        //                //    coll[0],
        //                //    coll[1],
        //                //    coll[2],
        //                //    coll[3],
        //                //    coll[4],
        //                //    coll[5],
        //                //    coll[6],
        //                //    coll[7],
        //                //    coll[8],
        //                //    coll[9],
        //                //    coll[10],
        //                //    coll[11],
        //                //    coll[12],
        //                //    coll[13],
        //                //    coll[14],
        //                //    coll[15],
        //                //    coll[16],
        //                //    coll[17],
        //                //    coll[18],
        //                //    coll[19],
        //                //    coll[20],
        //                //    coll[21],
        //                //    coll[22],
        //                //    coll[23],
        //                //    coll[24]
        //                //};

        //                _systemDataDictionary.Add(entryNum, coll);
        //                entryNum++;
        //                //_shipInts.Clear();
        //            }
        //        }

        //        reader.Close();
        //        SystemDataDictionary = _systemDataDictionary;
        //        //StaticStuff staticStuffToLoad = new StaticStuff();
        //        //staticStuffToLoad.LoadStaticShipData(_shipDataDictionary);
        //    }
        //    #endregion
        //}
    }
}
