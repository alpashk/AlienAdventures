using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBackground : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public float Width => spriteRenderer.bounds.size.x;

    public void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
}
