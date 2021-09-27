using UnityEngine;
using Work2.Battle.Entities;
using Work2.Battle.ProjectileTypes;
using Work2.Battle.Services.Abstract;

namespace Work2.Battle.Services
{
    public class ProjectileWrapper : IProjectileWrapper
    {
        private GameObject _value;
        private SpecialRotation _projectileRotation;

        public ProjectileWrapper(GameObject value)
        {
            _value = value;
            _projectileRotation = value.GetComponent<SpecialRotation>();
        }

        public GameObject Value => _value;

        public Rigidbody2D ProjectilesBody => _value.GetComponent<Rigidbody2D>();

        public ProjectileType ProjectileType => _value.GetComponent<ProjectileType>();

        public void Free()
        {
            _value.SetActive(false);
        }

        public void Launch(Vector2 localDirection, float force)
        {
            ProjectileType.Launch(localDirection, force, this);
        }

        public void WithPosition(Vector2 globalPosition)
        {
            _value.transform.position = globalPosition;
        }

        public void WithRotationTo(Vector2 localDirection)
        {
            _projectileRotation.RotateToTarget2D(localDirection);
        }
    }
}
