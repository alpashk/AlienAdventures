using UnityEngine;

namespace Gameplay.Enemies.ShootingStrategies
{
    public class EverywhereShootingStrategy : IEnemyStrategy
    {
        private EnemyProjectile projectile;
        private Transform muzzle;
        private Transform player;
        private int damage;
        public void Shoot()
        {
            Vector3 playerDirection = player.position - muzzle.position;
            float angle = Vector3.SignedAngle(Vector3.left, playerDirection, Vector3.forward);
            EnemyProjectile shotProjectile = GameObject.Instantiate(projectile, muzzle.position, muzzle.rotation * Quaternion.Euler(Vector3.forward * angle));
            shotProjectile.Initialize(damage);
        }

        public EverywhereShootingStrategy(Transform player, Transform muzzle, EnemyProjectile projectile, int damage)
        {
            this.player = player;
            this.muzzle = muzzle;
            this.projectile = projectile;
            this.damage = damage;
        }
    }
}