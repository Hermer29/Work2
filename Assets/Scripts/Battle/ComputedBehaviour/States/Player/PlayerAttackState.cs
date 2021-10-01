using System;
using UnityEngine;
using Work2.Battle.Entities;
using Work2.Battle.Entities.Attack;

namespace Work2.Battle.ComputedBehaviour.States
{
    public class PlayerAttackState : AttackState
    {
        private Transform _target;
        private float _fireRate = 2;
        private static float _lastShotTime;
        private Joystick _joystick;
        private Damagable _targetDamagable;

        public PlayerAttackState(GameObject attacker, Transform target, Joystick joystick, float fireRate) : base(attacker, target)
        {
            _target = target;
            _fireRate = fireRate;
            _joystick = joystick;
        }
        
        public override void OnUpdate(Vector2 attackVector, Attacker attacker, Action workFinished)
        {
            if (_joystick.Direction.magnitude > 0.2f)
                workFinished.Invoke();

            if (_lastShotTime + _fireRate > Time.time)
                return;

            _lastShotTime = Time.time;
            UpdateAttackPosition();
            attacker.Attack(attackVector);
        }

        public override void OnStart(Vector2 attackVector, Attacker attacker, Action workFinished)
        {
            _targetDamagable = _target.GetComponent<Damagable>();
            _targetDamagable.Died += workFinished;
        }

        public override void OnExit(Vector2 attackVector, Attacker attacker, Action workFinished)
        {
            _targetDamagable.Died -= workFinished;
        }
    }
}
