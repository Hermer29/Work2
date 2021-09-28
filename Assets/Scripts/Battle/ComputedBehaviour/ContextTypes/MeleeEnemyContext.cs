using System;
using UnityEngine;
using UnityEngine.AI;
using Work2.Battle.CompositeRoot;
using Work2.Battle.ComputedBehaviour.Entities;
using Work2.Battle.ComputedBehaviour.States;
using Work2.Battle.Entities.Attack;
using Zenject;

namespace Work2.Battle.ComputedBehaviour.ContextTypes
{
    [RequireComponent(typeof(Attacker))]
    class MeleeEnemyContext : StateMachineContext
    {
        private Transform _playerTransform;
        private Attacker _attacker;

        [Inject] private void Construct(IPlayer player)
        {
            _playerTransform = player.PositionInfo();
            _attacker = GetComponent<Attacker>();
        }

        public override Func<IState>[] GetStates()
        {
            return new Func<IState>[]
            {
                () => new MoveToPlayerState(_playerTransform, transform),
                () => new MeleeAttackState(_attacker, _playerTransform.gameObject)
            };
        }
    }
}
