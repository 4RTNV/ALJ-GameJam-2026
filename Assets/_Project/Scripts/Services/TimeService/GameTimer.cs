using _Project.StaticData;
using System;
using UnityEngine;

namespace _Project.Infrastructure.GameTime
{
    internal class GameTimer : IGameTimer
    {
        public bool IsGameEnded { get; private set; } = false;

        public TimeSpan TotalTime { get; private set; }

        public TimeSpan TimeLeft {get; private set; }
        public bool IsActive { get; set; }

        public event EventHandler TimeExpired;
        public GameTimer(IStaticData data)
        {
            SingletonCoroutineRunner.OnGameLoopUpdate += Update;
            TotalTime = data.GetTotalTime();
            TimeLeft = TotalTime;
        }

        private void Update(object sender, EventArgs e)
        {
            if (!IsActive)
                return;

            TimeLeft -= TimeSpan.FromSeconds(Time.deltaTime);
            if (TimeLeft.TotalMilliseconds < 0)
            {
                TimeExpired.Invoke(this, null);
                IsGameEnded = true;
            }
        }
    }
}
