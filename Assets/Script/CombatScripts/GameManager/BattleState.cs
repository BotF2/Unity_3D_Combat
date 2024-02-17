using Assets.Plugins.YAFSM;

namespace Assets.SpaceCombat.AutoBattle.Scripts.GameManager
{
    public class BattleState : State
    {
        public AutoBattleGameManager GameManager
        {
            get { return (AutoBattleGameManager)Machine; }
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
