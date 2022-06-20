using System;

namespace Gameplay.ShipData.Interfaces
{
    public interface IHeatController//
    {
        Action<int> OnHeatChanged { get; set; }
        Action OnOverheat { get; set; }
        Action OnHeatReachedZero { get; set; }
        int MaxHeat { get; }
        void ChangeHeat(int changeAmount);
    }
}