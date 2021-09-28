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
        private Movable _attackableMovable;

        public event Action WorkFinished;

        public AttackState(GameObject attacker, Transform attackable)
        {
            _attackerObject = attacker;
            _attackableTransform = attackable;
            _rotation = _attackerObject.GetComponent<SpecialRotation>();
            _attacker = _attackerObject.GetComponent<Attacker>();
            _attackableMovable = _attackableTransform.gameObject.GetComponent<Movable>();
        }

        protected void UpdateAttackPosition()
        {
            Vector2 attackableLastMovement = Vector2.zero;
            if(_attackableMovable != null)
                attackableLastMovement = _attackableMovable.LastDirection * _attackableMovable.Speed * 2;
            var localVector = _attackableTransform.position - _attackerObject.transform.position + (Vector3) attackableLastMovement;
            _attackVector = localVector;
            _attackerObject.transform.rotation = _rotation.RotationToTarget2D(_attackVector);
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
        }

        public void Update()
        {
            OnUpdate(_attackVector, _attacker, () => WorkFinished?.Invoke());
        }
    }
}
