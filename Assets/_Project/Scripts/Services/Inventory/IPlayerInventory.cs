using _Project.Services.ItemPickup;
using System;

public interface IPlayerInventory
{
    void AcceptNewTreasure(Treasure weightedItem);
    void Clear();
    bool CanAccept(Treasure treasure);
    int InventoryMass { get; }
    int InventoryValue { get; }


    event EventHandler<Treasure> ItemPickedUp;
    event EventHandler InventoryCleared;

}