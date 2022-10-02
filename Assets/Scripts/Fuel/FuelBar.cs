using System;
using UnityEngine;
using UnityEngine.UI;

namespace SuareDemo
{
    [RequireComponent(typeof(Image))]
    public class FuelBar : MonoBehaviour
    {
        public static Action<float> OnFuelAmountChanged = delegate { };
        private Image _bar;

        private void Awake()
        {
            _bar = GetComponent<Image>();

        }

        private void OnEnable()
        {
            OnFuelAmountChanged += BarValue;
        }

        private void OnDisable()
        {
            OnFuelAmountChanged -= BarValue;
        }

        private void BarValue(float value)
        {
            _bar.fillAmount = value / 100;
        }
    }
}