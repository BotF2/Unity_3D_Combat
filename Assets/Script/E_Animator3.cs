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

        void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame  
        void Update()
        {
            if (GameManager.Instance._statePassedCombatInit)
                anim.SetBool("EnemyWarp3", true); ;
            // lets warp animation run
            if (GameManager.Instance._statePassedCombatPlay)
                anim.SetBool("EnemyStop3", true);
        }

        public void PlayWarp() // called in animation - warp
        {
            warpAudioSource_0.volume = 1f;
            warpAudioSource_0.Play();
        }
    }
}
