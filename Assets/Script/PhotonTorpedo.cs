using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonTorpedo : MonoBehaviour
{
    public GameManager gameManager;
    public float speed =1000f;
    public float turnRate = 1f;
    private Rigidbody homingTorpedo;
    //public float fuseDelay = 10f;
    //public GameObject torpedo;
    private Transform target;
    private Dictionary<int, GameObject> theLocalTargetDictionary;
    private float diff = 0;

    //private AudioSource theSource;
    //public AudioClip clipTorpedoFire;

    private void Start()
    {
        if (GameManager.FriendShips.Count > 0)
        {
            string whoTorpedo = gameObject.name.Substring(0, 3);
            string friendShips = GameManager.FriendArray[1].Substring(0, 3); // first one can be a dummy so go with [1]
            if (whoTorpedo == friendShips)
                theLocalTargetDictionary = GameManager.EnemyShips;
            else
                theLocalTargetDictionary = GameManager.FriendShips;
            homingTorpedo = transform.GetComponent<Rigidbody>();
            if (homingTorpedo != null)
            {
                FindTargetNearTorpedo(theLocalTargetDictionary);
            }
            if (target == null)
            {
                Destroy(gameObject);
            }
        }
    }
    private void Awake()
    {
        //if (GameManager.FriendShips.Count >1)
        //{
        //    string whoTorpedo = gameObject.name.Substring(0, 3); 
        //    string friendShips = GameManager.friendArray[1].Substring(0, 3); // first one can be a dummy so go with [1]
        //    if (whoTorpedo == friendShips)
        //        theLocalTargetDictionary = GameManager.EnemyShips;
        //    else
        //        theLocalTargetDictionary = GameManager.FriendShips;
        //    homingTorpedo = transform.GetComponent<Rigidbody>();
        //    if (homingTorpedo != null)
        //    {
        //        FindTargetNearTorpedo(theLocalTargetDictionary);
        //    }
        //    if (target == null)
        //    {
        //        Destroy(gameObject);
        //    }
        //}
    }
    private void FixedUpdate()
    {
        if (target != null && homingTorpedo != null)
        {
            var forward = transform.forward;
            var quaternion = Quaternion.identity;
            //Vector3 localDirection = new Vector3();
            //ToLocal(ref forward, ref quaternion, out localDirection);
            //homingTorpedo.velocity = localDirection * speed;
            //homingTorpedo.velocity = transform.TransformDirection(Vector3.forward)  ; // get the local forward
            
            var targetRotation = Quaternion.LookRotation(target.position - transform.position);
            homingTorpedo.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, turnRate));
            transform.Translate(Vector3.forward * speed * Time.deltaTime * 3);
        }
        if (target == null)
        {
            Destroy(gameObject);
        }

    }
    private void Update()
    {
        //if (homingTorpedo != null)
        //    transform.Translate(Vector3.forward * speed * Time.deltaTime * 3);
    }
    public void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject); // kill weapon gameobject holding speed script
    }
    //public void GetTargetDictionaries()
    //{
    //    foreach(var keyValuePairFriend in GameManager.FriendShips)
    //    {
    //        _friendGameObjectDictionary.Add(keyValuePairFriend.Key, keyValuePairFriend.Value);
    //    }
    //    foreach (var keyValuePairEnemy in GameManager.EnemyShips)
    //    {
    //        _enemyGameObjectDictionary.Add(keyValuePairEnemy.Key, keyValuePairEnemy.Value);
    //    }
    //}
    public void FindTargetNearTorpedo(Dictionary<int, GameObject> theTargets)
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
    //internal static void ToLocal(ref Vector3 worldVector, ref Quaternion worldRotation, out Vector3 localVector)
    //{
    //    localVector = Quaternion.Inverse(worldRotation) * worldVector;
    //}
}
