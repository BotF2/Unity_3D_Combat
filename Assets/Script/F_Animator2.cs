using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Script
{
   
    public class F_Animator2 : MonoBehaviour
    {
        // must name class and file the same
        public Animator anim;
        public AudioSource warpAudioSource_0;
       // private SetShipLayerByAnimaStat shipLayerSetup;
        int once = 0;
  
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame  
        void Update()
        {
            if (GameManager.Instance._statePassedCombatInit)
            {
                anim.SetBool("FriendWarp2", true);// lets warp animation run
                PlayWarp();
                //if (once == 0 && anim.GetCurrentAnimatorStateInfo(0).IsName("F2_allGoodThings"))
                //{
                //    shipLayerSetup.OnStateEnter(anim, anim.GetCurrentAnimatorStateInfo(anim.GetLayerIndex(anim.name)), anim.GetLayerIndex(anim.name));
                //    once = 1;
                //}
            }
            //if (GameManager.Instance._statePassedCombatPlay)
            //    anim.SetBool("FriendStop2", true);
        }
        public void PlayWarp() // called in animation - warp
        {
            if (GameManager.Instance._statePassedCombatInit)
            {
                warpAudioSource_0.volume = 1f;
                warpAudioSource_0.Play();
            }
        }
    }
}
