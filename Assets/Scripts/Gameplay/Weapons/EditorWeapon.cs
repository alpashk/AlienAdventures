using Gameplay.ShipData.Interfaces;
using UnityEngine;

namespace CompositionRoot.Gameplay.Weapons
{
    public class EditorWeapon : IWeapon
    {
        private float shotDelay = 0.5f;
        private IHeatController heatController;
        private int heatAmount = 25;
        public float ShotDelay
        {
            get => shotDelay;
        }
        public void Shoot()
        {
            Debug.Log("Pew");
            heatController.ChangeHeat(heatAmount);
        }

        public void Initialize(IHeatController heatController, Transform muzzle)
        {
            this.heatController = heatController;
        }

    }
}