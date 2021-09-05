using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Script
{
    public class MoveCombat : MonoBehaviour
    { 
        // rotate around the empty gameobject 'MoveCombat'
        //public GameManager gameManager;
        //private float speed;
        //public float maxRotation;
        
        private void Start()
        {
           // speed = gameManager.viewCombatSpeed;
        }

        void Update()
        {
            //// ToDo make this a user control of view, rotate and add y transform up down
            //if (gameManager.StatePassedInit == true)
            //{
            //    //CalculateMovement();
            //    transform.Rotate(0, speed * Time.deltaTime, 0);
            //}
        }

        void CalculateMovement()
        {
            //float horizontalInput = Input.GetAxis("Horizontal");
            //float verticalInput = Input.GetAxis("Vertical");
            //Vector3 direction = new Vector3(horizontalInput, verticalInput);
            //transform.Translate(direction * speed * Time.deltaTime);
        }
        public void LocateCenterOfCombat() // Not working so well, trying to set center based on size of gride.
        {
            //float counter;
            //if (gameManager.friends > gameManager.enemies) // what side of the ride is longer down z?
            //    counter = gameManager.friends;
            //else
            //    counter = gameManager.enemies;
            //counter -= 0.01f; // if it is < 1 then casting to int makes it zero....
            //float zLocation = ((int)(counter / 3)) * (gameManager.zFactor / 2);
            //transform.position = new Vector3(gameManager.xFactorEnemmy + gameManager.xFactorFriend, (gameManager.yFactor * 2), zLocation);
        }
    }
}
