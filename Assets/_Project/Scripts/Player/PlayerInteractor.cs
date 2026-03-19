using _Project.Interactables;
using UnityEngine;

namespace _Project.Player
{
    public class PlayerInteractor : MonoBehaviour
    {
        private Camera _camera;
        private InputActionsAsset.PlayerActions _playerActions;
        private IInteractable _interactable;

        [SerializeField]
        private float interactionRange;

        private void Awake()
        {
            _camera = Camera.main; // to be injected?
            _playerActions = new InputActionsAsset().Player;
            _playerActions.Enable();
            _playerActions.Attack.performed += OnPlayerInteracted;

        }

        private void OnPlayerInteracted(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            _interactable?.Interact();
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
            if (!hitInfo.collider.gameObject.TryGetComponent(out _interactable))
                return;
            _interactable.SelectForInteraction();
        }

        public void Construct()
        {

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
