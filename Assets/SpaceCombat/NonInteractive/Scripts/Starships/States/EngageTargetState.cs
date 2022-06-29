using Assets.Plugins.YAFSM;
using UnityEngine;

namespace Assets.SpaceCombat.NonInteractive.Scripts.Starships.States
{
    public class EngageTargetState : State
    {
        private StarshipController StarshipController => (StarshipController)Machine;

        public override void Update()
        {
            base.Update();

            StarshipController.WeaponsManager.FireEverything(StarshipController.CurrentTarget.transform);
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            StarshipController.Steering.SetVelocity();

            StarshipController.transform.Translate(StarshipController.transform.forward * StarshipController.Steering.CurrentVelocity * Time.deltaTime, Space.World);

            var targetRotation = Quaternion.LookRotation(StarshipController.CurrentTarget.transform.position - StarshipController.transform.position);
            var turningStrength = Mathf.Min(StarshipController.Steering.TurnRate * Time.deltaTime, 1);
            StarshipController.transform.rotation = Quaternion.Lerp(StarshipController.transform.rotation, targetRotation, turningStrength);


            var targetDistance = Vector3.Distance(StarshipController.CurrentTarget.transform.position, StarshipController.transform.position);
            if (targetDistance > StarshipController.WeaponsManager.WeaponsRange)
            {
                StarshipController.ChangeState<SeekTargetState>();
            }

            if (StarshipController.CurrentTarget.HitPoints <= 0)
            {
                StarshipController.ChangeState<FindNextTargetState>();
            }
        }
    }
}
