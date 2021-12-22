using Gameplay.Controls;
using UnityEngine;

namespace CompositionRoot
{
    public class CompositionRootGame : MonoBehaviour
    {
        void Start()
        {
            //Loads BaseLine stats from consistent stuff
            
            int receivedHealth = 100;
            
            

            var healthController = new HealthController(receivedHealth);

            IMovementController movementController = gameObject.AddComponent<KeyboardMovementController>();

            //new Controller
            //new PlayerStuff
            //new EnemyFactory
            //new UiModel
            //get Sound
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
