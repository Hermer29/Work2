using System;
using UnityEngine;

namespace Work2.Battle.Attackers
{
    public abstract class Attacker : MonoBehaviour
    {
        [SerializeField][Range(1, 100)] private float _fireRate = 1;
        [SerializeField] private GameObject _playersObject;
        private float _nextFireTime;
        public event Action<float> Reload;

        private void Update()
        {
            if (_nextFireTime >= Time.time)
                return;

            _nextFireTime = Time.time + _fireRate;
            var preciseShot = CorrectTargetByPlayersSpeed();
            RotateToTarget(preciseShot);
            Shot(preciseShot);
            Reload?.Invoke(_fireRate);
        }

        private Vector2 CorrectTargetByPlayersSpeed()
        {
            var playersBody = _playersObject.GetComponent<Rigidbody2D>();
            return (Vector2) playersBody.transform.position + playersBody.velocity;
        }

        private void RotateToTarget(Vector2 target)
        {
            float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        public abstract void Shot(Vector2 direction);
    }
}