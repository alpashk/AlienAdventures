using Gameplay.CheatScripts;
using Gameplay.Controls;
using Gameplay.Health;
using Gameplay.UI;
using UnityEngine;

namespace CompositionRoot
{
    public class CompositionRootGame : MonoBehaviour
    {
        [SerializeField] private GameUIController uiPrefab;
        void Start()
        {
            //Loads BaseLine stats from consistent stuff
            
            int receivedHealth = 100;
            
            

            var healthController = new HealthController(receivedHealth);

            IMovementController movementController = gameObject.AddComponent<KeyboardMovementController>();

            GameUIController uiController = Instantiate(uiPrefab);
            uiController.Setup(healthController);

            //new Controller
            //new PlayerStuff
            //new EnemyFactory
            //new UiModel
            //get Sound
            
            #if UNITY_EDITOR || DEBUG
            
            HotkeyHealer hotkeyHealer = gameObject.AddComponent<HotkeyHealer>();
            hotkeyHealer.Setup(healthController);
            
            #endif
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
