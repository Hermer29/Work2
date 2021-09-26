using System;
using UnityEngine;
using Work2.Battle.Entities;
using Work2.Battle.ComputedBehaviour.Entities;
using Work2.Battle.Entities.Attack;

namespace Work2.Battle.ComputedBehaviour.States
{
    public class AttackState : IState
    {
        private SpecialRotation _rotation;
        private GameObject _enemy;
        private Transform _playersTransform;
        private Vector2 _attackVector;
        private Attacker _enemyAttacker;

        public event Action WorkFinished;

        public AttackState(GameObject enemy, Transform playersTransform)
        {
            _enemy = enemy;
            _playersTransform = playersTransform;
            _rotation = _enemy.GetComponent<SpecialRotation>();
            _enemyAttacker = _enemy.GetComponent<Attacker>();
        }

        public void Exit() { }

        public void Start()
        {
            var localVector = _playersTransform.position - _enemy.transform.position;
            _attackVector = localVector;
            _enemy.transform.rotation = _rotation.RotationToTarget2D(_attackVector);
        }

        public void Update()
        {
            _enemyAttacker.Shot(_attackVector);
            WorkFinished?.Invoke();
        }
    }
}
