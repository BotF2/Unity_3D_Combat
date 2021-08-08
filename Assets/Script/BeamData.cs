using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamData : MonoBehaviour
{
    public GameManager gameManager;
    private LineRenderer beamLine;
    private Transform target;
    private Dictionary<int, GameObject> theLocalTargetDictionary;
    private float diff = 0;
    private Vector3[] linePositions = new Vector3[2];
    //private AudioSource theSource;
    //public AudioClip clipBeamWeapon;


    void Start()
    {
        if (GameManager.FriendShips.Count > 1)
        {
            //gameObject.AddComponent<AudioSource>().playOnAwake = false;
            //gameObject.AddComponent<AudioSource>().clip = clipBeamWeapon;
            //theSource = gameObject.GetComponent<AudioSource>();
            //theSource.PlayOneShot(clipBeamWeapon);
            beamLine = GetComponent<LineRenderer>();
            //linePositions[0] = this.transform.position;
            string whoTorpedo = gameObject.name.Substring(0, 3);
            string friendShips = GameManager.friendArray[1].Substring(0, 3); // first one can be a dummy so go with [1]
            if (whoTorpedo == friendShips)
                theLocalTargetDictionary = GameManager.EnemyShips;
            else
                theLocalTargetDictionary = GameManager.FriendShips;

            FindTarget(theLocalTargetDictionary);
            if (target == null)
            {
                Destroy(gameObject);
            }
        }
        // beamLine = gameObject.;
        //beamLine.SetPositions(linePositions);
        //Vector3[] myPointsInLine;
        //myPointsInLine = new Vector3[beamLine.positionCount];// array vector3 must be created first with myLine.positionCount before using  myLine.GetPositions

        //beamLine.GetPositions(myPointsInLine);

        //for (int i = 0; i < myPointsInLine.Length; i++)
        //{
        //    Debug.Log(myPointsInLine[i]);
        //}
    }

    void Update()
    {
        if (target != null)
        {
            linePositions[0] = this.transform.position;
            linePositions[1] = target.position;
            beamLine.SetPositions(linePositions);
        }
    }
    public void FindTarget(Dictionary<int, GameObject> theTargets)
    {
        var distance = Mathf.Infinity;
        foreach (var possibleTarget in theTargets.Values)
        {
            if (possibleTarget != null)
            {
                diff = (transform.position - possibleTarget.transform.position).sqrMagnitude;
                if (diff < distance)
                {
                    distance = diff;
                    target = possibleTarget.transform;
                }
            }
        }
    }
}
