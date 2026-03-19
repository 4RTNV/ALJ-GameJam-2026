using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float PlayerMoveMaxSpeed;

    private InputActionsAsset.PlayerActions _playerInputActions;
    private Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _playerInputActions = new InputActionsAsset().Player;
        _playerInputActions.Enable(); // Will be moved to outside context later
    }


    private void Update()
    {
        var movementDirection = _playerInputActions.Move.ReadValue<Vector2>();
        _rigidBody.linearVelocity = new Vector3(movementDirection.x * PlayerMoveMaxSpeed,
                                                _rigidBody.linearVelocity.y,
                                                movementDirection.y * PlayerMoveMaxSpeed);
    }
    private void OnDestroy()
    {
        _playerInputActions.Disable();
    }
}
