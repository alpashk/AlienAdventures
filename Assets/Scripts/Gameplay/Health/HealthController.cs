using System;

namespace Gameplay.Health
{
    public class HealthController : IHealthController
    {
        private Action<int> onHealthChanged;
        private Action onDeath;
    
        private readonly int maxHealth;
        private int currentHealth;

        public int MaxHealth => maxHealth;
    
        public HealthController(int baseHealth)
        {
            maxHealth = baseHealth;
            currentHealth = baseHealth;
        }

        public void SetupCallbacks(Action<int> onHealthChange = null, Action onDead = null)
        {
            if (onHealthChange != null)
            {
                this.onHealthChanged += onHealthChange;
            }

            if (onDead != null)
            {
                this.onDeath += onDead;
            }
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