using System;

namespace Gameplay.Health
{
    public interface IHealthController
    {
        int MaxHealth { get; }
        void ChangeHealth(int changeAmount);
        void SetupCallbacks(Action<int> onHealthChange = null, Action onDead = null);
    }
}