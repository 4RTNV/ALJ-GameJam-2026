using _Project.Services.ItemPickup;
using System;

public interface IPlayerInventory
{
    void AcceptNewTreasure(IWeightedItem weightedItem);
    bool CanAccept(Treasure treasure);
    int InventoryMass { get; }

    event EventHandler<IWeightedItem> ItemPickedUp;
    event EventHandler InventoryCleared;

}