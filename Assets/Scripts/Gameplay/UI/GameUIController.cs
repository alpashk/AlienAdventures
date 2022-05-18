using System.Threading.Tasks;
using Gameplay.ShipData.Interfaces;
using TMPro;
using UnityEngine;

namespace Gameplay.UI
{
    public class GameUIController : MonoBehaviour
    {
        [SerializeField] private TMP_Text health;
        [SerializeField] private TMP_Text maxHealth;
        
        [SerializeField] private TMP_Text dead;
        
        [SerializeField] private TMP_Text heat;
        [SerializeField] private TMP_Text maxHeat;
        
        [SerializeField] private TMP_Text overheated;

        public void Setup(IHealthController healthController, IHeatController heatController)
        {
            healthController.OnDeath += DisplayDeathScreen;
            healthController.OnHealthChanged += ChangeDisplayedHealth;
            maxHealth.text = healthController.MaxHealth.ToString();
            ChangeDisplayedHealth(healthController.MaxHealth);
            
            heatController.OnOverheat += DisplayOverheatScreen;
            heatController.OnHeatChanged += ChangeDisplayedHeat;
            maxHeat.text = heatController.MaxHeat.ToString();
            ChangeDisplayedHeat(0);
        }

        private void ChangeDisplayedHealth(int currentHealth)
        {
            health.text = currentHealth.ToString();
        }
        
        private void ChangeDisplayedHeat(int currentHeat)
        {
            heat.text = currentHeat.ToString();
        }

        private void DisplayDeathScreen()
        {
            dead.text = "lol u died";
        }

        private async void DisplayOverheatScreen()
        {
            overheated.text = "overheated";
            await Task.Delay(2000);
            overheated.text = "";
        }
    }
}
