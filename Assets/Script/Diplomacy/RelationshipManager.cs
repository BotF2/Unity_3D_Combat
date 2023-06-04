using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BOTF3D_GalaxyMap;
using BOTF3D_Core;
using BOTF3D_Combat;

namespace Assets.Script
{
    public static class RelationshipManager
    {
        // here, we're storing relationships in a 2D array. 
        // ?? Do we need to use only major civilizations do relationships, all for now
        private static RelationshipInfo[,] civRelationships;

        // each faction will get an index in the array
        private static Dictionary<Civilization, int> civRelationshipIndexes;

        // this method must be called at the start of your game to initialize the civilization manager
        public static void Initialize(ICollection<Civilization> civilizations)
        {
            civRelationships = new RelationshipInfo[civilizations.Count, civilizations.Count];
            civRelationshipIndexes = new Dictionary<Civilization, int>(civilizations.Count);

            int i = 0;
            foreach (var civ in civilizations)
            {
                civRelationshipIndexes[civ] = i;
                i++;
            }
        }

        public static RelationshipInfo GetRelationshipInfo(Civilization civilization1, Civilization civilization2)
        {
            int civilization1Index = civRelationshipIndexes[civilization1];
            int civilization2Index = civRelationshipIndexes[civilization2];

            RelationshipInfo civRelationshipInfo = civRelationships[civilization1Index, civilization2Index];
            if (civRelationshipInfo == null)
            {
                civRelationshipInfo = new RelationshipInfo();
                civRelationships[civilization1Index, civilization2Index] = civRelationshipInfo;
            }

            return civRelationshipInfo;
        }

    }

    
}
