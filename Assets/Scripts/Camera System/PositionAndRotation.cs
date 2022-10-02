using System;
using UnityEngine;

namespace SuareDemo
{
    [Serializable]
    public class PositionAndRotation
    {
        [SerializeField] private Vector3 _position;
        [SerializeField] private Vector3 _rotation;

        public Vector3 Position => _position;
        public Vector3 Rotation => _rotation;
    }
}