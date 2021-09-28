using UnityEngine;
using Work2.Battle.Entities;
using Work2.Battle.ProjectileTypes;
using Work2.Battle.Services.Abstract;

namespace Work2.Battle.Attackers.Helpers
{
    public class InstantType : ProjectileType
    {
        private bool _launchStarted = false;
        private IProjectileWrapper _wrapper;
        private Vector2 _direction;
        private float _shotForce;

        public override void Launch(Vector2 direction, float shotForce, IProjectileWrapper wrapper)
        {
            _wrapper = wrapper;
            _direction = direction;
            _shotForce = shotForce;
            _launchStarted = true;
        }

        private void Update()
        {
            if (_launchStarted)
                transform.position = transform.position + (Vector3) _direction.normalized * 
                    (_shotForce * Time.deltaTime);
        }

        private void OnBecameInvisible()
        {
            if(_launchStarted)
            {
                _launchStarted = false;
                _wrapper.Free();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(_launchStarted)
            {
                if(collision.gameObject.TryGetComponent<Hitbox>(out var hitbox))
                {
                    var stalkedDamageable = hitbox.Damageable;
                    stalkedDamageable.GainDamage(Damage);
                }
                else
                {
                    hitbox = collision.gameObject.GetComponentInChildren<Hitbox>();
                    if(hitbox != null)
                    {
                        var stalkedDamageable = hitbox.Damageable;
                        stalkedDamageable.GainDamage(Damage);
                    }
                }
                _launchStarted = false;
                _wrapper.Free();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_launchStarted)
            {
                if (collision.gameObject.TryGetComponent<Hitbox>(out var hitbox))
                {
                    var stalkedDamageable = hitbox.Damageable;
                    stalkedDamageable.GainDamage(Damage);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position, _direction);
        }
    }
}
