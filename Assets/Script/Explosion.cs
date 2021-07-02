using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private bool weAreTaggedKling = false;
    private bool weAreTaggedFed = false;
    public GameObject explotionPrefab;
    private GameObject whoWeAre;
    Rigidbody m_Rigidbody;
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
                        
                        Destroy(explo, 3f);
                    }
                break;
                }
            case "Fed":
                {
                    if (whoWeAre.tag != "Fed")
                    {
                        GameObject explo = Instantiate(explotionPrefab, transform.position, Quaternion.identity) as GameObject;
                        
                        Destroy(explo, 3f);
                    }
                    break;
                }
            default:
                break;
        }
    }
}
