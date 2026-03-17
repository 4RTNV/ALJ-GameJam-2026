using System;
using System.Runtime.CompilerServices;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.UI.ViewModels
{
    public class PlayerInventoryViewModel : INotifyBindablePropertyChanged
    {
        private int mass;

        [CreateProperty]
        public Color LegsTint { get; set; }

        [CreateProperty]
        public Color TorsoTint { get; set; }

        [CreateProperty]
        public Color LeftArmTint { get; set; }

        [CreateProperty]
        public Color RightArmTint { get; set; }

        [CreateProperty]
        public int Mass
        {
            get => mass;
            private set
            {
                mass = value;
                OnPropertyChanged();
            }
        }

        public PlayerInventoryViewModel()
        {
            //player inventory goes here
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            propertyChanged?.Invoke(this, new(propertyName));
        }

        public event EventHandler<BindablePropertyChangedEventArgs> propertyChanged;
    }
}
