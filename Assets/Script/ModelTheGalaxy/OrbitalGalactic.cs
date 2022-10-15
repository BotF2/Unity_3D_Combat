using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class OrbitalGalactic
    {
        public OrbitalGalactic Parent;
        public List<OrbitalGalactic> Children;
        public float InitAngle; // random first angle of orbital to parent in constructor below
        public float OffsetAngle; // angle aroung orbit over time
        public UInt64 OrbitalDistance; // in *meters*
        public UInt64 TimeToOrbit; // in sec to get around the star, ToDo: Kepler's Third Law: the squares
                                   // of the orbital periods of the
                                   // planets are directly proportional to the cubes of the semi-major axes
                                   // of their orbits. Kepler's Third Law implies that the period for a planet
                                   // to orbit the Sun increases rapidly with the radius of its orbit.
        public int GraphicID; // sprit 
        public OrbitalGalactic()
        {
            TimeToOrbit = 1;
            Children = new List<OrbitalGalactic>();
            InitAngle = UnityEngine.Random.Range(0, Mathf.PI * 2);
        }
        public Vector3 Position
        {
            get
            {
                Vector3 myOffset = new Vector3(
                    Mathf.Sin(InitAngle + OffsetAngle) * OrbitalDistance,
                    0,
                    Mathf.Cos(InitAngle + OffsetAngle) * OrbitalDistance
                    ); // y (up/down) is locked to zero but consider addint in 3D
        
                if (Parent != null)
                {
                    myOffset += Parent.Position;
                }
                return myOffset;
            }
        }
        public void Update(UInt64 timeSinceStart)
        {
            // advance angle to current time
            OffsetAngle = 2f * Mathf.PI * (float)timeSinceStart / (float)TimeToOrbit;

            // update all of our children
            for (int i = 0; i < Children.Count; i++)
            {
                Children[i].Update(timeSinceStart);
            }
        }
        public void MakeOrbital()
        {
            OffsetAngle = 0; // North of star Earth
            OrbitalDistance = 150000000000; // 150 million KM
            TimeToOrbit = 365 * 24 * 60 * 60; // for Earth, days * hours * min * sec (in sec)
        }

        public void AddChild(OrbitalGalactic child)
        {
            child.Parent = this;
            Children.Add(child);
        }
        public void RemoveChild(OrbitalGalactic child)
        {
            child.Parent = null;
            Children.Remove(child);
        }
    }
}
