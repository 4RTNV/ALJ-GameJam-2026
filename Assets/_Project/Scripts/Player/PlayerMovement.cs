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
        // Read input in Update so no frames are skipped
        _cachedInput = _playerInputActions.Move.ReadValue<Vector2>();
        _cachedCursorPosition = _playerInputActions.CursorPosition.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
        RotateTowardsCursor();
    }

    private Vector2 _cachedInput;
    private Vector2 _cachedCursorPosition;

    private void Move()
    {
        Vector3 camForward = _camera.transform.forward;
        Vector3 camRight = _camera.transform.right;
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = camForward * _cachedInput.y + camRight * _cachedInput.x;

        _rigidBody.linearVelocity = new Vector3(
            moveDirection.x * PlayerMoveMaxSpeed,
            _rigidBody.linearVelocity.y,
            moveDirection.z * PlayerMoveMaxSpeed);
    }

    private void RotateTowardsCursor()
    {
        if (!Physics.Raycast(_camera.ScreenPointToRay(_cachedCursorPosition), out RaycastHit hit))
            return;

        Vector3 direction = hit.point - _rigidBody.position;
        direction.y = 0f;
        if (direction.sqrMagnitude < 0.001f)
            return;

        _rigidBody.MoveRotation(Quaternion.LookRotation(direction));
    }

    private void OnDestroy() => _playerInputActions.Disable();
}
