using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Net;
using UnityEngine.Rendering.VirtualTexturing;
//using BOTF3D_Core;
//using BOTF3D_Combat;
using Assets.Core;
using TMPro;

namespace GalaxyMap
{
    public class SolarSystemView : MonoBehaviour
    {
        public GameManager gameManager;
        private SolarSystem solarSystem;
        public Image civOwnerImage; // asigned in inspector, just like StarSystemData
        public Image civInsigniaImage;
        public Sprite spriteForOwnerCiv;
        public Sprite spriteForOwnerInsignia;
        private string originalCivOwnerName;
        public GameObject ownerTxMeshName;
        public string ownerStringName;
        TextMeshProUGUI ownerName;
        public GameObject sysTxMeshName;
        public string sysStringName;
        TextMeshProUGUI sysName;
        public Sprite[] starSprites;
        public Sprite[] solFedSys;
        public Sprite[] m_TypeHabitable;
        public Sprite[] h_TypeUnInhabitable;
        public Sprite[] k_TypeMarsLike;
        public Sprite[] j_TypeGasGiants;
        public Sprite[] moonType;
        public Sprite[] solSprites;
        public Sprite earthMoonSprite;
        private Color systemColorTint = new Color(1, 1, 1);
        private string[] systemDataArray;
        public ulong zoomLevels = 150000000000; // times 1 billion zoom
        float planetMoonScale = 0.25f;
        public float galacticTime = 0;
        private int deltaTime = 1000;
        private int earthSpriteCounter = 0;
        Dictionary<OrbitalGalactic, GameObject> orbitalGameObjectMap; // put in the orbital sprit and get the game object
        public static Dictionary<int, string[]> systemDataDictionary = new Dictionary<int, string[]>();

        void Start()
        {
            gameManager = GameManager.Instance;
            systemDataDictionary = GalaxyView.SystemDataDictionary; // this really works
            ownerName = ownerTxMeshName.GetComponent<TextMeshProUGUI>();
        
            sysName = sysTxMeshName.GetComponent<TextMeshProUGUI>();
        }
        void Update()
        {
            galacticTime = galacticTime + deltaTime;
            if (solarSystem == null)
                return;
            else
            {
                OrbitalGalactic sunOrbitalGalactic = solarSystem.Children[0];

                for (int i = 0; i < sunOrbitalGalactic.Children.Count; i++)
                {
                    sunOrbitalGalactic.Children[i].Update(galacticTime); // update offset angle for orbital
                    UpdateSprites(sunOrbitalGalactic.Children[i]); // UpdateSprites for starsystem
                }
            }
        }

        public void TurnOffSolarSystemview(Galaxy galaxy, int solarSystemID)
        {
            //ourGalaxy = galaxy;
            while (transform.childCount > 0) // delelt old systems from prior update
            {
                Transform child = transform.GetChild(0);
                child.SetParent(null); // decreases number of children in while loop
                Destroy(child.gameObject);
            }
            solarSystem = null;
        }

