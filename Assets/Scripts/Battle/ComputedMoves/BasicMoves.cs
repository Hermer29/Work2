using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Work2.Battle.Attackers;

namespace Work2.Battle.ComputedMoves
{
    class BasicMoves : MonoBehaviour
    {
        private Rigidbody2D _attackersBody;
        [Range(0.001f,100)][SerializeField] private float _speed;

        private Vector2 _currentDirection;
        private Quaternion _currentRotation;

        private void Awake()
        {
            _attackersBody = GetComponent<Rigidbody2D>();
            _attackersBody.GetComponent<Attacker>()
                .Reload += MoveOnReload;
        }

        private void MoveOnReload(float time)
        {
            var localDirection = GetMovementVector(time, _speed);
            var globalDirection = (Vector2)transform.position + localDirection; 
            _currentDirection = globalDirection;
            RotateToMovementDirection(localDirection);
            StartCoroutine(MoveSlowly());
        }

        private IEnumerator MoveSlowly()
        {

            while ((Vector2) transform.position != _currentDirection)
            {
                _attackersBody.MovePosition(Vector3.MoveTowards(transform.position, _currentDirection, 0.1f));
                yield return new WaitForSeconds(0.01f);
            }
        }

        private void RotateToMovementDirection(Vector3 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            var targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

            StartCoroutine(RotateSlowly());
        }

        private IEnumerator RotateSlowly()
        {
            var rotationStep = 100;
            var stepRotation = _currentRotation.z / rotationStep;

            while(transform.rotation != _currentRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, _currentRotation, stepRotation);
                yield return new WaitForSeconds(0.01f);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _attackersBody.angularVelocity = 0;
            StopAllCoroutines();
        }

        private Vector2 GetMovementVector(float time, float velocity)
        {
            const float mapSizeFactor = 0.1f;
            var pathLength = time * velocity * mapSizeFactor;
            var randomDegree = UnityEngine.Random.Range(0, 180);

            var y = (float)Math.Sin(randomDegree);
            var x = (float)Math.Cos(randomDegree);
            var direction = new Vector3(x, y);

            var result = direction * pathLength;

            if (Physics2D.Raycast(transform.position, result))
                return -result;
            return result;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, _currentDirection);
            Gizmos.DrawWireSphere(_currentDirection, 0.3f);
            Gizmos.color = Color.white;
        }
    }
}
