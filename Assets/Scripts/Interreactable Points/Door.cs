using UnityEngine;

namespace SuareDemo
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private string _tag;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                SendTag();
            }
        }

        private void SendTag()
        {
            DoorCollectableSetter.SetTag?.Invoke(_tag);
        }
    }
}