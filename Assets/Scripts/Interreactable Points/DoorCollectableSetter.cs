using System;
using UnityEngine;

namespace SuareDemo
{
    public class DoorCollectableSetter : MonoBehaviour
    {
        public static Action<string> SetTag = delegate
          { };

        private void OnEnable()
        {
            SetTag += TagSetter;
        }

        private void OnDisable()
        {
            SetTag -= TagSetter;
        }

        private void TagSetter(string whichObject)
        {
            GameObject[] collectable = GameObject.FindGameObjectsWithTag(whichObject);

            for (int i = 0; i < collectable.Length; i++)
            {
                collectable[i].tag = "Collectable";
            }

            CollectableTrain[] train = FindObjectsOfType<CollectableTrain>();

            foreach (CollectableTrain item in train)
            {
                item.ChangeTrainType(whichObject == "Coal");
            }

            ObjectActivator[] activator = FindObjectsOfType<ObjectActivator>();

            foreach (ObjectActivator item in activator)
            {
                item.IsCoal(whichObject == "Coal");
            }
        }
    }
}