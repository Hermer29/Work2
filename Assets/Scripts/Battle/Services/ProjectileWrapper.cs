using Assets.Scripts.Battle.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Battle.Services
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
