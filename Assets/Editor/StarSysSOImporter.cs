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

    private string filePath = $"Assets/StarSys.csv";

    void OnGUI()
    {
        GUILayout.Label("StarSysSO CSV Importer", EditorStyles.boldLabel);
        filePath = EditorGUILayout.TextField("CSV File Path", filePath);

        if (GUILayout.Button("Import StarSys CSV"))
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
                //StarSysSO StarSys = CreateInstance<StarSysSO>();
                ////StarSysInt	,	StarSys Enum	,	StarSys Short Name	,	StarSys Long Name	,	Home System	,	Triat One	,	Trait Two	,	StarSys Image	,	Insginia	,	Population	,	Credits	,	Tech Points
                //StarSys.StarSysInt = int.Parse(fields[0]);
                //StarSys.StarSysEnum = fields[1];
                //StarSys.StarSysShortName= fields[2];
                //StarSys.StarSysLongName = fields[3];
                //StarSys.StarSysHomeSystem = fields[4];
                //StarSys.TraitOne = fields[5];
                //StarSys.TraitTwo = fields[6];
                //StarSys.StarSysImage = fields[7];
                //StarSys.Insignia = fields[8];
                //StarSys.Population = int.Parse(fields[9]);
                //StarSys.Credits = int.Parse(fields[10]);
                //StarSys.TechPoints = int.Parse(fields[11]);


                //string assetPath = $"Assets/SO/StarSysilizationSO/StarSysSO_{StarSys.StarSysInt}_{StarSys.StarSysShortName}.asset";
                //AssetDatabase.CreateAsset(StarSys, assetPath);
                //AssetDatabase.SaveAssets();
            }
        }

        Debug.Log("StarSysSOImporter Import Complete");
    }
}
