using System;
using System.Runtime.CompilerServices;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.UI.ViewModels
{
    public class PlayerInventoryViewModel : INotifyBindablePropertyChanged
    {
        private int _mass;
        private Color legsTint;
        private Color torsoTint;
        private Color leftArmTint;
        private Color rightArmTint;
        private readonly Color _occupiedColor = Color.aliceBlue;
        private readonly Color _freeColor = Color.aliceBlue;

        [CreateProperty]
        public Color LegsTint
        {
            get => legsTint;
            set
            {
                legsTint = value;
                OnPropertyChanged();
            }
        }

        [CreateProperty]
        public Color TorsoTint
        {
            get => torsoTint;
            set
            {
                torsoTint = value;
                OnPropertyChanged();
            }
        }

        [CreateProperty]
        public Color LeftArmTint
        {
            get => leftArmTint; set
            {
                leftArmTint = value;
                OnPropertyChanged();
            }
        }

        [CreateProperty]
        public Color RightArmTint
        {
            get => rightArmTint;
            set
            {
                rightArmTint = value;
                OnPropertyChanged();
            }
        }

        [CreateProperty]
        public int Mass
        {
            get => _mass;
            private set
            {
                _mass = value;
                OnPropertyChanged();
            }
        }

        public PlayerInventoryViewModel(IPlayerInventory playerInventory)
        {
            playerInventory.ItemPickedUp += OnItemPickedUp;
            playerInventory.InventoryCleared += OnInventoryCleared;
            OnInventoryCleared(this, null);
        }

        private void OnInventoryCleared(object sender, EventArgs e)
        {
            TorsoTint = _freeColor;
            LeftArmTint = _freeColor;
            RightArmTint = _freeColor;
            LegsTint = _freeColor;
        }

        private void OnItemPickedUp(object sender, IWeightedItem e)
        {
            switch (e.Slot) //this is horrible and I hate myself... But not enough to make a proper VM w/ converters
            {
                case InventorySlotType.Back:
                    TorsoTint = _occupiedColor;
                    break;
                case InventorySlotType.Hand:
                    if (LeftArmTint == _occupiedColor)
                        RightArmTint = _occupiedColor;
                    else
                        LeftArmTint = _occupiedColor;
                    break;
                case InventorySlotType.Pocket:
                    //Lerp once I we get clear on pockets limit
                    break;
                case InventorySlotType.Drag:
                    LeftArmTint = _occupiedColor;
                    RightArmTint = _occupiedColor;
                    break;
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            propertyChanged?.Invoke(this, new(propertyName));
        }

        public event EventHandler<BindablePropertyChangedEventArgs> propertyChanged;
    }
}
