using _Project.Infrastructure;
using _Project.Services.Factory;
using _Project.UI.ViewModels;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.Interactables
{
    public class InteractablesSelector : IInteractablesSelector
    {
        private readonly TooltipViewModel _viewModel;
        private readonly IGameFactory _factory;
        private readonly ICameraProvider _cameraProvider;
        private UIDocument _tooltipUI;
        
        private Vector3 CurrentCameraPosition => _cameraProvider.Camera.transform.position;

        public InteractablesSelector(IGameFactory factory, ICameraProvider cameraProvider)
        {
            _viewModel = new();
            _factory = factory;
            _cameraProvider = cameraProvider;
        }

        public void DisplayInteractionTooltip(ITooltipHolder interactable)
        {
            Debug.Log($"Requesting camera: {_cameraProvider.Camera}");
            _tooltipUI = _factory.CreateTooltipUI(_viewModel);
            _tooltipUI.gameObject.transform.SetPositionAndRotation(interactable.Model.Position,
                Quaternion.LookRotation(interactable.Model.Position - CurrentCameraPosition));
            _viewModel.Model = interactable.Model;
        }

        public void HideUI()
        {
            _viewModel.Model = null;
            Object.Destroy(_tooltipUI);
        }
    }
}
