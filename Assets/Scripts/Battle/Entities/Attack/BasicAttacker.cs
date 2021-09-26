using UnityEngine;
using Work2.Battle.ProjectileTypes;
using Work2.Battle.Services;

namespace Work2.Battle.Entities.Attack
{
    public class BasicAttacker : Attacker
    {
        [SerializeField] private ProjectilePool _projectilePool;
        [SerializeField] private float _shotForce = 2.5f;
        private Vector3 _attackDirection;
        
        public override void Shot(Vector2 localTarget)
        {
            var projectile = PreparedProjectile();
            var launchable = projectile.GetComponent<ProjectileType>();
            var projectileRotation = projectile.GetComponent<SpecialRotation>();
            projectileRotation.RotateToTarget2D(localTarget);
            launchable.Launch(
                localTarget, _shotForce, new ProjectileWrapper(projectile));

            _attackDirection = localTarget;
        }

        private GameObject PreparedProjectile()
        {
            var projectile = _projectilePool.GetOne();
            var projectileObject = projectile.Value;
            projectileObject.transform.position = transform.position;
            return projectileObject;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, _attackDirection * 0.5f);
        }
    }
}
