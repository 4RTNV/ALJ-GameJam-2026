using UnityEngine;

namespace _Project.Interactables
{
    public class TooltipModel
    {
        public string Name { get; private set; }
        public string Tooltip { get; private set; }
        public Vector3 Position { get; private set; }

        public TooltipModel(string name, string tooltip, Vector3 position)
        {
            Name = name;
            Tooltip = tooltip;
            Position = position;
        }
    }
}