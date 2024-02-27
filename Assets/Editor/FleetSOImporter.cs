using UnityEngine;
using UnityEditor;
using System.IO;

public class FleetSOImporter : EditorWindow
{
    [MenuItem("Tools/Import FleetSO CSV")]
    public static void ShowWindow()
    {
        GetWindow<FleetSOImporter>("FleetSO CSV Importer");
    }

    private string filePath = "Fleet.csv";

    void OnGUI()
    {
        GUILayout.Label("FleetSO CSV Importer", EditorStyles.boldLabel);
        filePath = EditorGUILayout.TextField("CSV File Path", filePath);

        if (GUILayout.Button("Import Fleet CSV"))
        {


            //Output the Game data path to the console
            Debug.Log("dataPath : " + Application.dataPath);
            ImportFleetCSV(filePath);
        }
    }

    private static void ImportFleetCSV(string filePath)
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
                FleetSO fleet = CreateInstance<FleetSO>();
                fleet.fleetInt = int.Parse(fields[0]);
                //fleetInt	,	fleet Enum	,	fleet Short Name	,	fleet Long Name	,	Home System	,	Triat One	,	Trait Two	,	fleet Image	,	Insginia	,	Population	,	Credits	,	Tech Points

                fleet.CivEnum = fields[1];
                fleet.FleetName = fields[2];
                fleet.fleetLongName = fields[3];
                fleet.fleetHomeSystem = fields[4];
                fleet.TraitOne = fields[5];
                fleet.TraitTwo = fields[6];
                fleet.FleetImage = fields[7];
                fleet.Insignia = fields[8];
                fleet.Population = int.Parse(fields[9]);
                fleet.Credits = int.Parse(fields[10]);
                fleet.TechPoints = int.Parse(fields[11]);


                string assetPath = $"Assets/SO/FleetSO/FleetSO_{fleet.fleetInt}_{fleet.fleetName}.asset";
                AssetDatabase.CreateAsset(fleet, assetPath);
                AssetDatabase.SaveAssets();
            }
        }

        Debug.Log("FleetSOImporter Import Complete");
    }
}
