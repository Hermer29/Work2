using Work2.Battle.Entities.Attack;
using Work2.Battle.Entities.Attack.AttackMethods;
using Work2.Battle.Services;
using Zenject;

namespace Work2.Battle.CompositeRoot.Helpers
{
    public class ArcherMark : EnemyMark
    {
        private static IArcherProjectilePool _projectilePool;

        public override IAttackMethod GetAttackMethod()
        {
            var attacker = GetComponent<Attacker>();
            return new AttackMethod(attacker, _projectilePool);
        }

        public override IProjectilePool GetPool()
        {
            return _projectilePool;
        }

        [Inject] private void Construct(IArcherProjectilePool pool)
        {
            if(_projectilePool == null)
            {
                _projectilePool = pool;
            }  
        }
    }
}
