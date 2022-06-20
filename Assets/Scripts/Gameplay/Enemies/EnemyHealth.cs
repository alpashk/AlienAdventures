using System;
using UnityEngine;

namespace Gameplay.Enemies
{
    public class EnemyHealth
    {
        [SerializeField] private int health;
        public Action OnDeath;

        public EnemyHealth(int health, Action onDeath)
        {
            this.health = health;
            OnDeath = onDeath;
        }

        public void ReceiveDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                OnDeath?.Invoke();
            }
        }
    }
}