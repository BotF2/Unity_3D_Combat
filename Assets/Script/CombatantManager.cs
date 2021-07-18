using Assets.Script;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Script
{
    public class CombatantManager : MonoBehaviour
    {
        private char separator = ';';
        private Dictionary<string, int> _assetsDictionary = new Dictionary<string, int>();

        public static GameObject enemy_0; // parent empty gameobjects
        public static GameObject enemy_1; // can use one parent for all or multiple parents 
        public static GameObject enemy_2;
        public static GameObject enemy_3;
        public static GameObject enemy_4;
        public static GameObject enemy_5;
        public static List<GameObject> enemyPositionList = new List<GameObject>() { enemy_0, enemy_1, enemy_2, enemy_3, enemy_4, enemy_5 };

        public static GameObject friend_0; // parent empty gameobjects
        public static GameObject friend_1; // can use one parent for all or multiple parents 
        public static GameObject friend_2;
        public static GameObject friend_3;
        public static GameObject friend_4;
        public static GameObject friend_5;
        public static List<GameObject> friendPositionList = new List<GameObject>() { friend_0, friend_1, friend_2, friend_3, friend_4, friend_5 };

        private GameObject enemyInstance_0;
        private GameObject enemyInstance_1;
        private GameObject enemyInstance_2;
        private GameObject enemyInstance_3;
        private GameObject enemyInstance_4;
        private GameObject enemyInstance_5;

        private GameObject FriendInstance_0;
        private GameObject FriendInstance_1;
        private GameObject FriendInstance_2;
        private GameObject FriendInstance_3;
        private GameObject FriendInstance_4;
        private GameObject FriendInstance_5;

        public void Combatant()
        {
            LoadAssets(Environment.CurrentDirectory + "\\Assets\\" + "Assets.txt");

            List<Friend> friends = new List<Friend>();
            List<Enemy> enemies = new List<Enemy>();

            foreach (var item in _assetsDictionary)
            {
                if (item.Key.Contains("Friend"))
                {
                    var _coll = item.Key.Split('#');

                        Friend friendNew = new Friend(
                            _coll[0].ToString()
                            ,_coll[1].ToString()
                            , item.Value);
                        friends.Add(friendNew);
                }

                if (item.Key.Contains("Enemy"))
                {
                    var _coll = item.Key.Split('#');
                        Enemy itemNew = new Enemy(
                            _coll[0].ToString()
                            , _coll[1].ToString()
                            , item.Value);
                        enemies.Add(itemNew);

                }
            }



            //foreach (GameObject obj in enemyArray)
            //{
            //    enemyList.Add(obj);
            //}
            //foreach (GameObject obj in friendArray)
            //{
            //    friendList.Add(obj);
            //}

            //for (int x = 0; x < enemyList.Count; x++)
            //{
            //    Instantiate(enemyList[x], enemyList[x].transform.position, enemyList[x].transform.rotation, enemyList[x].transform);

            //}
            //for (int x = 0; x < friendList.Count; x++)
            //{
            //    Instantiate(friendList[x], friendList[x].transform.position, friendList[x].transform.rotation, friendList[x].transform);
            //}

            friend_0.transform.SetParent(FriendInstance_0.transform, true);
            friend_1.transform.SetParent(friend_1.transform, true);
            friend_2.transform.SetParent(friend_2.transform, true);
            friend_3.transform.SetParent(friend_3.transform, true);
            friend_4.transform.SetParent(friend_4.transform, true);
            friend_5.transform.SetParent(friend_5.transform, true);

            Ship.SetLayerRecursively(friend_0, 10);
            Ship.SetLayerRecursively(friend_1, 10);
            Ship.SetLayerRecursively(friend_2, 10);
            Ship.SetLayerRecursively(friend_3, 10);
            Ship.SetLayerRecursively(friend_4, 10);
            Ship.SetLayerRecursively(friend_5, 10);
        }

        //private void Split(string key, out string party, out string design)
        //{
        //    var _coll = key.Split('#');
        //    foreach (var _key in _coll)
        //    {
        //        var _party = _key[0];
        //        var _design = _key[1];
        //    }
        //    return _party, _design;
        //}

        //private void Start()
        //{
        //GameObject[] enemyArray = Resources.LoadAll<GameObject>("Enemies/");
        //GameObject[] friendArray = Resources.LoadAll<GameObject>("Firends/");

        //foreach (GameObject obj in enemyArray)
        //{
        //   enemyList.Add(obj);
        //}
        //foreach (GameObject obj in friendArray)
        //{
        //    friendList.Add(obj);
        //}
        //foreach (var item in enemyList)
        //{

        //}

        //for (int x = 0; x < enemyList.Count; x++)
        //{
        //    Instantiate(enemyList[x], enemyList[x].transform.position, enemyList[x].transform.rotation);

        //}
        //for (int x = 0; x < friendList.Count; x++)
        //{
        //    Instantiate(friendList[x], friendList[x].transform.position, friendList[x].transform.rotation);
        //}
        //}
        public void LoadAssets(string filename) // List<sting>
        {

            var file = new FileStream(filename, FileMode.Open, FileAccess.Read);

            var _assetsData = new List<string>();
            using (var reader = new StreamReader(file))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                        continue;
                    Console.WriteLine("loaded from file: {0}", line);

                    _assetsData.Add(line.Trim());

                    if (line.Length > 0)
                    {
                        var coll = line.Split(separator);

                        _ = int.TryParse(coll[1], out int currentValue);
                        _assetsDictionary.Add(coll[0].ToString(), currentValue);
                    }
                }
                reader.Close();
            }
            // return _weapons;
        }

        public class Friend
        {
            public string F_INDEX;
            public string Design;
            public int Number;

            public Friend(
                    string f_index
                    , string design
                    , int number
                    )
            {
                F_INDEX = f_index;
                Design = design;
                Number = number;
            }
        }

        public class Enemy
        {
            public string E_INDEX;
            public string Design;
            public int Number;

            public Enemy(
                    string e_index
                    , string design
                    , int number
                    )
            {
                E_INDEX = e_index;
                Design = design;
                Number = number;
            }
        }


        //public static Enemy GetClosestEnemy(Vector3 position, float maxRange);

        // Start is called before the first frame update
        //    void Start()
        //{
        //    //enemyList = new List<GameObject>();

        //    foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        //    {
        //        var enemyScript = enemy.AddComponent<EnemyScript>();
        //        enemyScript._combatantManager = this;
        //        enemyList.Add(enemy);
        //    }
        //}



        //public GameObject GetEnemyClosestToPoint(Vector3 point)
        //{
        //    GameObject closestEnemy = null;
        //    float closestEnemyDistance = 0.0f;

        //if (_allEnemies.Count > 0)
        //{
        //    // by default grab first enemy 
        //    closestEnemy = _allEnemies[0];
        //    closestEnemyDistance = Vector3.Distance(closestEnemy.transform.position, point);
        //}

        //foreach (var enemy in _allEnemies)
        //{
        //    if (enemy == closestEnemy) continue;

        //    var distance = Vector3.Distance(enemy.transform.position, point);

        //    if (distance < closestEnemyDistance)
        //    {
        //        closestEnemy = enemy;
        //        closestEnemyDistance = distance;
        //    }
        //}

        //    return closestEnemy;
        //}
    }
}
