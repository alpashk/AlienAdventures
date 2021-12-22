using System;
using UnityEngine;

namespace Gameplay.Controls
{
    public class KeyboardMovementController : MonoBehaviour, IMovementController
    {
        private float xMove;
        private float yMove;


        public float XMove => xMove;
        public float YMove => yMove;

        private void Update()
        {
            xMove = Input.GetAxis("Horizontal");
            yMove = Input.GetAxis("Vertical");
        }
    }
}