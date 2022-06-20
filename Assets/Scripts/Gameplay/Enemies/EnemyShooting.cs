using System;
using System.Collections;
using Gameplay.Enemies.ShootingStrategies;
using UnityEngine;

namespace Gameplay.Enemies
{
    public class EnemyShooting
    {
        private EnemyProjectile projectilePrefab;
        private Transform muzzle;
        private Transform target;
        private int damage;
        private ShootingDirections direction;
        private float cooldown;

        private MonoBehaviour coroutineObject;

        private IEnemyStrategy strategy;

        public EnemyShooting(MonoBehaviour coroutineObject, EnemyProjectile projectilePrefab, Transform muzzle, int damage, ShootingDirections direction, float cooldown, Transform target = null)
        {
            this.coroutineObject = coroutineObject;
            this.projectilePrefab = projectilePrefab;
            this.target = target;
            this.muzzle = muzzle;
            this.damage = damage;
            this.direction = direction;
            this.cooldown = cooldown;
            
            switch (direction)
            {
                case ShootingDirections.Forward: 
                    strategy = new ForwardShootingStrategy(muzzle, projectilePrefab, damage);
                    break;
                case ShootingDirections.Everywhere:
                    strategy = new EverywhereShootingStrategy(target, muzzle, projectilePrefab, damage);
                    break;
            }
        }

        public void StartShooting()
        {
            coroutineObject.StartCoroutine(ShootRoutine());
        }

        public void StopShooting()
        {
            coroutineObject.StopCoroutine(ShootRoutine());
        }

        private IEnumerator ShootRoutine()
        {
            while (true)
            {
                strategy.Shoot();
                yield return new WaitForSeconds(cooldown);
            }
        }
        
    }


    public enum ShootingDirections
    {
        Forward = 0,
        Everywhere = 1,
    }
    
}