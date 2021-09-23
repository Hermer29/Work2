using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Work2.Battle.Player.Movement;

namespace Work2.Battle.InputSystem
{
    public class MobileInputSystem : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _player;
        [SerializeField] private Joystick _joystick;

        private void Update()
        {
            _player.Move(_joystick.Direction);
        }
    }
}
