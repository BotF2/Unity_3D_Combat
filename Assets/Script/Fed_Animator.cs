using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Script
{
    public class Fed_Animator : MonoBehaviour
    {
        // must name class and file the same
        public Animator anim;
        public bool _doingInit_0;
        public AudioClip _warpClip;
        public AudioSource warpAudioSource_0;

        private void Awake()
        {

        }
        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
            anim.SetBool("_doingInit_0", false);
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.StatePassedInit) // lets warp animation run
            {
                anim.SetBool("_doingInit_0", true);
                
            }
        }
        public void PlayWarp() // called in animation - warp
        {
            //_object.AddComponent<AudioSource>().playOnAwake = false;
            //_object.AddComponent<AudioSource>().clip = _warpClip;
            //_object.AddComponent<AudioSource>().PlayOneShot(_warpClip);

            //warpAudioSource_0.volume = 0.1f;
            warpAudioSource_0.Play();
        }
    }
}
