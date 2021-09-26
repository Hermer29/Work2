using UnityEngine;
using Work2.Battle.Services.Abstract;

namespace Work2.Battle.ProjectileTypes
{
    public abstract class ProjectileType : MonoBehaviour
    {
        public abstract void Launch(Vector2 direction, float velocity, IProjectileWrapper disposeWay);
    }
}
