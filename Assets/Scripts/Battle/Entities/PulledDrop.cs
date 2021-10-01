using System;
using UnityEngine;
using Work2.Battle.CompositeRoot;
using Work2.Battle.Services;
using Zenject;

namespace Work2.Battle.Entities
{
    public class PulledDrop : MonoBehaviour
    {
        public float CashAmount 
        { 
            set
            {
                if (_cashAmount != 0)
                    throw new InvalidOperationException("Can be setted ones");

                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value));

                _cashAmount = value;
            }
            get => _cashAmount;
        }

        private float _cashAmount = 0;
        private Transform _playerTransform;

        public void Construct(EnemyService enemy, IPlayer player)
        {          
            _playerTransform = player.PositionInfo();
        }

        private void OnDestroy()
        {
            if (_playerTransform == null)
                return;
            _playerTransform.GetComponent<CashContainer>().AddCash(_cashAmount);
        }
    }
}