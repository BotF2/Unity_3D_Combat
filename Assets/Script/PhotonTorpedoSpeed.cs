using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonTorpedoSpeed : MonoBehaviour
{
    public float speed =100f;
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime * 3);
    }
    public void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject); // kill weapon gameobject holding speed script
    }
}
