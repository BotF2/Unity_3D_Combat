using System;
using System.Windows;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
//using UnityEngine.UI;
using System.Linq;

namespace Assets.Script
{
    [RequireComponent(typeof(GameManager))]
    public class Ship : MonoBehaviour
    {
        public GameManager gameManager; // grant access to GameManager by assigning it in the inspector field for public gameManager with GameManager in Inspector
        public Civilization civilization;
        public int _shieldsMaxHealth; // set in ShipData.txt
        public int _hullMaxHealth;
        public int _torpedoDamage; // update with data of torpedo that hits
        public int _beamDamage;
        public int _cost;
        private bool _isFriend;
        private Rigidbody rigidbody;
        private GameObject shipGameObject;
        private Transform _farTarget;
        private Transform _nearTarget;
        private Transform _currentTarget;
        private bool isFarTargetSet = false;
       // public float combatAreaOffset = -5000f;
        private float turnRate = 1f;
        private bool lockTurn = true;
        private int _shieldsCurrentHealth;
        private float _shieldsRegeneratRate = 4f; // of Shields
        private float _speedBooster = 15000f;
       // public bool allStop = false;
        private int _sheildsRegenerateAmount = 1;
        private GameObject _shields;
        public bool shieldsAreUp;
        // public Image _hullHealthImage;
        public GameObject _warpCoreBreach;
        public GameObject _ringExplosion;
        private bool _isTorpedo;
        private Transform beamTargetTransform;

        private Dictionary<int, GameObject> theLocalTargetDictionary;
        private float diff = 0;
        private Vector3[] linePositions = new Vector3[2]; // beam line render points in update
        //private int _torpedoWarhead;
        //private int _beamPower;
        public int _layer;
        public GameObject torpedoPrefab; // set in prefab of ships
        public GameObject beamPrefab;
        private GameObject beamObject;
        public GameObject shieldPrefab;
        public GameObject explosionPrefab;

        private AudioSource theSource;
        private AudioSource theNextSource;
        public AudioClip clipTorpedoFire;
        public AudioClip clipExplodTorpedo;
        public AudioClip clipBeamWeapon;
        public AudioClip clipWarpCoreBreach;

        // private Renderer rend; // not working 

