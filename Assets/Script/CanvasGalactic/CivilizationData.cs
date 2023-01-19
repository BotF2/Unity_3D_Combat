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
using UnityEngine.Device;

namespace BOTF3D_GalaxyMap
{
    public class CivilizationData : MonoBehaviour
    {
        #region Fields
        //public Canvas canvasGalactic;
        [SerializeField]
        public static Dictionary<int, string[]> CivDataDictionary; // incoming data
        [SerializeField]
        public static Dictionary<CivEnum, Civilization> CivilizationDictionary = new Dictionary<CivEnum, Civilization>() { { CivEnum.PLACEHOLDER, new Civilization(111) } };

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

            }
            #endregion
        }
        public static Civilization Create(int systemInt)
        {
            Civilization daCiv = new Civilization(systemInt);
            var sysStrings = CivilizationData.CivDataDictionary[systemInt];
            daCiv._civEnum = (CivEnum)systemInt;
            daCiv._shortName = sysStrings[2];
            daCiv._longName = sysStrings[3];

            //GetImage(systemInt, 8, "Insignias/", daCiv); // 8 is insignia
            string holdInsigniaName = CivDataDictionary[systemInt][8];
            string pathInsignia = "Insignias/" + holdInsigniaName.ToUpper();
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Plane); // (nameInsginia);
            var rend = go.GetComponent<Renderer>();
            rend.material.mainTexture = Resources.Load(pathInsignia) as Texture;
            daCiv._insignia = Sprite.Create((Texture2D)rend.material.mainTexture, new Rect(0, 0, rend.material.mainTexture.width, rend.material.mainTexture.height), new Vector2(0.5f, 0.5f));
            go.gameObject.SetActive(false);

            //GetImage(systemInt, 7, "Civilizations/", daCiv); // 7 is Civ
            string holdCivName = CivDataDictionary[systemInt][7];
            string pathCiv = "Civilizations/" + holdCivName.ToLower();
            GameObject goTwo = GameObject.CreatePrimitive(PrimitiveType.Plane);
            var rendTwo = goTwo.GetComponent<Renderer>();
            rendTwo.material.mainTexture = Resources.Load(pathCiv) as Texture;
            daCiv._civImage = Sprite.Create((Texture2D)rendTwo.material.mainTexture, new Rect(0, 0, rendTwo.material.mainTexture.width, rendTwo.material.mainTexture.height), new Vector2(0.5f, 0.5f));
            goTwo.gameObject.SetActive(false);

            daCiv._civResearch = int.Parse(sysStrings[10]);
            daCiv._civCredits = int.Parse(sysStrings[9]);
            CivilizationDictionary.Add(daCiv._civEnum, daCiv);
            daCiv._homeSystem = StarSystemData.Create(systemInt);
            daCiv._homeSystem._ownerCiv = daCiv;
            return daCiv;
        }
        //private static void GetImage(int system, int theIndex, string path, Civilization daCiv)
        //{
        //    string holdInsigniaName = CivDataDictionary[system][theIndex];
        //    string pathInsignia = path + holdInsigniaName;
        //    GameObject go = GameObject.CreatePrimitive(PrimitiveType.Plane); // (nameInsginia);
        //    var rend = go.GetComponent<Renderer>();
        //    rend.material.mainTexture = Resources.Load(pathInsignia) as Texture;
        //    daCiv._insignia = Sprite.Create((Texture2D)rend.material.mainTexture, new Rect(0, 0, rend.material.mainTexture.width, rend.material.mainTexture.height), new Vector2(0.5f, 0.5f));
        //    go.gameObject.SetActive(false);

        //}
    }
}
