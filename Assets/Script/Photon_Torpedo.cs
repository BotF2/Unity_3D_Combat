using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photon_Torpedo : MonoBehaviour
{
    public GameObject prefab; // set to prefab in unity on parent of ship
    private AudioSource theSource;
    public AudioClip clip;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject _temp = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            _temp.AddComponent<AudioSource>().playOnAwake = false;
            _temp.AddComponent<AudioSource>().clip = clip;
            theSource = _temp.GetComponent<AudioSource>();
            theSource.volume = 0.5f;
            theSource.PlayOneShot(clip);
            //_temp.AddComponent<AudioSource>().PlayOneShot(clip);

        }

    }
}
