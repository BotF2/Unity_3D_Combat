using UnityEngine;
using UnityEditor;
using System.IO;
using Assets.Core;

public class StarSysSOImporter : EditorWindow
{
    [MenuItem("Tools/Import StarSysSO CSV")]
    public static void ShowWindow()
    {
        GetWindow<StarSysSOImporter>("StarSysSO CSV Importer");
    }

    private string filePath = $"Assets/StarSysSO.csv";

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

            if (fields.Length == 12) // Ensure there are enough fields
            {
                StarSysSO StarSysSO = CreateInstance<StarSysSO>();
                ////StarSysInt	,	StarSysSO Enum	,	StarSysSO Short Name	,	StarSysSO Long Name	,	Home System	,	Triat One	,	Trait Two	,	StarSysSO Image	,	Insginia	,	Population	,	Credits	,	Tech Points
                StarSysSO.StarSysInt = int.Parse(fields[0]);
                StarSysSO.Position = new Vector3(int.Parse(fields[1]), int.Parse(fields[2]), int.Parse(fields[3]));
                //StarSysSO.StarSysEnum = fields[1];
                //StarSysSO.StarSysShortName= fields[2];
                //StarSysSO.StarSysLongName = fields[3];
                //StarSysSO.StarSysHomeSystem = fields[4];
                //StarSysSO.TraitOne = fields[5];
                //StarSysSO.TraitTwo = fields[6];
                //StarSysSO.StarSysImage = fields[7];
                //StarSysSO.Insignia = fields[8];
                //StarSysSO.Population = int.Parse(fields[9]);
                //StarSysSO.Credits = int.Parse(fields[10]);
                //StarSysSO.TechPoints = int.Parse(fields[11]);


                //string assetPath = $"Assets/SO/StarSysilizationSO/StarSysSO_{StarSysSO.StarSysInt}_{StarSysSO.StarSysShortName}.asset";
                //AssetDatabase.CreateAsset(StarSysSO, assetPath);
                //AssetDatabase.SaveAssets();
            }
        }

        Debug.Log("StarSysSOImporter Import Complete");
    }
}
