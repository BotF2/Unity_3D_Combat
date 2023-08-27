using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;
using BOTF3D_Combat;
using BOTF3D_Core;
using UnityEngine.UIElements;
using Unity.VisualScripting;

namespace BOTF3D_GalaxyMap
{
    public class MoveGalacticObjects : MonoBehaviour
    {
        //public GalaxyView galaxyView;
        [SerializeField]
        private GameObject target;
        [SerializeField]
        public float warpSpeed = 5f;
        private float realSpeedFactor = 0.05f;

        Transform myTrans;
        Transform lastTrans;
        Vector3 myTargetPosition;
        Transform _galaxyPlanePoint;
        public GameObject endpointPrefab;
        private GalaxyDropLine galaxyDropLine;

        private void Awake()
        {

        }
        private void Update()
        {
            if (myTrans != null && lastTrans != null)
            {
                if (myTrans.transform != lastTrans.transform)
                {
                    var fleet = this.GetComponentInParent<Fleet>();
                    if (fleet._galaxyPlanePoint != null)
                    {
                        Vector3 planePint = new Vector3(myTrans.position.x, myTrans.position.y, 600f);
                        GameObject emptyForFleetPlanePoint = Instantiate(endpointPrefab, planePint, Quaternion.identity);
                        Transform[] endFleetPoints = new Transform[2] { myTrans, emptyForFleetPlanePoint.transform };
                        galaxyDropLine.SetUpLine(endFleetPoints);
                    }
                }
            }

        }
        public void BoldlyGo(GameObject myGameObject, GameObject myTarget, float myWarpSpeed, GalaxyDropLine fleetLine)
        {
            if (myWarpSpeed == 0 && GalaxyView._movingGalaxyObjects.Contains(myGameObject))
            {
                GalaxyView._movingGalaxyObjects.Remove(myGameObject);
                return;
            }
            else if (!GalaxyView._movingGalaxyObjects.Contains(myGameObject))
            {
                GalaxyView._movingGalaxyObjects.Add(myGameObject);
            }
            galaxyDropLine = fleetLine;
            myTrans = myGameObject.transform;
            lastTrans = myTrans;
            myTargetPosition = myTarget.transform.position;
            warpSpeed = myWarpSpeed;
            
        }
        //private void SetObjectTrans(GameObject myObject)
        //{
            
        //}
        //private void ProvideTarget(GameObject myTarget)
        //{
        //    target = myTarget; //.GetComponent<GameObject>();
        //    myTargetPosition = myTrans.position;
        //}
        ////public void ProvidGalaxyPlaneTrans(Transform trans)
        ////{
        ////    _galaxyPlanePoint = trans;
        ////}
        //private void ProvideTargetPosition(Vector3 position)
        //{
        //    myTargetPosition = position;
        //    var myTempOb = new GameObject();
        //    myTempOb.transform.position = position;
        //    target = myTempOb;
        //}
        //private void MyWarpSpeed(float warpFactor)
        //{
        //    warpSpeed = warpFactor;
        //}
        //private void OnEnable()
        //{
        //    TimeManager.OnMinuteChanged += TimeCheck;
        //}
        //private void OnDisable()
        //{
        //    TimeManager.OnMinuteChanged -= TimeCheck;
        //}
        //private void TimeCheck()
        //{
        //    ThrustVector(); // myT.position += myT.forward * warpSpeed; // * Time.deltaTime;
        //}

        public void ThrustVector()
        {
            //myTrans.position += myTrans.forward * warpSpeed; // * Time.deltaTime;
            if (target != null && myTrans != null)
            { 
                myTrans.position = Vector3.MoveTowards(myTrans.position, target.transform.position, warpSpeed*realSpeedFactor);
                
            }
            else if(myTargetPosition != null && myTrans != null)
            {
                myTrans.position = Vector3.MoveTowards(myTrans.position, myTargetPosition, warpSpeed*realSpeedFactor);
            }
        }
    }
}
