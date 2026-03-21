using _Project.Interactables;
using Reflex.Attributes;
using System;
using UnityEngine;

namespace _Project.Services.ItemPickup
{
    public class Treasure : MonoBehaviour, IWeightedItem, IInteractable, ITooltipHolder
    {
        [SerializeField] private int _mass = 1;
        [SerializeField] private InventorySlotType _slot = InventorySlotType.Pocket;
        [SerializeField] private int _itemValue = 10;
        [Header("Tooltip")]
        [SerializeField] private string _name;

        private IItemPickup _itemPickup;
        private IInteractablesSelector _selector;
        private TooltipModel _model;
        

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
            _itemPickup.TryPickUpItem(this);
        }

        public void SelectForInteraction()
        {
            Debug.Log("Treasure was selected for interaction but the method implementation is missing");
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