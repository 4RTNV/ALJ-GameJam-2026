using _Project.Services.ItemPickup;
using Reflex.Attributes;
using UnityEngine;

namespace _Project.Player
{
    public class PlayerHands : MonoBehaviour
    {
        [SerializeField] private GameObject backpackObject;

        private IPlayerInventory _playerInventory;

        public void Construct(IPlayerInventory playerInventory)
        {
            _playerInventory = playerInventory;
        }

        private void Start()
        {
            backpackObject.SetActive(false);
            _playerInventory.ItemPickedUp += OnItemPickedUp;
        }

        private void OnDestroy()
        {
            if (_playerInventory != null)
                _playerInventory.ItemPickedUp -= OnItemPickedUp;
        }

        private void OnItemPickedUp(object sender, Treasure treasure)
        {
            if (treasure.Slot == InventorySlotType.Back)
                backpackObject.SetActive(true);
        }
    }
}
