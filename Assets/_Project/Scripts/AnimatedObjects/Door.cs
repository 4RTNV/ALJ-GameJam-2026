using System;
using System.Collections;
using UnityEngine;

namespace _Project.AnimatedObjects
{
    public enum DoorDirection { Positive = 1, Negative = -1 }

    [Serializable]
    public class DoorLeaf
    {
        public Transform transform;
        public DoorDirection direction;
    }

    public class Door : MonoBehaviour
    {
        [SerializeField] private DoorLeaf[] doorLeaves;
        [SerializeField] private float openAngle = 90f;
        [SerializeField] private float openDuration = 0.4f;
        [SerializeField] private AnimationCurve openCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        [SerializeField] private float closeDuration = 0.4f;
        [SerializeField] private AnimationCurve closeCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

        private Coroutine _animationCoroutine;
        private float _currentAngle;
        private bool _isOpen;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player"))
                return;

            OpenDoor();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.CompareTag("Player"))
                return;

            CloseDoor();
        }

        private void OpenDoor()
        {
            if (_isOpen) return;
            _isOpen = true;
            AnimateDoor(openAngle, openCurve, openDuration);
        }

        private void CloseDoor()
        {
            if (!_isOpen) return;
            _isOpen = false;
            AnimateDoor(0f, closeCurve, closeDuration);
        }

        private void AnimateDoor(float targetAngle, AnimationCurve curve, float duration)
        {
            if (_animationCoroutine != null)
                StopCoroutine(_animationCoroutine);

            _animationCoroutine = StartCoroutine(AnimateDoorRoutine(targetAngle, curve, duration));
        }

        private IEnumerator AnimateDoorRoutine(float targetAngle, AnimationCurve curve, float duration)
        {
            float startAngle = _currentAngle;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float t = curve.Evaluate(elapsed / duration);
                _currentAngle = Mathf.LerpUnclamped(startAngle, targetAngle, t);
                foreach (DoorLeaf leaf in doorLeaves)
                    leaf.transform.localRotation = Quaternion.Euler(0f, _currentAngle * (int)leaf.direction, 0f);
                yield return null;
            }

            _currentAngle = targetAngle;
            foreach (DoorLeaf leaf in doorLeaves)
                leaf.transform.localRotation = Quaternion.Euler(0f, _currentAngle * (int)leaf.direction, 0f);
        }
    }
}
