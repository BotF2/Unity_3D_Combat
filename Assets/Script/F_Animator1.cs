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

        void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame  
        void Update()
        {
            if (GameManager.Instance._statePassedCombatInit)
            {
                anim.SetBool("FriendWarp1", true);
                PlayWarp();
            }
            // lets warp animation run
            //if (GameManager.Instance._statePassedCombatPlay)
            //    anim.SetBool("FriendStop1", true);
        }

        public void PlayWarp() // called in animation - warps by event to function PlayWarp()
        {
            if (GameManager.Instance._statePassedCombatInit)
            {
                warpAudioSource_0.volume = 1f;
                warpAudioSource_0.Play();
            }
        }
    }
}
