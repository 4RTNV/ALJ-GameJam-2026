using UnityEngine;

namespace _Project.Services.ItemPickup
{
    public class Treasure : MonoBehaviour, IWeightedItem
    {
        [SerializeField] private int _mass = 1;
        [SerializeField] private InventorySlotType _slot = InventorySlotType.Pocket;

        public int Mass => _mass;
        public InventorySlotType Slot => _slot;
    }
}