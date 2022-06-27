using Assets.Plugins.YAFSM;
using UnityEngine;

namespace Assets.SpaceCombat.NonInteractive.Scripts.Starships.States
{
    public class FindNextTargetState : State
    {
        private StarshipController StarshipController => (StarshipController)Machine;
    
        public override void Enter()
        {
            base.Enter();

            StarshipController.CurrentTarget = FindNearestTarget();

            if (StarshipController.CurrentTarget != null)
            {
                StarshipController.ChangeState<SeekTargetState>();
            }
            else
            {
                StarshipController.ChangeState<IdleState>();
            }
        }

        private StarshipController FindNearestTarget()
        {
            StarshipController foundTarget = null;

            float minimumDistance = Mathf.Infinity;

            foreach (var availableTarget in StarshipController.AvailableTargets)
            {
                float distance = Vector3.Distance(availableTarget.transform.position, StarshipController.transform.position);

                if (distance < minimumDistance)
                {
                    foundTarget = availableTarget;
                    minimumDistance = distance;
                }
            }

            return foundTarget;
        }
    }
}
