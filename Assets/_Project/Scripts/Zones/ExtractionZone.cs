using Reflex.Attributes;
using UnityEngine;

public class ExtractionZone : MonoBehaviour
{
    protected IPlayerInventory _inventory;
    [Inject]
    private void Construct(IPlayerInventory playerInventory) //gamescore service?
    {
        _inventory = playerInventory;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;
        
        _inventory.Clear();
        return;
    }
}
