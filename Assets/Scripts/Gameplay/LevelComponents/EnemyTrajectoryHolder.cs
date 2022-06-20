using System.Collections;
using System.Collections.Generic;
using Gamepaly.LevelData;
using Gameplay.Enemies;
using UnityEngine;

namespace Gameplay.LevelComponents
{
    public class EnemyTrajectoryHolder : MonoBehaviour
    {
        [SerializeField] private List<Vector3> movementTargets;
        [SerializeField] private EnemyMover enemyPrefab;
        [SerializeField] private OnPathEnd onPathEnd;
        
        [SerializeField] private int enemyAmount;
        [SerializeField] private float enemyDelay;

        [SerializeField] private float startCoordinate;

        private List<EnemyMover> enemies = new List<EnemyMover>();
        private LevelMover levelMover;

        #region Properties

        public List<Vector3> MovementTargets => movementTargets;

        public EnemyMover EnemyPrefab => enemyPrefab;

        public OnPathEnd OnPathEnd => onPathEnd;

        public int EnemyAmount => enemyAmount;

        public float EnemyDelay => enemyDelay;

        public float StartCoordinate => startCoordinate;

        #endregion

        public void Initialize(LevelMover levelMover, MovingEnemiesData enemyData)
        {
            this.levelMover = levelMover;
            levelMover.OnUpdatedPosition += CheckRequiredPosition;
            
            movementTargets = enemyData.MovementTargets;
            enemyPrefab = enemyData.EnemyPrefab;
            onPathEnd = enemyData.ONPathEnd;
            enemyAmount = enemyData.EnemyAmount;
            enemyDelay = enemyData.EnemyDelay;
            startCoordinate = enemyData.StartCoordinate;

            for (int i = 0; i < enemyAmount; i++)
            {
                EnemyMover enemy = Instantiate(enemyPrefab, transform);
                enemy.SetPosition(movementTargets[0]);
                enemy.Initialize(movementTargets, onPathEnd);
                enemy.gameObject.SetActive(false);
                enemies.Add(enemy);
            }
        }

        private void CheckRequiredPosition(float position)
        {
            if (-startCoordinate > position)
            {
                SendEnemies();
                levelMover.OnUpdatedPosition -= CheckRequiredPosition;
            }
        }

        private void SendEnemies()
        {
            StartCoroutine(SendEnemiesRoutine());
        }

        private IEnumerator SendEnemiesRoutine()
        {
            foreach (var enemy in enemies)
            {
                enemy.gameObject.SetActive(true);
                yield return new WaitForSeconds(enemyDelay);
            }
        }
    }
    
    public enum OnPathEnd
    {
        MoveToStart = 0,
        TeleportToStart = 1,
        Destroy = 2,
    }
}
