using System;
using Gameplay.Health;
using UnityEngine;

namespace Gameplay.CheatScripts
{
    public class HotkeyHealer : MonoBehaviour
    {
        private IHealthController healthController;

        public void Setup(IHealthController healthController)
        {
            this.healthController = healthController;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                healthController.ChangeHealth(10);
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                healthController.ChangeHealth(-10);
            }
        }
    }
}