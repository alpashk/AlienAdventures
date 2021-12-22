using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour
{
    void Start()
    {
        /*Something could be here*/
        SceneManager.LoadScene("MainMenu");
    }

}
