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

        public void TryPickUpItem(Vector3 playerPosition)
        {
            Treasure[] treasures = Object.FindObjectsByType<Treasure>(FindObjectsSortMode.None);
            foreach (var treasure in treasures)
            {
                if (!IsInRange(treasure.transform, playerPosition)) 
                    continue;
                
                PickUpNearestTreasure(treasure);
                return;
            }
        }

        private void PickUpNearestTreasure(Treasure treasure)
        {
            _playerInventory.AcceptNewTreasure(treasure);
            Object.Destroy(treasure.gameObject);
        }

        private bool IsInRange(Transform target, Vector3 playerPosition)
        {
            Vector3 targetPos = target.position;
            playerPosition.y = 0;
            targetPos.y = 0;
            return Vector3.Distance(playerPosition, targetPos) <= PickupRange;
        }
    }
}