using System;
using System.Collections.Generic;
using Assets.Plugins.YAFSM;
using Assets.SpaceCombat.AutoBattle.Scripts.Starships;
using UnityEngine;

namespace Assets.SpaceCombat.AutoBattle.Scripts.GameManager
{
    public class AutoBattleGameManager : MachineBehaviour
    {
        [SerializeField] public List<StarshipInfo> AttackersPrefabs = new();
        [SerializeField] public List<StarshipInfo> DefendersPrefabs = new();
        [SerializeField] public int MaxStarshipsWidth = 10;

        [SerializeField] private GameObject _attackersGameObject;
        [SerializeField] private GameObject _defendersGameObject;

        public GameObject AttackersGameObject => _attackersGameObject;
        public GameObject DefendersGameObject => _defendersGameObject;

        public List<StarshipController> AttackingStarships = new();
        public List<StarshipController> DefendingStarships = new();
        // Start is called before the first frame update
        protected override void AddStates()
        {
            AddState<DeployState>();
            AddState<BattleState>();

            SetInitialState<DeployState>();
        }
    }

    [Serializable]
    public class StarshipInfo
    {
        [SerializeField] public GameObject GameObject;
        [SerializeField] public int ShipCount;
    }
}
