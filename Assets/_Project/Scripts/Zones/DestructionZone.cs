using Reflex.Attributes;
using UnityEngine;

public class DestructionZone : MonoBehaviour
{
    protected IPlayerInventory _inventory;
    [Inject]
    private void Construct(IPlayerInventory playerInventory) //gamescore service?
    {
        _inventory = playerInventory;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _inventory.Clear();
            return;
        }

        if (!other.TryGetComponent(out IWeightedItem item))
            return;
        Destroy(other.gameObject);
    }
}
