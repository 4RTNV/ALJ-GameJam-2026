using _Project.Interactables;
using UnityEngine;

namespace _Project.Player
{
    public class PlayerInteractor : MonoBehaviour
    {
        private Camera _camera;
        private InputActionsAsset.PlayerActions _playerActions;
        private ITooltipHolder _selectable;

        [SerializeField]
        private float interactionRange;

        private void Awake()
        {
            _playerActions = new InputActionsAsset().Player;
            _playerActions.Enable();
            _playerActions.Attack.performed += OnPlayerInteracted;
        }

        public void Construct(Camera camera)
        {
            Debug.LogWarning("Use injection and CameraProvider for this");
            _camera = camera;
        }

        private void OnPlayerInteracted(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (_selectable != null && _selectable is IInteractable interactable)
                interactable.Interact();
        }

        private void Update()
        {
            var cursorPosition = _playerActions.CursorPosition.ReadValue<Vector2>();
            Physics.Raycast(_camera.ScreenPointToRay(cursorPosition),
                out RaycastHit hitInfo);
            if (!IsInRange(hitInfo.point, transform.position))
                return;
            if (hitInfo.collider == null || hitInfo.collider.gameObject == null)
                return;
            if (!hitInfo.collider.gameObject.TryGetComponent(out ITooltipHolder selectable))
            {
                _selectable?.OnMouseLeave();
                _selectable = null;
                return;
            }
            if(_selectable == null || selectable != _selectable)
            {
                _selectable = selectable;
                _selectable.OnMouseHover();
            }
        }

        private void OnDestroy() 
            => _playerActions.Disable();
            
        private bool IsInRange(Vector3 target, Vector3 playerPosition)
        {
            playerPosition.y = 0;
            target.y = 0;
            return Vector3.Distance(playerPosition, target) <= interactionRange;
        }
    }
}
