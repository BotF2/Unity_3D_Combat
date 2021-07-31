using System;
using System.Windows;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Assets.Script
{
    //public enum Civilization
    //{
    //    Fed,
    //    Terran,
    //    Rom,
    //    Kling,
    //    Card,
    //    Dom,
    //    Borg
    //}
    //[RequireComponent(typeof(GameManager))]
    public class Ship : MonoBehaviour
    {
        //public GameManager gameManager; // grant access to GameManager by assigning it in the inspector field for public gameManager with GameManager in Inspector
        public int _shieldsMaxHealth; // set in ShipData.txt
        public int _hullHealth; 
        //private int _torpedoWarhead;
        //private int _beamPower;
        public int _layer;
        public GameObject weaponPrefab; // set to prefab in unity on parent of ship
        //public int torpeodDamaga;
        //public int beamDamaga;
        private int _torpedoDamage = 0;
        private int _beamDamage = 0;
        public GameObject shieldPrefab;
        public GameObject explosionPrefab;
        private AudioSource theSource;
        public AudioClip clipTorpedoFire;
        public AudioClip clipExplodTorpedo;
        private int _shieldsCurrentHealth;
        private float _shieldsRegeneratRate = 4f; // of Shields
        private int _sheildsRegenerateAmount = 1;
        private GameObject _shields;
        private bool shieldsAreUp;
        public Image _hullHealthImage;
        public GameObject _warpCoreBreach;   
    
        // public Material _hitMaterial;
        //List<Design> shipDesign = new List<Design>();
        //Material _orgMaterial;
        //Renderer _renderer;

        private void Awake()
        {

        }

        // Start is called before the first frame update
        void Start()
        {
            //var whatever = StaticStuff._shipsData;
            //for (int i = 0; i < whatever.Count; i++)
            //{
            //    //if (whatever.ToString() == gameObject.name)
            //    //{
            //    //    _shieldsMaxHealth = whatever.;
            //    //}
            //}
            ////var positionINT = StaticStuff._shipsData.FindIndex(item => item == gameObject.name);
            if (StaticStuff._shipDataDictionary.TryGetValue(gameObject.name, out int[]_result))
            {
                _shieldsMaxHealth = _result[0];
                _hullHealth = _result[1];
                //_torpedoWarhead = _result[2]; // Do we ever need to know the warhead loaded on the ship object? we get torpedo damage from incoming weapon / dictionary
                //_beamPower = _result[3];
            }
            _shieldsCurrentHealth = _shieldsMaxHealth;
            //InvokeRepeating("Regenerate", _shieldsRegeneratRate, _shieldsRegeneratRate); // see Regenerate method below
            shieldsAreUp = true;
            //_shields.SetActive(true);
            //_renderer = GetComponent<Renderer>();
            //_orgMaterial = _renderer.sharedMaterial;

        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {               
                 GameObject _weapon = Instantiate(weaponPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                _weapon.layer = gameObject.layer + 10;
                _weapon.tag = gameObject.name.ToUpper();
                
                //_weapon.tag = gameObject.name; // THIS DOES NOT WORK, would need all ship names available on list of tags in Unity
                _weapon.AddComponent<AudioSource>().playOnAwake = false;
                _weapon.AddComponent<AudioSource>().clip = clipTorpedoFire;
                theSource = _weapon.GetComponent<AudioSource>();
                theSource.PlayOneShot(clipTorpedoFire);
                Destroy(_weapon, 8f);
            }
        }
        private void FixedUpdate()
        {
            if (_shieldsCurrentHealth < 1)
                shieldsAreUp = false;
        }
        public void OnCollisionEnter(Collision collision)
        {
            var theOriginOf = transform.position;
            ContactPoint contact = collision.contacts[0];
            Quaternion rotationOf = Quaternion.FromToRotation(Vector3.down, contact.normal);
            Vector3 positionOf = contact.point;
            string weaponName = collision.gameObject.tag;

            if (StaticStuff._shipDataDictionary.TryGetValue(weaponName, out int[] _result))
            {
                _torpedoDamage = _result[2];
                _beamDamage = _result[3]; // ToDo, update to use beam damage also
            }
            switch (shieldsAreUp)
            {
                case true:
                    theOriginOf += transform.forward * 20; // ship origin plus 20 forward for explosion
                    positionOf += transform.forward * 10;  // ship origin plus 10 forward for shields
                    _shields = Instantiate(shieldPrefab, positionOf, rotationOf) as GameObject;
                    Destroy(_shields, 2.1f);
                    ShieldsTakeDagame(_torpedoDamage);
                    break;
                case false:
                    HullTakeDamage(_torpedoDamage);
                    break;
                default:
                    break;
            }
            GameObject explo = Instantiate(explosionPrefab, theOriginOf, Quaternion.identity) as GameObject;
            explo.AddComponent<AudioSource>().playOnAwake = false;
            explo.AddComponent<AudioSource>().clip = clipExplodTorpedo;
            theSource = explo.GetComponent<AudioSource>();
            theSource.PlayOneShot(clipExplodTorpedo);
            Destroy(explo, 2f);
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
                //Destroy(_shields);
                Debug.Log("Shields destroid");
            }
        }
        public void HullTakeDamage(int damage)
        {
            _hullHealth -= damage;
            Debug.Log("Hull took damage");
            if (_hullHealth < 1)
            {
                Destroy(transform.gameObject);
                Debug.Log("Ship destroid");
            }
        }
 
        public static void SetLayerRecursively(GameObject obj, int newLayer)
        {
          if (null == obj)
            {
                return;
            }

            obj.layer = newLayer;

            foreach(Transform child in obj.transform)
            {
                if(null == child)
                {
                    continue;
                }
                SetLayerRecursively(child.gameObject, newLayer);
            }
        }
        //private void CreateDesigns()
        //{
        //    //List<Design> shipDesign = new List<Design>();
        //    Design newDesign;

        //    newDesign = new Design("FED_SCOUT_I", "FED_SCOUT_I", 11, 22); shipDesign.Add(newDesign);
        //    newDesign = new Design("FED_SCOUT_II", "FED_SCOUT_II", 21, 42); shipDesign.Add(newDesign);
        //    newDesign = new Design("FED_SCOUT_III", "FED_SCOUT_III", 31, 62); shipDesign.Add(newDesign);
        //    newDesign = new Design("FED_CRUISER_I", "FED_CRUISER_I", 51, 102); shipDesign.Add(newDesign);

        //    newDesign = new Design("KLING_SCOUT_I", "KLING_SCOUT_I", 10, 20); shipDesign.Add(newDesign);
        //    newDesign = new Design("KLING_SCOUT_II", "KLING_SCOUT_II", 20, 40); shipDesign.Add(newDesign);
        //    newDesign = new Design("KLING_SCOUT_III", "KLING_SCOUT_III", 30, 60); shipDesign.Add(newDesign);
        //    newDesign = new Design("KLING_CRUISER_I", "KLING_CRUISER_I", 50, 100); shipDesign.Add(newDesign);

            //name = "FED_COLONY_SHIP_I)";
            //            name = "FED_COLONY_SHIP_II)";
            //            name = "FED_COLONY_SHIP_III)";
            //            name = "FED_COMMAND_SHIP_I)";
            //            name = "FED_COMMAND_SHIP_II)";
            //            name = "FED_COMMAND_SHIP_III)";
            //            name = "FED_CONSTRUCTION_SHIP_I)";
            //            name = "FED_CONSTRUCTION_SHIP_II)";
            //            name = "FED_CRUISER_I)";
            //            name = "FED_CRUISER_II)";
            //            name = "FED_CRUISER_III)";
            //            name = "FED_CRUISER_IV)";
            //            name = "FED_CRUISER_V)";
            //            name = "FED_DESTROYER_I)";
            //            name = "FED_DESTROYER_II)";
            //            name = "FED_DESTROYER_III)";
            //            name = "FED_DESTROYER_IV)";
            //            name = "FED_DIPLOMATIC_I)";
            //            name = "FED_DIPLOMATIC_II)";
            //            name = "FED_DIPLOMATIC_III)";
            //            name = "FED_FRIGATE_I)";
            //            name = "FED_FRIGATE_II)";
            //            name = "FED_FRIGATE_III)";
            //            name = "FED_FRIGATE_IV)";
            //            name = "FED_MEDICAL_SHIP_I)";
            //            name = "FED_MEDICAL_SHIP_II)";
            //            name = "FED_SCIENCE_SHIP_I)";
            //            name = "FED_SCIENCE_SHIP_II)";
            //            name = "FED_SCIENCE_SHIP_III)";
            //            name = "FED_SCOUT_I)";
            //            name = "FED_SCOUT_II)";
            //            name = "FED_SCOUT_III)";
            //            name = "FED_SPY_SHIP_I)";
            //            name = "FED_SPY_SHIP_II)";
            //            name = "FED_SPY_SHIP_III)";
            //            name = "FED_STRIKE_CRUISER_I)";
            //            name = "FED_STRIKE_CRUISER_II)";
            //            name = "FED_STRIKE_CRUISER_III)";
            //            name = "FED_TACTICAL_CRUISER)";
            //            name = "FED_TRANSPORT_I)";
            //            name = "FED_TRANSPORT_II)";
            //            name = "FED_TRANSPORT_III)";
            //    name = "ACAMARIAN_RAIDER_I)";
            //hull = ;
            //name = "ACAMARIAN_RAIDER_II)";
            //name = "AKRITIRIAN_ATTACK_SHIP)";
            //name = "ANDORIAN_CRUISER_I)";
            //name = "ANDORIAN_CRUISER_II)";
            //name = "ANGOSIAN_TRANSPORT)";
            //name = "ANKARI_CRUISER)";
            //name = "ANKARI_TRANSPORT)";
            //name = "ATREAN_CRUISER)";
            //name = "AXANAR_DESTROYER)";
            //name = "BAJORAN_ATTACK_SHIP_I)";
            //name = "BAJORAN_ATTACK_SHIP_II)";
            //name = "BENZITE_EXPLORER)";
            //name = "BETAZOID_STARCRUISER)";
            //name = "BILANAIAN_DESTROYER)";
            //name = "BOLIAN_TRANSPORT_I)";
            //name = "BOLIAN_TRANSPORT_II)";
            //name = "BOMAR_COLONY_SHIP)";
            //name = "BORG_CONSTRUCTION_SHIP_I)";
            //name = "BORG_CONSTRUCTION_SHIP_II)";
            //name = "BORG_CUBE_I)";
            //name = "BORG_CUBE_II)";
            //name = "BORG_CUBE_III)";
            //name = "BORG_MEDICAL_SHIP_I)";
            //name = "BORG_MEDICAL_SHIP_II)";
            //name = "BORG_PROBE_I)";
            //name = "BORG_PROBE_II)";
            //name = "BORG_PROBE_III)";
            //name = "BORG_PROBE_IV)";
            //name = "BORG_SCIENCE_SHIP_I)";
            //name = "BORG_SCIENCE_SHIP_II)";
            //name = "BORG_SCOUT_I)";
            //name = "BORG_SCOUT_II)";
            //name = "BORG_SCOUT_III)";
            //name = "BORG_SPHERE_I)";
            //name = "BORG_SPHERE_II)";
            //name = "BORG_SPHERE_III)";
            //name = "BORG_STRIKE_DIAMOND_I)";
            //name = "BORG_STRIKE_DIAMOND_II)";
            //name = "BORG_STRIKE_DIAMOND_III)";
            //name = "BORG_TACTICAL_CUBE)";
            //name = "BORG_TRANSPORT_I)";
            //name = "BORG_TRANSPORT_II)";
            //name = "BORG_TRANSPORT_III)";
            //name = "BOSLIC_TRANSPORT_I)";
            //name = "BOSLIC_TRANSPORT_II)";
            //name = "BOTHAN_DESTROYER)";
            //name = "BREEN_HEAVY_CRUISER_I)";
            //name = "BREEN_HEAVY_CRUISER_II)";
            //name = "BREEN_HEAVY_CRUISER_III)";
            //name = "BREKKIAN_TRANSPORT)";
            //name = "BYNAR_CRUISER)";
            //name = "CAIRN_SURVEYOR)";
            //name = "CALDONIAN_EXPLORER)";
            //name = "CARD_AUTOMATED_MISSILE)";
            //name = "CARD_COLONY_SHIP_I)";
            //name = "CARD_COLONY_SHIP_II)";
            //name = "CARD_COLONY_SHIP_III)";
            //name = "CARD_COMMAND_SHIP_I)";
            //name = "CARD_COMMAND_SHIP_II)";
            //name = "CARD_COMMAND_SHIP_III)";
            //name = "CARD_CONSTRUCTION_SHIP)";
            //name = "CARD_CRUISER_I)";
            //name = "CARD_CRUISER_II)";
            //name = "CARD_CRUISER_III)";
            //name = "CARD_CRUISER_IV)";
            //name = "CARD_DESTROYER_I)";
            //name = "CARD_DESTROYER_II)";
            //name = "CARD_DESTROYER_III)";
            //name = "CARD_DESTROYER_IV)";
            //name = "CARD_DIPLOMATIC_I)";
            //name = "CARD_DIPLOMATIC_II)";
            //name = "CARD_DIPLOMATIC_III)";
            //name = "CARD_MEDICAL_SHIP_I)";
            //name = "CARD_MEDICAL_SHIP_II)";
            //name = "CARD_SCIENCE_SHIP_I)";
            //name = "CARD_SCIENCE_SHIP_II)";
            //name = "CARD_SCIENCE_SHIP_III)";
            //name = "CARD_SCOUT_I)";
            //name = "CARD_SCOUT_II)";
            //name = "CARD_SCOUT_III)";
            //name = "CARD_SPY_SHIP_I)";
            //name = "CARD_SPY_SHIP_II)";
            //name = "CARD_SPY_SHIP_III)";
            //name = "CARD_STRIKE_CRUISER_I)";
            //name = "CARD_STRIKE_CRUISER_II)";
            //name = "CARD_TRANSPORT_I)";
            //name = "CARD_TRANSPORT_II)";
            //name = "CARD_TRANSPORT_III)";
            //name = "CORIDAN_CRUISER_I)";
            //name = "CORIDAN_CRUISER_II)";
            //name = "CORVALLEN_DESTROYER)";
            //name = "CORVALLEN_TRANSPORT)";
            //name = "DELTAN_SURVEYOR)";
            //name = "DENOBULAN_FRIGATE)";
            //name = "DEVORE_CRUISER)";
            //name = "DEVORE_HEAVY_CRUISER)";
            //name = "DEVORE_HEAVY_SCOUT)";
            //name = "DOM_COLONY_SHIP_I)";
            //name = "DOM_COLONY_SHIP_II)";
            //name = "DOM_COMMAND_SHIP_I)";
            //name = "DOM_COMMAND_SHIP_II)";
            //name = "DOM_COMMAND_SHIP_III)";
            //name = "DOM_CONSTRUCTION_SHIP)";
            //name = "DOM_CRUISER_I)";
            //name = "DOM_CRUISER_II)";
            //name = "DOM_CRUISER_III)";
            //name = "DOM_DESTROYER_I)";
            //name = "DOM_DESTROYER_II)";
            //name = "DOM_DESTROYER_III)";
            //name = "DOM_DESTROYER_IV)";
            //name = "DOM_DIPLOMATIC_I)";
            //name = "DOM_DIPLOMATIC_II)";
            //name = "DOM_DIPLOMATIC_III)";
            //name = "DOM_MEDICAL_SHIP_I)";
            //name = "DOM_MEDICAL_SHIP_II)";
            //name = "DOM_SCIENCE_SHIP_I)";
            //name = "DOM_SCIENCE_SHIP_II)";
            //name = "DOM_SCOUT_I)";
            //name = "DOM_SCOUT_II)";
            //name = "DOM_SCOUT_III)";
            //name = "DOM_SPY_SHIP_I)";
            //name = "DOM_SPY_SHIP_II)";
            //name = "DOM_SPY_SHIP_III)";
            //name = "DOM_STRIKE_CRUISER_I)";
            //name = "DOM_STRIKE_CRUISER_II)";
            //name = "DOM_TACTICAL_BATTLESHIP)";
            //name = "DOM_TRANSPORT_I)";
            //name = "DOM_TRANSPORT_II)";
            //name = "DOM_TRANSPORT_III)";
            //name = "DOSI_CRUISER)";
            //name = "DOSI_TRANSPORT)";
            //name = "ELAYSIAN_SURVEYOR)";
            //name = "ENTHARAN_TRANSPORT)";
            //name = "EVORA_SURVEYOR)";
            //name = "FED_COLONY_SHIP_I)";
            //name = "FED_COLONY_SHIP_II)";
            //name = "FED_COLONY_SHIP_III)";
            //name = "FED_COMMAND_SHIP_I)";
            //name = "FED_COMMAND_SHIP_II)";
            //name = "FED_COMMAND_SHIP_III)";
            //name = "FED_CONSTRUCTION_SHIP_I)";
            //name = "FED_CONSTRUCTION_SHIP_II)";
            //name = "FED_CRUISER_I)";
            //name = "FED_CRUISER_II)";
            //name = "FED_CRUISER_III)";
            //name = "FED_CRUISER_IV)";
            //name = "FED_CRUISER_V)";
            //name = "FED_DESTROYER_I)";
            //name = "FED_DESTROYER_II)";
            //name = "FED_DESTROYER_III)";
            //name = "FED_DESTROYER_IV)";
            //name = "FED_DIPLOMATIC_I)";
            //name = "FED_DIPLOMATIC_II)";
            //name = "FED_DIPLOMATIC_III)";
            //name = "FED_FRIGATE_I)";
            //name = "FED_FRIGATE_II)";
            //name = "FED_FRIGATE_III)";
            //name = "FED_FRIGATE_IV)";
            //name = "FED_MEDICAL_SHIP_I)";
            //name = "FED_MEDICAL_SHIP_II)";
            //name = "FED_SCIENCE_SHIP_I)";
            //name = "FED_SCIENCE_SHIP_II)";
            //name = "FED_SCIENCE_SHIP_III)";
            //name = "FED_SCOUT_I)";
            //name = "FED_SCOUT_II)";
            //name = "FED_SCOUT_III)";
            //name = "FED_SPY_SHIP_I)";
            //name = "FED_SPY_SHIP_II)";
            //name = "FED_SPY_SHIP_III)";
            //name = "FED_STRIKE_CRUISER_I)";
            //name = "FED_STRIKE_CRUISER_II)";
            //name = "FED_STRIKE_CRUISER_III)";
            //name = "FED_TACTICAL_CRUISER)";
            //name = "FED_TRANSPORT_I)";
            //name = "FED_TRANSPORT_II)";
            //name = "FED_TRANSPORT_III)";
            //name = "FERENGI_DESTROYER_I)";
            //name = "FERENGI_DESTROYER_II)";
            //name = "FERENGI_MARAUDER_I)";
            //name = "FERENGI_MARAUDER_II)";
            //name = "GORN_CRUISER_I)";
            //name = "GORN_CRUISER_II)";
            //name = "HAAKONIAN_DESTROYER)";
            //name = "HAZARI_CRUISER)";
            //name = "HEKARAN_CRUISER)";
            //name = "HIROGEN_CRUISER_I)";
            //name = "HIROGEN_CRUISER_II)";
            //name = "HIROGEN_CRUISER_III)";
            //name = "IYAARAN_SURVEYOR)";
            //name = "JNAII_SURVEYOR)";
            //name = "KAREMMA_CRUISER)";
            //name = "KAREMMA_TRANSPORT)";
            //name = "KAZON_ATTACK_SHIP)";
            //name = "KAZON_HEAVY_CRUISER_I)";
            //name = "KAZON_HEAVY_CRUISER_II)";
            //name = "KELLERUN_CRUISER)";
            //name = "KESPRYTT_FRIGATE)";
            //name = "KLAESTRONIAN_CRUISER)";
            //name = "KLING_COLONY_SHIP_I)";
            //name = "KLING_COLONY_SHIP_II)";
            //name = "KLING_COMMAND_SHIP_I)";
            //name = "KLING_COMMAND_SHIP_II)";
            //name = "KLING_COMMAND_SHIP_III)";
            //name = "KLING_CONSTRUCTION_SHIP)";
            //name = "KLING_CRUISER_I)";
            //name = "KLING_CRUISER_II)";
            //name = "KLING_CRUISER_III)";
            //name = "KLING_DESTROYER_I)";
            //name = "KLING_DESTROYER_II)";
            //name = "KLING_DESTROYER_III)";
            //name = "KLING_DESTROYER_IV)";
            //name = "KLING_DIPLOMATIC_I)";
            //name = "KLING_DIPLOMATIC_II)";
            //name = "KLING_DIPLOMATIC_III)";
            //name = "KLING_MEDICAL_SHIP_I)";
            //name = "KLING_MEDICAL_SHIP_II)";
            //name = "KLING_SCIENCE_SHIP_I)";
            //name = "KLING_SCIENCE_SHIP_II)";
            //name = "KLING_SCIENCE_SHIP_III)";
            //name = "KLING_SCOUT_I)";
            //name = "KLING_SCOUT_II)";
            //name = "KLING_SCOUT_III)";
            //name = "KLING_SPY_SHIP_I)";
            //name = "KLING_SPY_SHIP_II)";
            //name = "KLING_SPY_SHIP_III)";
            //name = "KLING_STRIKE_CRUISER_I)";
            //name = "KLING_STRIKE_CRUISER_II)";
            //name = "KLING_TACTICAL_CRUISER)";
            //name = "KLING_TRANSPORT_I)";
            //name = "KLING_TRANSPORT_II)";
            //name = "KLING_TRANSPORT_III)";
            //name = "KRADIN_FIGHTER)";
            //name = "KREETASSAN_SURVEYOR)";
            //name = "KRESSARI_TRANSPORT)";
            //name = "KRIOSIAN_CRUISER)";
            //name = "KTARIAN_CRUISER)";
            //name = "KTARIAN_DESTROYER)";
            //name = "LEDOSIAN_FRIGATE)";
            //name = "LEDOSIAN_SCOUT)";
            //name = "LISSEPIAN_TRANSPORT)";
            //name = "LOKIRRIM_LIGHT_CRUISER)";
            //name = "LOKIRRIM_SCOUT)";
            //name = "LURIAN_TRANSPORT)";
            //name = "MALCORIAN_SURVEYOR)";
            //name = "MALON_TRANSPORT_I)";
            //name = "MALON_TRANSPORT_II)";
            //name = "MALON_TRANSPORT_III)";
            //name = "MAQUIS_FIGHTER)";
            //name = "MAQUIS_RAIDER)";
            //name = "MARKALIAN_CRUISER)";
            //name = "MIRADORN_CRUISER)";
            //name = "MIRADORN_FIGHTER)";
            //name = "MOKRA_DESTROYER_I)";
            //name = "MOKRA_DESTROYER_II)";
            //name = "MONEAN_FIGHTER)";
            //name = "NAUSICAAN_FIGHTER)";
            //name = "NEZU_TRANSPORT)";
            //name = "NUMIRIR_CRUISER_I)";
            //name = "NUMIRIR_CRUISER_II)";
            //name = "NYRIAN_CRUISER)";
            //name = "ORION_SCOUT_I)";
            //name = "ORION_SCOUT_II)";
            //name = "PAKLED_LIGHT_CRUISER_I)";
            //name = "PAKLED_LIGHT_CRUISER_II)";
            //name = "REMAN_SCIMITAR)";
            //name = "REMAN_SCORPION)";
            //name = "ROM_COLONY_SHIP_I)";
            //name = "ROM_COLONY_SHIP_II)";
            //name = "ROM_COLONY_SHIP_III)";
            //name = "ROM_COMMAND_SHIP_I)";
            //name = "ROM_COMMAND_SHIP_II)";
            //name = "ROM_COMMAND_SHIP_III)";
            //name = "ROM_CONSTRUCTION_SHIP)";
            //name = "ROM_CRUISER_I)";
            //name = "ROM_CRUISER_II)";
            //name = "ROM_CRUISER_III)";
            //name = "ROM_CRUISER_IV)";
            //name = "ROM_DESTROYER_I)";
            //name = "ROM_DESTROYER_II)";
            //name = "ROM_DESTROYER_III)";
            //name = "ROM_DESTROYER_IV)";
            //name = "ROM_DIPLOMATIC_I)";
            //name = "ROM_DIPLOMATIC_II)";
            //name = "ROM_DIPLOMATIC_III)";
            //name = "ROM_MEDICAL_SHIP_I)";
            //name = "ROM_MEDICAL_SHIP_II)";
            //name = "ROM_SCIENCE_SHIP_I)";
            //name = "ROM_SCIENCE_SHIP_II)";
            //name = "ROM_SCIENCE_SHIP_III)";
            //name = "ROM_SCOUT_I)";
            //name = "ROM_SCOUT_II)";
            //name = "ROM_SCOUT_III)";
            //name = "ROM_SPY_SHIP_I)";
            //name = "ROM_SPY_SHIP_II)";
            //name = "ROM_SPY_SHIP_III)";
            //name = "ROM_STRIKE_CRUISER_I)";
            //name = "ROM_STRIKE_CRUISER_II)";
            //name = "ROM_STRIKE_CRUISER_III)";
            //name = "ROM_TACTICAL_CRUISER)";
            //name = "ROM_TRANSPORT_I)";
            //name = "ROM_TRANSPORT_II)";
            //name = "ROM_TRANSPORT_III)";
            //name = "SHELIAK_DESTROYER)";
            //name = "SHELIAK_HEAVY_DESTROYER)";
            //name = "SONA_CRUISER)";
            //name = "SONA_HEAVY_CRUISER)";
            //name = "SULIBAN_LIGHT_CRUISER)";
            //name = "SULIBAN_SURVEYOR)";
            //name = "TAK_TAK_DESTROYER_I)";
            //name = "TAK_TAK_DESTROYER_II)";
            //name = "TALARIAN_CRUISER_I)";
            //name = "TALARIAN_SURVEYOR)";
            //name = "TALAXIAN_ATTACK_SHIP)";
            //name = "TALAXIAN_DESTROYER)";
            //name = "TAMARIAN_COMMAND_CRUISER)";
            //name = "TAMARIAN_CRUISER)";
            //name = "TAMARIAN_LIGHT_CRUISER)";
            //name = "TELLARITE_CRUISER_I)";
            //name = "TELLARITE_TRANSPORT)";
            //name = "TERRAN_COLONY_SHIP_I)";
            //name = "TERRAN_COLONY_SHIP_II)";
            //name = "TERRAN_COLONY_SHIP_III)";
            //name = "TERRAN_COMMAND_SHIP_I)";
            //name = "TERRAN_COMMAND_SHIP_II)";
            //name = "TERRAN_COMMAND_SHIP_III)";
            //name = "TERRAN_CONSTRUCTION_SHIP_I)";
            //name = "TERRAN_CONSTRUCTION_SHIP_II)";
            //name = "TERRAN_CRUISER_I)";
            //name = "TERRAN_CRUISER_II)";
            //name = "TERRAN_CRUISER_III)";
            //name = "TERRAN_CRUISER_IV)";
            //name = "TERRAN_CRUISER_V)";
            //name = "TERRAN_DESTROYER_I)";
            //name = "TERRAN_DESTROYER_II)";
            //name = "TERRAN_DESTROYER_III)";
            //name = "TERRAN_DESTROYER_IV)";
            //name = "TERRAN_DIPLOMATIC_I)";
            //name = "TERRAN_DIPLOMATIC_II)";
            //name = "TERRAN_DIPLOMATIC_III)";
            //name = "TERRAN_FRIGATE_I)";
            //name = "TERRAN_FRIGATE_II)";
            //name = "TERRAN_FRIGATE_III)";
            //name = "TERRAN_FRIGATE_IV)";
            //name = "TERRAN_MEDICAL_SHIP_I)";
            //name = "TERRAN_MEDICAL_SHIP_II)";
            //name = "TERRAN_SCIENCE_SHIP_I)";
            //name = "TERRAN_SCIENCE_SHIP_II)";
            //name = "TERRAN_SCIENCE_SHIP_III)";
            //name = "TERRAN_SCOUT_I)";
            //name = "TERRAN_SCOUT_II)";
            //name = "TERRAN_SCOUT_III)";
            //name = "TERRAN_SPY_SHIP_I)";
            //name = "TERRAN_SPY_SHIP_II)";
            //name = "TERRAN_SPY_SHIP_III)";
            //name = "TERRAN_STRIKE_CRUISER_I)";
            //name = "TERRAN_STRIKE_CRUISER_II)";
            //name = "TERRAN_STRIKE_CRUISER_III)";
            //name = "TERRAN_TACTICAL_CRUISER)";
            //name = "TERRAN_TRANSPORT_I)";
            //name = "TERRAN_TRANSPORT_II)";
            //name = "TERRAN_TRANSPORT_III)";
            //name = "THOLIAN_CRUISER_I)";
            //name = "THOLIAN_CRUISER_II)";
            //name = "TLANI_HEAVY_CRUISER_I)";
            //name = "TLANI_HEAVY_CRUISER_II)";
            //name = "TRABE_CRUISER)";
            //name = "TRILL_LIGHT_CRUISER_I)";
            //name = "TRILL_LIGHT_CRUISER_II)";
            //name = "TROGORAN_CRUISER_I)";
            //name = "TROGORAN_CRUISER_II)";
            //name = "VAADWAUR_COLONY_SHIP_I)";
            //name = "VAADWAUR_CRUISER)";
            //name = "VAADWAUR_DESTROYER)";
            //name = "VIDIIAN_CRUISER_SHIP_I)";
            //name = "VIDIIAN_CRUISER_SHIP_II)";
            //name = "VISSIAN_CRUISER)";
            //name = "VORGON_CRUISER)";
            //name = "VULCAN_CRUISER)";
            //name = "VULCAN_HEAVY_CRUISER)";
            //name = "VULCAN_SURVEYOR)";
            //name = "XANTHAN_TRANSPORT)";
            //name = "XEPOLITE_CRUISER)";
            //name = "XINDI_CRUISER)";
            //name = "XINDI_SCOUT)";
            //name = "XYRILLIAN_SURVEYOR)";
            //name = "YRIDIAN_SURVEYOR_I)";
            //name = "YRIDIAN_TRANSPORT)";
            //name = "ZAHL_CRUISER)";
            //name = "ZAKDORN_CRUISER)";
            //name = "ZALKONIAN_CRUISER_I)";
        //}

    }
}
