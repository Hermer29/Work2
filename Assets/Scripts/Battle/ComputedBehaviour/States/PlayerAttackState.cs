using System;
using UnityEngine;
using Work2.Battle.Entities.Attack;

namespace Work2.Battle.ComputedBehaviour.States
{
    class PlayerAttackState : AttackState
    {
        private float _fireRate = 2;
        private static float _lastShotTime;
        private Joystick _joystick;

        public PlayerAttackState(GameObject attacker, Transform target, Joystick joystick, float fireRate) : base(attacker, target)
        {
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
    }
}
