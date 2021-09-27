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
        private GameObject _attackerObject;
        private Transform _attackableTransform;
        private Vector2 _attackVector;
        private Attacker _attacker;

        public event Action WorkFinished;

        public AttackState(GameObject attacker, Transform attackable)
        {
            _attackerObject = attacker;
            _attackableTransform = attackable;
            _rotation = _attackerObject.GetComponent<SpecialRotation>();
            _attacker = _attackerObject.GetComponent<Attacker>();
        }

        protected void UpdateAttackPosition()
        {
            var localVector = _attackableTransform.position - _attackerObject.transform.position;
            _attackVector = localVector;
        }

        public virtual void OnUpdate(Vector2 attackVector, Attacker attacker, Action workFinished)
        {
            _attacker.Attack(attackVector);
            WorkFinished?.Invoke();
        }

        public void Exit() { }

        public void Start()
        {
            UpdateAttackPosition();
            _attackerObject.transform.rotation = _rotation.RotationToTarget2D(_attackVector);
        }

        public void Update()
        {
            OnUpdate(_attackVector, _attacker, () => WorkFinished?.Invoke());
        }
    }
}
