using System;
using UnityEngine;
using Work2.Battle.ComputedBehaviour.Entities;
using Work2.Battle.Entities;

namespace Work2.Battle.ComputedBehaviour.States
{
    public class MovingState : IState
    {
        private readonly GameObject _enemy;
        private readonly SpecialRotation _specialRotation;
        private readonly Movable _enemyMovable;

        private float _startTime;
        private Vector2 _movementVector;

        public event Action WorkFinished;

        public MovingState(GameObject enemy)
        {
            _enemy = enemy;
            _specialRotation = _enemy.GetComponent<SpecialRotation>();
            _enemyMovable = _enemy.GetComponent<Movable>();
        }

        public void Exit() 
        {
            _enemyMovable.Stop();
        }

        public void Start()
        {
            _startTime = Time.time;
            var archerMovementDistance = 0.5f;
            _movementVector = GetMovementVector(archerMovementDistance);
            _enemy.transform.rotation = _specialRotation.RotationToTarget2D(_movementVector);
        }

        public void Update()
        {
            if (Time.time - _startTime > 2)
                WorkFinished?.Invoke();

            _enemyMovable.Move(_movementVector * Time.deltaTime);
        }

        private Vector2 GetMovementVector(float distance)
        { 
            var randomDegree = UnityEngine.Random.Range(0, 180);

            var y = (float)Math.Sin(randomDegree);
            var x = (float)Math.Cos(randomDegree);
            var direction = new Vector3(x, y);
            direction *= distance;

            return CorrectedByWallsVector(direction);
        }

        private Vector2 CorrectedByWallsVector(Vector2 direction)
        {
            var ray = Physics2D.Raycast(_enemy.transform.position, direction, Mathf.Infinity,LayerMask.GetMask("Surroundings"));
            if (ray.distance < direction.magnitude + 2f)
            {
                return ray.normal * 0.5f;
            }
            return direction;
        }
    }
}