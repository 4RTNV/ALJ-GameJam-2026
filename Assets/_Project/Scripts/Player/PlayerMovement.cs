using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float playerMoveMaxSpeed;
    [SerializeField]
    private Animator animator;

    private static readonly int IsMoving = Animator.StringToHash("is_running");
    private static readonly int FloorLayerMask = 1 << 6;

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
        Rotate();
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
            moveDirection.x * playerMoveMaxSpeed,
            _rigidBody.linearVelocity.y,
            moveDirection.z * playerMoveMaxSpeed);

        animator.SetBool(IsMoving, _cachedInput.sqrMagnitude > 0f);
    }

    private void Rotate()
    {
        bool isMoving = _cachedInput.sqrMagnitude > 0f;

        Vector3 direction = isMoving ? GetMovementDirection() : GetCursorDirection();
        if (direction.sqrMagnitude < 0.001f)
            return;

        _rigidBody.MoveRotation(Quaternion.LookRotation(direction));
    }

    private Vector3 GetMovementDirection()
    {
        Vector3 camForward = _camera.transform.forward;
        Vector3 camRight = _camera.transform.right;
        camForward.y = 0f;
        camRight.y = 0f;

        Vector3 direction = camForward.normalized * _cachedInput.y + camRight.normalized * _cachedInput.x;
        direction.y = 0f;
        return direction;
    }

    private Vector3 GetCursorDirection()
    {
        if (!Physics.Raycast(_camera.ScreenPointToRay(_cachedCursorPosition), out RaycastHit hit, Mathf.Infinity, FloorLayerMask))
            return Vector3.zero;

        Vector3 direction = hit.point - _rigidBody.position;
        direction.y = 0f;
        return direction;
    }

    private void OnDestroy() => _playerInputActions.Disable();
}
