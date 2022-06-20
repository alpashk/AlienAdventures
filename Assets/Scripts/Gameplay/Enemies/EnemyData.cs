using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.LevelComponents;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gameplay.Enemies
{
    public class EnemyData : MonoBehaviour
    {
        private EnemyHealth healthManager;
        private EnemyShooting shootingManager;

        [SerializeField] private int startHealth;
        
        [SerializeField] private EnemyProjectile projectilePrefab;
        [SerializeField] private Transform muzzle;
        [SerializeField] private int damage;
        [SerializeField] private ShootingDirections direction;
        [SerializeField] private float cooldown;
        [SerializeField] private float speed;

        [SerializeField] private EnemyType enemy;
        
        private List<Vector3> movementTargets = new List<Vector3>();
        private OnPathEnd onPathEnd;
        private LevelMover levelMover;
        private float triggerCoordinate;
        
        private int currentTargetObject;
        
        public void StartShooting()
        {
            shootingManager.StartShooting();
        }

        public void ReceiveDamage(int damageAmount)
        {
            healthManager.ReceiveDamage(damageAmount);
        }

        public void StartMoving()
        {
            StartCoroutine(Move());
        }
        
        public void InitializeMoving(List<Vector3> movementTargets, OnPathEnd onPathEnd)
        {
            healthManager = new EnemyHealth(startHealth, EnemyHealth_OnDeath);
            shootingManager = new EnemyShooting(this, projectilePrefab, muzzle, damage, direction, cooldown);
            this.movementTargets = movementTargets;
            this.onPathEnd = onPathEnd;
            currentTargetObject = 0;
        }

        public void InitializeStationary(Transform player, LevelMover levelMover)
        {
            healthManager = new EnemyHealth(startHealth, EnemyHealth_OnDeath);
            shootingManager = new EnemyShooting(this, projectilePrefab, muzzle, damage, direction, cooldown, player);
            triggerCoordinate = transform.position.x - 10.0f;
            this.levelMover = levelMover;
            levelMover.OnUpdatedPosition += LevelMover_OnUpdatedPosition;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        private IEnumerator Move()
        {
            while(true)
            {
                if (transform.position != movementTargets[currentTargetObject])
                {
                    transform.position =
                        Vector3.MoveTowards(transform.position, movementTargets[currentTargetObject], speed);
                }
                else
                {
                    currentTargetObject += 1;
                    if (currentTargetObject >= movementTargets.Count)
                    {
                        switch (onPathEnd)
                        {
                            case OnPathEnd.MoveToStart:
                                currentTargetObject = 0;
                                break;
                            case OnPathEnd.TeleportToStart:
                                transform.position = movementTargets[0];
                                currentTargetObject = 1;
                                break;
                            case OnPathEnd.Destroy:
                                Destroy(gameObject);
                                break;
                        }
                    }
                }

                yield return new WaitForFixedUpdate();
            }
        }


        private void EnemyHealth_OnDeath()
        {
            Destroy(gameObject);
        }

        private void LevelMover_OnUpdatedPosition(float position)
        {
            if (position < -triggerCoordinate)
            {
                levelMover.OnUpdatedPosition -= LevelMover_OnUpdatedPosition;
                levelMover.OnUpdatedPosition += LevelMover_OnUpdatedPositionObjectDestruction;
                StartShooting();
            }

        }
        private void LevelMover_OnUpdatedPositionObjectDestruction(float position)
        {
            if (position < -(triggerCoordinate + 25.0f))
            {
                levelMover.OnUpdatedPosition -= LevelMover_OnUpdatedPositionObjectDestruction;
                Destroy(gameObject);
            }
        }
        

    }

    public enum EnemyType
    {
        Moving = 0,
        Stationary = 1
    }
}