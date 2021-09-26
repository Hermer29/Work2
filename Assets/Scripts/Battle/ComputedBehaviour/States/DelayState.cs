using System;
using UnityEngine;
using Work2.Battle.ComputedBehaviour.Entities;

namespace Work2.Battle.ComputedBehaviour.States
{
    internal class DelayState : IState
    {
        private float _startTime;
        private float _delayTime;

        public event Action WorkFinished;

        public DelayState(float seconds)
        {
            _delayTime = seconds;
        }

        public void Start()
        {
            _startTime = Time.time;
        }

        public void Update()
        {
            if (_startTime + _delayTime < Time.time)
                WorkFinished?.Invoke();
        }

        public void Exit() { }
    }
}
