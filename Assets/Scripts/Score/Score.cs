using UnityEngine;
using UnityEngine.UI;

namespace SuareDemo
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private SO_ScoreHolder _scoreHolder;
        private Text _scoreText;

        private void Awake()
        {
            _scoreText = GetComponent<Text>();
        }

        private void OnEnable()
        {
            _scoreText.text = "Score: " + _scoreHolder.Score.ToString();
        }
    }
}