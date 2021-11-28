using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Script
{
   
    public class E_Animator3 : MonoBehaviour
    {
        // must name class and file the same
        public Animator anim;
        // public bool _doingInit_0;
        public bool EnemyWarp3;
        public AudioSource warpAudioSource_0;
        private Rigidbody rigidbody;
        bool allStop = false;
        //float stopTimer = 0;

        private void Awake()
        {

        }

        void Start()
        {
            anim = GetComponent<Animator>();
            // anim.SetBool("_doingInit_0", false);
            // anim.SetBool("Friend_DoInit", false);
        }

        // Update is called once per frame  
        void Update()
        {
            if (GameManager.Instance._statePassedCombatInit)
                anim.SetBool("EnemyWarp3", true); ;
            // lets warp animation run
            if (GameManager.Instance._statePassedCombatPlay)
                anim.SetBool("EnemyStop3", true);
            //if (allStop && rigidbody != null)
            //{
            //    rigidbody.velocity = Vector3.zero;
            //    rigidbody.angularVelocity = Vector3.zero;
            //    //    //stopTimer++;
            //    //    //if (stopTimer > 1000)
            //    //    //    allStop = false;
            //}
        }

        public void AllStop()
        {
            //allStop = true;
            //GameObject ship = GetComponentInChildren<GameObject>();
            //rigidbody = ship.GetComponent<Rigidbody>();
            ////rigidbody = GetComponentInChildren<Rigidbody>();
            //rigidbody.velocity = Vector3.zero;
            //rigidbody.angularVelocity = Vector3.zero;
            
        }
        public void PlayWarp() // called in animation - warp
        {
            warpAudioSource_0.volume = 1f;
            warpAudioSource_0.Play();
            //warpAudioSource_0.volume = 0.1f;
            //warpAudioSource_0.Play();
            //this.gameObject.AddComponent<AudioSource>().playOnAwake = false;
            //this.gameObject.AddComponent<AudioSource>().clip = _warpClip;
            ////theSource = explo.GetComponent<AudioSource>();
            //warpAudioSource_0.PlayOneShot(_warpClip);
        }
    }
}
