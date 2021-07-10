using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class Weapon : MonoBehaviour
{
    public GameObject weaponPrefab; // set to prefab in unity on parent of ship
    public GameObject sheildPrefab;
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
        GameObject sheild = Instantiate(sheildPrefab, transform.position, Quaternion.identity) as GameObject;
        sheild.transform.position += new Vector3(-70, 0, 0);
        sheild.transform.localScale += new Vector3(180, 100, 100);
        //new Vector3(transform.position.x -20, transform.position.y, transform.position.z), transform.rotation);
        Destroy(sheild, 2.0f);
    }
}
                    
