using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    //public class ZoomCamera_copy : MonoBehaviour

    //{
    //    public Camera _shipCamera;
    //    public CameraMultiTarget cameraMultiTarget;
    //    bool _startZoomerUpdate = false;
    //    bool _doneWithWideAngle = false;
    //    float _startTimer = 0;
    //    public bool _lookAtTarget = true;
    //    public bool _rotateAroundTarget = true;
    //    private Vector3 _cameraOffSet;
    //    public float _mouseRotationSpeed = 5.0f;
    //    public bool turningPositiveX = true;
    //    private float _autoTimer = 7f;
    //    public float MoveSmoothTime = 0.19f;
    //    Vector3 newPositionX = new Vector3(150, 115, -800);

    //    void Update()
    //    {
    //        if (_startZoomerUpdate)
    //        {
    //            if (!_doneWithWideAngle && _shipCamera.fieldOfView > 20)
    //                _shipCamera.fieldOfView = _shipCamera.fieldOfView - (Time.time - _startTimer) / 5;
    //            if (!_doneWithWideAngle && _shipCamera.fieldOfView <= 20)
    //                _doneWithWideAngle = true;

    //            if (_doneWithWideAngle && _rotateAroundTarget)
    //            {
    //                if (Input.mouseScrollDelta == Vector2.zero)
    //                    return;
    //                else//GameManager.Instance._statePassedCombatInit)
    //                {

    //                    if (Input.mouseScrollDelta.y > 0 && _shipCamera.fieldOfView > 10) //GetAxis("Mouse ScrollWheel") 
    //                    {
    //                        _shipCamera.fieldOfView--;
    //                    }
    //                    if (Input.mouseScrollDelta.y < 0 && _shipCamera.fieldOfView < 30) //.GetAxis("Mouse ScrollWheel") < 0 
    //                    {
    //                        _shipCamera.fieldOfView++;
    //                    }
    //                }
    //            }
    //        }

    //        //if (Input.GetKey("space")) //  && GameManager.Instance._statePassedCombatInit) // use GetKey for holding key down, GetKeyDown() is for one frame of pressed
    //        //{
    //        //    _cameraOffSet = CameraMultiTarget._cameraOffSet;
    //        //    if (CameraMultiTarget._cameraTarget != null)
    //        //        newPositionX = CameraMultiTarget._cameraTarget.transform.position + _cameraOffSet;
    //        //    Quaternion cameraTurnAngleX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * _mouseRotationSpeed, Vector3.up);
    //        //    _cameraOffSet = cameraTurnAngleX * _cameraOffSet;

    //        //    gameObject.transform.position = Vector3.Slerp(gameObject.transform.position, newPositionX, MoveSmoothTime);
    //        //    Quaternion cameraTurnAngleY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * _mouseRotationSpeed, Vector3.right);
    //        //    _cameraOffSet = cameraTurnAngleY * _cameraOffSet;
    //        //    Vector3 newPositionY = CameraMultiTarget._cameraTarget.transform.position + _cameraOffSet;
    //        //    gameObject.transform.position = Vector3.Slerp(gameObject.transform.position, newPositionY, MoveSmoothTime);
    //        //}
    //        //else
    //        //{
    //        //    float xRotation = 0.01f;
    //        //    float yRotation = 0.005f;

    //        //    if (turningPositiveX)
    //        //    {
    //        //        if (_autoTimer <= 0)
    //        //        {
    //        //            turningPositiveX = false;
    //        //            _autoTimer = 14;

    //        //        }
    //        //        AutoRotation(xRotation, Vector3.up);
    //        //        AutoRotation(yRotation, Vector3.right);
    //        //    }
    //        //    else if (!turningPositiveX)
    //        //    {
    //        //        if (_autoTimer <= 0)
    //        //        {
    //        //            turningPositiveX = true;
    //        //            _autoTimer = 14;
    //        //        }
    //        //        AutoRotation(-xRotation, Vector3.up);
    //        //        AutoRotation(-yRotation, Vector3.right);
    //        //    }
    //        //    _autoTimer -= Time.deltaTime;

    //        //}

    //        if (_lookAtTarget || _rotateAroundTarget)
    //        {
    //            if (CameraMultiTarget._cameraTarget != null)
    //            gameObject.transform.LookAt(CameraMultiTarget._cameraTarget.transform);
    //        }
    //    }
    //    public void ZoomIn()
    //    {
    //        _doneWithWideAngle = false;
    //        _startZoomerUpdate = true;
    //        _shipCamera.fieldOfView = 80;
    //        _startTimer = Time.time;
    //    }
    //    public void TurnOfZoomerUpdate()
    //    {
    //        _startZoomerUpdate = false;
    //        _doneWithWideAngle = false;
    //    }
    //    private void AutoRotation(float xRotating, Vector3 direction)
    //    {
    //        Quaternion cameraTurnAngleX = Quaternion.AngleAxis(xRotating * _mouseRotationSpeed, direction);
    //        _cameraOffSet = cameraTurnAngleX * _cameraOffSet;
    //        Vector3 newPositionX = CameraMultiTarget._cameraTarget.transform.position + _cameraOffSet;
    //        gameObject.transform.position = Vector3.Slerp(gameObject.transform.position, newPositionX, MoveSmoothTime);
    //    }
    //    //if (GameManager.Instance._statePassedCombatInit)
    //    //{
    //    //    if (Input.GetKeyDown("o"))  ///GetAxis("Mouse ScrollWheel") > 0 && camera.fieldOfView > 12)
    //    //    {
    //    //        camera.fieldOfView--;
    //    //    }
    //    //    if (Input.GetKeyDown("p"))//GetAxis("Mouse ScrollWheel") < 0 && camera.fieldOfView < 40)
    //    //    {
    //    //        camera.fieldOfView++;
    //    //    }
    //    //}
    //    //if (GameManager.Instance._statePassedCombatInit)
    //    //{
    //    //    if (Input.GetAxis("Mouse ScrollWheel") > 0 && GetComponent<Camera>().fieldOfView > 12)
    //    //    {
    //    //        GetComponent<Camera>().fieldOfView--;
    //    //    }
    //    //    if (Input.GetAxis("Mouse ScrollWheel") < 0 && GetComponent<Camera>().fieldOfView < 40)
    //    //    {
    //    //        GetComponent<Camera>().fieldOfView++;
    //    //    }
    //    //}   


    //}
}
