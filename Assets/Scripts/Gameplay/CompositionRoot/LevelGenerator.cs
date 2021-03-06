using System.Collections.Generic;
using CompositionRoot.Gameplay;
using Gamepaly.LevelData;
using Gameplay.Enemies;
using Gameplay.LevelComponents;
using UnityEngine;

namespace CompositionRoot
{
    public class LevelGenerator
    {
        private LevelData levelData;
        private LevelMover levelMover;
        private Transform levelTarget;
        private Transform stationaryLevelTarget;
        private MainShip ship;

        public LevelGenerator(LevelData levelData, LevelMover levelMover, Transform stationaryLevelTarget,
            MainShip shipController)
        {
            this.levelData = levelData;
            this.levelMover = levelMover;
            levelTarget = levelMover.transform;
            this.stationaryLevelTarget = stationaryLevelTarget;
            ship = shipController;
            
            GenerateBackground();
            GenerateMidground();
            GenerateStationaryEnemies();
            GenerateMovingEnemies();
        }

        private void GenerateBackground()
        {
            float currentX = -10.0f;
            LevelBackground backgroundPrefab = levelData.BackgroundPrefab;
            foreach (BackgroundData backgrounds in levelData.Backgrounds)
            {
                for (int i = 0; i < backgrounds.Amount; i++)
                {
                    LevelBackground background = GameObject.Instantiate(backgroundPrefab, levelTarget);
                    background.SetSprite(backgrounds.BackgroundImage);
                    currentX += background.Width / 2;
                    background.SetPosition(new Vector3(currentX, 0));
                    currentX += background.Width / 2;
                }
            }
        }

        private void GenerateMidground()
        {
            LevelMidground midgroundPrefab = levelData.MidgroundPrefab;
            foreach (MidgroundData midgrounds in levelData.Midgrounds)
            {
                foreach (Vector3 position in midgrounds.Positions)
                {
                    LevelMidground midground = GameObject.Instantiate(midgroundPrefab, levelTarget);
                    midground.Setup(midgrounds.Image, position);
                }
            }
        }

        private void GenerateMovingEnemies()
        {
            foreach (MovingEnemiesData data in levelData.MovingEnemies)
            {
                GameObject trajectoryHolder = new GameObject("EnemyTrajectoryHolder");
                trajectoryHolder.transform.parent = stationaryLevelTarget;
                EnemyTrajectoryHolder trajectory = trajectoryHolder.AddComponent<EnemyTrajectoryHolder>();
                trajectory.Initialize(levelMover, data);
            }
        }
        
        private void GenerateStationaryEnemies()
        {
            foreach (StationaryEnemiesData stationaryEnemies in levelData.StationaryEnemies)
            {
                foreach (Vector3 position in stationaryEnemies.Positions)
                {
                    EnemyData enemy = GameObject.Instantiate(stationaryEnemies.Prefab, levelTarget);
                    enemy.transform.position = position;
                    enemy.InitializeStationary(ship.transform, levelMover);
                }
            }
        }
        
    }
}