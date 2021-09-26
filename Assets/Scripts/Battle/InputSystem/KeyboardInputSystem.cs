using UnityEngine;
using Work2.Battle.Entities;

namespace Work2.Battle.InputSystem
{
    public class KeyboardInputSystem : MonoBehaviour
    {
        [SerializeField] private Movable _movable;
      
        private void Update()
        {
            MoveOnClick(KeyCode.W, Vector2.up);
            MoveOnClick(KeyCode.A, Vector2.left);
            MoveOnClick(KeyCode.S, Vector2.down);
            MoveOnClick(KeyCode.D, Vector2.right);
        }

        private void MoveOnClick(KeyCode key, Vector2 vector)
        {
            if (Input.GetKey(key))
            {
                _movable.Move(vector);
            }
        }
    }
}