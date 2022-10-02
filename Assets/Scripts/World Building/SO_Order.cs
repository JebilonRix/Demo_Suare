using UnityEngine;

namespace SuareDemo
{
    [CreateAssetMenu(menuName = "Red Panda/Order")]
    public class SO_Order : ScriptableObject
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private GamePart _part;
        [SerializeField] private int _amount = 10;
        [SerializeField] private Vector3 rotation;
        [SerializeField] private Vector3 scale;

        public GameObject Prefab => _prefab;
        public int Amount => _amount;
        public GamePart Part => _part;
        public Vector3 Rotation => rotation;
        public Vector3 Scale => scale;
    }
}