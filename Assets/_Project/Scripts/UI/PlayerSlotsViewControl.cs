using _Project.Services;
using System;
using System.Runtime.CompilerServices;
using Unity.Properties;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.UI.Controls
{
    [UxmlElement]
    public partial class PlayerSlotsViewControl : VisualElement, INotifyBindablePropertyChanged
    {
        private Color headTint;
        private Color torsoTint;
        private Color leftArmTint;
        private Color rightArmTint;
        private Color legsTint;

        [UxmlAttribute, CreateProperty]
        public Color HeadTint
        {
            get => headTint;
            private set
            {
                headTint = value;
                OnPropertyChanged();
            }
        }

        [UxmlAttribute, CreateProperty]
        public Color TorsoTint
        {
            get => torsoTint;
            private set
            {
                torsoTint = value;
                OnPropertyChanged();
            }
        }

        [UxmlAttribute, CreateProperty]
        public Color LeftArmTint
        {
            get => leftArmTint;
            private set
            {
                leftArmTint = value;
                OnPropertyChanged();
            }
        }

        [UxmlAttribute, CreateProperty]
        public Color RightArmTint
        {
            get => rightArmTint;
            private set
            {
                rightArmTint = value;
                OnPropertyChanged();
            }
        }

        [UxmlAttribute, CreateProperty]
        public Color LegsTint
        {
            get => legsTint;
            private set
            {
                legsTint = value;
                OnPropertyChanged();
            }
        }
        public PlayerSlotsViewControl()
        {
        }

        private void OnPropertyChanged([CallerMemberName] string  propertyName = "")
        {
            propertyChanged?.Invoke(this, new(propertyName));
        }
        public event EventHandler<BindablePropertyChangedEventArgs> propertyChanged;
    }
}
