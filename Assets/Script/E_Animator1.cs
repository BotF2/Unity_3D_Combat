using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Script
{
   
    public class E_Animator1 : MonoBehaviour
    {
        public Animator anim;
        public AudioSource warpAudioSource_0;

        void Start()
        {
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            if (GameManager.Instance._statePassedCombatInit)
            {
                anim.SetBool("EnemyWarp1", true);
                PlayWarp();
            }
            // lets warp animation run
            //if (GameManager.Instance._statePassedCombatPlay)
            //    anim.SetBool("EnemyStop1", true);
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
