//using System;
//using System.Collections;
//using UnityEngine;
//using Work2.Battle.Attackers;

//namespace Work2.Battle.ComputedMoves
//{
//    class EnemyContext : MonoBehaviour
//    {
//        private Rigidbody2D _attackersBody;
//        [Range(0.001f,100)][SerializeField] private float _speed;

//        private Vector2 _currentDirection;
//        private SpecialRotation _objectRotation;

//        private void Awake()
//        {
//            _objectRotation = new SpecialRotation(gameObject);
//            _attackersBody = GetComponent<Rigidbody2D>();
//            _attackersBody.GetComponent<Attacker>()
//                .Reload += MoveOnReload;
//        }

//        private void MoveOnReload(float time)
//        {
//            var localDirection = GetMovementVector(time, _speed);
//            var globalDirection = (Vector2)transform.position + localDirection; 
//            _currentDirection = globalDirection;
//            _objectRotation.SlowlyRotationCoroutine(localDirection, 4, () =>
//            {
//                StartCoroutine(MoveSlowly());
//            });
//        }

//        private IEnumerator MoveSlowly()
//        {
//            while ((Vector2) transform.position != _currentDirection)
//            {
//                _attackersBody.MovePosition(Vector3.MoveTowards(transform.position, _currentDirection, 0.1f));
//                yield return new WaitForSeconds(0.01f);
//            }
//        }

//        private void OnCollisionEnter2D(Collision2D collision)
//        {
//            _attackersBody.angularVelocity = 0;
//            StopAllCoroutines();
//        }

//        

//        private void OnDrawGizmos()
//        {
//            Gizmos.color = Color.green;
//            Gizmos.DrawLine(transform.position, _currentDirection);
//            Gizmos.DrawWireSphere(_currentDirection, 0.3f);
//            Gizmos.color = Color.white;
//        }

//        public void Move(Vector2 direction)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
