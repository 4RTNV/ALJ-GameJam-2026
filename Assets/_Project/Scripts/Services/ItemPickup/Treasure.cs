using _Project.Interactables;
using Reflex.Attributes;
using UnityEngine;

namespace _Project.Services.ItemPickup
{
    public class Treasure : MonoBehaviour, IWeightedItem, IInteractable
    {
        [SerializeField] private int _mass = 1;
        [SerializeField] private InventorySlotType _slot = InventorySlotType.Pocket;
        [SerializeField] private int _itemValue = 10;

        private IItemPickup _itemPickup;
        private readonly TooltipModel _model;

        public int Mass => _mass;
        public int Value => _itemValue;
        public InventorySlotType Slot => _slot;

        public TooltipModel Model => _model;

        [Inject]
        private void Construct(IItemPickup picker)
        {
            _itemPickup = picker;
        }
        public void Interact()
        {
            _itemPickup.TryPickUpItem(this);
        }

        public void OnMouseHover()
        {

        }

        public void OnMouseLeave()
        {
            throw new System.NotImplementedException();
        }
    }
}