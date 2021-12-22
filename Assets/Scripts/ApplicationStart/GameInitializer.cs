using UnityEngine;
using UnityEngine.SceneManagement;

namespace ApplicationStart
{
    public class GameInitializer : MonoBehaviour
    {
        void Start()
        {
            /*Something could be here*/
            SceneManager.LoadScene("MainMenu");
        }

    }
}
