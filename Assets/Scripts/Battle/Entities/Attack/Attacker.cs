using UnityEngine;
using Work2.Battle.CompositeRoot.Helpers;
using Work2.Battle.Entities.Attack.AttackMethods;
using Work2.Battle.ProjectileTypes;
using Work2.Battle.Services;

namespace Work2.Battle.Entities.Attack
{
    public class Attacker : MonoBehaviour
    {
        public float shotForce = 2.5f;
        public float damageAmount = 100;
        public float attackRate = 1f;
        private Vector3 _attackDirection;
        private IAttackMethod _method;

        private void Start()
        {
            var specialInfo = GetComponent<CharacterMark>();
            _method = specialInfo.GetAttackMethod();
        }

        public void Attack(Vector2 localTarget)
        {
            _method.Attack(localTarget);
            _attackDirection = localTarget;
        }

        public void Attack(GameObject target)
        {
            _method.Attack(target);
            _attackDirection = target.transform.position;
        }

        public void AddMethod(AttackMethod method)
        {
            _method.AddMethod(method);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, _attackDirection * 0.5f);
        }
    }
}