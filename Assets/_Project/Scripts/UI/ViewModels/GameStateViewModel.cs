using _Project.Infrastructure;
using _Project.Infrastructure.GameTime;
using System;
using System.Runtime.CompilerServices;
using Unity.Properties;
using UnityEngine.UIElements;

namespace _Project.UI.ViewModels
{
    public class GameStateViewModel : INotifyBindablePropertyChanged
    {
        private readonly IGameTimer _timer;

        [CreateProperty]
        public PlayerInventoryViewModel InventoryVM { get; }

        [CreateProperty]
        public string TimeRemaining
        {
            get
            {
                return $"{_timer.TimeLeft.Minutes:D2}:{_timer.TimeLeft.Seconds:D2}";
            }
        }

        public GameStateViewModel(IGameTimer timer, PlayerInventoryViewModel inventoryVM)
        {
            _timer = timer;
            InventoryVM = inventoryVM;
            SingletonCoroutineRunner.OnGameLoopUpdate += Update;
        }

        private void Update(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(TimeRemaining));
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            propertyChanged?.Invoke(this, new(propertyName));
        }

        public event EventHandler<BindablePropertyChangedEventArgs> propertyChanged;
    }
}
