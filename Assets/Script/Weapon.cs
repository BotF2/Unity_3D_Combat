using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject photonPrefab; // set to prefab in unity on parent of ship
    private AudioSource theSource;
    public AudioClip clip;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject _temp = Instantiate(photonPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            _temp.layer = gameObject.layer + 10;
            _temp.AddComponent<AudioSource>().playOnAwake = false;
            _temp.AddComponent<AudioSource>().clip = clip;
            theSource = _temp.GetComponent<AudioSource>();
            theSource.PlayOneShot(clip);

        }
    }
}
