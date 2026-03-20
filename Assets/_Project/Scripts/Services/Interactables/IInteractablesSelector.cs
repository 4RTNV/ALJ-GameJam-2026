using UnityEngine.UIElements;

namespace _Project.Interactables
{
    public interface IInteractablesSelector
    {
        void DisplayInteractionTooltip(ITooltipHolder interactable);
        void HideUI();
    }
}