using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;
using BOTF3D_Combat;
using BOTF3D_Core;
using UnityEngine.UIElements;

namespace BOTF3D_GalaxyMap
{
    public class MoveGalacticObjects : MonoBehaviour
    {
        [SerializeField]
        private GameObject target;
        [SerializeField]
        public float warpSpeed = 1f;

        Transform myTrans;
        Vector3 myTargetPosition;

        private void Awake()
        {
            myTrans = transform;
        }
        //private void Update()
        //{
        //    ThrustVector();
        //}
        public void SetObjectTrans(GameObject myObject)
        {
            myTrans = myObject.transform;
        }
        public void ProvideTarget(GameObject myTarget)
        {
            target = myTarget; //.GetComponent<GameObject>();
            myTargetPosition = myTrans.position;
        }
        public void ProvideTargetPosition(Vector3 position)
        {
            myTargetPosition = position;
            var myTempOb = new GameObject();
            myTempOb.transform.position = position;
            target = myTempOb;
        }
        public void MyWarpSpeed(float warpFactor)
        {
            warpSpeed = warpFactor;
        }
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
                myTrans.position = Vector3.MoveTowards(myTrans.position, target.transform.position, warpSpeed/10);
            }
            else if(myTargetPosition != null && myTrans != null)
            {
                myTrans.position = Vector3.MoveTowards(myTrans.position, myTargetPosition, warpSpeed/10);
            }
        }
    }
}
