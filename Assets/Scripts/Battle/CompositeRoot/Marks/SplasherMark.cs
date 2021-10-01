using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Work2.Battle.CompositeRoot.Helpers;
using Work2.Battle.Entities.Attack;
using Work2.Battle.Entities.Attack.AttackMethods;
using Work2.Battle.Services;
using Zenject;

namespace Work2.Battle.CompositeRoot.Marks
{
    [RequireComponent(typeof(Attacker))]
    public class SplasherMark : EnemyMark
    {
        private IProjectilePool _pool;

        [Inject] private void Construct(ISplasherProjectilePool pool)
        {
            _pool = pool;
        }

        public override IAttackMethod GetAttackMethod()
        {
            var attacker = GetComponent<Attacker>();
            return new SplashAroundAttackMethod(attacker, GetPool(), 10);
        }

        public override IProjectilePool GetPool()
        {
            return _pool;
        }
    }
}