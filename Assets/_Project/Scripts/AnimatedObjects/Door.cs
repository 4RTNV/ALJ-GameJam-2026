using System.Collections;
using UnityEngine;

namespace _Project.AnimatedObjects
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Transform doorTransform;
        [SerializeField] private float openAngle = 90f;
        [SerializeField] private float animationDuration = 0.4f;
        [SerializeField] private AnimationCurve animationCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

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
            AnimateDoor(openAngle);
        }

        private void CloseDoor()
        {
            if (!_isOpen) return;
            _isOpen = false;
            AnimateDoor(0f);
        }

        private void AnimateDoor(float targetAngle)
        {
            if (_animationCoroutine != null)
                StopCoroutine(_animationCoroutine);

            _animationCoroutine = StartCoroutine(AnimateDoorRoutine(targetAngle));
        }

        private IEnumerator AnimateDoorRoutine(float targetAngle)
        {
            float startAngle = _currentAngle;
            float elapsed = 0f;

            while (elapsed < animationDuration)
            {
                elapsed += Time.deltaTime;
                float t = animationCurve.Evaluate(elapsed / animationDuration);
                _currentAngle = Mathf.LerpUnclamped(startAngle, targetAngle, t);
                doorTransform.localRotation = Quaternion.Euler(0f, _currentAngle, 0f);
                yield return null;
            }

            _currentAngle = targetAngle;
            doorTransform.localRotation = Quaternion.Euler(0f, _currentAngle, 0f);
        }
    }
}
