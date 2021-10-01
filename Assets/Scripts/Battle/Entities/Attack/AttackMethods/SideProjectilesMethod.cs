using System;
using UnityEngine;
using Work2.Battle.Services;

namespace Work2.Battle.Entities.Attack.AttackMethods
{
    public class SideProjectilesMethod : AttackMethod
    {
        private Attacker _attacker;
        private IProjectilePool _pool;
        private const int _deltaDegree = 30;

        public SideProjectilesMethod(Attacker attacker, IProjectilePool pool) : base(attacker, pool)
        {
            _attacker = attacker;
            _pool = pool;
        }

        public override void Attack(Vector2 localDirection)
        {
            var localDirectionDegree = GetDegreeFromDirection(localDirection);

            var localDegreeRight = localDirectionDegree + _deltaDegree;
            var localDegreeLeft = localDirectionDegree - _deltaDegree;

            var localDirectionRight = GetVectorFromDegree(localDegreeRight);
            var localDirectionLeft = GetVectorFromDegree(localDegreeLeft);
            localDirectionRight *= localDirection.magnitude;
            localDirectionLeft *= localDirection.magnitude;

            base.Attack(localDirectionRight);
            base.Attack(localDirectionLeft);
        }

        private float GetDegreeFromDirection(Vector2 localDirection)
        {
            var radiusVector = localDirection.normalized;
            return (float) Math.Acos(radiusVector.x);
        }

        private Vector2 GetVectorFromDegree(double degree)
        {
            return new Vector2((float) Math.Cos(degree), (float) Math.Sin(degree));
        }
    }
}
