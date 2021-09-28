using System;
using UnityEngine;
using Work2.Battle.ComputedBehaviour.Entities;
using Work2.Battle.Entities.Attack;

namespace Work2.Battle.ComputedBehaviour.States
{
    public class MeleeAttackState : IState
    {
        private Attacker _source;
        private GameObject _target;
        private float _attackRate;
        private float _lastAttackTime;
        private Transform _attackerPosition;

        public MeleeAttackState(Attacker source, GameObject target)
        {
            _attackerPosition = source.transform;
            _source = source;
            _target = target;
            _attackRate = source.attackRate;
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
            if ((_attackerPosition.position - _target.transform.position).magnitude > 0.2f)
                WorkFinished?.Invoke();

            if (!(_lastAttackTime + _attackRate >= Time.time))
                return;

            _lastAttackTime = Time.time;
            _source.Attack(_target);
        }
    }
}
