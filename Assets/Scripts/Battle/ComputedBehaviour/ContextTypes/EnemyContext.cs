using Work2.Battle.ComputedBehaviour.Entities;
using UnityEngine;
using System;
using Work2.Battle.ComputedBehaviour.ContextTypes;

namespace Work2.Battle.ComputedBehaviour
{
    public abstract class EnemyContext : MonoBehaviour
    {
        private IState _currentState;
        private Circular<Func<IState>> _circular;

        public abstract Func<IState>[] GetStates();

        private void Start()
        {
            var statesArray = GetStates();
            _circular = new Circular<Func<IState>>(statesArray);

            UseNextState();
        }

        private void UseNextState()
        {
            _currentState?.Exit();
            if(_currentState != null)
            {
                _currentState.WorkFinished -= UseNextState;
            }
            var next = _circular.GetNext();
            _currentState = next.Invoke();
            _currentState.WorkFinished += UseNextState;
            _currentState.Start();
        }

        private void Update()
        {
            _currentState?.Update();
        }
    }
}
