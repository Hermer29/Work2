using UnityEngine;
using UnityEngine.UI;
using Work2.Battle.Entities;

namespace Work2.Battle.Entities.Health
{
    [RequireComponent(typeof(Slider))]
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Damagable _damagable;
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _damagable.HealthPercentChanged += OnHealthPercentChange;
        }

        private void OnHealthPercentChange(float newPercent)
        {
            _slider.value = newPercent;
        }
    }
}
