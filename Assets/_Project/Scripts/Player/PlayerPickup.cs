using _Project.Services.ItemPickup;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickup : MonoBehaviour
{
    private IItemPickup _itemPickUp;

    [Inject]
    public void Construct(IItemPickup itemPickup)
    {
        _itemPickUp = itemPickup;
    }
    
    private void Start()
    {
        var playerInputActions = new InputActionsAsset().Player;
        playerInputActions.Attack.performed += PickUpItem;
        playerInputActions.Enable();
    }

    private void PickUpItem(InputAction.CallbackContext obj) 
        => _itemPickUp.TryPickUpItem(transform.position);
}