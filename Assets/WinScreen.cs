using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private Button exitToMenu;
    [SerializeField] private Button restart;

    private void Awake()
    {
        exitToMenu.onClick.AddListener((() => SceneManager.LoadScene("MainMenu")));
        restart.onClick.AddListener((() => SceneManager.LoadScene("Gameplay")));
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
