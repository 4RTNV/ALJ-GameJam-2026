using System;

namespace _Project.Infrastructure.GameTime
{
    public interface IGameTimer
    {
        public TimeSpan TotalTime { get; }
        public TimeSpan TimeLeft { get; }
        public bool IsActive { get; set; }

        public event EventHandler TimeExpired;
        public bool IsGameEnded { get; }
    }
}
