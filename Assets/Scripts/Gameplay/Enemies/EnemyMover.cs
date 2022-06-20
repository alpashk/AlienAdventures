using System.Collections;
using System.Collections.Generic;
using Gameplay.LevelComponents;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Vector3> movementTargets;
    [SerializeField] private OnPathEnd onPathEnd;
    [SerializeField] private float speed;

    [SerializeField] private int currentTargetObject;
    public void Initialize(List<Vector3> movementTargets, OnPathEnd onPathEnd)
    {
        this.movementTargets = movementTargets;
        this.onPathEnd = onPathEnd;
        currentTargetObject = 0;
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (transform.position != movementTargets[currentTargetObject]) 
        {  
            transform.position = Vector3.MoveTowards(transform.position, movementTargets[currentTargetObject], speed);
        } 
        else
        {
            currentTargetObject += 1;
            if (currentTargetObject >= movementTargets.Count)
            {
                switch (onPathEnd)
                {
                    case OnPathEnd.MoveToStart:
                        currentTargetObject = 0;
                        break;
                    case OnPathEnd.TeleportToStart:
                        transform.position = movementTargets[0];
                        currentTargetObject = 1;
                        break;
                    case OnPathEnd.Destroy:
                        Destroy(gameObject);
                        break;
                }
            }
        }
    }
}
