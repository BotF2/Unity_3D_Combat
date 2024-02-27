using UnityEngine;
using UnityEditor;
using System.IO;
using Assets.Core;

public class CivSOImporter : EditorWindow
{
    [MenuItem("Tools/Import CivSO CSV")]
    public static void ShowWindow()
    {
        GetWindow<CivSOImporter>("CivSO CSV Importer");
    }

    private string filePath = "Civilizations.csv";

    void OnGUI()
    {
        GUILayout.Label("CivSO CSV Importer", EditorStyles.boldLabel);
        filePath = EditorGUILayout.TextField("CSV File Path", filePath);

        if (GUILayout.Button("Import CIV CSV"))
        {


            //Output the Game data path to the console
            Debug.Log("dataPath : " + Application.dataPath);
            ImportCIVCSV(filePath);
        }
    }

    private static void ImportCIVCSV(string filePath)
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
                CivSO civ = CreateInstance<CivSO>();
                //CivInt	,	Civ Enum	,	Civ Short Name	,	Civ Long Name	,	Home System	,	Triat One	,	Trait Two	,	Civ Image	,	Insginia	,	Population	,	Credits	,	Tech Points
                civ.CivInt = int.Parse(fields[0]);
                civ.CivEnum = fields[1];
                civ.CivShortName= fields[2];
                civ.CivLongName = fields[3];
                civ.CivHomeSystem = fields[4];
                civ.TraitOne = fields[5];
                civ.TraitTwo = fields[6];
                civ.CivImage = fields[7];
                civ.Insignia = fields[8];
                civ.Population = int.Parse(fields[9]);
                civ.Credits = int.Parse(fields[10]);
                civ.TechPoints = int.Parse(fields[11]);


                string assetPath = $"Assets/SO/CivilizationSO/CivSO_{civ.CivInt}_{civ.CivShortName}.asset";
                AssetDatabase.CreateAsset(civ, assetPath);
                AssetDatabase.SaveAssets();
            }
        }

        Debug.Log("CivSOImporter Import Complete");
    }
}
