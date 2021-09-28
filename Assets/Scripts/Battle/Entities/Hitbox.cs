using UnityEngine;
using Work2.Battle.CompositeRoot.Helpers;
using Work2.Battle.ProjectileTypes;

namespace Work2.Battle.Entities
{
    public class Hitbox : MonoBehaviour
    {
        [SerializeField] private Damagable _damagable;

        public Damagable Damageable => _damagable;
    }
}
