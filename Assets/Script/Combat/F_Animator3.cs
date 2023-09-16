using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using BOTF3D_GalaxyMap;
using Assets.Script;
using BOTF3D_Core;

namespace BOTF3D_Combat
{
   
    public class F_Animator3 : MonoBehaviour
    {
        public Animator anim;
        public AudioSource warpAudioSource_0;
       // private SetShipLayerByAnimaStat shipLayerSetup;
        int once = 0;

        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
        }
  
        void Update()
        {
            if (GameManager.Instance._statePassedCombatInit)
            {
                anim.SetBool("FriendWarp3", true);// lets warp animation run
                PlayWarp();
                //if (once == 0 && anim.GetCurrentAnimatorStateInfo(0).IsName("F3_allGoodThings"))
                //{
                //    shipLayerSetup.OnStateEnter(anim, anim.GetCurrentAnimatorStateInfo(anim.GetLayerIndex(anim.name)), anim.GetLayerIndex(anim.name));
                //    once++;
                //}
            }
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
