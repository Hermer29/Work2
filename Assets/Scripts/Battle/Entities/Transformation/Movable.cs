using System;
using UnityEngine;

namespace Work2.Battle.Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movable : MonoBehaviour
    {
        private Rigidbody2D _body;
        [SerializeField] private float _speed = 5;

        public event Action<Vector2> Moving;

        public Vector2 LastDirection { get; private set; }

        public float Speed
        {
            get => _speed;
            set
            {
                _speed = Mathf.Clamp(value, 0, 60);
            }
        }

        private void OnValidate()
        {
            Speed = _speed;
        }

        private void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
        }

        public virtual void Move(Vector2 localDirection)
        {
            LastDirection = localDirection;
            Moving?.Invoke(localDirection);
            _body.MovePosition((Vector2)_body.gameObject.transform.position + localDirection * (_speed));
        }

        public virtual void Stop()
        {
            _body.velocity = Vector2.zero;
            _body.angularVelocity = 0;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, (Vector2) transform.position + LastDirection * _speed);
        }
    }
}