using UnityEngine;

namespace _Project.Services.ItemPickup
{
    public class ItemPickup : IItemPickup
    {
        private readonly IPlayerInventory _playerInventory;
        private readonly InputActionsAsset.PlayerActions _playerInputActions;
        private readonly Transform _playerTransform;
        private const float PickupRange = 3f;

        public ItemPickup(IPlayerInventory playerInventory, Transform playerTransform)
        {
            _playerInventory = playerInventory;
            _playerTransform = playerTransform;

            _playerInputActions = new InputActionsAsset().Player;
            _playerInputActions.Enable(); // Will be moved to outside context later
            _playerInputActions.Attack.performed += _ => TryPickUpNearestTreasure();
        }

        public void PickUpItem(Treasure treasure)
        {
            _playerInventory.AcceptNewTreasure(treasure);
            Object.Destroy(treasure.gameObject);
        }

        private void TryPickUpNearestTreasure()
        {
            Treasure[] treasures = Object.FindObjectsByType<Treasure>(FindObjectsSortMode.None);
            foreach (var treasure in treasures)
            {
                if (!IsInRange(treasure.transform)) 
                    continue;
                
                PickUpItem(treasure);
                return;
            }
        }

        private bool IsInRange(Transform target)
        {
            Vector3 playerPos = _playerTransform.position;
            Vector3 targetPos = target.position;
            playerPos.y = 0;
            targetPos.y = 0;
            return Vector3.Distance(playerPos, targetPos) <= PickupRange;
        }
    }
}