using Gameplay.Health;
using TMPro;
using UnityEngine;

namespace Gameplay.UI
{
    public class GameUIController : MonoBehaviour
    {
        [SerializeField] private TMP_Text health;
        [SerializeField] private TMP_Text maxHealth;
        [SerializeField] private TMP_Text dead;

        public void Setup(IHealthController healthController)
        {
            healthController.SetupCallbacks(ChangeDisplayedHealth, DisplayDeathScreen);
            maxHealth.text = healthController.MaxHealth.ToString();
        }

        private void ChangeDisplayedHealth(int currentHealth)
        {
            health.text = currentHealth.ToString();
        }

        private void DisplayDeathScreen()
        {
            dead.text = "lol u died";
        }
    }
}