        // public Material _hitMaterial;
        //List<Design> shipDesign = new List<Design>();
        //Material _orgMaterial;
        //Renderer _renderer;
        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }
        void Start()
        {
              //_whoIAm = MyCivilization(this.name);
            _shieldsCurrentHealth = _shieldsMaxHealth;
            //InvokeRepeating("Regenerate", _shieldsRegeneratRate, _shieldsRegeneratRate); // see Regenerate method below
            shieldsAreUp = true;
            _isFriend = GameManager.Instance.AreWeFriends(gameObject);
            if (_isFriend)
               // combatAreaOffset *= -1;
            //_shields.SetActive(true);
            //_renderer = GetComponent<Renderer>();
            //_orgMaterial = _renderer.sharedMaterial;

            shipGameObject = gameObject;

        }
        private void Update()
        { // Move
            if (GameManager.Instance._statePassedCombatInit)
            {
                //rigidbody.velocity = Vector3.zero;
                //rigidbody.angularVelocity = Vector3.zero;
                // ToDo: update to put physics movement on parent of ship so camera empty gets it too

                //rigidbody.velocity = transform.forward * Time.deltaTime * _speedBooster;
                #region travel between targets here
                //if (!isFarTargetSet)
                //{
                //    GameObject fart = new GameObject();
                //    GameObject[] farty = new GameObject[] { fart, fart };
                //    //Transform value = fart.transform;
                //    var dictionary = GameManager.Instance.GetShipTravelTargets();

                //    if (dictionary.TryGetValue(shipGameObject, out farty))
                //    {
                //        _nearTarget = farty[0].transform;
                //        _farTarget = farty[1].transform;
                //    }
                //    _currentTarget = _farTarget;
                //    isFarTargetSet = true;
                //}
                //#endregion
                //#region Alernate near and far targets
                //if (Math.Abs(transform.position.x) <= 200) // when passing the zero point of the x axis turn lockTurn false, ready to turn
                //    lockTurn = false;

                //int leftRight = 1;
                //if (_currentTarget.position.x < 0)
                //    leftRight = -1;
                //if ((this._currentTarget.position.x * leftRight) - (leftRight * shipGameObject.transform.position.x) < 100 && !lockTurn) // when near the target turn
                //{
                //    if (_currentTarget == _farTarget)
                //    {
                //        _currentTarget = _nearTarget;
                //        lockTurn = true;
                //    }
                //    else if (_currentTarget == _nearTarget)
                //    {
                //        _currentTarget = _farTarget;
                //        lockTurn = true;
                //    }
                //}
                #endregion
                #region turn to target
                //var targetRotation = Quaternion.LookRotation(this._currentTarget.position - transform.position);
                //rigidbody.MoveRotation(Quaternion.RotateTowards(shipGameObject.transform.rotation, targetRotation, turnRate));
                ////transform.Translate(Vector3.forward * 100 * Time.deltaTime * 3);
                #endregion

                if (GameManager.FriendShips.Count > 0 && gameObject.name != "Ship")
                {
                    string whoTorpedo = gameObject.name.Substring(0, 3);
                    string friendShips = GameManager.FriendNameArray[1].Substring(0, 3); // first one might be a dummy so go with [1]
                    if (whoTorpedo == friendShips)
                        theLocalTargetDictionary = GameManager.EnemyShips;
                    else
                        theLocalTargetDictionary = GameManager.FriendShips;
                    FindBeamTarget(theLocalTargetDictionary);
                }
 
                if (beamObject == null)
                    beamTargetTransform = null;

                if (Input.GetKeyDown(KeyCode.V))
                {
                    GameObject _tempTorpedo = Instantiate(torpedoPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                    _tempTorpedo.layer = gameObject.layer + 10;
                    _tempTorpedo.tag = gameObject.name.ToUpper();
                    _tempTorpedo.AddComponent<AudioSource>().playOnAwake = false;
                    _tempTorpedo.AddComponent<AudioSource>().clip = clipTorpedoFire;
                    theSource = _tempTorpedo.GetComponent<AudioSource>();
                    theSource.PlayOneShot(clipTorpedoFire);
                    Destroy(_tempTorpedo, 8f);
                }
                if (Input.GetKeyDown(KeyCode.B))
                {
                    GameObject beamObject = Instantiate(beamPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                    FindBeamTarget(theLocalTargetDictionary);
                    linePositions[0] = this.transform.position + (transform.right * 50) + (transform.forward * 50);
                    linePositions[1] = beamTargetTransform.position + (transform.right * 50) - (transform.forward * 50);
                    //beamObject = _tempBeam;
                    //_tempBeam.layer = gameObject.layer + 10;
                    beamObject.tag = gameObject.name.ToUpper();

                    var theLine = beamObject.GetComponent<LineRenderer>();
                    theLine.SetVertexCount(2);
                    theLine.SetWidth(50f, 50f);
                    theLine.SetPosition(0, linePositions[0]);
                    theLine.SetPosition(1, linePositions[1]);
                    var meshCollider = theLine.GetComponent<MeshCollider>();
                    Mesh mesh = new Mesh();
                    theLine.BakeMesh(mesh, true);
                    meshCollider.sharedMesh = mesh;
                    meshCollider.isTrigger = true;

                    beamObject.AddComponent<AudioSource>().playOnAwake = false;
                    beamObject.AddComponent<AudioSource>().clip = clipBeamWeapon;
                    theNextSource = beamObject.GetComponent<AudioSource>();
                    theNextSource.PlayOneShot(clipBeamWeapon);
                    OnTriggerStay(meshCollider);
                    Destroy(beamObject, 0.65f);
                }
            }
        }
        private void FixedUpdate()
        {
            if (_shieldsCurrentHealth < 1)
                shieldsAreUp = false;
        }

        public void OnTriggerStay(Collider other) // beams
        {
            Quaternion rotationOf = Quaternion.FromToRotation(Vector3.down, transform.forward);
            string beamFiringShip = gameObject.name.ToUpper();

            if (GameManager.ShipDataDictionary.TryGetValue(beamFiringShip, out int[] _result))
            {
                _beamDamage = _result[3];
            }
            if (_beamDamage > 0 && beamTargetTransform != null)
            {
                Ship target = beamTargetTransform.GetComponent<Ship>(); // get the targeted Ship
                switch (target.shieldsAreUp)
                {
                    case true:
                        var positionOf = beamTargetTransform.position; // traget ship origin
                        _shields = Instantiate(shieldPrefab, positionOf, rotationOf) as GameObject;
                        Destroy(_shields, 2.1f);
                        target.ShieldsTakeDagame(_beamDamage);
                        _beamDamage = 0;
                        break;
                    case false:
                        target.HullTakeDamage(_beamDamage);
                        _beamDamage = 0;
                        break;
                    default:
                        break;
                }
            }
            GameObject hitShip = other.GetComponent<GameObject>(); // will this work???
            other.transform.parent = null;
            for (var i = hitShip.transform.childCount - 1; i >= 0; i--)
            {
                // objectA is not the attached GameObject, so you can do all your checks with it.
                var objectA = hitShip.transform.GetChild(i);
                objectA.transform.parent = null;
                // Optionally destroy the objectA if not longer needed
            }
            Destroy(hitShip, 1f);
           // Destroy(other.gameObject, 1f);
        }
        public void OnCollisionEnter(Collision collision)
        {
            string nameOfImpactor = collision.gameObject.name;
            string[] _nameParts = nameOfImpactor.ToUpper().Split('_');
            string maybeTorpedo = _nameParts[1];
            if (maybeTorpedo == "TORPEDO(CLONE)")
            {

                var theOriginOf = transform.position; // for explosion below
                ContactPoint contact = collision.contacts[0];
                Quaternion rotationOf = Quaternion.FromToRotation(Vector3.down, contact.normal);
                Vector3 positionOf = contact.point;
                string weaponName = collision.gameObject.tag;
                string gameObjectName = collision.gameObject.name;
                if (gameObjectName.Contains("TORPEDO"))
                    _isTorpedo = true;

                if (GameManager.ShipDataDictionary.TryGetValue(weaponName, out int[] _result))
                {
                    if (_isTorpedo)
                        _torpedoDamage = _result[2];
                    //else
                    //_beamDamage = _result[3]; 
                }
                if (_torpedoDamage > 0) //if (_isTorpedo &&
                {
                    switch (shieldsAreUp)
                    {
                        case true:
                            theOriginOf += transform.forward * 20; // ship origin plus 20 forward for explosion
                            positionOf += transform.forward * 10;  // ship origin plus 10 forward for shields
                            _shields = Instantiate(shieldPrefab, positionOf, rotationOf) as GameObject;
                            Destroy(_shields, 1.3f);
                            ShieldsTakeDagame(_torpedoDamage);
                            _torpedoDamage = 0;
                            break;
                        case false:
                            HullTakeDamage(_torpedoDamage);
                            _torpedoDamage = 0;
                            break;
                        default:
                            break;
                    }
                }
                GameObject explo = Instantiate(explosionPrefab, theOriginOf, Quaternion.identity) as GameObject;
                explo.AddComponent<AudioSource>().playOnAwake = false;
                explo.AddComponent<AudioSource>().clip = clipExplodTorpedo;
                theSource = explo.GetComponent<AudioSource>();
                theSource.PlayOneShot(clipExplodTorpedo);
                Destroy(explo, 2f);
            }
        }
        public void FindBeamTarget(Dictionary<int, GameObject> theTargets)
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
                        beamTargetTransform = possibleTarget.transform;
                    }
                }
            }
        }
        void Regenerate()
        {
            if (_shieldsCurrentHealth < _shieldsMaxHealth)
                _shieldsCurrentHealth += _sheildsRegenerateAmount;
            if (_shieldsCurrentHealth > _shieldsMaxHealth)
            {
                _shieldsCurrentHealth = _shieldsMaxHealth;
            }
        }
        public void ShieldsTakeDagame(int damage)
        {
            _shieldsCurrentHealth -= damage;
            Debug.Log("Shields took damage");
            if (_shieldsCurrentHealth < 1)
            {
                Destroy(_shields);
                Debug.Log("Shields destroid");
            }
        }
        public void HullTakeDamage(int damage)
        {
            _hullMaxHealth -= damage;
            Debug.Log("Hull took damage");
            if (_hullMaxHealth < 1)
            {
                Destroy(transform.gameObject, 0.2f);
                if (GameManager.FriendNameArray.Contains(gameObject.name))
                {
                    var newList = GameManager.FriendNameArray.ToList();
                    newList.Remove(gameObject.name);
                    GameManager.FriendNameArray = newList.ToArray();
                    if (GameManager.FriendShips.ContainsValue(gameObject))
                    {
                        var someKeyAndShip = GameManager.FriendShips.FirstOrDefault(o => o.Value == gameObject);
                        GameManager.FriendShips.Remove(someKeyAndShip.Key);
                    }
                }
                else if (GameManager.EnemyNameArray.Contains(gameObject.name))
                {
                    var newList = GameManager.EnemyNameArray.ToList();
                    newList.Remove(gameObject.name);
                    GameManager.EnemyNameArray = newList.ToArray();
                    if (GameManager.EnemyShips.ContainsValue(gameObject))
                    {
                        var otherKeyAndShip = GameManager.EnemyShips.FirstOrDefault(o => o.Value == gameObject);
                        GameManager.EnemyShips.Remove(otherKeyAndShip.Key);
                    }
                }
                Debug.Log("Ship destroid");
                GameObject ringExplosion = Instantiate(_ringExplosion, transform.position, Quaternion.LookRotation(transform.up)) as GameObject;
                ringExplosion.AddComponent<AudioSource>().playOnAwake = false;
                ringExplosion.AddComponent<AudioSource>().clip = clipWarpCoreBreach;
                theSource = ringExplosion.GetComponent<AudioSource>();
                theSource.PlayOneShot(clipWarpCoreBreach);
                GameObject warpCore = Instantiate(_warpCoreBreach, transform.position, Quaternion.identity) as GameObject;
                Destroy(warpCore, 1.3f);
                Destroy(ringExplosion, 4f);
                Destroy(shieldPrefab);
            }
        }

        //public void SetNearTargets(Dictionary<GameObject, Transform> nearTargets)
        //{
        //    _shipsNearTargets = nearTargets; // empty dummy gameObjects as targets located where 3D ships warp in.
        //}
        //public void SetEnemyTargets(GameObject[] targets)
        //{
        //    _enemyTargets = targets; // empty dummy gameObjects as targets located where 3D ships warp in.
        //}
        public static void SetLayerRecursively(GameObject obj, int newLayer)
        {
            if (null == obj)
            {
                return;
            }

            obj.layer = newLayer;

            foreach (Transform child in obj.transform)
            {
                if (null == child)
                {
                    continue;
                }
                SetLayerRecursively(child.gameObject, newLayer);
            }
        }
        //public static Civilization MyCivilization(string who)
        //{
        //    //string readFriendName = _friendNameArray[0].ToUpper();
        //    //string[] _collFriend = readFriendName.Split('_');
        //    //SetShipLayer(_collFriend[0], FriendOrFoe.friend);
        //    //switch (who)
        //    //{
        //    //    case "FED":
        //    //        {
        //    //            if (who == FriendOrFoe.friend)
        //    //                friendShipLayer = 10;
        //    //            else
        //    //                enemyShipLayer = 10;
        //    //            break;
        //    //        }
        //    //    case "TERRAN":
        //    //        {
        //    //            if (who == FriendOrFoe.friend)
        //    //                friendShipLayer = 11;
        //    //            else
        //    //                enemyShipLayer = 11;
        //    //            break;
        //    //        }
        //    //    case "ROM":
        //    //        {
        //    //            if (who == FriendOrFoe.friend)
        //    //                friendShipLayer = 12;
        //    //            else
        //    //                enemyShipLayer = 12;
        //    //            break;
        //    //        }
        //    //    case "KLING":
        //    //        {
        //    //            if (who == FriendOrFoe.friend)
        //    //                friendShipLayer = 13;
        //    //            else
        //    //                enemyShipLayer = 13;
        //    //            break;
        //    //        }
        //    //    case "CARD":
        //    //        {
        //    //            if (who == FriendOrFoe.friend)
        //    //                friendShipLayer = 14;
        //    //            else
        //    //                enemyShipLayer = 14;
        //    //            break;
        //    //        }
        //    //    case "DOM":
        //    //        {
        //    //            if (who == FriendOrFoe.friend)
        //    //                friendShipLayer = 15;
        //    //            else
        //    //                enemyShipLayer = 15;
        //    //            break;
        //    //        }
        //    //    case "BORG":
        //    //        {
        //    //            if (who == FriendOrFoe.friend)
        //    //                friendShipLayer = 16;
        //    //            else
        //    //                enemyShipLayer = 16;
        //    //            break;
        //    //        }
        //    //    default:
        //    //        break;
        //    //}
        //}
    }
}
