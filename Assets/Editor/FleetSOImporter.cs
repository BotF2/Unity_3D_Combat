using UnityEngine;
using UnityEditor;
using System.IO;

public class FleetSOImporter : EditorWindow
{
    //[MenuItem("Tools/Import SO CSV")]
    //public static void ShowWindow()
    //{
    //    GetWindow<FleetSOImporter>("SO CSV Importer");
    //}

    //private string filePath = $"Assets/SO.csv";

    //void OnGUI()
    //{
    //    GUILayout.Label("SO CSV Importer", EditorStyles.boldLabel);
    //    filePath = EditorGUILayout.TextField("CSV File Path", filePath);

    //    if (GUILayout.Button("Import Fleet CSV"))
    //    {


    //        //Output the Game data path to the console
    //        Debug.Log("dataPath : " + Application.dataPath);
    //        ImportFleetCSV(filePath);
    //    }
    //}

    //private static void ImportFleetCSV(string filePath)
    //{
    //    if (!File.Exists(filePath))
    //    {
    //        Debug.LogError("File not found: " + filePath);
    //        return;
    //    }

    //    string[] lines = File.ReadAllLines(filePath);

    //    foreach (string line in lines)
    //    {
    //        string[] fields = line.Split(',');

    //        if (fields.Length == 3) // Ensure there are enough fields
    //        {
    //            CivSO fleet = CreateInstance<CivSO>();
    //            //insignia, fleetName, civOwnerEnum, defaultWarp
    //            fleet.Insignia = fields[0];  
    //            fleet.CivOwner = fields[1];
    //            fleet.DefaultWarpFactor = float.Parse(fields[2]);

    //            string assetPath = $"Assets/SO/SO/FleetSO_{fleet.CivOwner}.asset";
    //            AssetDatabase.CreateAsset(fleet, assetPath);
    //            AssetDatabase.SaveAssets();
    //        }
    //    }

    //    Debug.Log("FleetSOImporter Import Complete");
    //}
}
