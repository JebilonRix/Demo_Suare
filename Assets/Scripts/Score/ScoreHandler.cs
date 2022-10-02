using UnityEngine;

namespace SuareDemo
{
    public class ScoreHandler : MonoBehaviour
    {
        [SerializeField] private SO_ScoreHolder _scoreHolder;

        private void Start()
        {
            _scoreHolder.Score = 0;
        }

        public void ScoreUp()
        {
            _scoreHolder.Score++;
        }
    }
}