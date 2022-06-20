using System.Threading.Tasks;
using Gameplay.ShipData.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI
{
    public class GameUIController : MonoBehaviour
    {
        [SerializeField] private Image healthImage;
        [SerializeField] private Image heatImage;
        
        [SerializeField] private TMP_Text dead;

        [SerializeField] private TMP_Text overheated;

        private int maxHealth;
        private int maxHeat;

        public void Setup(IHealthController healthController, IHeatController heatController)
        {
            healthController.OnDeath += DisplayDeathScreen;
            healthController.OnHealthChanged += ChangeDisplayedHealth;
            
            ChangeDisplayedHealth(healthController.MaxHealth);
            
            heatController.OnOverheat += DisplayOverheatScreen;
            heatController.OnHeatChanged += ChangeDisplayedHeat;
            heatController.OnHeatReachedZero += StopOverheatScreen;

            maxHealth = healthController.MaxHealth;
            maxHeat = heatController.MaxHeat;

            healthImage.fillAmount = 1;
            heatImage.fillAmount = 0;
            ChangeDisplayedHeat(0);
        }

        private void ChangeDisplayedHealth(int currentHealth)
        {
            healthImage.fillAmount = (float) currentHealth / maxHealth;
        }
        
        private void ChangeDisplayedHeat(int currentHeat)
        {
            heatImage.fillAmount = (float) currentHeat / maxHeat;
        }

        private void DisplayDeathScreen()
        {
            dead.text = "lol u died";
        }

        private void DisplayOverheatScreen()
        {
            overheated.text = "overheated";
        }

        private void StopOverheatScreen()
        {
            overheated.text = "";
        }
        
    }
}
