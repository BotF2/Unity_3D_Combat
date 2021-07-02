using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fed_Photon_Torpedo : MonoBehaviour
{
    public GameObject photonPrefab; // set to prefab in unity on parent of ship
    private AudioSource theSource;
    public AudioClip clip;
    private float _weaponDamage =0.5f;

    public float WeaponDamage { get { return _weaponDamage; } set{ _weaponDamage = value; } } // get from data base for weapon we got hit with

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject _temp = Instantiate(photonPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            _temp.layer = 20;
            _temp.tag = "Fed";
           // var something = _temp.GetComponent<Fed_Photon_Torpedo>().WeaponDamage;
            _temp.AddComponent<AudioSource>().playOnAwake = false;
            _temp.AddComponent<AudioSource>().clip = clip;
            _temp.GetComponent<CapsuleCollider>().radius = 50f;
            theSource = _temp.GetComponent<AudioSource>();
            theSource.PlayOneShot(clip);  
            
        }
    }
}
