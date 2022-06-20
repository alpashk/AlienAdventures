using Gameplay.Enemies;
using Gameplay.Weapons.Visuals;
using UnityEngine;

namespace Gameplay.Weapons
{
    public class HitScanWeapon : BaseWeapon
    {
        [SerializeField] private Tracer tracerPrefab;
        
        public override void Shoot()
        {
            heatController.ChangeHeat(heatAmount);
            Instantiate(tracerPrefab, muzzle.position, Quaternion.identity);

            RaycastHit2D hit;

            hit = Physics2D.Raycast(muzzle.position, Vector2.right, 15.0f, raycastMask);

            if (hit.collider != null)
            {
                EnemyData health;
                if (hit.transform.gameObject.TryGetComponent(out health))
                {
                    health.ReceiveDamage(damageAmount);
                }
            }
        }
    }
}