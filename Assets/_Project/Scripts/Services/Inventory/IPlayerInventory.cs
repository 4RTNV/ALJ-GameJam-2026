using _Project.Services.ItemPickup;

public interface IPlayerInventory
{
    void AcceptNewTreasure(IWeightedItem weightedItem);
    bool CanAccept(Treasure treasure);

    int InventoryMass { get; }
}