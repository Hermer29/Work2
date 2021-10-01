using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Work2.Battle.CompositeRoot;
using Work2.Battle.Entities;
using Zenject;

namespace Work2.Battle.Services
{
    public class EnemyService : MonoBehaviour
    {
        private List<GameObject> _enemies;
        private IPlayer _player;
        [SerializeField] private EnemiesEvent _noMoreEnemies;

        public event Action NoMoreEnemies;
        public event Action<GameObject> EnemyDied;

        [Inject] private void Construct(IPlayer player)
        {
            _enemies = new List<GameObject>();
            _player = player;
        }

        public GameObject GetNearest()
        {
            var playerPosition = _player.PositionInfo().position;
            var lowestDistance = Mathf.Infinity;
            GameObject foundEnemy = null;

            foreach(var enemy in _enemies)
            {
                var vectorToEnemy = enemy.transform.position - playerPosition;
                var sqrMagnitude = vectorToEnemy.sqrMagnitude;
                if(sqrMagnitude < lowestDistance)
                {
                    lowestDistance = sqrMagnitude;
                    foundEnemy = enemy;
                }
            }
            return foundEnemy;
        }

        public void AddEnemy(GameObject enemy)
        {
            _enemies.Add(enemy);

            if(enemy.TryGetComponent<Damagable>(out var damagable))
            {
                damagable.Died += () => ExcludeEnemy(enemy);
                damagable.Died += () => EnemyDied?.Invoke(damagable.gameObject);
                return;
            }

            Debug.LogWarning($"{enemy.name} has not Damagable component, this will not allow to finish the game");
        }

        public void ExcludeEnemy(GameObject enemy)
        {
            _enemies.Remove(enemy);
            if (!_enemies.Any())
            {
                _noMoreEnemies?.Invoke();
                NoMoreEnemies?.Invoke();
            }
        }
    }

    [Serializable]
    public class EnemiesEvent : UnityEvent
    { 

    }
}
