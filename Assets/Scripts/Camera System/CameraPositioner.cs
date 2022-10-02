using System.Collections.Generic;
using UnityEngine;

namespace SuareDemo
{
    public class CameraPositioner : MonoBehaviour
    {
        [Header("Target")]
        [SerializeField] private Transform _target;
        [SerializeField] private bool _followTarget = true;

        [Header("Camera Movement")]
        [SerializeField][Range(0.1f, 10f)] private float _speed = 5f;
        [SerializeField] private bool _setPosition = true;
        [SerializeField] private bool _setRotation = true;
        [SerializeField] private List<PositionAndRotation> _cameraPositions = new();
        private int _index = 0;

        public List<PositionAndRotation> CameraPositions => _cameraPositions;
        public bool SetPosition => _setPosition;
        public bool SetRotation => _setRotation;

        private void Start()
        {
            if (_followTarget && _target == null)
            {
                _target = GameObject.Find("Player").transform;
            }

            SetIndex(0);
        }

        private void LateUpdate()
        {
            if (CameraPositions == null)
            {
                Debug.Log("There is no position preset. Please add one.");
                return;
            }

            Move(_index);
        }

        public void SetIndex(int id)
        {
            _index = id;
        }

        private void Move(int id)
        {
            if (_followTarget && _target == null)
            {
                return;
            }

            if (SetPosition)
            {
                transform.position = Vector3.Lerp(transform.position, _target.transform.position + CameraPositions[id].Position, Time.deltaTime * _speed);
            }
            if (SetRotation)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(CameraPositions[id].Rotation), Time.deltaTime * _speed);
            }
        }
    }

#if UNITY_EDITOR

    [UnityEditor.CustomEditor(typeof(CameraPositioner))]
    public class CameraPositionerEditor : UnityEditor.Editor
    {
        private CameraPositioner positioner;
        private int _index = 0;

        private int Index
        {
            get
            {
                if (_index >= positioner.CameraPositions.Count)
                {
                    _index = 0;
                }
                else if (_index < 0)
                {
                    _index = positioner.CameraPositions.Count - 1;
                }

                return _index;
            }

            set => _index = value;
        }

        private void OnEnable()
        {
            Index = 0;
            positioner = (CameraPositioner)target;
        }

        private void OnDisable()
        {
            Index = 0;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Next Position"))
            {
                ToPosition(1);
            }

            if (GUILayout.Button("Previous Position"))
            {
                ToPosition(-1);
            }
        }

        private void ToPosition(int index)
        {
            Index += index;

            if (positioner.SetPosition)
            {
                positioner.transform.position = positioner.CameraPositions[Index].Position;
            }
            if (positioner.SetRotation)
            {
                positioner.transform.rotation = Quaternion.Euler(positioner.CameraPositions[Index].Rotation);
            }
        }
    }

#endif
}