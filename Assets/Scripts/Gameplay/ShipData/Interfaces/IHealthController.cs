using System;

namespace Gameplay.ShipData.Interfaces
{
    public interface IHealthController//
    {
        Action<int> OnHealthChanged { get; set; }
        Action OnDeath { get; set; }
        int MaxHealth { get; }
        void ChangeHealth(int changeAmount);
    }
}