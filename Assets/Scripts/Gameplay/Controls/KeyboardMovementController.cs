using System;
using UnityEngine;

namespace Gameplay.Controls
{
    public class KeyboardMovementController : MonoBehaviour, IMovementController
    {
        private float xMove;
        private float yMove;
        private Action onShootPressed;
        private Action onKidnapPressed;


        public float XMove => xMove;
        public float YMove => yMove;

        public Action OnShootPressed => onShootPressed;

        public Action OnKidnapPressed => onKidnapPressed;

        private void Update()
        {
            xMove = Input.GetAxis("Horizontal");
            yMove = Input.GetAxis("Vertical");
            
            if (Input.GetKeyDown(KeyCode.Z))
            {
                onShootPressed?.Invoke();
            }
            
            if (Input.GetKeyDown(KeyCode.X))
            {
                onKidnapPressed?.Invoke();
            }
        }
    }
}