public interface IPlayerInventory
{
    void AcceptNewTreasure(IWeightedItem weightedItem);
    int InventoryMass { get; }
}