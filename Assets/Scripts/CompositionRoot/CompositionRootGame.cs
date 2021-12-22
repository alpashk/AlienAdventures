using UnityEngine;

namespace CompositionRoot
{
    public class CompositionRootGame : MonoBehaviour
    {
        void Start()
        {
            //Loads BaseLine stats from consistent stuff
            
            int recievedHealth = 100;

            var healthController = new HealthController(recievedHealth);
            
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
