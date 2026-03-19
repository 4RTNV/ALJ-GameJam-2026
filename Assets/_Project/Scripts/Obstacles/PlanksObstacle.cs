using System;
using UnityEngine;
namespace _Project.Obstacles
{
    public class GenericObstacle : Obstacle
    {
        private BoxCollider _trigger;
        private MeshCollider _collider;

        void Start()
        {
            _collider = GetComponent<MeshCollider>();
            _trigger = GetComponent<BoxCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!CheckIfWeightCanPass(other.GetComponentInParent<IWeightedItem>()))
            {
                _collider.enabled = false;
                _trigger.enabled = false;
                //replace models, etc etc...
            }
        }

        protected override bool CheckIfWeightCanPass(IWeightedItem weightedObject)
        {
            return weightedObject.Mass <= _weightThreshold;
        }

        public event EventHandler OnWeightThresholdReached;
    }
}
