using _Project.Interactables;
using System;
using System.Runtime.CompilerServices;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.UI.ViewModels
{
    public class TooltipViewModel : INotifyBindablePropertyChanged
    {
        private string _name;
        private string _tooltip;
        private string _secondaryTooltip;
        private Vector3 worldPosition;

        [CreateProperty]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        [CreateProperty]
        public string Tooltip
        {
            get => _tooltip;
            set
            {
                _tooltip = value;
                OnPropertyChanged();
            }
        }
        [CreateProperty]
        public Vector3 WorldPosition
        {
            get => worldPosition;
            set
            {
                worldPosition = value;
                OnPropertyChanged();
            }
        }
        [CreateProperty]
        public string SecondaryTooltip
        {
            get => _secondaryTooltip;
            set
            {
                _secondaryTooltip = value;
                OnPropertyChanged();
            }

        }
        public TooltipModel Model
        { 
            set
            {
                if(value == null)
                {
                    return;
                }

                Name = value.Name;
                Tooltip = value.Tooltip;
                SecondaryTooltip = value.SecondaryTooltip;
                WorldPosition = value.Position;
            } 
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            propertyChanged?.Invoke(this, new(propertyName));
        }

        public event EventHandler<BindablePropertyChangedEventArgs> propertyChanged;
    }
}
