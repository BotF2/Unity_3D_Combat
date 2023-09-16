using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class ScaleMeshText : MonoBehaviour
{
    float distance = 700.0f;
    float defaultSize = 40f;
    Vector3 startScale;
    public Camera camGalactica;
    public TextMeshProUGUI textMesh;


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
        textMesh.fontSize = Mathf.RoundToInt(defaultSize* Mathf.Sqrt(dist/distance));
    }
}
