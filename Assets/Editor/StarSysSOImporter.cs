using UnityEngine;
using UnityEditor;
using System.IO;
using Assets.Core;
using System;

public class StarSysSOImporter : EditorWindow
{
    [MenuItem("Tools/Import StarSysSO CSV")]
    public static void ShowWindow()
    {
        GetWindow<StarSysSOImporter>("StarSysSO CSV Importer");
    }

    private string filePath = $"Assets/Resources/Data/StarSystems.csv";

    void OnGUI()
    {
        GUILayout.Label("StarSysSO CSV Importer", EditorStyles.boldLabel);
        filePath = EditorGUILayout.TextField("CSV File Path", filePath);

        if (GUILayout.Button("Import StarSysSO CSV"))
        {


            //Output the Game data path to the console
            Debug.Log("dataPath : " + Application.dataPath);
            ImportStarSysCSV(filePath);
        }
    }
    private static void ImportStarSysCSV(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError("File not found: " + filePath);
            return;
        }

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] fields = line.Split(',');

            if (fields.Length == 8) // Ensure there are enough fields
            {
                string imageString = fields[7];
                foreach (string file in Directory.GetFiles($"Assets/Resources/Stars/", "*.png"))
                {
                    if (file == "Assets/Resources/Stars/" + imageString + ".png")
                    {
                        imageString = "Stars/" + imageString;
                    }
                }


                if (fields.Length == 8) // Ensure there are enough fields
                {
                    StarSysSO StarSysSO = CreateInstance<StarSysSO>();
                    ////StarSysInt	,	StarSysSO Enum	,	StarSysSO Short Name	,	StarSysSO Long Name	,	Home System	,	Triat One	,	Trait Two	,	StarSysSO Image	,	Insginia	,	Population	,	Credits	,	Tech Points
                    StarSysSO.StarSysInt = int.Parse(fields[0]);
                    StarSysSO.Position = new Vector3(int.Parse(fields[1]), int.Parse(fields[2]), int.Parse(fields[3]));
                    StarSysSO.SysName = fields[4];
                    StarSysSO.FirstOwner = GetMyCivEnum(fields[5]);
                    StarSysSO.StarType = GetMyStarTypeEnum(fields[7]);
                    StarSysSO.StarSprit = Resources.Load<Sprite>(imageString);
                    StarSysSO.Population = int.Parse(fields[6]);

                    string assetPath = $"Assets/SO/StarSysSO/StarSysSO_{StarSysSO.StarSysInt}_{StarSysSO.SysName}.asset";
                    AssetDatabase.CreateAsset(StarSysSO, assetPath);
                    AssetDatabase.SaveAssets();
                }
            }
            Debug.Log("CivSOImporter Import Complete");
        }
    }
    public static CivEnum GetMyCivEnum(string title)
    {
        CivEnum st;
        Enum.TryParse(title, out st);
        return st;
    }
    public static StarType GetMyStarTypeEnum(string title)
    {
        StarType st;
        Enum.TryParse(title, out st);
        return st;
    }
}
