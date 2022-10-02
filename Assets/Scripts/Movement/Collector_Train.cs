using UnityEngine;

namespace SuareDemo
{
    [RequireComponent(typeof(PlayerController))]
    public class Collector_Train : MonoBehaviour
    {
        [SerializeField] private float _spaceBetweenVagons = 15f;
        private CameraPositioner cameraPositioner;
        private Transform lastOne;
        private int index = 0;

        private void Start()
        {
            index = 0;
            lastOne = GetComponent<PlayerController>().GetComponent<Transform>();
            cameraPositioner = FindObjectOfType<CameraPositioner>();
        }

        public void StackTrain(Transform train)
        {
            train.GetComponent<CollectbleTrain_Movement>().PreviousVagon = lastOne;
            train.position = lastOne.position + new Vector3(0, 0, _spaceBetweenVagons);
            lastOne = train;

            if (index < 5)
            {
                index++;
                cameraPositioner.SetIndex(index);
            }
        }
    }
}