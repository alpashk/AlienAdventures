using System;

public interface IHealthController
{
    void ChangeHealth(int changeAmount);
    void SetupCallbacks(Action<int> onHealthChange = null, Action onDead = null);
}