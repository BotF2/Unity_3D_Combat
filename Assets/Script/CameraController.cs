
using UnityEngine;
using System;
using System.Collections;

namespace Assets.Script
{
    // This is a very simple camera controller. It follows a target-object,
    // rotates around it and is able to zoom in and out
    //
    // Attach the script to your main camera
    public class CameraController : MonoBehaviour
    {
        //    [Tooltip("The target is the object the camera rotates around")]
        //    public Transform target;
        //    [Tooltip("Sensitivity of the camera rotation. Higher values mean a faster rotation")]
        //    public float rotationSpeed = 10;
        //    [Tooltip("Boundaries for X-rotation of the camera")]
        //    public Interval tiltBoundaries;
        //    [Tooltip("Maximum and minimum zoom level")]
        //    public Interval zoomLevelBoundaries;
        //    [Tooltip("Sensitivity of the camera zoom")]
        //    public float zoomSpeed;
        //    // The direction from the camera position to the target
        //    private Vector3 lookDirection;
        //    // Input variables for rotation and zoom
        //    private float cameraXInput, cameraYInput, zoomInput;
        //    // Current vertical rotation of the camera
        //    private float tilt;
        //    // Linear zoom level. Will be transformed into an exponential value
        //    private float zoomLevel = 0.0f;
        //    // Transformed zoom level
        //    private float zoomValue = 1.0f;
        //    // Hides the transformation of the zoom level into the zoom value
        //    // When the zoom level is set, the zoom value is automatically calculated
        //    public float ZoomLevel
        //    {
        //        get { return zoomLevel; }
        //        set
        //        {
        //            // Recalculate only if zoom level changed
        //            if (zoomLevel != value)
        //            {
        //                zoomLevel = value;
        //                // Consider zoom level boundaries and calculate zoom value
        //                zoomLevel = Mathf.Clamp(zoomLevel, zoomLevelBoundaries.Min, zoomLevelBoundaries.Max);
        //                zoomValue = Mathf.Pow(1.1f, -zoomLevel);
        //            }
        //        }
        //    }
        //    private void Start()
        //    {
        //        // In the beginning calculate the look direction to prevent
        //        // the Vector3 to be zero
        //        lookDirection = target.position - transform.position;
        //    }
        //    private void Update()
        //    {
        //        // Ask and store user input at each frame
        //        cameraXInput = Input.GetAxisRaw("Mouse X") * rotationSpeed;
        //        cameraYInput = Input.GetAxisRaw("Mouse Y") * rotationSpeed;
        //        zoomInput = Input.GetAxisRaw("Mouse ScrollWheel") * zoomSpeed;
        //    }
        //    private void FixedUpdate()
        //    {
        //        // Set position and rotation of the camera
        //        // Quaternion.LookRotation transforms a direction Vector3 into a rotation
        //        transform.position = CalcCameraPos();
        //        transform.rotation = Quaternion.LookRotation(target.position - transform.position);
        //    }
        //    // Calculates the new camera position. Considers mouse- and zoom-input
        //    private Vector3 CalcCameraPos()
        //    {
        //        // New look direction is based on the input camera rotation
        //        lookDirection = Quaternion.Euler(0.0f, cameraXInput, 0.0f) * lookDirection;
        //        // Normalize look direction
        //        lookDirection.Normalize();
        //        // Update camera tilt and check tilt-boundaries
        //        tilt -= cameraYInput;
        //        tilt = Mathf.Clamp(tilt, tiltBoundaries.Min, tiltBoundaries.Max);
        //        // Recalculate zoom value
        //        ZoomLevel += zoomInput;
        //        // Calculate the new camera position. Steps:
        //        //  - Place it at the target's position
        //        //  - Rotate it towards the target and consider camera tilting
        //        //  - then move the camera backwards by the zoom value
        //        return target.position - Quaternion.LookRotation(new Vector3(lookDirection.x, 0.0f, lookDirection.z))
        //            * Quaternion.Euler(tilt, 0.0f, 0.0f) * Vector3.forward * 4.0f * zoomValue;
    //}
    }
}

