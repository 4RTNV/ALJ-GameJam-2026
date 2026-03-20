using _Project.UI.ViewModels;

namespace _Project.Interactables
{
    public class InteractablesSelector
    {
        private readonly TooltipViewModel _viewModel;
        public InteractablesSelector()
        {
            _viewModel = new();
        }

        public void DisplayInteractionTooltip(ITooltipHolder interactable)
        {
            _viewModel.Model = interactable.Model;
        }
        public void HideUI()
        {
            _viewModel.Hide();
        }
    }
}
