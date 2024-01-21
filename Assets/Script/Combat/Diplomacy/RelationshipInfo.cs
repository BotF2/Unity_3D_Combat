using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BOTF3D_GalaxyMap;
using BOTF3D_Core;
using BOTF3D_Combat;
using Unity.VisualScripting;
using System;

namespace Assets.Script
{
    //[Serializable]
    public class RelationshipInfo 
    {
        // the RelationshipInfo class can store properties of the civ relationships for RelationshipManager
        public int RelationshipScore = -100; // to +100
        //public int[] relationshipInfo; // array of infor scores
        public bool HasTrade = false; // just an example of a relationship property
        public RelationshipInfo()
        {
            RelationshipScore = -100;
            HasTrade = false;
        }

        public bool IsUnknown
        {
            get { return this.RelationshipScore < -95; } // if Unknown, relationship score is -100 and on first contact add 100 to score zero
        }
        public bool IsTotalWar
        {
            get { return this.RelationshipScore < -90 && this.RelationshipScore >= -95; } // another example of a relationship property
        }
        public bool IsColdWar
        {
            get { return this.RelationshipScore < -50 && this.RelationshipScore >= -90; } // another example of a relationship property
        }
        public bool IsNeutral
        {
            get { return this.RelationshipScore >= -50 && this.RelationshipScore <= 50; } // another example of a relationship property
        }
        public bool IsFriend
        {
            get { return this.RelationshipScore > 50 && this.RelationshipScore <=75; } // another example of a relationship property
        }
        public bool IsAlly
        {
            get { return this.RelationshipScore > 75 && this.RelationshipScore <= 90; } // another example of a relationship property
        }
        public bool IsUnified // with major to major
        {
            get { return this.RelationshipScore > 90; } // another example of a relationship property
        }
        //see CivilizationData DoDiplomacy(int relationScore)
    }
    //public class Civilization and CivilizationData
    //public static class RelationshipManager
}
