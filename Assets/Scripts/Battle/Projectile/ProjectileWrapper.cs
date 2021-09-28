using UnityEngine;
using Work2.Battle.Entities;
using Work2.Battle.ProjectileTypes;
using Work2.Battle.Services.Abstract;

namespace Work2.Battle.Services
{
    public class ProjectileWrapper : IProjectileWrapper, IDealingDamage, ISetProjectileTransform, ILaunchable
    {
        private GameObject _value;
        private SpecialRotation _projectileRotation;

        private ProjectileWrapper(GameObject value)
        {
            _value = value;
            _projectileRotation = value.GetComponent<SpecialRotation>();
        }

        public static IDealingDamage PrepareFirst(GameObject value)
        {
            return new ProjectileWrapper(value);
        }

        public GameObject Value => _value;

        public Rigidbody2D ProjectilesBody => _value.GetComponent<Rigidbody2D>();

        private ProjectileType _cachedProjectileType;

        public ProjectileType ProjectileType
        {
            get
            {
                if (_cachedProjectileType == null)
                    _cachedProjectileType = _value.GetComponent<ProjectileType>();
                return _cachedProjectileType;
            }
        }

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

        public ILaunchable SetTransform()
        {
            return this;
        }

        public ISetProjectileTransform WithDamage(float amount)
        {
            ProjectileType.SetDealingDamage(amount);
            return this;
        }
    }

    public interface IDealingDamage
    {
        ISetProjectileTransform WithDamage(float amount);
    }

    public interface ISetProjectileTransform
    {
        ILaunchable SetTransform();
        void WithPosition(Vector2 globalPosition);
        void WithRotationTo(Vector2 localPosition);
    }

    public interface ILaunchable
    {
        void Launch(Vector2 localDirection, float force);
    }

}
