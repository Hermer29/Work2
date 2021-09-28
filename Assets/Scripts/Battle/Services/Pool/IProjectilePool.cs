using Work2.Battle.Services.Abstract;

namespace Work2.Battle.Services
{
    public interface IProjectilePool
    {
        IDealingDamage GetOne();
    }

    public interface IPlayerProjectilePool : IProjectilePool
    { 

    }

    public interface IArcherProjectilePool : IProjectilePool
    {

    }

}
