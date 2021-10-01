using System.Collections.Generic;
using UnityEngine;
using Work2.Battle.Services.Exceptions;

namespace Work2.Battle.Services
{
    public class ProjectilePool : MonoBehaviour, IPlayerProjectilePool, IArcherProjectilePool, ISplasherProjectilePool
    {
        [SerializeField] private GameObject _projectilePrefab;
        private IEnumerable<GameObject> _projectiles;
        [SerializeField] private int _poolSize;
        [SerializeField] private Transform _parentForProjectiles;

        private void Start()
        {
            InstantiatePool();
        }

        private void InstantiatePool()
        {
            if (_projectiles != null)
                foreach (var projectile in _projectiles)
                    Destroy(projectile);

            var beforeFilling = new List<GameObject>();

            for (int i = 0; i < _poolSize; i++)
            {
                var newProjectile = Instantiate(_projectilePrefab, _parentForProjectiles);
                beforeFilling.Add(newProjectile);
            }
            _projectiles = beforeFilling;
        }

        public IDealingDamage GetOne()
        {
            foreach(var projectile in _projectiles)
            {
                if (projectile.activeInHierarchy)
                    continue;

                projectile.SetActive(true);
                return ProjectileWrapper.PrepareFirst(projectile);
            }
            throw new PoolException("Pool has no more free elements. To fix this error increase _poolSize value");
        }

        public void ReplacePrefabWithOneWithLayer(LayerMask other)
        {
            var newPrefab = Instantiate(_projectilePrefab, transform);
            newPrefab.layer = other;
            newPrefab.SetActive(false);
            _projectilePrefab = newPrefab;
            InstantiatePool();
        }
    }
}
