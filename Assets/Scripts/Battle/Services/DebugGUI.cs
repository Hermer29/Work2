using UnityEngine;
using Work2.Battle.CompositeRoot;
using Work2.Battle.Entities.Attack;
using Work2.Battle.Entities.Attack.AttackMethods;
using Zenject;

namespace Work2.Battle.Services
{
    public class DebugGUI : MonoBehaviour
    {
        private IPlayerProjectilePool _pool;
        private IPlayerAttackMethod _playerAttackMethod;
        private Transform _playerTransform;

        [Inject] private void Construct(IPlayerAttackMethod playerAttackMethod, IPlayer player, IPlayerProjectilePool pool)
        {
            _pool = pool;
            _playerAttackMethod = playerAttackMethod;
            _playerTransform = player.PositionInfo();
        }

        private void OnGUI()
        {
            var playerAttacker = _playerTransform.GetComponent<Attacker>();
            GUI.BeginGroup(new Rect(0, 0, 200, 200));

            if(GUI.Button(new Rect(10,10,50,50), "Splash"))
            {
                _playerAttackMethod.AddMethod(new SideProjectilesMethod(playerAttacker, _pool));
            }
            if(GUI.Button(new Rect(120, 10, 50, 50), "Wallproof"))
            {
                _pool.ReplacePrefabWithOneWithLayer(LayerMask.NameToLayer("IgnoreAllExceptEnemies"));
            }
            GUI.EndGroup();
        }
    }
}
