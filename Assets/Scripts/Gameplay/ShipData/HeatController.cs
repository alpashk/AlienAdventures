using System;
using System.Collections;
using System.Threading.Tasks;
using Gameplay.ShipData.Interfaces;
using UnityEngine;

namespace Gameplay.ShipData
{
    public class HeatController : MonoBehaviour, IHeatController
    {

        #region Fields

        private int maxHeat;
        private int currentHeat;
        private int heatDecrease;

        private float timeInterval;

        private Action<int> onHeatChanged;
        private Action onOverheat;

        #endregion

        
        
        #region Properties

        public Action<int> OnHeatChanged
        {
            get => onHeatChanged;
            set => onHeatChanged = value;
        }

        public Action OnOverheat
        {
            get => onOverheat;
            set => onOverheat = value;
        }

        public int MaxHeat => maxHeat;

        #endregion



        #region Class lifecycle

        public void Initialize(int maxHeat, int heatDecrease, float timeInterval = 0.1f)
        {
            this.maxHeat = maxHeat;
            this.heatDecrease = heatDecrease;
            this.timeInterval = timeInterval;
            
            currentHeat = 0;

            StartCoroutine(CooldownCycle());
        }

        #endregion
        

        #region Methods

        public void ChangeHeat(int changeAmount)
        {
            currentHeat += changeAmount;
            if (currentHeat > maxHeat)
            {
                currentHeat = maxHeat;
                onHeatChanged?.Invoke(currentHeat);
                onOverheat?.Invoke();
            }
            else if (currentHeat <= 0)
            {
                currentHeat = 0;
                onHeatChanged?.Invoke(currentHeat);
            }
            else
            {
                onHeatChanged?.Invoke(currentHeat);
            }
        }


        private IEnumerator CooldownCycle()
        {
            while (true)
            {
                if (currentHeat > 0)
                {
                    ChangeHeat(-heatDecrease);
                }
                yield return new WaitForSeconds(timeInterval);
            }
        }

        #endregion
    }
}