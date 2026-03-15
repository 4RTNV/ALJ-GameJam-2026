using _Project.Infrastructure.GameTime;
using Unity.Properties;
using UnityEngine.UIElements;

namespace _Project.MVVM
{
    public class GameStateViewModel
    {
        private readonly IGameTimer timer;

        [UxmlAttribute, CreateProperty]
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
        }

        public void Start() => timer.IsActive = true;
    }
}
