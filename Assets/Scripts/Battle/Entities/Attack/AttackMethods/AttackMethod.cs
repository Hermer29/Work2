using UnityEngine;
using Work2.Battle.Services;

namespace Work2.Battle.Entities.Attack.AttackMethods
{
    public class AttackMethod : IPlayerAttackMethod
    {
        private Attacker _source;
        private IProjectilePool _pool;
        private AttackMethod _inner;

        public AttackMethod(Attacker attacker, IProjectilePool pool)
        {
            _source = attacker;
            _pool = pool;
        }

        public void AddMethod(AttackMethod newMethod)
        {
            var current = _inner;
            while(current._inner != null)
            {
                current = current._inner;
            }
            current._inner = newMethod;
        }

        public virtual void Attack(Vector2 localDirection)
        {
            var projectileForLaunch = _pool.GetOne();
            projectileForLaunch.WithPosition(_source.transform.position);
            projectileForLaunch.WithRotationTo(localDirection);
            projectileForLaunch.Launch(localDirection, 2);
        }
    }
}
