using System;
using UnityEngine;
using Work2.Battle.CompositeRoot;
using Work2.Battle.ComputedBehaviour.Entities;
using Work2.Battle.ComputedBehaviour.States;
using Zenject;

namespace Work2.Battle.ComputedBehaviour.ContextTypes
{
    public class ArcherEnemyContext : StateMachineContext
    {
        private static Transform _playerTransform;

        [Inject] public void Construct(IPlayer player)
        {
            if (_playerTransform == null)
                _playerTransform = player.PositionInfo();
        }

        public override Func<IState>[] GetStates()
        {
            return new Func<IState>[]
            {
                () => new AttackState(gameObject, _playerTransform),
                () => new DelayState(1f),
                () => new MovingState(gameObject),
                () => new DelayState(0.5f)
            };
        }
    }
}
