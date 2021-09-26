using UnityEngine;

namespace Work2.Battle.Entities.Attack
{
    public abstract class Attacker : MonoBehaviour
    {
        public abstract void Shot(Vector2 localVector);
    }
}