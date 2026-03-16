using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

public class PlayerInventory : IPlayerInventory
{
    private readonly ObservableCollection<IWeightedItem> _inventoryItems;
    private int _inventoryMass;

    public PlayerInventory()
    {
        _inventoryItems = new ObservableCollection<IWeightedItem>();
        _inventoryItems.CollectionChanged += OnInventoryUpdated;
    }

    public void AcceptNewTreasure(IWeightedItem weightedItem) 
        => _inventoryItems.Add(weightedItem);

    public int InventoryMass => _inventoryMass;
    
    private void OnInventoryUpdated(object sender, NotifyCollectionChangedEventArgs e) 
        => _inventoryMass = ComputeInventoryMass();

    private int ComputeInventoryMass() 
        => _inventoryItems.Sum(x => x.Mass);
}