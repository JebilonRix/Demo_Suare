using System.Collections;
using UnityEngine;

namespace SuareDemo
{
    [RequireComponent(typeof(BoxCollider))]
    public class FinishPoint : MonoBehaviour
    {
        [SerializeField] private GameObject _particle;
        [SerializeField] private float _delay = 1f;
        private CameraPositioner positioner;

        private void Awake()
        {
            GetComponent<BoxCollider>().isTrigger = true;
            positioner = FindObjectOfType<CameraPositioner>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerController>().Speed = 0;

                positioner.SetIndex(6);

                StartCoroutine(DelayedParticle());

                GameOverScene.OnGameOver?.Invoke(1);
            }
        }

        private IEnumerator DelayedParticle()
        {
            yield return new WaitForSeconds(_delay);

            _particle.SetActive(true);
        }
    }
}