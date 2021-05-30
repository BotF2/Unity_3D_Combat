using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class MoveRight : MonoBehaviour
    {
        float _speed = 40f;
        Rigidbody _rigidbody;
        public Vector3 _startVector;
        float timer = 0;
        bool timerReached = false;


        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.velocity = Vector3.right * _speed; // start going left but can change later
        }
        private void Update()
        {
            if (!timerReached)
                timer += Time.deltaTime;

            if (!timerReached && timer > 1)
            {
                Debug.Log("Done waiting");
                ResumeMove();

                //Set to false so that We don't run this again
                timerReached = true;
            }
        }
        // Update is called once per frame
        void FixedUpdate()
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
        }
        void ResumeMove()
        {
            _rigidbody.velocity = Vector3.right * _speed;
        }
        private void OnCollisionEnter(Collision collision)
        {

        }
    }
}
