using System.Collections.Generic;
using UnityEngine;
using Work2.Battle.Services.Abstract;
using Work2.Battle.Services.Exceptions;

namespace Work2.Battle.Services
{
    public class ProjectilePool : MonoBehaviour
    {
        [SerializeField] private GameObject _projectilePrefab;
        private IEnumerable<GameObject> _projectiles;
        [SerializeField] private int _poolSize;
        [SerializeField] private Transform _parentForProjectiles;

        private void Start()
        {
            var beforeFilling = new List<GameObject>();

            for(int i = 0; i < _poolSize; i++)
            {
                var newProjectile = Instantiate(_projectilePrefab, _parentForProjectiles);
                newProjectile.SetActive(false);
                beforeFilling.Add(newProjectile);
            }
            _projectiles = beforeFilling;
        }

        public IProjectileWrapper GetOne()
        {
            foreach(var projectile in _projectiles)
            {
                if (projectile.activeInHierarchy)
                    continue;

                projectile.SetActive(true);
                return new ProjectileWrapper(projectile);
            }
            throw new PoolException("Pool has no more free elements. To fix this error increase _poolSize value");
        }
    }
}
