using System;
using UnityEngine;

namespace Assets.SpaceCombat.NonInteractive.Scripts.Starships
{
    [Serializable]
    public class Steering
    {
        [SerializeField]
        private float _maxVelocity = 1f;
        public float MaxVelocity => _maxVelocity;

        [SerializeField]
        private float _accelerationSpeed = 1f;
        public float AccelerationSpeed => _accelerationSpeed; // Amount to increase Acceleration with.

        [SerializeField]
        private float _turnRate = 1f;
        public float TurnRate => _turnRate; 

        [SerializeField]
        private float _maxAcceleration = 1f;
        public float MaxAcceleration => _maxAcceleration;

        [SerializeField]
        private float _minAcceleration = 1f;
        public float MinAcceleration => _minAcceleration;

        public float CurrentVelocity { get; private set; }
        public float CurrentAcceleration { get; private set; }

        public void SetVelocity()
        {
            if (CurrentAcceleration > MaxAcceleration)
            {
                CurrentAcceleration = MaxAcceleration;
            }
            else if (CurrentAcceleration < MinAcceleration)
            {
                CurrentAcceleration = MinAcceleration;
            }

            CurrentVelocity += CurrentAcceleration;

            if (CurrentVelocity > MaxVelocity)
            {
                CurrentVelocity = MaxVelocity; 
            }
            else if (CurrentVelocity < -MaxVelocity)
            {
                CurrentVelocity = -MaxVelocity;
            }
        }
    }
}
