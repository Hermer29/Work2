using UnityEngine;
using Work2.Battle.Services.Abstract;

namespace Work2.Battle.Services
{
    public interface IProjectilePool
    {
        IDealingDamage GetOne();
        void ReplacePrefabWithOneWithLayer(LayerMask other);
    }

    public interface IPlayerProjectilePool : IProjectilePool
    { 

    }

    public interface IArcherProjectilePool : IProjectilePool
    {

    }

    public interface ISplasherProjectilePool : IProjectilePool
    {
        
    }
}
