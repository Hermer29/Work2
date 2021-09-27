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
        [SerializeField] private GameObject _playerObject;
        [SerializeField] private ProjectilePool _projectilePoolForEnemies;
        [SerializeField] private ProjectilePool _projectilePoolForPlayer;
        [SerializeField] private EnemyService _enemyService;
        [SerializeField] private Joystick _joystick;

        public override void InstallBindings()
        {
            var playerAttacker = _playerObject.GetComponent<Attacker>();

            Container.Bind<IPlayer>().FromInstance(new Player(_playerObject));
            Container.Bind<IArcherProjectilePool>().FromInstance(_projectilePoolForEnemies);
            Container.Bind<IPlayerProjectilePool>().FromInstance(_projectilePoolForPlayer);    
            Container.Bind<IPlayerAttackMethod>().FromInstance(new AttackMethod(playerAttacker, _projectilePoolForPlayer)).AsCached();
            Container.Bind<EnemyService>().FromInstance(_enemyService).AsCached();
            Container.Bind<Joystick>().FromInstance(_joystick).AsCached();

        }
    }
}
