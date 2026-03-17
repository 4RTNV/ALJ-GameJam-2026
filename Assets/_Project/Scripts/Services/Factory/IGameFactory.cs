using System.Collections.Generic;
using _Project.Services.PlayerProgress;
using _Project.UI.ViewModels;

namespace _Project.Services.Factory
{
    public interface IGameFactory : IProgressUpdater
    {
        List<ISavedProgressReader> ProgressReaders { get; } 
        List<IProgressUpdater> ProgressWriters { get; }
        void CreatePlayerUI(GameStateViewModel gameVM);
    }
}