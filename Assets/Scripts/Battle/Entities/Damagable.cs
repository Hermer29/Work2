using UnityEngine;

namespace Work2.Battle.Entities
{
    public class Damagable : MonoBehaviour 
    {
        [SerializeField] private float _healthAmount;
        private float _maxHealthAmount = 100;

        private void Start()
        {
            _maxHealthAmount = _healthAmount;
        }

        public void GainDamage(float amount)
        {
            Debug.Log($"{name} damaged! : {_healthAmount - amount}/{_maxHealthAmount}. Dealt: {amount}");
            _healthAmount -= amount;
        }
    }
}
