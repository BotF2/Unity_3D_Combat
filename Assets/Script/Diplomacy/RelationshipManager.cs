using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BOTF3D_GalaxyMap;
using BOTF3D_Core;
using BOTF3D_Combat;
using System;
using Unity.VisualScripting;
using UnityEngine.Apple.ReplayKit;

namespace Assets.Script
{
    public class RelationshipManager : MonoBehaviour
    {
        // here, we're storing relationships in a 2D array. 
        //// ?? Do we need to use only major civilizations do relationships, all civs for now
        //private static RelationshipInfo[,] civRelationships; // = new RelationshipInfo[200,200]; // index owner civ, index other civ, stores relationship score value
        //private static RelationshipInfo[,] civRelationshipsTemp;
        //private static int[,] civDiplomaticRelations;

        //public List<RelationshipInfo> relationshipInfos;
        //public Dictionary<int, RelationshipInfo> relationshipsDictionary;
        //public RelationshipInfo[][] relationshipsList; // = new List<RelationshipInfo>();
        //public Array[,] DiplomaticScoreArray;
        //private static RelationshipInfo relationshipInfo;

        //public RelationshipManager(ICollection<Civilization> civList)
        //{

        //    //RelationshipInfo anInfo = new RelationshipInfo();
        //    relationshipsList = new RelationshipInfo[civList.Count][];
        //    for (int i = 0; i < civList.Count; i++)
        //    {
        //        relationshipsList[i] = new RelationshipInfo[civList.Count];
        //    }

        //}

        //public static void Initialize(List<Civilization> civilizations) // calling this from GameManager at galaxy map setup
        //{

        //    //RelationshipInfo civRelationships = new RelationshipInfo(); //.AddRange(civilizations);
        //    //civRelationshipsTemp = RelationshipInfo[civilizations.Count, civilizations.Count];
        //    foreach (var civ in civilizations)
        //    {
        //        RelationshipManager diploRelations = new RelationshipManager(civilizations);

        //        //for (int i = 0; i < civilizations.Count; i++)
        //        //{
        //        civ._relationshipManager = diploRelations;
        //        for (int j = 0; j < civilizations.Count; j++)
        //        {
        //            diploRelations.relationshipsList.Add(new RelationshipInfo());
        //        }
        //    }
        //}

        //    //foreach (Civilization civ in civilizations)
        //    //{
        //    //    foreach (Civilization otherCiv in civilizations)
        //    //    {
        //    //        if (otherCiv == civ)
        //    //            civRelationships[civ._civID, otherCiv._civID].RelationshipScore = 100;
        //    //        else
        //    //            civRelationships[civ._civID, otherCiv._civID].RelationshipScore = -100;
        //    //    }
        //    //}
        //}
        //public static RelationshipInfo GetRelationshipInfo(Civilization civ1, Civilization civ2)
        //{
        //    if (civRelationships != null)
        //    {
        //        RelationshipInfo relationshipInfo = civRelationships[civ1._civID, civ2._civID];
        //        return relationshipInfo;
        //    }
        //    else
        //    {
        //        INt
        //        return relationshipInfo;
        //    }
        //}
        //public static int GetRelationshipScore(Civilization civ1, Civilization civ2)
        //{
        //    if (civRelationships != null)
        //        return (int)civRelationships[civ1._civID, civ2._civID].RelationshipScore;
        //    else
        //        return 0;
        //}
        //public static int GetRelationshipScore(int civ1, int civ2)
        //{
        //    if(civRelationships != null)
        //        return (int)civRelationships[civ1, civ2].RelationshipScore;
        //    else
        //        return 0;
        //}
    }

    
}
