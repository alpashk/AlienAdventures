using Gameplay.Controls;
using Gameplay.ShipControls;
using Gameplay.ShipData.Interfaces;
using Gameplay.Weapons;
using UnityEngine;

namespace CompositionRoot.Gameplay
{
    public class MainShip : MonoBehaviour//
    {
        #region Fields

        [SerializeField] private ShipController shipController;
        [SerializeField] private ShootingController shootingController;

        private IHealthController healthController;

        #endregion

        
        
        #region Unity lifecycle

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == 9)
            {
                healthController.ChangeHealth(-5);
                Destroy(other.collider.gameObject);
            }
        }

        #endregion

        

        #region Methods

        public void Initialize(IMovementController movementController, BaseWeapon weapon, IHealthController healthController, IHeatController heatController)
        {
            shootingController.Initialize(movementController, heatController, weapon);
            
            shipController.Initialize(movementController);

            this.healthController = healthController;
        }


        public void ReceiveDamage(int amount)
        {
            healthController.ChangeHealth(-amount);
        }

        #endregion
    }
}