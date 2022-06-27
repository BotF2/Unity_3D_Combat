using System;
using UnityEngine;

namespace Assets.SpaceCombat.NonInteractive.Scripts
{
    [Serializable]
    public class Steering
    {
        [SerializeField]
        private float _maxVelocity = 1f;
        public float MaxVelocity => _maxVelocity; // Maximum Velocity

        [SerializeField]
        private float _accelerationSpeed = 1f;
        public float AccelerationSpeed => _accelerationSpeed; // Amount to increase Acceleration with.

        [SerializeField]
        private float _turnSpeed = 1f;
        public float TurnSpeed => _turnSpeed; // Amount to increase Acceleration with.

        [SerializeField]
        private float _maxAcceleration = 1f;
        public float MaxAcceleration => _maxAcceleration; // Amount to increase Acceleration with.

        [SerializeField]
        private float _minAcceleration = 1f;
        public float MinAcceleration => _minAcceleration; // Amount to increase Acceleration with.

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
