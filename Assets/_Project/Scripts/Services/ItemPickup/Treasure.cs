using _Project.Interactables;
using _Project.Player;
using Reflex.Attributes;
using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Project.Services.ItemPickup
{
    public class Treasure : MonoBehaviour, IWeightedItem, IInteractable
    {
        [SerializeField] private int _mass = 1;
        [SerializeField] private InventorySlotType _slot = InventorySlotType.Pocket;
        [SerializeField] private int _itemValue = 10;
        [Header("Tooltip")]
        [SerializeField] private string _name;

        private IItemPickup _itemPickup;
        private IInteractablesSelector _selector;
        private TooltipModel _model;
        private bool _isBeingPickedUp;

        public int Mass => _mass;
        public int Value => _itemValue;
        public InventorySlotType Slot => _slot;

        public TooltipModel Model => _model;

        [Inject]
        private void Construct(IItemPickup picker, IInteractablesSelector selector)
        {
            _itemPickup = picker;
            _selector = selector;
        }
        private void Start()
        {
            _model = new(_name, $"{Mass}kg, ${Value}", Enum.GetName(typeof(InventorySlotType), Slot), transform.position + 1 * Vector3.up);
        }

        public void Interact()
        {
            if (_isBeingPickedUp) return;
            _isBeingPickedUp = true;
            StartCoroutine(VacuumToBackpackCoroutine());
        }

        private IEnumerator VacuumToBackpackCoroutine()
        {
            if (TryGetComponent<Collider>(out var col)) col.enabled = false;

            PlayerHands playerHands = FindFirstObjectByType<PlayerHands>();
            Vector3 target = playerHands != null ? playerHands.BackpackPosition : transform.position;

            Vector3 startPos = transform.position;
            Vector3 startScale = transform.localScale;
            float duration = 0.45f;
            float t = 0f;

            while (t < 1f)
            {
                t = Mathf.Min(t + Time.deltaTime / duration, 1f);

                // Cubic ease-in: slow start, rapid pull to target (vacuum feel)
                float posT = t * t * t;
                transform.position = Vector3.Lerp(startPos, target, posT);

                // Scale: slight bulge at start (0→0.2), then collapses to 0 (0.2→1)
                float scaleFactor = t < 0.2f
                    ? 1f + (t / 0.2f) * 0.15f
                    : 1.15f * (1f - (t - 0.2f) / 0.8f);
                transform.localScale = startScale * scaleFactor;

                yield return null;
            }

            _itemPickup.TryPickUpItem(this);
            Destroy(gameObject);
        }

        public void OnMouseHover()
        {
            _selector.DisplayInteractionTooltip(this);
        }

        public void OnMouseLeave()
        {
            _selector.HideUI();
        }
    }
}