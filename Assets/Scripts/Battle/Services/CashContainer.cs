using UnityEngine;

namespace Work2.Battle.Services
{
    public class CashContainer : MonoBehaviour
    {
        private float _cashAmount = 0;

        public float CashAmount => _cashAmount;

        public void AddCash(float amount)
        {
            _cashAmount += amount;
        }

        public void Empty()
        {
            _cashAmount = 0;
        }
    }
}
