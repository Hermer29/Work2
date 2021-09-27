using Work2.Battle.Entities.Attack.AttackMethods;
using Work2.Battle.Services;
using Zenject;

namespace Work2.Battle.CompositeRoot.Helpers
{
    public class PlayerMark : CharacterMark
    {
        private IPlayerProjectilePool _projectilePool;
        private IPlayerAttackMethod _playerAttackMethod;

        public override IAttackMethod GetAttackMethod()
        {
            return _playerAttackMethod;
        }

        public override IProjectilePool GetPool()
        {
            return _projectilePool;
        }

        [Inject]
        private void Construct(
            IPlayerProjectilePool pool,
            IPlayerAttackMethod method)
        {
            _playerAttackMethod = method;
            _projectilePool = pool;
        }
    }
}
