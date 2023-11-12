using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class ScaleMeshText : MonoBehaviour
{
    float distance = 700.0f;
    float defaultSize = 30f;
    Vector3 startScale;
    public Camera camGalactica;
    public TextMeshProUGUI textMesh;
    //private int counter = 0;


    void Start()
    {
        startScale = transform.localScale;
        foreach (Camera cam in Camera.allCameras)
            if (cam.name == "CameraGalactica")
            {
                camGalactica= cam;
            }
        textMesh = gameObject.GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        Scale();
    }
    void Scale()
    {
        float dist = Vector3.Distance(camGalactica.transform.position, transform.position);
        if (dist > 0)
        { 
            textMesh.fontSize = Mathf.RoundToInt(defaultSize* Mathf.Sqrt(dist/distance));
            //if (counter == 0)
            //{
            //    var wereItIS = textMesh.transform.position;
            //    float theX = textMesh.fontSize;//Mathf.RoundToInt(defaultSize * Mathf.Sqrt(dist / distance));
            //    var nudgeVector = new Vector3(theX/2, 0, 0);
            //    textMesh.gameObject.transform.Translate(nudgeVector, Space.World);
            //    counter++;
            //}
        }
    }
}
