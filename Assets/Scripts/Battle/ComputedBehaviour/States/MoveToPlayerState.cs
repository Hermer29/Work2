using System;
using UnityEngine;
using UnityEngine.AI;
using Work2.Battle.ComputedBehaviour.Entities;

namespace Work2.Battle.ComputedBehaviour.States
{
    class MoveToPlayerState : IState
    {
        private Transform _attackableTransform;
        private Transform _attackerTransform;

        public MoveToPlayerState(Transform attackableTransform, Transform attackerTransform)
        {
            _attackerTransform = attackerTransform;
            _attackableTransform = attackableTransform;
        }

        public event Action WorkFinished;

        public void Exit()
        {
            
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            var vectorToAttackable = _attackableTransform.position - _attackerTransform.position;
            if (vectorToAttackable.magnitude < 0.2f)
                WorkFinished?.Invoke();
        }
    }
}
