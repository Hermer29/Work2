using UnityEngine;

namespace Work2.Battle.Services.Abstract
{
    public interface IProjectileWrapper
    {
        GameObject Value { get; }
        Rigidbody2D ProjectilesBody { get; }
        void Free();
    }
}
