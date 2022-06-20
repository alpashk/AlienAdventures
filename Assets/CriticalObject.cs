using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Enemies;
using UnityEngine;

public class CriticalObject : MonoBehaviour
{

    [SerializeField] private EnemyHealth enemyTrigger;
    [SerializeField] private LevelMover levelMover;
    [SerializeField] private WinScreen winScreen;

    private void Awake()
    {
        enemyTrigger.OnDeath += () => winScreen.Show();
    }

    void Update()
    {
        if (transform.position.x <= 4 && levelMover.LevelSpeed>=0)
        {
            levelMover.LevelSpeed -=0.0001f;
        }

        if (levelMover.LevelSpeed < 0)
        {
            levelMover.LevelSpeed = 0;
        }
    }
}
