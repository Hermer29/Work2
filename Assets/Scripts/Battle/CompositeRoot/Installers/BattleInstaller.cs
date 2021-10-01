using Pathfinding;
using UnityEngine;
using Work2.Battle.CompositeRoot.Helpers;
using Work2.Battle.Entities.Attack;
using Work2.Battle.Entities.Attack.AttackMethods;
using Work2.Battle.Services;
using Zenject;

namespace Work2.Battle.CompositeRoot.Installers
{
    public class BattleInstaller : MonoInstaller
    {
        [Header("Pools")]
        [SerializeField] private ProjectilePool _poolForArchers;
        [SerializeField] private ProjectilePool _poolForPlayer;
        [SerializeField] private ProjectilePool _poolForSplashers;
        [Header("--------------------------")]
        [SerializeField] private EnemyService _enemyService;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private GameObject _playerObject;

        public override void InstallBindings()
        {
            var playerAttacker = _playerObject.GetComponent<Attacker>();

            Container.Bind<IArcherProjectilePool>().FromInstance(_poolForArchers);
            Container.Bind<IPlayerProjectilePool>().FromInstance(_poolForPlayer);
            Container.Bind<ISplasherProjectilePool>().FromInstance(_poolForSplashers);

            Container.Bind<IPlayer>().FromInstance(new Player(_playerObject));
            Container.Bind<IPlayerAttackMethod>().FromInstance(new AttackMethod(playerAttacker, _poolForPlayer)).AsCached();
            Container.Bind<EnemyService>().FromInstance(_enemyService).AsCached();
            Container.Bind<Joystick>().FromInstance(_joystick).AsCached();
        }
    }
}
