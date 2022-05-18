using Gameplay.Controls;
using UnityEngine;

namespace Gameplay.ShipControls
{
    public class ShipController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float speed = 3.0f;
        
        private Rigidbody2D rb;
    
        private float borderOffset = 0.3f;

        private float verticalBorder;
        private float horizontalBorder;

        private IMovementController movementController;

        #endregion



        #region Unity lifecycle

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            Camera mainCamera = Camera.main;
            Vector2 screenBounds =
                mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            Vector3 spriteBounds = spriteRenderer.bounds.size;

            horizontalBorder = screenBounds.x - spriteBounds.x / 2 - borderOffset;
            verticalBorder = screenBounds.y - spriteBounds.y / 2 - borderOffset;
        
            Debug.Log(horizontalBorder);
            Debug.Log(verticalBorder);
        }

        
        private void Update()
        {
            float x = movementController.XMove;
            float y = movementController.YMove;

            Move(new Vector2(x, y));
        }

        private void LateUpdate()
        {
            Vector3 currentPosition = transform.position;
    
            currentPosition.x = Mathf.Clamp(currentPosition.x, -horizontalBorder, horizontalBorder);
            currentPosition.y = Mathf.Clamp(currentPosition.y, -verticalBorder, verticalBorder);

            transform.position = currentPosition;
        }

        #endregion

        
        
        #region Methods

        public void Initialize(IMovementController movementController)
        {
            this.movementController = movementController;
        }
        

        private void Move(Vector2 direction)
        {
            Vector2 clampedDirection = Vector2.ClampMagnitude(direction, 1.0f);
            rb.velocity = clampedDirection * speed;
        }

        #endregion
    }
}