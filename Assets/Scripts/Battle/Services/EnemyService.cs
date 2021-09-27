using System.Collections.Generic;
using UnityEngine;
using Work2.Battle.CompositeRoot;
using Zenject;

namespace Work2.Battle.Services
{
    public class EnemyService : MonoBehaviour
    {
        private List<GameObject> _enemies;
        private IPlayer _player;

        [Inject] private void Construct(IPlayer player)
        {
            _enemies = new List<GameObject>();
            _player = player;
        }

        public GameObject GetNearest()
        {
            var playerPosition = _player.PositionInfo().position;
            var biggestDistance = 0f;
            GameObject foundEnemy = null;

            foreach(var enemy in _enemies)
            {
                var vectorToEnemy = enemy.transform.position - playerPosition;
                var sqrMagnitude = vectorToEnemy.sqrMagnitude;
                if(sqrMagnitude > biggestDistance)
                {
                    biggestDistance = sqrMagnitude;
                    foundEnemy = enemy;
                }
            }
            return foundEnemy;
        }

        public void AddEnemy(GameObject gameObject)
        {
            _enemies.Add(gameObject);
        }
    }
}
