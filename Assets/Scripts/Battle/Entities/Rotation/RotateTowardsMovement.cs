using UnityEngine;

namespace Work2.Battle.Entities.Rotation
{
    [RequireComponent(typeof(SpecialRotation), typeof(Movable))]
    public class RotateTowardsMovement : MonoBehaviour
    {
        private SpecialRotation _rotation;
        private Movable _movable;

        private void Awake()
        {
            _rotation = GetComponent<SpecialRotation>();
            _movable = GetComponent<Movable>();
        }

        private void OnEnable()
        {
            _movable.Moving += RotateTowards;
        }

        private void RotateTowards(Vector2 local)
        {
            _rotation.RotateToTarget2D(local);
        }

        private void OnDisable()
        {
            _movable.Moving -= RotateTowards;
        }
    }
}
