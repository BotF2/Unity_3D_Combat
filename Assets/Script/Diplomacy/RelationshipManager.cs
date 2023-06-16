using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BOTF3D_GalaxyMap;
using BOTF3D_Core;
using BOTF3D_Combat;
using System;

namespace Assets.Script
{
    public static class RelationshipManager
    {
        // here, we're storing relationships in a 2D array. 
        // ?? Do we need to use only major civilizations do relationships, all civs for now
        private static RelationshipInfo[,] civRelationships; // owner civ, other civ, relationship score

        //public static Array[] DiplomaticScoreArray;

        // each faction will get an index in the array
        private static Dictionary<Civilization, int> civRelationshipIndexs;  

        // this method must be called at the start of your game to initialize the civ manager
        public static void Initialize(ICollection<Civilization> civilizations) // call this later
        {
            civRelationships = new RelationshipInfo[civilizations.Count, civilizations.Count];
            // find a civs index with this Dictionary
            civRelationshipIndexs = new Dictionary<Civilization, int>(civilizations.Count);
            
            int j = 0; // where the civ is (index) in the array of relationshipinfos
            foreach (Civilization civ in civilizations)
            {
                civRelationshipIndexs[civ] = j;
                //if (!civ.deltaRelation.ContainsKey(j))
                //{
                //    civ.deltaRelation.Add(j, 0); // zero here for no delta Relation change at initialization
                //}
                j++;
            }
        }
        public static RelationshipInfo GetRelationshipInfo(Civilization civ1, Civilization civ2)
        {
            int civ1Index = civRelationshipIndexs[civ1];
            int civ2Index = civRelationshipIndexs[civ2];
            RelationshipInfo relationshipInfo = civRelationships[civ1Index,civ2Index];
            if (relationshipInfo == null)
            {
                relationshipInfo = new RelationshipInfo();
                civRelationships[civ1Index, civ2Index] = relationshipInfo;
            }
            return relationshipInfo;
        }
    }

    
}
