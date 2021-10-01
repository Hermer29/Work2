using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Work2.Battle.Entities
{
    public class Damagable : MonoBehaviour 
    {
        [SerializeField] private float _healthAmount = 100;
        private float _maxHealthAmount = 0;

        public event Action<float> HealthPercentChanged;
        public event Action<float> HealthChanging;
        public event Action Died;

        private void Start()
        {
            _maxHealthAmount = _healthAmount;
            Died += OnDied;
        }

        public void GainDamage(float amount)
        {
            HealthChanging?.Invoke(amount);
            _healthAmount -= amount;
            HealthPercentChanged?.Invoke(_healthAmount / _maxHealthAmount);
            if (_healthAmount <= 0)
                Died?.Invoke();
        }

        public virtual void OnDied()
        {
            gameObject.SetActive(false);
        }
    }
}
