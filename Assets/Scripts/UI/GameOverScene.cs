using System;
using UnityEngine;

namespace SuareDemo
{
    public class GameOverScene : MonoBehaviour
    {
        /// <summary>
        /// 0 = Game, 1 = Win, 2 = Lose
        /// </summary>
        public static Action<int> OnGameOver;

        [SerializeField] private GameObject[] _panels;

        private void OnEnable()
        {
            OnGameOver += ChangeActivationOfPanels;
        }

        private void Start()
        {
            ChangeActivationOfPanels(0);
        }

        private void OnDisable()
        {
            OnGameOver -= ChangeActivationOfPanels;
        }

        private void ChangeActivationOfPanels(int index)
        {
            for (int i = 0; i < _panels.Length; i++)
            {
                _panels[i].SetActive(i == index);
            }
        }
    }
}