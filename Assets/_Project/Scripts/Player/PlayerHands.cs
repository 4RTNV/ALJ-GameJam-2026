using _Project.Services.ItemPickup;
using System.Collections;
using UnityEngine;

namespace _Project.Player
{
    public class PlayerHands : MonoBehaviour
    {
        [SerializeField] private GameObject backpackObject;

        private IPlayerInventory _playerInventory;
        private Coroutine _pulseCoroutine;

        public Vector3 BackpackPosition => backpackObject.transform.position;

        public void Construct(IPlayerInventory playerInventory)
        {
            _playerInventory = playerInventory;
        }

        private void Start()
        {
            backpackObject.SetActive(false);
            _playerInventory.ItemPickedUp += OnItemPickedUp;
        }

        private void OnDestroy()
        {
            if (_playerInventory != null)
                _playerInventory.ItemPickedUp -= OnItemPickedUp;
        }

        private void OnItemPickedUp(object sender, Treasure treasure)
        {
            if (treasure.Slot == InventorySlotType.Back)
                backpackObject.SetActive(true);

            if (!backpackObject.activeSelf) return;

            if (_pulseCoroutine != null) StopCoroutine(_pulseCoroutine);
            _pulseCoroutine = StartCoroutine(BackpackPulseCoroutine());
        }

        private IEnumerator BackpackPulseCoroutine()
        {
            Vector3 baseScale = backpackObject.transform.localScale;
            float duration = 0.5f;
            float t = 0f;

            while (t < 1f)
            {
                t = Mathf.Min(t + Time.deltaTime / duration, 1f);

                // |sin(2πt)| produces exactly 2 bumps over t=[0,1]: peaks at t=0.25 and t=0.75
                float bump = Mathf.Abs(Mathf.Sin(t * Mathf.PI * 2f));
                float squeeze = bump * 0.3f;

                // XZ expands while Y compresses — classic squish deformation
                backpackObject.transform.localScale = new Vector3(
                    baseScale.x * (1f + squeeze),
                    baseScale.y * (1f - squeeze * 0.5f),
                    baseScale.z * (1f + squeeze)
                );

                yield return null;
            }

            backpackObject.transform.localScale = baseScale;
            _pulseCoroutine = null;
        }
    }
}
