using UnityEngine;
using Work2.Battle.CompositeRoot.Helpers;
using Zenject;

namespace Work2.Battle.CompositeRoot.Installers
{
    public class BattleInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _playerObject;

        public override void InstallBindings()
        {
            Container.Bind<IPlayer>().FromInstance(new Player(_playerObject));
        }
    }
}
