using _Project.Interactables;
using Reflex.Attributes;
using UnityEngine;

namespace _Project.Services.ItemPickup
{
    public class Treasure : MonoBehaviour, IWeightedItem, IInteractable
    {
        [SerializeField] private int _mass = 1;
        [SerializeField] private InventorySlotType _slot = InventorySlotType.Pocket;

        private IItemPickup _itemPickup;

        public int Mass => _mass;
        public InventorySlotType Slot => _slot;

        [Inject]
        private void Construct(IItemPickup picker)
        {
            _itemPickup = picker;
        }
        public void Interact()
        {
            _itemPickup.TryPickUpItem(this);
        }

        public void SelectForInteraction()
        {

        }
    }
}