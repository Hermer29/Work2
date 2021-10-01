using System;
using System.Collections.Generic;
using UnityEngine;
using Work2.Battle.Services;
using Work2.Battle.Services.Abstract;

namespace Work2.Battle.Entities.Attack.AttackMethods
{
    public class SplashAroundAttackMethod : AttackMethod
    {
        private Attacker _attacker;
        private IProjectilePool _pool;
        private int _projectilesCount;

        public SplashAroundAttackMethod(Attacker attacker, IProjectilePool pool, int projectiles) : base(attacker, pool)
        {
            if (projectiles <= 2)
                throw new ArgumentOutOfRangeException(nameof(projectiles));

            _attacker = attacker;
            _pool = pool;
            _projectilesCount = projectiles;
        }

        public override void Attack(Vector2 localDirection)
        {
            var step = 360f / (float) _projectilesCount;
            var everyAngle = -180f;
            var rotation = _attacker.transform.rotation;
            var rotation2d = rotation.z;

            for(int i = 0; i < _projectilesCount + 1; i++)
            {
                var newProjectile = _pool.GetOne();
                var projectileStage1 = newProjectile.WithDamage(_attacker.damageAmount);
                var newRadiusVector = GetVectorToAngleFrom(rotation2d, everyAngle);
                projectileStage1.WithPosition(_attacker.transform.position);
                var stage2 = projectileStage1.SetTransform();
                stage2.Launch(newRadiusVector, _attacker.shotForce);
                everyAngle += step;       
            }
        }

        private Vector2 GetVectorToAngleFrom(float from, float degree)
        {
            degree += from;
            var direction = new Vector2(Mathf.Cos(degree), Mathf.Sin(degree));
            return direction;
        }
    }
}
