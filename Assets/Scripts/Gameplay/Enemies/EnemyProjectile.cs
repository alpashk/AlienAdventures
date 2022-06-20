using System;
using CompositionRoot.Gameplay;
using UnityEngine;

namespace Gameplay.Enemies
{
    public class EnemyProjectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody2D;
        [SerializeField] private float speed;
        private int damage;

        public void Initialize(int damage)
        {
            this.damage = damage;
            rigidbody2D.velocity = -transform.right * speed;
        }
        

        private void OnTriggerEnter2D(Collider2D other)
        {
            GameObject hitObject = other.gameObject;
            if (hitObject.layer != 11)
            {
                return;
            }
            if (other.TryGetComponent(out MainShip ship))
            {
                ship.ReceiveDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}