using System;
using Gameplay.ShipData.Interfaces;

namespace Gameplay.ShipData
{
    public class HealthController : IHealthController
    {
        private Action<int> onHealthChanged;
        private Action onDeath;

        private readonly int maxHealth;
        private int currentHealth;
        

        public Action<int> OnHealthChanged
        {
            get => onHealthChanged;
            set => onHealthChanged = value;
        }

        public Action OnDeath
        {
            get => onDeath;
            set => onDeath = value;
        }

        public int MaxHealth => maxHealth;
        
    
        public HealthController(int baseHealth)
        {
            maxHealth = baseHealth;
            currentHealth = baseHealth;
        }

        public void ChangeHealth(int changeAmount)
        {
            currentHealth += changeAmount;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
                onHealthChanged?.Invoke(currentHealth);
            }
            else if (currentHealth <= 0)
            {
                onHealthChanged?.Invoke(currentHealth);
                onDeath?.Invoke();
            }
            else
            {
                onHealthChanged?.Invoke(currentHealth);
            }
        }
    }
}