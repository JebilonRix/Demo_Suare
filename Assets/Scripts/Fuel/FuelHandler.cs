using UnityEngine;

namespace SuareDemo
{
    public class FuelHandler : MonoBehaviour
    {
        [SerializeField] private float _fuelAmount = 50;
        [SerializeField] private float _fuelConsumptionPerSeconds = 1f;
        private float _timerSeconds = 0;
        private bool _isInvoked = false;

        public bool NoFuel { get; private set; }

        private void Start()
        {
            _isInvoked = false;
            NoFuel = false;
            FuelBar.OnFuelAmountChanged?.Invoke(_fuelAmount);
        }

        private void Update()
        {
            FuelConsumption();
        }

        public void ChangeFuelAmount(int amount)
        {
            _fuelAmount += amount;

            if (_fuelAmount < 0)
                _fuelAmount = 0;

            FuelBar.OnFuelAmountChanged?.Invoke(_fuelAmount);
        }

        private void FuelConsumption()
        {
            //Out of fuel.
            if (_fuelAmount <= 0)
            {
                NoFuel = true;

                if (!_isInvoked)
                {
                    GameOverScene.OnGameOver?.Invoke(2);
                    _isInvoked = true;
                }

                return;
            }

            _timerSeconds += Time.deltaTime;

            if (_timerSeconds < 1f)
                return;

            _fuelAmount -= _fuelConsumptionPerSeconds;
            FuelBar.OnFuelAmountChanged?.Invoke(_fuelAmount);

            _timerSeconds = 0f;
        }
    }
}