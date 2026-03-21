using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float PlayerMoveMaxSpeed;

    private InputActionsAsset.PlayerActions _playerInputActions;
    private Rigidbody _rigidBody;
    private Camera _camera;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _playerInputActions = new InputActionsAsset().Player;
        _playerInputActions.Enable(); // Will be moved to outside context later
    }

    public void Construct(Camera camera)
    {
        _camera = camera;
    }

    private void Update()
    {
        Move();
        RotateTowardsCursor();
    }

    private void Move()
    {
        var input = _playerInputActions.Move.ReadValue<Vector2>();

        Vector3 camForward = _camera.transform.forward;
        Vector3 camRight = _camera.transform.right;
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = camForward * input.y + camRight * input.x;

        _rigidBody.linearVelocity = new Vector3(
            moveDirection.x * PlayerMoveMaxSpeed,
            _rigidBody.linearVelocity.y,
            moveDirection.z * PlayerMoveMaxSpeed);
    }

    private void RotateTowardsCursor()
    {
        Vector2 cursorPosition = _playerInputActions.CursorPosition.ReadValue<Vector2>();
        if (!Physics.Raycast(_camera.ScreenPointToRay(cursorPosition), out RaycastHit hit))
            return;

        Vector3 direction = hit.point - transform.position;
        direction.y = 0f;
        if (direction.sqrMagnitude < 0.001f)
            return;

        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void OnDestroy() => _playerInputActions.Disable();
}
