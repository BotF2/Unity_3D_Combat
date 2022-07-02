using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class PhotonTorpedo : MonoBehaviour
    {
        //public GameManager gameManager;
        public float speed = 1000f;
        public float turnRate = 1f;
        private Rigidbody homingTorpedo;
        //public float fuseDelay = 10f;
        //public GameObject torpedo;
        private Transform target;
        private Dictionary<int, GameObject> theLocalTargetDictionary;
        private float diff = 0;


        private void Start()
        {
            if (GameManager.FriendShips.Count > 0)
            {
                string whoTorpedo = gameObject.name.Substring(0, 3);
                string friendShips = GameManager.FriendNameArray[1].Substring(0, 3); // first one may be a dummy so go with [1], think this does not happen now
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

        }
        private void FixedUpdate()
        {
            if (target != null && homingTorpedo != null)
            {
                //var forward = transform.forward;
                //var quaternion = Quaternion.identity;

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
            if (this.gameObject.tag != collision.gameObject.name) // do not blow up the torpedo if it hits the ship collider on launching
                Destroy(this.gameObject); // kill weapon gameobject holding speed script
        }
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
    }
}

