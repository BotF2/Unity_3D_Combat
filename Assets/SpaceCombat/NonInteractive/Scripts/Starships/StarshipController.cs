﻿using System;
using Assets.Plugins.YAFSM;
using Assets.SpaceCombat.NonInteractive.Scripts.Starships.States;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SpaceCombat.NonInteractive.Scripts.Starships
{
    public abstract class StarshipController : MachineBehaviour
    {
        [SerializeField] private Steering _steering;
        public Steering Steering => _steering;
        public List<StarshipController> AvailableTargets { get; private set; }
        public StarshipController CurrentTarget { get; set; }
        public float Radius { get; private set; }

        public int HitPoints { get; set;  } = 100;

        public WeaponsManager WeaponsManager { get; private set; }
        

        public override void Awake()
        {
            base.Awake();

            var myCollider = GetComponent<CapsuleCollider>();
            Radius = myCollider.radius;

            WeaponsManager = GetComponent<WeaponsManager>();
            WeaponsManager.StarshipCollider = myCollider;
        }

        protected override void AddStates()
        {
            AddState<IdleState>();
            AddState<FindNextTargetState>();
            AddState<SeekTargetState>();
            AddState<EngageTargetState>();

            SetInitialState<IdleState>();
        }

        public void SetAvailableTargets(List<StarshipController> availableTargets)
        {
            AvailableTargets = availableTargets;
            ChangeState<FindNextTargetState>();
        }

        public override void OnCollisionEnter(Collision collision)
        {
            base.OnCollisionEnter(collision);


            if (HitPoints > 0)
            {
                HitPoints -= 10;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
