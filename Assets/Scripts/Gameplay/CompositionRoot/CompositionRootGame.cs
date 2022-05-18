using Gameplay.CheatScripts;
using Gameplay.Controls;
using Gameplay.ShipControls;
using Gameplay.ShipData;
using Gameplay.UI;
using UnityEngine;

namespace CompositionRoot
{
    public class CompositionRootGame : MonoBehaviour
    {
        [SerializeField] private GameUIController uiPrefab;
        [SerializeField] private ShipController shipController;

        void Start()
        {
            //Loads BaseLine stats from consistent stuff
            int receivedHealth = 100;
            
            var healthController = new HealthController(receivedHealth);
            var heatController = gameObject.AddComponent<HeatController>();
            heatController.Initialize(100, 1);

            IMovementController movementController = gameObject.AddComponent<KeyboardMovementController>();

            GameUIController uiController = Instantiate(uiPrefab);
            uiController.Setup(healthController, heatController);
            
            shipController.Initialize(movementController);

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
