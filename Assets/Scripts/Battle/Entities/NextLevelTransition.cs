using UnityEngine;
using Work2.Battle.CompositeRoot.Helpers;
using Zenject;

namespace Work2.Battle.Entities
{
    [RequireComponent(typeof(Collider2D))]
    public class NextLevelTransition : MonoBehaviour
    {
        private Joystick _joystick;
        private bool _playerControlled;
        private Movable _playerMovable;

        [Inject] private void Construct(Joystick joystick)
        {
            _joystick = joystick;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.TryGetComponent<PlayerMark>(out var player))
            {
                _joystick.enabled = false;
                var playerBody = player.GetComponent<Rigidbody2D>();
                playerBody.isKinematic = true;
                _playerMovable = playerBody.GetComponent<Movable>();
                _playerControlled = true;
            }
        }

        private void Update()
        {
            if(_playerControlled)
                _playerMovable.Move(Vector2.up);
        }
    }
}
