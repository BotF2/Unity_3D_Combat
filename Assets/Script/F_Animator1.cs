using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Script
{
   
    public class F_Animator1 : MonoBehaviour
    {
        // must name class and file the same
        public Animator anim;
        // public bool _doingInit_0;
        //public bool FriendWarp1;
        public AudioSource warpAudioSource_0;
        //private Rigidbody rigidbody;
        //bool allStop = false;
        //float stopTimer = 0;

        private void Awake()
        {

        }
        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame  
        void Update()
        {
            if (GameManager.Instance._statePassedCombatInit)
                anim.SetBool("FriendWarp1", true); ;
            // lets warp animation run
            if (GameManager.Instance._statePassedCombatPlay)
                anim.SetBool("FriendStop1", true);
            //if (allStop)
            //{
            //    rigidbody.velocity = Vector3.zero;
            //    rigidbody.angularVelocity = Vector3.zero;
            //    //stopTimer++;
            //    //if (stopTimer > 1000)
            //    //    allStop = false;
            //}
        }
        public void AllStop()
        {
            //allStop = true;
            //Ship ship = GetComponentInChildren<Ship>();
            
            //rigidbody = ship.GetComponent<Rigidbody>();
            ////rigidbody = GetComponentInChildren<Rigidbody>();
            //rigidbody.velocity = Vector3.zero;
            //rigidbody.angularVelocity = Vector3.zero;
        }
        public void PlayWarp() // called in animation - warps by event to function PlayWarp()
        {
            warpAudioSource_0.volume = 1f;
            warpAudioSource_0.Play();
        }
    }
}
