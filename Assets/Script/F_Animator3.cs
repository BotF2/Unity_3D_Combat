using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Script
{
   
    public class F_Animator3 : MonoBehaviour
    {
        public Animator anim;
        public AudioSource warpAudioSource_0;
        //public bool endOfFriendWarp = false;

        private void Awake()
        {

        }
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
               // EndOfFiendWarp();
            }
            //if (GameManager.Instance._statePassedCombatPlay)
            //    anim.SetBool("FriendStop3", true);
        }

        public void PlayWarp() // called in animation - warp
        {
            if (GameManager.Instance._statePassedCombatInit)
            {
                warpAudioSource_0.volume = 1f;
                warpAudioSource_0.Play();
            }
        }
        public void EndOfFiendWarp()
        {
            //endOfFriendWarp = true;
           // GameManager.Instance.TurnOnRightSide();
        }
    }
}
