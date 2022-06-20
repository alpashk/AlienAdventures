using System.Linq;
using Gamepaly.LevelData;
using Gameplay.Enemies;
using UnityEditor;
using UnityEngine;

namespace Gameplay.LevelComponents.Editor
{
   
    public class EditorLevelGenerator : EditorWindow
    {
        private string name;
        private LevelData levelData;
        
        [MenuItem("Window/Generate Level")]
        public static void ShowWindow()
        {
            GetWindow<EditorLevelGenerator>("Generate Level");
        }
        
        
        private void OnGUI()
        {
            name = EditorGUILayout.TextField("File name", name);
            if (GUILayout.Button("Generate"))
            {
                LevelGeneration();
            }

            levelData = EditorGUILayout.ObjectField(levelData, typeof(LevelData), false) as LevelData;
            
            if (GUILayout.Button("Add objects from file to scene"))
            {
                GenerateLevelFromAsset();
            }
        }
 
        private void LevelGeneration()
        {
            LevelData generatedLevel = CreateInstance<LevelData>();

            GameObject stationaryObject = GameObject.Find("StationaryLevel");

            foreach (Transform child in stationaryObject.transform)
            {
                if (child.TryGetComponent(out EnemyTrajectoryHolder holder))
                {
                    MovingEnemiesData data = new MovingEnemiesData(holder.MovementTargets, holder.EnemyPrefab,
                        holder.OnPathEnd, holder.EnemyAmount, holder.EnemyDelay, holder.StartCoordinate);
                    generatedLevel.MovingEnemies.Add(data);
                }
            }

            GameObject movingObject = GameObject.Find("MovingLevel");
            
            foreach (Transform child in movingObject.transform)
            {
                switch (child.gameObject.layer)
                {
                    case 6:
                    {
                        if (child.TryGetComponent(out SpriteRenderer sprite))
                        {
                            BackgroundData data =
                                generatedLevel.Backgrounds.Find(x => x.BackgroundImage == sprite.sprite);
                            if (data != null)
                            {
                                data.Amount++;
                            }
                            else
                            {
                                generatedLevel.Backgrounds.Add(new BackgroundData(sprite.sprite));
                            }
                        }

                        break;
                    }

                    case 7:
                    {
                        if (child.TryGetComponent(out SpriteRenderer sprite))
                        {
                            MidgroundData data =
                                generatedLevel.Midgrounds.Find(x => x.Image == sprite.sprite);
                            if (data != null)
                            {
                                data.Positions.Add(child.position);
                            }
                            else
                            {
                                generatedLevel.Midgrounds.Add(new MidgroundData(sprite.sprite, child.position));
                            }
                        }
                        break;
                    }

                    case 9:
                    {
                        if (child.TryGetComponent(out EnemyData enemy))
                        {
                            var prefab = PrefabUtility.GetCorrespondingObjectFromSource(enemy);
                            if (prefab != null)
                            {
                                StationaryEnemiesData data =
                                    generatedLevel.StationaryEnemies.Find(x => x.Prefab == prefab);
                                if (data != null)
                                {
                                    data.Positions.Add(child.position);
                                }
                                else
                                {
                                    generatedLevel.StationaryEnemies.Add(new StationaryEnemiesData(prefab, child.position));
                                }
                            }
                        }

                        break;
                    }
                }
            }
            
            AssetDatabase.CreateAsset(generatedLevel, $"Assets/DataStorage/{name}.asset");
        }

        private void GenerateLevelFromAsset()
        {
            GameObject levelTarget = GameObject.Find("MovingLevel");
            GameObject stationaryTarget = GameObject.Find("StationaryLevel");
            GenerateBackground(levelTarget.transform);
            GenerateMidground(levelTarget.transform);
            GenerateStationaryEnemies(levelTarget.transform);
            GenerateMovingEnemies(stationaryTarget.transform);
        }
        
        private void GenerateBackground(Transform levelTarget)
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

        private void GenerateMidground(Transform levelTarget)
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

        private void GenerateStationaryEnemies(Transform levelTarget)
        {
            foreach (StationaryEnemiesData stationaryEnemies in levelData.StationaryEnemies)
            {
                foreach (Vector3 position in stationaryEnemies.Positions)
                {
                    EnemyData enemy = GameObject.Instantiate(stationaryEnemies.Prefab, levelTarget);
                }
            }
        }

        private void GenerateMovingEnemies(Transform stationaryLevelTarget)
        {
            foreach (MovingEnemiesData data in levelData.MovingEnemies)
            {
                GameObject trajectoryHolder = new GameObject("EnemyTrajectoryHolder");
                trajectoryHolder.transform.parent = stationaryLevelTarget;
                EnemyTrajectoryHolder trajectory = trajectoryHolder.AddComponent<EnemyTrajectoryHolder>();
                trajectory.Initialize(null, data);
            }
        }
        
    }
}