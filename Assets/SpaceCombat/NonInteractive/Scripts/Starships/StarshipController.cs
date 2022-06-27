using Assets.SpaceCombat.NonInteractive.Scripts.Starships.States;
using System.Collections.Generic;
using Assets.Plugins.YAFSM;
using UnityEngine;

namespace Assets.SpaceCombat.NonInteractive.Scripts.Starships
{
    public abstract class StarshipController : MachineBehaviour
    {
        public Steering Steering;
        //[SerializeField] public Steering Steering { get; set; } = new Steering();
        public List<StarshipController> AvailableTargets { get; private set; }
        public StarshipController CurrentTarget { get; set; }


        protected override void AddStates()
        {
            AddState<IdleState>();
            AddState<FindNextTargetState>();
            AddState<SeekTargetState>();

            SetInitialState<IdleState>();
        }

        public void SetAvailableTargets(List<StarshipController> availableTargets)
        {
            AvailableTargets = availableTargets;
            ChangeState<FindNextTargetState>();
        }
    }
}
