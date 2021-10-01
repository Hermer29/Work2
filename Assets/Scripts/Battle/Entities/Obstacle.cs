using UnityEngine;

namespace Work2.Battle.Entities
{
    public class Obstacle : MonoBehaviour
    {
        [Header("Нужно сделать повторный поиск путей")]
        [SerializeField] private bool _collideWithBullets;
        [SerializeField] private bool _collideWithCharacters;

        private void OnValidate()
        {
            if (_collideWithBullets)
                _collideWithCharacters = true;

            if (_collideWithBullets)
                gameObject.layer = 11;
            else if (_collideWithCharacters)
                gameObject.layer = 4;               
        }
    }
}
