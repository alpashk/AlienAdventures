using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMover : MonoBehaviour
{

    [SerializeField] private float levelSpeed = 0.01f;
    private float defaultSpeed;

    public Action<float> OnUpdatedPosition;

    public float LevelSpeed
    {
        get => levelSpeed;
        set => levelSpeed = value;
    }

    public void ChangeSpeed(float newSpeed)
    {
        
    }

    public void RestoreSpeed()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * levelSpeed);
        OnUpdatedPosition?.Invoke(transform.position.x);
    }
}
