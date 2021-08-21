using System.Collections.Generic;

namespace Assets.Script
{
    public class StaticStuff 
    {
        //grant 'access' to GameManager script class by assigning it in the inspector field for public 'gameManager' in Ship script with the GameManager in Inspector
        //use static only if there is only one copy of it
        public static float shipScale = 700f;
        public static Dictionary<string, int[]> _shipDataDictionary;
        public static Dictionary<int, object> _friendGameObjectDictionary;
        public static Dictionary<int, object> _enemyGameObjectDictionary;

        //public void LoadStaticShipData(Dictionary<string, int[]> dataDictionary)
        //{
        //    _shipDataDictionary = dataDictionary;
        //}
        //public static void LoadStaticFriendDictionary(Dictionary<int, object> friendDictionary)
        //{
        //    _friendGameObjectDictionary = friendDictionary;
        //}
        //public static void LoadStaticEnemyDictionary(Dictionary<int, object> enemyDictionary)
        //{
        //    _enemyGameObjectDictionary = enemyDictionary;
        //}
    }
}
