using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Work2.Battle.ComputedBehaviour.Entities;

namespace Work2.Battle.ComputedBehaviour.States
{
    class PlayerControlState : IState
    {
        private Joystick _joystick;
        public event Action WorkFinished;

        public PlayerControlState(Joystick joystick)
        {
            _joystick = joystick;
        }

        public void Exit() { }

        public void Start() {}

        public void Update()
        {
            if (_joystick.Direction.magnitude < 0.1f)
                WorkFinished?.Invoke();
        }
    }
}
