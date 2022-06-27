using Assets.Plugins.YAFSM;
using UnityEngine;

namespace Assets.SpaceCombat.NonInteractive.Scripts.Starships.States
{
    public class SeekTargetState : State
    {
        private StarshipController StarshipController => (StarshipController)Machine;

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            StarshipController.Steering.SetVelocity();

            StarshipController.transform.Translate(StarshipController.transform.forward * StarshipController.Steering.CurrentVelocity * Time.deltaTime, Space.World);

            var targetRotation = Quaternion.LookRotation(StarshipController.CurrentTarget.transform.position - StarshipController.transform.position);
            var turningStrength = Mathf.Min(StarshipController.Steering.TurnSpeed * Time.deltaTime, 1);
            StarshipController.transform.rotation = Quaternion.Lerp(StarshipController.transform.rotation, targetRotation, turningStrength);

            // If we are within weapons range, attack target
        }


    }
}