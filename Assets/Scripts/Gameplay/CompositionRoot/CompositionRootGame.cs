using CompositionRoot.Gameplay;
using Gamepaly.LevelData;
using Gameplay.Weapons;
using Gameplay.Weapons.Visuals;
using Gameplay.CheatScripts;
using Gameplay.Controls;
using Gameplay.ShipData;
using Gameplay.UI;
using UnityEngine;

namespace CompositionRoot
{
    public class CompositionRootGame : MonoBehaviour
    {
        [SerializeField] private GameUIController uiPrefab;
        [SerializeField] private MainShip shipController;
        [SerializeField] private Tracer shotPrefab;
        [SerializeField] private LevelMover levelTarget;
        [SerializeField] private Transform stationaryLevelTarget;
        [SerializeField] private LevelData levelData;

        [SerializeField] private BaseWeapon weapon;

        void Start()
        {
            //Loads BaseLine stats from consistent stuff
            var levelConstructor = new LevelGenerator(levelData, levelTarget, stationaryLevelTarget, shipController);
            
            int receivedHealth = 100;
            var healthController = new HealthController(receivedHealth);

            var heatController = gameObject.AddComponent<HeatController>();
            heatController.Initialize(100, 1);
            
            IMovementController movementController = gameObject.AddComponent<KeyboardMovementController>();

            GameUIController uiController = Instantiate(uiPrefab);
            uiController.Setup(healthController, heatController);
            
            shipController.Initialize(movementController, weapon, healthController, heatController);

            //new PlayerStuff
            //new EnemyFactory
            //new UiModel
            //get Sound

            #if UNITY_EDITOR || DEBUG
                HotkeyDebugger hotkeyDebugger = gameObject.AddComponent<HotkeyDebugger>();
                hotkeyDebugger.Setup(healthController, heatController);
            #endif
        }
    }
}
