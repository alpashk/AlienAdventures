using UnityEngine;

namespace Gameplay.LevelComponents
{
    public class LevelMidground : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
    
        public void Setup(Sprite sprite, Vector3 position)
        {
            spriteRenderer.sprite = sprite;
            transform.position = position;
        }
    }
}
