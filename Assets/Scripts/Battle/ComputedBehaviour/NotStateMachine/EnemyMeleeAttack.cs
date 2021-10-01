using Pathfinding;
using UnityEngine;
using Work2.Battle.CompositeRoot;
using Work2.Battle.Entities.Attack;
using Zenject;

namespace Work2.Battle.ComputedBehaviour.NotStateMachine
{
    [RequireComponent(typeof(AIPath), typeof(Attacker))]
    public class EnemyMeleeAttack : MonoBehaviour
    {
        private Transform _playerTransform;
        private AIPath _pathfinding;
        private Attacker _attacker;
        [SerializeField] private float _attackDistance;
        private float _lastShotTime;

        [Inject] private void Construct(IPlayer player)
        {
            _playerTransform = player.PositionInfo();
        }

        private void Start()
        {
            _pathfinding = GetComponent<AIPath>();
            _attacker = GetComponent<Attacker>();
        }

        private void OnValidate()
        {
            GetComponent<AIPath>().endReachedDistance = _attackDistance;
        }

        private void Update()
        {
            var attackerReached = _pathfinding.reachedEndOfPath;
            var canAttack = _lastShotTime + _attacker.attackRate < Time.time;

            if (attackerReached && canAttack)
            {
                _lastShotTime = Time.time;
                _attacker.Attack(_playerTransform.gameObject);
            }
        }
    }
}
