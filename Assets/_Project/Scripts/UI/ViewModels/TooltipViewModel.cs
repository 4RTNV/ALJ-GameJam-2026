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
        {
            set
            {
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
        }

        public void Hide()
        {
            //do something abt visibilit, idk yet
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            propertyChanged?.Invoke(this, new(propertyName));
        }

        public event EventHandler<BindablePropertyChangedEventArgs> propertyChanged;
    }
}
