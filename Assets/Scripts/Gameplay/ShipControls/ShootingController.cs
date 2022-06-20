using System;
using System.Collections;
using Gameplay.Weapons;
using Gameplay.Controls;
using Gameplay.ShipData.Interfaces;
using UnityEngine;

namespace Gameplay.ShipControls
{
    public class ShootingController : MonoBehaviour//
    {
        #region Fields

        [SerializeField] private Transform muzzle;
        private BaseWeapon weapon;
        private IHeatController heatController;
        private IMovementController movementController;

        private bool shotReloaded = true;
        private bool shotCooled = true;
        private float cooldown;
        
        #endregion



        #region Methods

        public void Initialize(IMovementController movementController, IHeatController heatController, BaseWeapon weapon)
        {
            this.weapon = weapon;
            cooldown = weapon.ShotDelay;
            this.heatController = heatController;
            this.movementController = movementController;
            
            weapon.Initialize(heatController);

            movementController.OnShootPressed += MovementController_OnShoot;
            
            heatController.OnOverheat += HeatController_OnOverheat;
        }
        

        private void MovementController_OnShoot()
        {
            if (shotReloaded && shotCooled)
            {
                weapon.Shoot();
                shotReloaded = false;
                StartCoroutine(CooldownCoroutine());
            }
        }

        
        private void HeatController_OnOverheat()
        {
            Debug.Log("Pew Overheat");
            shotCooled = false;
            heatController.OnHeatReachedZero += HeatController_OnHeatReachedZero;
        }


        private void HeatController_OnHeatReachedZero()
        {
            Debug.Log("Pew cool");
            shotCooled = true;
            heatController.OnHeatReachedZero -= HeatController_OnHeatReachedZero;
        }
        

        private IEnumerator CooldownCoroutine()
        {
            yield return new WaitForSeconds(cooldown);
            shotReloaded = true;
        }
        

        #endregion
    }
}