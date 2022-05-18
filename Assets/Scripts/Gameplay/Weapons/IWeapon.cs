using Gameplay.ShipData.Interfaces;
using UnityEngine;

namespace CompositionRoot.Gameplay.Weapons
{
    public interface IWeapon
    {
        float ShotDelay { get; }
        void Shoot();

        void Initialize(IHeatController heatController, Transform muzzle);
    }
}