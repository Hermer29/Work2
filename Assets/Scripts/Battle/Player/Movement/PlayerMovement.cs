using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Work2.Battle.Player.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _playerBody;
        [Range(0, 100)] public float speed = 1;

        private void Awake()
        {
            _playerBody = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector2 direction)
        {
            _playerBody.MovePosition((Vector2) transform.position + direction * 
                (speed * Time.deltaTime));
        }
    }
}
