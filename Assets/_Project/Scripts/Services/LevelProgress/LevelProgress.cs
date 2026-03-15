using System;

namespace _Project.Services.CurrentLevelProgress
{
    public class LevelProgress : ILevelProgress
    {
        public event EventHandler WaveCleared = delegate { };
        public event EventHandler LevelCleared = delegate { };
        public event EventHandler PlayerCoreDestroyed = delegate { };

        private LevelConfig _loadedLevelConfig;
        
        private int _mobsLeftThisWave;

        public LevelConfig LoadedLevelConfig => _loadedLevelConfig;

        public bool IsLevelSuccessfullyFinished { get; private set; }

        public void LoadLevelConfig(LevelConfig levelConfig)
        {
            IsLevelSuccessfullyFinished = false;
            _loadedLevelConfig = levelConfig;
        }
    }
}