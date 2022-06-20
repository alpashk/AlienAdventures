using System;
using System.Collections.Generic;
using Gameplay.LevelComponents;
using UnityEngine;

namespace Gamepaly.LevelData
{
    [CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LevelData", order = 1)]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private LevelBackground backgroundPrefab;
        [SerializeField] private LevelMidground midgroundPrefab;
        [SerializeField] private List<BackgroundData> backgrounds = new List<BackgroundData>();
        [SerializeField] private List<MidgroundData> midgrounds = new List<MidgroundData>();
        [SerializeField] private List<MovingEnemiesData> movingEnemies = new List<MovingEnemiesData>();

        public LevelBackground BackgroundPrefab => backgroundPrefab;

        public LevelMidground MidgroundPrefab => midgroundPrefab;

        public List<BackgroundData> Backgrounds => backgrounds;
        
        public List<MidgroundData> Midgrounds => midgrounds;
        
        public List<MovingEnemiesData> MovingEnemies => movingEnemies;
    }


    [Serializable]
    public class BackgroundData
    {
        [SerializeField] private Sprite backgroundImage;
        [SerializeField] private int amount;

        public Sprite BackgroundImage => backgroundImage;

        public int Amount
        {
            get => amount;
            set => amount = value;
        }

        public BackgroundData(Sprite backgroundImage)
        {
            this.backgroundImage = backgroundImage;
            amount = 1;
        }
    }

    [Serializable]
    public class MidgroundData
    {
        [SerializeField] private Sprite image;
        [SerializeField] private List<Vector3> positions;

        public Sprite Image => image;

        public List<Vector3> Positions => positions;

        public MidgroundData(Sprite image, Vector3 position)
        {
            this.image = image;
            positions = new List<Vector3> {position};
        }
    }


    [Serializable]
    public class MovingEnemiesData
    {
        [SerializeField] private List<Vector3> movementTargets;
        [SerializeField] private EnemyMover enemyPrefab;
        [SerializeField] private OnPathEnd onPathEnd;
        
        [SerializeField] private int enemyAmount;
        [SerializeField] private float enemyDelay;

        [SerializeField] private float startCoordinate;
        

        public List<Vector3> MovementTargets => movementTargets;

        public EnemyMover EnemyPrefab => enemyPrefab;

        public OnPathEnd ONPathEnd => onPathEnd;

        public int EnemyAmount => enemyAmount;

        public float EnemyDelay => enemyDelay;

        public float StartCoordinate => startCoordinate;

        public MovingEnemiesData(List<Vector3> movementTargets, EnemyMover enemyPrefab, OnPathEnd onPathEnd, int enemyAmount, float enemyDelay, float startCoordinate)
        {
            this.movementTargets = movementTargets;
            this.enemyPrefab = enemyPrefab;
            this.onPathEnd = onPathEnd;
            this.enemyAmount = enemyAmount;
            this.enemyDelay = enemyDelay;
            this.startCoordinate = startCoordinate;
        }
    }
}