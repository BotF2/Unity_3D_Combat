using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BOTF3D_GalaxyMap;
using BOTF3D_Core;
using Assets.Script;

namespace BOTF3D_Combat
{
    public class PhotonTorpedo : MonoBehaviour
    {
        public float speed = 10f;
        public float turnRate = 1f;
        private Rigidbody homingTorpedo;

        private Transform target;
        private List<GameObject> theLocalTargetList;
        private float diff = 0;


        private void Start()
        {
           
            if (GameManager.Instance._statePassedMain_Init) // ToDo: how do we know if combat is over? && GameManager.Instance.FriendShips.Count > 0)
            {
                string whoTorpedo = gameObject.name.Substring(0, 3);
                string friendShips = GameManager.FriendNameArray[0].Substring(0, 3); 
                if (whoTorpedo == friendShips)
                    theLocalTargetList = GameManager.EnemyShips;
                else
                    theLocalTargetList = GameManager.FriendShips;
                homingTorpedo = transform.GetComponent<Rigidbody>();
                if (homingTorpedo != null)
                {
                    FindTargetNearTorpedo(theLocalTargetList);
                }
                if (target == null)
                {
                    Destroy(gameObject, 0.3f);
                }
            }
        }

        private void FixedUpdate()
        {
            if (target != null && homingTorpedo != null)
            {
                var targetRotation = Quaternion.LookRotation(target.position - transform.position);
                homingTorpedo.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, turnRate));
                transform.Translate(Vector3.forward * speed * Time.deltaTime * 3);
            }
            if (target == null)
            {
                Destroy(gameObject);
            }

        }

        public void OnCollisionEnter(Collision collision)
        {
            if (this.gameObject.tag != collision.gameObject.name) // do not blow up the torpedo if it hits the ship collider on launching
                Destroy(this.gameObject, 0.3f); // kill weapon gameobject holding speed script
        }
        public void FindTargetNearTorpedo(List<GameObject> theTargets)
        {
            var distance = Mathf.Infinity;
            foreach (var possibleTarget in theTargets)
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

