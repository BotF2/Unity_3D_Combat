using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class Weapon : MonoBehaviour
{
    public GameObject weaponPrefab; // set to prefab in unity on parent of ship
    public GameObject explosionPrefab;
    private AudioSource theSource;
    public AudioClip clip;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject _temp = Instantiate(weaponPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            _temp.layer = gameObject.layer + 10;
            _temp.AddComponent<AudioSource>().playOnAwake = false;
            _temp.AddComponent<AudioSource>().clip = clip;
            theSource = _temp.GetComponent<AudioSource>();
            theSource.PlayOneShot(clip);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        GameObject explo = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
        Destroy(explo, 3f);
    }
}
                    
