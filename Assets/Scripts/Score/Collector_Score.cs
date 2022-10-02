using UnityEngine;

namespace SuareDemo
{
    [RequireComponent(typeof(ScoreHandler))]
    public class Collector_Score : MonoBehaviour
    {
        [SerializeField] private string _tagCollectable = "Collectable";
        private ScoreHandler _scoreHandler;

        private void Awake()
        {
            _scoreHandler = GetComponent<ScoreHandler>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(_tagCollectable))
                return;

            _scoreHandler.ScoreUp();
        }
    }
}