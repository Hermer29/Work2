using System.Collections;
using UnityEngine;
using Work2.Battle.ProjectileTypes;
using Work2.Battle.Services.Abstract;

namespace Work2.Battle.Attackers.Helpers
{
    public class InstantType : ProjectileType
    {
        private Rigidbody2D _projectilesBody;
        private IProjectileWrapper _wrapper;
        private Vector2 _direction;

        public override void Launch(Vector2 direction, float shotForce, IProjectileWrapper wrapper)
        {
            _wrapper = wrapper;
            _direction = direction;
            _projectilesBody.AddForce(direction.normalized * shotForce);
        }

        private void OnBecameInvisible()
        {
            _wrapper.Free();
        }

        private void OnEnable()
        {
            if(TryGetComponent<Rigidbody2D>(out var projectilesBody))
            {
                _projectilesBody = projectilesBody;
                return;
            }

            throw new UnityException("Passed to projectiles pool projectiles prefab must has Rigidbody2D");
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position, _direction);
        }
    }
}
