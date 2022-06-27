using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Plugins.YAFSM;

namespace Assets.SpaceCombat.NonInteractive.Scripts.GameManager
{
    public class BattleState : State
    {
        public NonInteractiveCombatGameManager GameManager
        {
            get { return (NonInteractiveCombatGameManager)Machine; }
        }

        public override void Enter()
        {
            base.Enter();

            foreach (var attackingStarship in GameManager.AttackingStarships)
            {
                attackingStarship.SetAvailableTargets(GameManager.DefendingStarships);
            }

            foreach (var defendingStarship in GameManager.DefendingStarships)
            {
                defendingStarship.SetAvailableTargets(GameManager.AttackingStarships);
            }
        }
    }
}
