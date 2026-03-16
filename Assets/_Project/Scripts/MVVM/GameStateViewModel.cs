using _Project.Infrastructure;
using _Project.Infrastructure.GameTime;
using System;
using System.Runtime.CompilerServices;
using Unity.Properties;
using UnityEngine.UIElements;

namespace _Project.MVVM
{
    public class GameStateViewModel : INotifyBindablePropertyChanged
    {
        private readonly IGameTimer timer;

        [CreateProperty]
        public string TimeRemaining
        {
            get
            {
                return $"{timer.TimeLeft.Minutes}:{timer.TimeLeft.Seconds}";
            }
        }

        public GameStateViewModel(IGameTimer _timer)
        {
            timer = _timer;
            SingletonCoroutineRunner.OnGameLoopUpdate += Update;
        }

        private void Update(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(TimeRemaining));
        }

        public void Start() => timer.IsActive = true;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            propertyChanged?.Invoke(this, new(propertyName));
        }

        public event EventHandler<BindablePropertyChangedEventArgs> propertyChanged;
    }
}
