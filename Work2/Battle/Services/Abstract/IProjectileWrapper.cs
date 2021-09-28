using UnityEngine;
using Work2.Battle.ProjectileTypes;

namespace Work2.Battle.Services.Abstract
{
    public interface IProjectileWrapper
    {
        GameObject Value { get; }
        Rigidbody2D ProjectilesBody { get; }
        ProjectileType ProjectileType { get; }
        void WithRotationTo(Vector2 localDirection);
        void WithPosition(Vector2 globalPosition);
        void Launch(Vector2 localDirection, float force);
        void Free();
    }
}
