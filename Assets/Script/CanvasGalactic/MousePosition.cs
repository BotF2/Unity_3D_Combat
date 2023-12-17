using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    public Camera galaxyCamera;
    //private Vector3 normal;
    Plane plane; // = new Plane();
    public GameObject galaxyImageOb; // get the galaxy grid image/object to make our plane for raycast.
                                        // public LayerMask layerToHit;
    private void Start()
    {
    //    GameObject galaxyImageTemp = new GameObject("freddy");
    //    galaxyImageTemp.transform.position = galaxyImageOb.transform.position;
    //    galaxyImageTemp.transform.rotation = Quaternion.Euler(galaxyImageOb.transform.position.x + 45f, galaxyImageOb.transform.position.y, galaxyImageOb.transform.position.z);
        //var position = galaxyImageOb.transform.position;
        //Vector3 turnPosition = new Vector3(position.x, position.z, position.y);
        plane = new Plane(galaxyImageOb.transform.position, galaxyImageOb.transform.position); // new Vector3(galaxyImageOb.transform.position.x, galaxyImageOb.transform.position.y, 620f));  
        
        //var renderer = galaxyImageOb.GetComponent<MeshRenderer>();
        //renderer.GetComponent<MeshFilter>();
        //var filter = renderer.GetComponent<MeshFilter>();
        //if (filter  && filter.mesh.normals.Length > 0)
        //{
        //    normal = filter.transform.TransformDirection(filter.mesh.normals[0]);
        //}
        //plane = new Plane(normal, transform.position);

    }
    void Update()
    {
        screenPosition = Input.mousePosition;
        Ray ray = galaxyCamera.ScreenPointToRay(screenPosition);
        if (plane.Raycast(ray,out float distance))
        {
            var tempWorldPosition = ray.GetPoint(distance);
            Vector3 roatedVector = Vector3.Cross(tempWorldPosition, Vector3.zero);

            worldPosition = roatedVector;
        }
        //if (Physics.Raycast(ray, out RaycastHit hitData, 100, 1<<8)) // only layer 9 for TargetPointer object hit
        //{
        //    worldPosition = hitData.point;
        //}
        transform.position = worldPosition;
    }
    //Vector3 RotateToPlane(Vector3 start,float angle)
    //{
    //    start.Normalize();
    //    Vector3 axis = Vector3.Cross(start, Vector3.up);
    //    if (axis == Vector3.zero)
    //        axis = Vector3.right
    //    return new Vector3();
    //}
}
