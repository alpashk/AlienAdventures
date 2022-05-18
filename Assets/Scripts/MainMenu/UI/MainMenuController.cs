using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button play;

    public void Setup()
    {
        //might be needed
    }
    
    
    void Start()
    {
        play.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Gameplay");
            //playSound;
        });
    }
    
}
