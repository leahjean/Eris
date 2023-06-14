using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
        public Image mHealthValue;

        private Slider mSlider;

        public void Awake()
        {
            mSlider = GetComponent<Slider>();
        }

        public void SetHealth(float health)
        {
            mSlider.value = health;
        }

        public void SetMaxHealth(float maxHealth)
        {
            mSlider.maxValue = maxHealth;
        }

        public void InitMaxHealth(float maxHealth)
        {
            mSlider.maxValue = maxHealth;
            SetHealth(maxHealth);
        }
    }
}