using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using BOTF3D_GalaxyMap;
using Assets.Script;
using BOTF3D_Combat;

namespace BOTF3D_Core
{
   
    public class F_Animator1 : MonoBehaviour
    {
        // must name class and file the same
        public Animator anim;
        public AudioSource warpAudioSource_0;
        //private SetShipLayerByAnimaStat shipLayerSetup;
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
                anim.SetBool("FriendWarp1", true);
                PlayWarp();

            }
            // lets warp animation run

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
