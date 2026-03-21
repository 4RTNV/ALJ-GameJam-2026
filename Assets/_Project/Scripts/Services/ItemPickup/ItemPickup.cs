namespace _Project.Services.ItemPickup
{
    public class ItemPickup : IItemPickup
    {
        private readonly IPlayerInventory _playerInventory;

        public ItemPickup(IPlayerInventory playerInventory)
        {
            _playerInventory = playerInventory;
        }

        public bool TryPickUpItem(Treasure treasure)
        {
            if (!_playerInventory.CanAccept(treasure))
                return false;

            _playerInventory.AcceptNewTreasure(treasure);
            return true;
        }
    }
}