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

        public virtual void Attack(GameObject target)
        {
            var targetDamagable = target.GetComponent<Damagable>();
            targetDamagable.GainDamage(_source.damageAmount);
        }

        public virtual void Attack(Vector2 localDirection)
        {
            var dealingDamage = _pool.GetOne();
            var positionBuilder = dealingDamage.WithDamage(_source.damageAmount);

            positionBuilder.WithPosition(_source.transform.position + (Vector3) localDirection.normalized * 0.2f);
            positionBuilder.WithRotationTo(localDirection);
            var launchable = positionBuilder.SetTransform();

            launchable.Launch(localDirection, _source.shotForce);
        }
    }
}
