using Reflex.Attributes;
using System;
using UnityEngine;

namespace _Project.Player
{
    public class PlayerWeight : MonoBehaviour, IWeightedItem
    {
        private IPlayerInventory _playerInventory;
        [Inject]
        private void Construct(IPlayerInventory playerInventory)
        {
            _playerInventory = playerInventory;
        }
        public int Mass => _playerInventory.InventoryMass;

        public InventorySlotType Slot => throw new NotImplementedException();
    }
}
