using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class OrbitalGalactic
    {
        public OrbitalGalactic()
        {
            TimeToOrbit = 1;
            Children = new List<OrbitalGalactic>();
        }
        public OrbitalGalactic Parent;
        public List<OrbitalGalactic> Children;
        public float Angle; // angle aroung orbit
        public UInt64 OrbitalDistance; // in *meters*
        public UInt64 TimeToOrbit; // in sec, ToDo: Kepler's Third Law: the squares of the orbital periods of the
                                   // planets are directly proportional to the cubes of the semi-major axes
                                   // of their orbits. Kepler's Third Law implies that the period for a planet
                                   // to orbit the Sun increases rapidly with the radius of its orbit.
        public int graphicID;
        public Vector3 Position
        {
            get
            {
                return new Vector3(
                    Mathf.Sin(Angle) * OrbitalDistance,
                    Mathf.Cos(Angle) * OrbitalDistance,
                    0
                    ); // z is locked to zero but consider addint in 3D
                // ToDo: convert oribtal info into vector to render GameObject in unity
            }
        }
        public void Update(UInt64 timeSinceStart)
        {
            // advance angle to current time
            Angle = (timeSinceStart / TimeToOrbit) * 2 * Mathf.PI;

            // update all of our children
            for (int i = 0; i < Children.Count; i++)
            {
                Children[i].Update(timeSinceStart);
            }
        }

        public void MakeOrbital()
        {
            Angle = 0; // North of star
            OrbitalDistance = 150000000000; // 150 million KM
            TimeToOrbit = 365 * 24 * 60 * 60; // for Earth, days * hours * min * sec (in sec)
        }

        public void Addchild(OrbitalGalactic child)
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
