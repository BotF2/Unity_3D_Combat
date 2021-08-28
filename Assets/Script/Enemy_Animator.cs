using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Script
{
    public class Enemy_Animator : MonoBehaviour
    {
        // must name class and file the same
        public Animator anim;
        public bool _doingInit_3;
        public AudioSource warpAudioSource;

        private void Awake()
        {

        }
        // Start is called before the first frame update
        void Start()
        {           
            anim = GetComponent<Animator>();
            anim.SetBool("_doingInit_3", false);
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.StatePassedInit) // lets warp animation run
            {
                anim.SetBool("_doingInit_3", true);
            }
        }
        public void PlayWarp()
        {
            warpAudioSource.volume = 0.1f;
            warpAudioSource.Play();
        }
    }
}
