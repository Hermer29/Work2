using Work2.Battle.CompositeRoot.Helpers;
using Work2.Battle.Entities.Attack;
using Work2.Battle.Entities.Attack.AttackMethods;
using Work2.Battle.Services;

namespace Work2.Battle.CompositeRoot.Marks
{
    public class MeleeMark : EnemyMark
    {
        public override IAttackMethod GetAttackMethod()
        {
            var attacker = GetComponent<Attacker>();
            return new AttackMethod(attacker, null);
        }

        public override IProjectilePool GetPool()
        {
            return null;
        }
    }
}
