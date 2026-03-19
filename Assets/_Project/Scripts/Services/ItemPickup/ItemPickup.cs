using UnityEngine;

namespace _Project.Services.ItemPickup
{
    public class ItemPickup : IItemPickup
    {
        private readonly IPlayerInventory _playerInventory;
        private const float PickupRange = 3f;

        public ItemPickup(IPlayerInventory playerInventory)
        {
            _playerInventory = playerInventory;
        }

        public bool TryPickUpItem(Treasure treasure)
        {
            //free slots check here, Or maybe move them down to TryAcceptNewTreasure
            _playerInventory.AcceptNewTreasure(treasure);
            Object.Destroy(treasure.gameObject); // should it not be on object
            return true;
        }
    }
}