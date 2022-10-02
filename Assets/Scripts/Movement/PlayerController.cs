using UnityEngine;

namespace SuareDemo
{
    [RequireComponent(typeof(FuelHandler))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _swerveSpeed = 5f;
        [SerializeField] private LayerMask _whatIsRoad;
        private Camera _camera;
        private FuelHandler _fuelHandler;

        public float Speed { get => _speed; set => _speed = value; }

        private void Awake()
        {
            _fuelHandler = GetComponent<FuelHandler>();
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            MovementLogic();
        }

        private void MovementLogic()
        {
            if (_fuelHandler.NoFuel)
                return;

            transform.position += Speed * Time.deltaTime * Vector3.forward;

            //Swerving horizontally.
            if (Input.GetMouseButton(0))
            {
                Methods_Swerve.SwerveHorizontally(transform, Input.mousePosition, _camera, _swerveSpeed, _whatIsRoad);
            }
        }
    }
}