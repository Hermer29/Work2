using System.Linq;
using UnityEngine;
using Zenject;

namespace Work2.Battle.Entities.Attack
{
    public class CompositeAttacker : Attacker
    {
        private Attacker[] _attackers;

        private void Update()
        {
            
        }

        public override void Shot(Vector2 localVector)
        {
            var attackTypes = GetComponents<Attacker>();
            foreach(var attackType in _attackers)
            {
                attackType.Shot(localVector);
            }
        }
    }
}
