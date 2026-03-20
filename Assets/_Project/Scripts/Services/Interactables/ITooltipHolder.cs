using _Project.UI.ViewModels;

namespace _Project.Interactables
{
    public interface ITooltipHolder
    {
        public TooltipModel Model { get; }
        public void OnMouseHover();
        public void OnMouseLeave();
    }
}
