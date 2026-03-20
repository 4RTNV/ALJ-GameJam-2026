using _Project.Services.ItemPickup;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using UnityEngine;

public class PlayerInventory : IPlayerInventory
{
    private readonly ILogger _logger;
    private readonly ObservableCollection<Treasure> _inventoryItems;

    public event EventHandler<Treasure> ItemPickedUp;
    public event EventHandler InventoryCleared;

    public PlayerInventory(ILogger logger)
    {
        _logger = logger;
        _inventoryItems = new ObservableCollection<Treasure>();
        _inventoryItems.CollectionChanged += OnInventoryUpdated;
        _logger.Log("Player inventory loaded");
    }

    public void AcceptNewTreasure(Treasure weightedItem)
    {
        _inventoryItems.Add(weightedItem);
        ItemPickedUp?.Invoke(this, weightedItem);
    }

    public int InventoryMass { get; private set; }

    public int InventoryValue => _inventoryItems?.Sum(x => x.Value) ?? 0;

    private void OnInventoryUpdated(object sender, NotifyCollectionChangedEventArgs e)
    {
        InventoryMass = ComputeInventoryMass();
        _logger.Log($"Inventory has now {_inventoryItems.Count} items");
    }

    private int ComputeInventoryMass() 
        => _inventoryItems.Sum(x => x.Mass);

    public bool CanAccept(Treasure treasure)
    {
        return treasure.Slot switch
        {
            InventorySlotType.Pocket => true,
            InventorySlotType.Back => !_inventoryItems.Any(x => x.Slot == InventorySlotType.Back),
            InventorySlotType.Hand => _inventoryItems.Where(x => x.Slot == InventorySlotType.Hand).Count() <= 1,
            InventorySlotType.Drag => !_inventoryItems.Any(x => x.Slot == InventorySlotType.Drag)
            && _inventoryItems.Where(x => x.Slot == InventorySlotType.Hand).Count() <= 0,
            _ => false,
        };
    }
}