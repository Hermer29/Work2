using UnityEngine;
using Work2.Battle.Entities.Attack.AttackMethods;
using Zenject;

namespace Work2.Battle.Services
{
    public class PlayerAttackMethodSystem : MonoBehaviour
    {
        private IPlayerAttackMethod _playerAttackMethod;
        
        [Inject] private void Construct(IPlayerAttackMethod playerAttackMethod)
        {
            _playerAttackMethod = playerAttackMethod;
        }

        public void AddMethod(AttackMethod attackMethod)
        {
            _playerAttackMethod.AddMethod(attackMethod);
        }
    }
}
