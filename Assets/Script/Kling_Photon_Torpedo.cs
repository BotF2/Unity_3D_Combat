using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kling_Photon_Torpedo : MonoBehaviour
{
    public GameObject photonPrefab; // set to prefab in unity on parent of ship
    private AudioSource theSource;
    public AudioClip clip;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject _temp = Instantiate(photonPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            _temp.layer = 23;
            _temp.tag = "Kling";
            _temp.AddComponent<AudioSource>().playOnAwake = false;
            _temp.AddComponent<AudioSource>().clip = clip;
            _temp.GetComponent<CapsuleCollider>().radius = 50f;
            theSource = _temp.GetComponent<AudioSource>();
            theSource.PlayOneShot(clip);
        }
    }
}
