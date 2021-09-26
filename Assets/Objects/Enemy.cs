using UnityEngine;

namespace Work2.Objects
{
    [CreateAssetMenu(fileName = "New Enemy", menuName = "Game Characters/Enemy")]
    public class Enemy : ScriptableObject
    {
        public float fireRate; 
    }
}