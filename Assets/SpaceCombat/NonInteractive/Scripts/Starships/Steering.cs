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

        private float _desiredVelocity;

        public StarshipController StarshipController { get; set; }

        public void SteeringUpdate()
        {
            UpdateVelocity();
            UpdateAcceleration();

            //TODO: Need to check for collision avoidance

            StarshipController.transform.Translate(StarshipController.transform.forward * CurrentVelocity * Time.deltaTime, Space.World);

            if (StarshipController.CurrentTarget != null)
            {
                var targetRotation = Quaternion.LookRotation(StarshipController.CurrentTarget.transform.position - StarshipController.transform.position);
                var turningStrength = Mathf.Min(_turnRate * Time.deltaTime, 1);
                Debug.Log($"{targetRotation}, {turningStrength}");
                float rotationZ = 0.1f * Mathf.Sin(Time.time * CurrentVelocity);
                StarshipController.transform.Rotate(new Vector3(0f, 0f, rotationZ));
                StarshipController.transform.rotation = Quaternion.Lerp(StarshipController.transform.rotation, targetRotation, turningStrength);
            }
        }

        public void SetDesiredVelocity(float desiredVelocity)
        {
            _desiredVelocity = desiredVelocity;
        }

        private void UpdateAcceleration()
        {
            if (_desiredVelocity > 0 || _desiredVelocity < CurrentVelocity)
            {
                CurrentAcceleration += _accelerationSpeed * Time.deltaTime;
            }
            else if (_desiredVelocity < 0 || _desiredVelocity > CurrentVelocity)
            {
                CurrentAcceleration -= _accelerationSpeed * Time.deltaTime;
            }

            if (CurrentAcceleration > MaxAcceleration)
            {
                CurrentAcceleration = MaxAcceleration;
            }
            else if (CurrentAcceleration < MinAcceleration)
            {
                CurrentAcceleration = MinAcceleration;
            }
        }

        private void UpdateVelocity()
        {
            CurrentVelocity += CurrentAcceleration;

            if (_desiredVelocity > 0 && _desiredVelocity > CurrentVelocity && _desiredVelocity < MaxVelocity)
            {
                CurrentVelocity = _desiredVelocity;
            }
            else if (_desiredVelocity < 0 && _desiredVelocity < CurrentVelocity && _desiredVelocity > -MaxVelocity)
            {
                CurrentVelocity = _desiredVelocity;
            }
            else if (CurrentVelocity > MaxVelocity)
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
