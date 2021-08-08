using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TargetingSystem : MonoBehaviour
{
    //public Transform target;
    //public Transform[] targets;
    //private Rigidbody rigidB;
    //public float speed = 10f;
    //public float rotateSpeed = 200f;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    target = targets[0];
    //    rigidB = GetComponent<Rigidbody>();

    //}

    //// Update is called once per frame
    //void FixedUpdate()
    //{
    //    Vector3 direction = target.position - rigidB.position;
    //    direction.Normalize();
    //    float rotateAnmountX = Vector3.Cross(direction, transform.forward).x;
    //    float rotateAmountY = Vector3.Cross(direction, transform.forward).y;
    //    float rotateAnmountZ = Vector3.Cross(direction, transform.forward).z;

    //   // rigidB.angularVelocity -rotateAmount * rotateSpeed;

    //    rigidB.velocity = transform.forward * speed;
    //}
}
