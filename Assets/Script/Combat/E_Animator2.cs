using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using BOTF3D_GalaxyMap;
using Assets.Script;
using BOTF3D_Core;

namespace BOTF3D_Combat
{
   
    public class E_Animator2 : MonoBehaviour
    {
        public Animator anim;
        public AudioSource warpAudioSource_0;
        //private SetShipLayerByAnimaStat shipLayerSetup;
        int once = 0;

        void Start()
        {
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            if (GameManager.Instance._statePassedCombatInit)
            {
                anim.SetBool("EnemyWarp2", true); // code state turns on warp animation
                PlayWarp();
                // how to get animation done to inform code of state????
                //if (once == 0 && anim.GetCurrentAnimatorStateInfo(anim.GetLayerIndex(anim.name)).IsName("E2_allGoodThings"))
                //{
                //    shipLayerSetup.OnStateEnter(anim, anim.GetCurrentAnimatorStateInfo(anim.GetLayerIndex(anim.name)), anim.GetLayerIndex(anim.name));
                //    once = 1;
                //}
            } 
            // lets warp animation run
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
