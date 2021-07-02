using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photon_Torpedo : MonoBehaviour
{
    //public Photon_Torpedo Instance;
    public GameObject photonPrefab; // set to prefab in unity on parent of ship
    //public Ship firingShip; 
    public AudioSource theSource;
    public AudioClip clip;
    public float _weaponDamage = 10f;
    public Civilization civ;
    //public Ship[] shipsArray;

    public float WeaponDamage { get { return _weaponDamage; } set{ _weaponDamage = value; } } // get from data base for weapon we got hit with


    private void Update()
    {
        //Instance = (Photon_Torpedo)GameObject.FindObjectOfType(typeof(Photon_Torpedo));
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // Debug.Log(_torpedoDamage);
            int theLayer = 0;
            string currentCiv = tag;
            switch (currentCiv)
            {
                case "Fed":
                    {
                        theLayer = 20;
                        break;
                    }
                case "Terran":
                    {
                        theLayer = 21;
                        break;
                    }
                case "Rom":
                    {
                        theLayer = 22;
                        break;
                    }
                case "Kling":
                    {
                        theLayer = 23;
                        break;
                    }
                case "Card":
                    {
                        theLayer = 24;
                        break;
                    }
                case "Dom":
                    {
                        theLayer = 25;
                        break;
                    }
                case "Borg":
                    {
                        theLayer = 26;
                        break;
                    }
                default:
                    {
                        theLayer = 0; 
                    break;
                    }
            }
            
            GameObject _temp = Instantiate(photonPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            //shipsArray = gameObject.GetComponentsInChildren<Ship>();
            // _temp.transform.SetParent(gameObject.transform, true); // parent to the empty game object for the ship. In ship look back for the firing ship when hit
            //firingShip = gameObject.GetComponentInChildren<Ship>();
            _temp.layer = theLayer;
            _temp.tag = currentCiv;
            _temp.AddComponent<AudioSource>().playOnAwake = false;
            _temp.AddComponent<AudioSource>().clip = clip;
            theSource = _temp.GetComponent<AudioSource>();
            theSource.PlayOneShot(clip);
            //Ship.PassShipObject(_temp.gameObject);
            //CapsuleCollider collider = _temp.GetComponent<CapsuleCollider>();
            //collider.enabled = true;
            //_temp.transform.SetParent(gameObject.transform, true);
            //firingShip = gameObject.GetComponent<Ships>();
            //_temp.gameObject.GetComponent<Photon_Torpedo>().WeaponDamage = (float)gameObject.GetComponentInParent<Ships>().TorpedoDamage;
            //WeaponDamage = gameObject.GetComponent<Ships>().TorpedoDamage;
            // var something = _temp.GetComponent<Fed_Photon_Torpedo>().WeaponDamage;


        }
    }
    //public void GetTorpedoDamage(GameObject torpedo, out float theDamage)
    //{
    //    theDamage = torpedo.GetComponent<Photon_Torpedo>().WeaponDamage;
    //}
}
