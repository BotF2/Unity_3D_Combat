using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera theCam;
    private float rotate =1f;
   // public bool holdStaticBuillboard;
    // Start is called before the first frame update
    void Start()
    {
        //if (!holdStaticBuillboard) // if we need to keep sprite from being turned by camera hit
        //{
        theCam = Camera.main; // only find it once
        //}
        //else
        //{
            //transform.rotation = theCam.transform.rotation;
        //}
    }

    // Update is called once per frame
    void LateUpdate()
    {
        rotate += 150;
        transform.LookAt(theCam.transform);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, rotate);
    }
}
