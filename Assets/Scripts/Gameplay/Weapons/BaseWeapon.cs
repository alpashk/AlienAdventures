using Gameplay.ShipData.Interfaces;
using UnityEngine;

namespace Gameplay.Weapons
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        [SerializeField] protected int damageAmount;
        [SerializeField] private float shotDelay;
        [SerializeField] protected int heatAmount;
        [SerializeField] protected Transform muzzle;
        
        protected int raycastMask = ~9;
        
        protected IHeatController heatController;

        
        public float ShotDelay => shotDelay;

        public virtual void Shoot()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Initialize(IHeatController heatController)
        {
            this.heatController = heatController;
        }
    }
}