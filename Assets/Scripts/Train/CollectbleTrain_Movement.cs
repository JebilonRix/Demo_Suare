using UnityEngine;

namespace SuareDemo
{
    public class CollectbleTrain_Movement : MonoBehaviour
    {
        [SerializeField] private float _lerpSpeed = 0.25f;
        [SerializeField] private float _space = 1f;

        public Transform PreviousVagon { get; set; }

        private void Update()
        {
            if (PreviousVagon == null)
                return;

            transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, PreviousVagon.position.x, _lerpSpeed),
                0,
                PreviousVagon.position.z - _space);
        }
    }
}