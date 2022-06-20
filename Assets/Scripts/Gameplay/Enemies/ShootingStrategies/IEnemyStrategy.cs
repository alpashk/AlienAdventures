using UnityEngine;

namespace Gameplay.Enemies.ShootingStrategies
{
    public interface IEnemyStrategy
    {
        void Shoot();
        void Initialize(Transform muzzle, EnemyProjectile projectile, int damage);
    }
}