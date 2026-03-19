using _Project.Interactables;
using UnityEngine;

namespace _Project.Services.ItemPickup
{
    public class Treasure : MonoBehaviour, IWeightedItem, IInteractable
    {
        [SerializeField] private int _mass = 1;
        [SerializeField] private InventorySlotType _slot = InventorySlotType.Pocket;

        public int Mass => _mass;
        public InventorySlotType Slot => _slot;

        public void Interact() => Try

        public void SelectForInteraction()
        {
            throw new System.NotImplementedException();
        }
    }
}