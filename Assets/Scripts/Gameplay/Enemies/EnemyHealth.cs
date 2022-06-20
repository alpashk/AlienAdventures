using System;
using UnityEngine;

namespace Gameplay.Enemies
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int health;
        public Action OnDeath;

        public void ReceiveDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                OnDeath?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}