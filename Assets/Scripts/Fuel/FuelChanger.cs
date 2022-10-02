using UnityEngine;

namespace SuareDemo
{
    [RequireComponent(typeof(BoxCollider))]
    public class FuelChanger : MonoBehaviour
    {
        [SerializeField] private int _changeAmount = 10;

        private void Start()
        {
            GetComponent<BoxCollider>().isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;

            other.GetComponent<FuelHandler>().ChangeFuelAmount(_changeAmount);

            gameObject.SetActive(false);
        }
    }
}