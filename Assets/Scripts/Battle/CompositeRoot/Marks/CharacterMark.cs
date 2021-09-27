using UnityEngine;
using Work2.Battle.Entities.Attack.AttackMethods;
using Work2.Battle.Services;

namespace Work2.Battle.CompositeRoot.Helpers
{
    public abstract class CharacterMark : MonoBehaviour
    {
        public abstract IProjectilePool GetPool();
        public abstract IAttackMethod GetAttackMethod();
    }

}
