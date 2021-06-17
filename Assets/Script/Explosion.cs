using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private bool weAreTaggedKling = false;
    private bool weAreTaggedFed = false;
    public GameObject explotionPrefab;
    private GameObject whoWeAre;

    public void Awake()
    {
        whoWeAre = gameObject;
        switch (this.gameObject.tag)
        {
            case "Kling":
                weAreTaggedKling = true;
                break;
            case "Fed":
                weAreTaggedFed = true;
                break;
            default:
                break;
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.gameObject.tag)
        {
            case "Kling":
                {
                    if (whoWeAre.tag != "Kling")
                    {
                        GameObject explo = Instantiate(explotionPrefab, transform.position, Quaternion.identity) as GameObject;
                    }
                break;
                }
            case "Fed":
                {
                    if (whoWeAre.tag != "Fed")
                    {
                        GameObject explo = Instantiate(explotionPrefab, transform.position, Quaternion.identity) as GameObject;
                    }
                    break;
                }
            default:
                break;
        }

        //Destroy(collision.collider.gameObject);
        //Destroy(gameObject);
        // GameObject explo = Instantiate(explotionPrefab, transform.position, Quaternion.identity) as GameObject;
        //Destroy(gameObject); // destroy the torpedo
        // Destroy(explo, 3); // delete the explotion after 3 seconds
        //if (collision.gameObject.tag == "ship")
        //{
        //    Destroy(collision.gameObject); // destroy ship that was hit
        //}
    }
        //public void OnCollisionEnter(Collision collision)
        //{
        //    //GameObject explo = Instantiate(explotionPrefab, transform.position, Quaternion.identity) as GameObject;
        //    //Destroy(gameObject); // destroy the torpedo
        //    //Destroy(explo, 3); // delete the explotion after 3 seconds
        //    //if (collision.gameObject.tag == "ship")
        //    //{
        //    //    Destroy(collision.gameObject); // destroy ship that was hit
        //    //}
        //}

        // Update is called once per frame
        //void FixedUpdate()
        //{
        //    if (torpedo == enabled)
        //    {
        //        Invoke("Detonate", 5);
        //    }
        //}
    }
