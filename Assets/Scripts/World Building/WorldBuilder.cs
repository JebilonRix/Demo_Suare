using System.Collections.Generic;
using UnityEngine;

namespace SuareDemo
{
    public class WorldBuilder : MonoBehaviour
    {
        [Header("Platforms")]
        [SerializeField] private GameObject _platformPrefab;
        [SerializeField] private int _platformAmount;
        [SerializeField] private float _distanceBetweenTwoPlatforms = 4f;
        [SerializeField] private SO_Order[] _orders;

        [ContextMenu("Build Road")]
        private void BuildRoad()
        {
            if (_platformPrefab == null)
                return;

            for (int i = 0; i < _platformAmount; i++)
            {
                GameObject platform = Instantiate(_platformPrefab, _platformPrefab.transform.position + new Vector3(0, 0, _distanceBetweenTwoPlatforms * i), Quaternion.identity);
                platform.transform.localScale = new Vector3(0.02f, 0.025f, 0.02f);
                platform.transform.rotation = Quaternion.Euler(-90, -90, 0);
                platform.transform.SetParent(transform);
            }
        }

        [ContextMenu("Spawn Randomly")]
        private void SpawnRandomly()
        {
            for (int i = 0; i < _orders.Length; i++)
            {
                List<Vector3> _positions = new();

                for (int j = 0; j < _orders[i].Amount; j++)
                {
                    float x = Random.Range(-1.5f, 1.5f);
                    float z = 0;

                    switch (_orders[i].Part)
                    {
                        case GamePart.First_Half:
                            z = Random.Range(5f, 95f);

                            break;

                        case GamePart.Second_Half:
                            z = Random.Range(105f, 192f);
                            break;
                    }

                    _positions.Add(new Vector3(x, 0, z));
                }

                for (int z = 0; z < _positions.Count; z++)
                {
                    GameObject obj = Instantiate(_orders[i].Prefab, _positions[z], Quaternion.identity);

                    if (_orders[i].Scale != Vector3.zero)
                    {
                        obj.transform.localScale = new Vector3(_orders[i].Scale.x, _orders[i].Scale.y, _orders[i].Scale.z);
                    }

                    if (_orders[i].Rotation != Vector3.zero)
                    {
                        obj.transform.rotation = Quaternion.Euler(_orders[i].Rotation.x, _orders[i].Rotation.y, _orders[i].Rotation.z);
                    }

                    // obj.transform.SetParent(transform);
                }
            }
        }
    }
}