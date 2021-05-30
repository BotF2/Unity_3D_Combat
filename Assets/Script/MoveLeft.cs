using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Script
{

    public class MoveLeft : MonoBehaviour
    {
        float _speed = 40f;
        Rigidbody _rigidbody;
 
        public Vector3 _oldVector3;


        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.velocity = Vector3.left * _speed; // start going left but can change later
        }
        private void Update()
        {

        }
        // Update is called once per frame
        void FixedUpdate()
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
            //Store old vector3
       
            
        }

        private void OnCollisionEnter(Collision collision)
        {
         
        }
    }
}
