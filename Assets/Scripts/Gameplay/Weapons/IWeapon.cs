using Gameplay.ShipData.Interfaces;

namespace CompositionRoot.Gameplay.Weapons
{
    public interface IWeapon
    {
        void Shoot();

        void Initialize(IHeatController heatController);
    }
}