using System;
using System.Collections;
using Gameplay.Enemies.ShootingStrategies;
using UnityEngine;

namespace Gameplay.Enemies
{
    public class EnemyShooting : MonoBehaviour
    {
        [SerializeField] private EnemyProjectile projectilePrefab;
        [SerializeField] private Transform muzzle;
        [SerializeField] private int damage;
        [SerializeField] private ShootingDirections direction;
        [SerializeField] private float cooldown;

        private IEnemyStrategy strategy;

        private void Awake()
        {
            switch (direction)
            {
                default:
                case ShootingDirections.Forward:
                    strategy = new ForwardShootingStrategy();
                    strategy.Initialize(muzzle, projectilePrefab, damage);
                    break;
            }
        }

        public void Start()
        {
            StartCoroutine(ShootRoutine());
        }

        private void OnDisable()
        {
            StopCoroutine(ShootRoutine());
        }

        private void OnDestroy()
        {
            StopCoroutine(ShootRoutine());
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
        LeftHalf = 1,
        Everywhere = 2,
    }
    
}