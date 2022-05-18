using Gameplay.ShipData.Interfaces;
using UnityEngine;

namespace Gameplay.CheatScripts
{
    public class HotkeyDebugger : MonoBehaviour
    {
        private IHealthController healthController;
        private IHeatController heatController;

        public void Setup(IHealthController healthController, IHeatController heatController)
        {
            this.healthController = healthController;
            this.heatController = heatController;
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

            if (Input.GetKeyDown(KeyCode.O))
            {
                heatController.ChangeHeat(10);
            }
        }
    }
}