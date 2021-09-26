using UnityEngine;
using Work2.Battle.Entities;

namespace Work2.Battle.InputSystem
{
    public class MobileInputSystem : MonoBehaviour
    {
        [SerializeField] private Movable _movable;
        [SerializeField] private Joystick _joystick;

        private void Update()
        {
            if(_joystick.Direction.magnitude >= 0.1f)
                _movable.Move(_joystick.Direction);
        }
    }
}
