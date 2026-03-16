using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using UnityEngine;

public class PlayerInventory : IPlayerInventory
{
    private readonly ILogger _logger;
    private readonly ObservableCollection<IWeightedItem> _inventoryItems;

    public PlayerInventory(ILogger logger)
    {
        _logger = logger;
        _inventoryItems = new ObservableCollection<IWeightedItem>();
        _inventoryItems.CollectionChanged += OnInventoryUpdated;
        _logger.Log("Player inventory loaded");
    }

    public void AcceptNewTreasure(IWeightedItem weightedItem) 
        => _inventoryItems.Add(weightedItem);

    public int InventoryMass { get; private set; }

    private void OnInventoryUpdated(object sender, NotifyCollectionChangedEventArgs e)
    {
        InventoryMass = ComputeInventoryMass();
        _logger.Log($"Inventory has now {_inventoryItems.Count} items");
    }

    private int ComputeInventoryMass() 
        => _inventoryItems.Sum(x => x.Mass);
}