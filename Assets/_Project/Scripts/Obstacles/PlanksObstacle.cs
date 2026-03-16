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
            _trigger = GetComponent<BoxCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!CheckIfWeightCanPass(other.GetComponent<IWeightedObject>()))
            {
                _collider.enabled = false;
                _trigger.enabled = false;
            }
        }

        protected override bool CheckIfWeightCanPass(IWeightedObject weightedObject)
        {
            throw new NotImplementedException();
        }

        public event EventHandler OnWeightThresholdReached;
    }
}
