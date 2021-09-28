using UnityEngine;

namespace Work2.Battle.Entities.Attack.AttackMethods
{
    public interface IPlayerAttackMethod : IAttackMethod
    {
    }

    public interface IAttackMethod
    {
        void AddMethod(AttackMethod newMethod);
        void Attack(Vector2 localDirection);
        void Attack(GameObject target);
    }

}