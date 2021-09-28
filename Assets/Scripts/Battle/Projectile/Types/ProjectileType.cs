using System;
using UnityEngine;
using Work2.Battle.Services.Abstract;

namespace Work2.Battle.ProjectileTypes
{
    public abstract class ProjectileType : MonoBehaviour
    {
        public float Damage { get; private set; } = 0;

        public void SetDealingDamage(float amount)
        {
            if (Damage != 0)
                throw new InvalidOperationException($"{nameof(amount)} can be set only once");
                
            Damage = amount;
        }

        private void OnDisable()
        {
            Damage = 0;
        }

        public abstract void Launch(Vector2 direction, float velocity, IProjectileWrapper disposeWay);
    }
}