        public void ShowNextSolarSystemView(int buttonSystemID)// background solar system view
        {
            while (transform.childCount > 0) // transform is the SSView child of the solar system button, delete old systems from prior update
            {
                Transform child = transform.GetChild(0);
                child.SetParent(null); // decreases number of children in while loop
                Destroy(child.gameObject);
            }

            gameManager.ChangeSystemClicked(buttonSystemID, this); // clicked galaxy map star

            gameManager.SwitchtState(GameManager.State.GALACTIC_MAP_INIT, buttonSystemID);
            systemDataArray = systemDataDictionary[buttonSystemID];
            var mySolarSystem = new SolarSystem();
            mySolarSystem.LoadSystem(systemDataArray, buttonSystemID);
            solarSystem = mySolarSystem;
            for (int i = 0; i < solarSystem.Children.Count; i++)
            {
                this.LoadSpritesForOrbital(this.transform, solarSystem.Children[i], buttonSystemID, i);
            }
            //StarSystem theSystem = starSystemData.StarSystemDictionary[(StarSystemEnum)sysID];
            this.civOwnerImage.sprite = mySolarSystem.spriteForOwnerCiv;
            this.civInsigniaImage.sprite = mySolarSystem.spriteForOwnerInsignia;
            this.ownerStringName = mySolarSystem.sysOwner;
            ownerName.SetText(ownerStringName);
            this.sysStringName = mySolarSystem.sysName;
            sysName.SetText(sysStringName);
        }
        private void LoadSpritesForOrbital(Transform transformParent, OrbitalGalactic orbitalG, int systemID, int i)
        {
            GameObject gameObject = new GameObject();
            if (orbitalGameObjectMap != null)
            {
                // do nothing
            }
            else
                orbitalGameObjectMap = new Dictionary<OrbitalGalactic, GameObject>();// { { orbitalG, gameObject } };

            orbitalGameObjectMap.TryAdd(orbitalG, gameObject);

            gameObject.transform.SetParent(transformParent, false);
            gameObject.transform.position = orbitalG.Position / zoomLevels;
            gameObject.layer = 3; // Star System layer
            gameObject.name = "Orbital";
            SpriteRenderer renderer = gameObject.AddComponent<SpriteRenderer>();
            renderer.transform.localScale = new Vector3(planetMoonScale, planetMoonScale, planetMoonScale);

            //********* bring up sprites base on num in systemdata after planet type
            if (int.Parse(systemDataArray[0]) == 0)
                this.LoadEarthSprites(gameObject.transform, orbitalG, renderer);
            else
            {

                switch (orbitalG.GraphicID)
                {
                    case 0:
                        string starColor = systemDataArray[7];
                        gameObject.name = "Star"; // star in system view is single sprite
                        switch (starColor)
                        {
                            case "Blue":
                                renderer.sprite = starSprites[0];
                                systemColorTint = new Color(0.004f, 0.765f, 1f); // blueish
                                break;
                            case "Orange":
                                renderer.sprite = starSprites[1];
                                systemColorTint = new Color(1f, 0.827f, 0.588f); // Orangish
                                break;
                            case "Red":
                                renderer.sprite = starSprites[2];
                                systemColorTint = new Color(0.96f, 0.58f, 0.58f); // reddish
                                break;
                            case "White":
                                renderer.sprite = starSprites[3];
                                break;
                            case "Yellow":
                                renderer.sprite = starSprites[4];
                                systemColorTint = new Color(0.992f, 0.984f, 0.698f); // yellowish
                                break;
                            case "Nebula":
                                renderer.sprite = m_TypeHabitable[int.Parse(systemDataDictionary[systemID][9])]; // use first planet sprite as 'star'
                                break;
                            case "Complex":
                                renderer.sprite = m_TypeHabitable[int.Parse(systemDataDictionary[systemID][9])]; // use first planet sprite as 'star'
                                break;
                            default:
                                break;
                        }
                        break;
                    case 1 + (int)PlanetType.H_uninhabitable:
                        renderer.sprite = h_TypeUnInhabitable[int.Parse(systemDataDictionary[systemID][9 + (i * 3)])];
                        break;
                    case 1 + (int)PlanetType.J_gasGiant:
                        renderer.sprite = j_TypeGasGiants[int.Parse(systemDataDictionary[systemID][9 + (i * 3)])];
                        break;
                    case 1 + (int)PlanetType.M_habitable:
                        renderer.sprite = m_TypeHabitable[int.Parse(systemDataDictionary[systemID][9 + (i * 3)])];
                        break;
                    //case 1 + (int)PlanetType.L_marginalForLife:
                    //    renderer.sprite = planetMoonSprites[UnityEngine.Random.Range(17, 22)];
                    //    break;
                    case 1 + (int)PlanetType.K_marsLike:
                        renderer.sprite = k_TypeMarsLike[int.Parse(systemDataDictionary[systemID][9 + (i * 3)])];
                        break;
                    case 1 + (int)PlanetType.Moon:
                        renderer.sprite = moonType[UnityEngine.Random.Range(0, 6)];
                        break;
                    default:
                        break;

                }
                renderer.color = systemColorTint;
            }

            for (int j = 0; j < orbitalG.Children.Count; j++)
            {
                LoadSpritesForOrbital(gameObject.transform, orbitalG.Children[j], systemID, j);
            }

        }
        private void LoadEarthSprites(Transform transformParent, OrbitalGalactic orbitalG, SpriteRenderer renderer)
        {
            if (orbitalG.GraphicID == 1 + (int)PlanetType.Moon) // if Moon the PlanetType.Moon index = 5 in enum so graphic id = 6 is moon
            {
                if (orbitalG.Parent.GraphicID == 7) // Earth is set in switch below when earth goes through
                {
                    renderer.sprite = earthMoonSprite;
                }
                else
                    renderer.sprite = moonType[UnityEngine.Random.Range(0, 6)];
                renderer.transform.localScale = new Vector3(planetMoonScale, planetMoonScale, planetMoonScale); // smaller for moons
            }
            else
            {
                switch (earthSpriteCounter)
                {
                    case 0:
                        renderer.sprite = starSprites[4]; //yellow star
                        earthSpriteCounter++;
                        break;
                    case 1:
                        renderer.sprite = solFedSys[0];
                        earthSpriteCounter++;
                        break;
                    case 2:
                        renderer.sprite = solFedSys[1];
                        earthSpriteCounter++;
                        break;
                    case 3:
                        renderer.sprite = solFedSys[2];
                        orbitalG.GraphicID = 7; // find earth and use to get it's moon
                        earthSpriteCounter++;
                        break;
                    case 4:
                        renderer.sprite = solFedSys[3];
                        earthSpriteCounter++;
                        break;
                    case 5:
                        renderer.sprite = solFedSys[4]; // find Jupiter
                        renderer.transform.localScale += new Vector3(0.3f, 0.3f, 0);
                        earthSpriteCounter++;
                        break;
                    case 6:
                        renderer.sprite = solFedSys[5]; // find Saturn
                        renderer.transform.localScale += new Vector3(0.2f, 0.2f, 0);
                        earthSpriteCounter++;
                        break;
                    case 7:
                        renderer.sprite = solFedSys[6]; // find Uranus
                        Vector3 roatationVector = new Vector3(0, 0, 45);
                        Quaternion roatation = Quaternion.Euler(roatationVector);
                        renderer.transform.rotation = renderer.transform.rotation * roatation;
                        renderer.transform.localScale += new Vector3(0.3f, 0.3f, 0);
                        earthSpriteCounter++;
                        break;
                    case 8:
                        renderer.sprite = solFedSys[7];
                        renderer.transform.localScale += new Vector3(0.2f, 0.2f, 0);
                        earthSpriteCounter = 0;
                        break;
                    case 9:
                        earthSpriteCounter = 0;
                        break;
                    default:
                        break;
                }
            }
            // no need for additional loop here
        }
        void UpdateSprites(OrbitalGalactic orbital) //, float time)
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
    }
}
