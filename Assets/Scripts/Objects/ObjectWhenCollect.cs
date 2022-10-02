using UnityEngine;

namespace SuareDemo
{
    public class ObjectWhenCollect : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            if (!gameObject.CompareTag("Collectable"))
            {
                Debug.Log("tag Collectable deðil");
                return;
            }

            gameObject.SetActive(false);

            ObjectActivator[] actiavator = FindObjectsOfType<ObjectActivator>(false);

            for (int i = 0; i < actiavator.Length; i++)
            {
                if (!actiavator[i].IsAvaible)
                    continue;

                actiavator[i].Activate();
                break;
            }
        }
    }
}