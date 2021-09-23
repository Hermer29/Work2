using Assets.Scripts.Battle.Services;
using UnityEngine;
using Work2.Battle.Attackers.Helpers;

namespace Work2.Battle.Attackers
{
    public class BasicAttacker : Attacker
    {
        [SerializeField] private ProjectilePool _projectilePool;
        private Vector3 _attackDirection;

        public override void Shot(Vector2 direction)
        {
            var projectile = _projectilePool.GetOne();
            projectile.Value.transform.position = transform.position;
            var launchable = projectile.Value.AddComponent<BasicLaunchable>();
            launchable.Launch(direction, 0.5f, projectile);
            _attackDirection = direction;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, _attackDirection * 0.5f);
            Gizmos.color = Color.white;
        }
    }
}
