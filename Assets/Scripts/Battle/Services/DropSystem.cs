using System.Collections.Generic;
using UnityEngine;
using Work2.Battle.CompositeRoot;
using Work2.Battle.Entities;
using Zenject;

namespace Work2.Battle.Services
{
    public class DropSystem : MonoBehaviour
    {
        [SerializeField] private Vector2 _dropGoldAmount;
        [SerializeField] private GameObject _dropPrefab = null;
        private List<GameObject> _spawnedDrop;
        private bool _noMoreEnemies = false;
        private IPlayer _player;
        private EnemyService _service;

        [Inject] private void Construct(EnemyService service, IPlayer player)
        {
            service.EnemyDied += DropRandomItem;
            _spawnedDrop = new List<GameObject>();
            _player = player;

            service.NoMoreEnemies += () =>
            {
                _noMoreEnemies = true;
                _spawnedDrop.ForEach(x => GameObject.Destroy(x));
            };
        }

        private void DropRandomItem(GameObject diedEnemy)
        {
            var moneyAmount = Random.Range(_dropGoldAmount.x, _dropGoldAmount.y);

            if (moneyAmount == 0)
                return;

            var spawnPosition = diedEnemy.transform.position;
            var actual = Instantiate(_dropPrefab, spawnPosition, Quaternion.identity);
            var pulledDrop = actual.GetComponent<PulledDrop>();
            pulledDrop.CashAmount = moneyAmount;
            pulledDrop.Construct(_service, _player);
            if (_noMoreEnemies)
            {
                Destroy(actual);
            }

            _spawnedDrop.Add(actual);
        }
    }
}
