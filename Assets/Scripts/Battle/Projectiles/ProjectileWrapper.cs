using UnityEngine;
using Work2.Battle.Services.Abstract;

namespace Work2.Battle.Services
{
    public class ProjectileWrapper : IProjectileWrapper
    {
        private GameObject _value;

        public ProjectileWrapper(GameObject value)
        {
            _value = value;
        }

        public GameObject Value => _value;

        public Rigidbody2D ProjectilesBody => _value.GetComponent<Rigidbody2D>();

        public void Free()
        {
            _value.SetActive(false);
        }
    }
}
