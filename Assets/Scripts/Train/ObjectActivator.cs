using UnityEngine;

namespace SuareDemo
{
    public class ObjectActivator : MonoBehaviour
    {
        [SerializeField] private GameObject[] _coals;
        [SerializeField] private GameObject[] _stickmans;
        private int count = 0;
        private bool _isCoal;

        public bool IsAvaible { get; private set; }

        private void Awake()
        {
            IsAvaible = true;
            count = 0;

            foreach (var item in _coals)
            {
                item.SetActive(false);
            }

            foreach (var item in _stickmans)
            {
                item.SetActive(false);
            }

            enabled = false;
        }

        public void IsCoal(bool isCoal)
        {
            _isCoal = isCoal;
        }

        public void Activate()
        {
            if (count >= _coals.Length)
            {
                IsAvaible = false;
                return;
            }

            if (_isCoal)
            {
                _coals[count].SetActive(true);
            }
            else
            {
                _stickmans[count].SetActive(true);
            }

            count++;
        }
    }
}