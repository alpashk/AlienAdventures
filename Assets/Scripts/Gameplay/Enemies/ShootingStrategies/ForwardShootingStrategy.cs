using UnityEngine;

namespace Gameplay.Enemies.ShootingStrategies
{
    public class ForwardShootingStrategy : IEnemyStrategy
    {
        private EnemyProjectile projectile;
        private Transform muzzle;
        private int damage;
        public void Shoot()
        {
            EnemyProjectile shotProjectile = GameObject.Instantiate(projectile, muzzle.position, muzzle.rotation);
            shotProjectile.Initialize(damage);
        }

        public ForwardShootingStrategy(Transform muzzle, EnemyProjectile projectile, int damage)
        {
            this.muzzle = muzzle;
            this.projectile = projectile;
            this.damage = damage;
        }
    }
}