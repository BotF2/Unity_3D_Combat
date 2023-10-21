using BOTF3D_GalaxyMap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GalaxyObjectClick : MonoBehaviour, IPointerClickHandler
{
    bool ClickUI = true;
    public CameraManagerGalactica cameraManagerGalactica;
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
    public void OnPointerClick(PointerEventData eventData)
    {
        ClickUI = false;
        if (cameraManagerGalactica != null)
            cameraManagerGalactica.ClickUI = false;
    }
}
