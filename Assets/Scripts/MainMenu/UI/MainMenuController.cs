using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button play;
    [SerializeField] private Button shopButton;

    [SerializeField] private GameObject ShopWindow;

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
        
        shopButton.onClick.AddListener(() => ShopWindow.SetActive(true));
    }
    
}
