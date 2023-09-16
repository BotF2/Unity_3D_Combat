using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnGUI()
    {
        GUI.Label  (new Rect(5,5,800,200), "Galaxy View");
    }
}
