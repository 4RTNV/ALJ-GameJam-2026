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
        private readonly Camera _camera;
        private UIDocument _tooltipUI;

        public InteractablesSelector(IGameFactory factory)
        {
            _viewModel = new();
            _camera = Camera.main;
            _factory = factory;
        }

        public void DisplayInteractionTooltip(ITooltipHolder interactable)
        {
            _tooltipUI = _factory.CreateTooltipUI(_viewModel);
            _tooltipUI.gameObject.transform.SetPositionAndRotation(interactable.Model.Position,
                Quaternion.LookRotation(interactable.Model.Position - _camera.transform.position));
            _viewModel.Model = interactable.Model;
        }
        public void HideUI()
        {
            _viewModel.Model = null;
            Object.Destroy(_tooltipUI);
        }
    }
}
