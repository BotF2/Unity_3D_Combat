using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 thePosition;
    public Camera galaxyCamera;
    public GameObject galaxyImageOb;
    //private float targetPointerZ;
    //private float targetPointerY;
    private Vector3 GetMousePosition()
    {
        //transform.Rotate(90,0,0);
        return galaxyCamera.WorldToScreenPoint(transform.position);
    }
    private void OnMouseDown()
    {
        Vector3 tempPosition = Input.mousePosition - GetMousePosition();
        thePosition = tempPosition;
    }
    private void OnMouseDrag()
    {
        //Vector3 holderPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.z, Input.mousePosition.y);

        var tempPosition = galaxyCamera.ScreenToWorldPoint(Input.mousePosition - thePosition);
        Vector3 rotated = new Vector3(tempPosition.x, tempPosition.z, 0f);
        transform.position = rotated;
        //Vector3 roatedVector = Vector3.Cross(tempWorldPosition, Vector3.zero);
    
    }
}
