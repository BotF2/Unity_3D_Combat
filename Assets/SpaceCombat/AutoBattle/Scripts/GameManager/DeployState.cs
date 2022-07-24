using System;
using System.Collections.Generic;
using Assets.Plugins.YAFSM;
using Assets.SpaceCombat.AutoBattle.Scripts.Starships;
using UnityEngine;
using Object = UnityEngine.Object;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

namespace Assets.SpaceCombat.AutoBattle.Scripts.GameManager
{
    public class DeployState : State
    {
        public AutoBattleGameManager GameManager
        {
            get { return (AutoBattleGameManager)Machine; }
        }

        public override void Enter()
        {
            base.Enter();
        
            var starships = DeployStarships(GameManager.AttackersPrefabs, GameManager.AttackersGameObject, false);
            GameManager.AttackingStarships.AddRange(starships);
        
            starships = DeployStarships(GameManager.DefendersPrefabs, GameManager.DefendersGameObject, true);
            GameManager.DefendingStarships.AddRange(starships);

            GameManager.ChangeState<BattleState>();
        }

        private List<StarshipController> DeployStarships(List<StarshipInfo> starshipInfoPrefabs, GameObject parentGameObject, bool rotateGameObject)
        {
            var starships = new List<StarshipController>();
            var currentStarshipPosition = new CurrentStarshipPositionInfo
            {
                Position = parentGameObject.transform.position
            };

            int numberOfShipsInRow = 0;

            foreach (var starshipInfo in starshipInfoPrefabs)
            {
                for (int i = 0; i < starshipInfo.ShipCount; i++)
                {
                    var position = currentStarshipPosition.Position;

                    if (i > 0)
                    {
                        if (currentStarshipPosition.AddToTheRight)
                        {
                            currentStarshipPosition.AddToTheRight = false;
                            position.x = Math.Abs(position.x) + CurrentStarshipPositionInfo.XModifier;
                        }
                        else
                        {
                            currentStarshipPosition.AddToTheRight = true;
                            position.x = -position.x;
                        }
                    }

                    position = AddPlacementNoise(position);

                    var gameObject = Object.Instantiate(starshipInfo.GameObject, position, Quaternion.identity, parentGameObject.transform);

                    if (rotateGameObject)
                    {
                        gameObject.transform.Rotate(0f, 180f, 0f);
                    }

                    starships.Add(gameObject.GetComponent<StarshipController>());

                    numberOfShipsInRow++;

                    if (numberOfShipsInRow >= GameManager.MaxStarshipsWidth)
                    {
                        position.x = 0;
                        position.y = ModifyYAxis(currentStarshipPosition, position.y);
                        numberOfShipsInRow = 0;
                    }

                    currentStarshipPosition.Position = position;
                }
            }

            return starships;
        }

        private Vector3 AddPlacementNoise(Vector3 position)
        {
            const float noise = 0.05f;
            position.x += Random.Range(-noise, noise);
            position.y += Random.Range(-noise, noise);

            return position;
        }

        private float ModifyYAxis(CurrentStarshipPositionInfo currentStarshipPositionInfo, float yPos)
        {
            if (currentStarshipPositionInfo.AddAbove)
            {
                currentStarshipPositionInfo.AddAbove = false;
                yPos = Math.Abs(yPos) + CurrentStarshipPositionInfo.YModifier;
            }
            else
            {
                currentStarshipPositionInfo.AddAbove = true;
                yPos = -yPos;
            }

            return yPos;
        }

        public override void Exit()
        {
            base.Exit();
        }

        private class CurrentStarshipPositionInfo
        {
            public bool AddToTheRight { get; set; } = true;
            public Vector3 Position { get; set; }

            public const int XModifier = 1;
            public const int YModifier = 1;

            public bool AddAbove { get; set; } = true;
            //int yAxis = 0;

        }
    }
}
