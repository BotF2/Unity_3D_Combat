using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fed_Photon_Torpedo : MonoBehaviour
{
    public GameObject photonPrefab; // set to prefab in unity on parent of ship
    private AudioSource theSource;
    public AudioClip clip;
    // private bool _waitForIt = true;
    //private bool _newTorpedo = false;
    //private float waitTime = 0.5f;
    //[SerializeField]
    //private GameObject explotionPrefab; // set to prefab explotion, add sound to prefab with PlayOnAwake, autodestuct and one shot

    //private void Start()
    //{
    //    StartCoroutine
    //}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject _temp = Instantiate(photonPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            _temp.layer = 20;
            _temp.tag = "Fed";
            _temp.AddComponent<AudioSource>().playOnAwake = false;
            _temp.AddComponent<AudioSource>().clip = clip;
            _temp.GetComponent<CapsuleCollider>().radius = 50f;
            theSource = _temp.GetComponent<AudioSource>();
            theSource.PlayOneShot(clip);           
        }
    }
    //public void OnCollisionEnter(Collision collision)
    //{
    //    //    var nameOf = collision.rigidbody.gameObject.name;
    //    //    if (!nameOf.Contains("Blue"))
    //    //    {
    //    //        GameObject explo = Instantiate(explotionPrefab, transform.position, Quaternion.identity) as GameObject;
    //    //    }
    //}

    //IEnumerator ExampleCoroutine()
    //{
    //    //yield on a new YieldInstruction that waits for 5 seconds.
    //    yield return new WaitForSeconds(1f);
    //    if (_newTorpedo == true)
    //    {

    //    }
    //}
    //Destroy(gameObject); // destroy the torpedo
    // Destroy(explo, 3); // delete the explotion after 3 seconds
    //if (collision.gameObject.tag == "ship")
    //{
    //    Destroy(collision.gameObject); // destroy ship that was hit
    //}
    //}
}
