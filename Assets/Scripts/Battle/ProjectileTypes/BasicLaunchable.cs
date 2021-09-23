using Assets.Scripts.Battle.Services.Abstract;
using System.Collections;
using UnityEngine;

namespace Work2.Battle.Attackers.Helpers
{
    public class BasicLaunchable : MonoBehaviour
    {
        private Rigidbody2D _projectilesBody;
        private IProjectileWrapper _wrapper;
        private Vector2 _direction;
        private float _shotForce;

        public void Launch(Vector2 direction, float shotForce, IProjectileWrapper wrapper)
        {
            _wrapper = wrapper;
            _direction = direction;
            _shotForce = shotForce;
            StartCoroutine(FlyToLastPlayersPosition());
        }

        private IEnumerator FlyToLastPlayersPosition()
        {
            while((Vector2) transform.position != _direction)
            {
                _projectilesBody.MovePosition(Vector2.MoveTowards(transform.position, _direction, _shotForce));
                yield return new WaitForSeconds(0.01f);
            }

            _projectilesBody.AddForce(_direction * 2);
        }

        private void OnCollisionEnter2D(Collision2D collision)
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

            throw new UnityEngine.UnityException("Passed to projectiles pool projectiles prefab must has Rigidbody2D");
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position, _direction);
        }
    }
}
