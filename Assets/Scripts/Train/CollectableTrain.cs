using UnityEngine;

namespace SuareDemo
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(CollectbleTrain_Movement))]
    [RequireComponent(typeof(ObjectActivator))]
    public class CollectableTrain : MonoBehaviour
    {
        [SerializeField] private GameObject _coal;
        [SerializeField] private GameObject _people;
        private BoxCollider _box;
        private ObjectActivator _objectActivator;

        private void Awake()
        {
            _box = GetComponent<BoxCollider>();
            _objectActivator = GetComponent<ObjectActivator>();
            _box.isTrigger = true;
        }

        private void Start()
        {
            ChangeTrainType(true);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;

            _box.enabled = false;
            other.GetComponent<Collector_Train>().StackTrain(transform);
            _objectActivator.enabled = true;
        }

        public void ChangeTrainType(bool isCoal)
        {
            _coal.SetActive(isCoal);
            _people.SetActive(!isCoal);
        }
    }
}