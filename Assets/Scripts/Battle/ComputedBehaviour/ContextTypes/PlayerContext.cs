using System;
using Work2.Battle.ComputedBehaviour.Entities;
using Work2.Battle.ComputedBehaviour.States;
using Work2.Battle.Entities.Attack;
using Work2.Battle.Services;
using Zenject;

namespace Work2.Battle.ComputedBehaviour.ContextTypes
{
    class PlayerContext : StateMachineContext
    {
        private EnemyService _enemyService;
        private Joystick _joystick;
        private Attacker _attacker;

        [Inject] private void Construct(EnemyService enemyService, Joystick joystick)
        {
            _joystick = joystick;
            _enemyService = enemyService;
            _attacker = GetComponent<Attacker>();
        }

        public override Func<IState>[] GetStates()
        {
            Func<bool> attackEndCondition = () => _joystick.Direction.magnitude > 0.1f;
            return new Func<IState>[]
            {
                () =>
                {
                    var attackRate = _attacker.attackRate;
                    var nearestEnemy = _enemyService.GetNearest();
                    if(nearestEnemy == null || _joystick.Direction.magnitude > 0.1f)
                        return new PlayerControlState(_joystick);
                    return new PlayerAttackState(gameObject, nearestEnemy.transform, _joystick, attackRate);
                }
            };
        }
    }
}
