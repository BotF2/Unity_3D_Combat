using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Script
{
   
    public class E_Animator1 : MonoBehaviour
    {
        // must name class and file the same
        public Animator anim;
        // public bool _doingInit_0;
        //public bool EnemyWarp1;
        public AudioSource warpAudioSource_0;
        //private Rigidbody rigidbody;
        //public bool EnemyStop1 = false;
       // float stopTimer = 0;

        void Start()
        {
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            if (GameManager.Instance._statePassedCombatInit)
                anim.SetBool("EnemyWarp1", true);
            // lets warp animation run
            if (GameManager.Instance._statePassedCombatPlay)
                anim.SetBool("EnemyStop1", true);
        }

        public void PlayWarp() // called in animation - warp
    {
        warpAudioSource_0.volume = 1f;
        warpAudioSource_0.Play();
        }
    }
}
