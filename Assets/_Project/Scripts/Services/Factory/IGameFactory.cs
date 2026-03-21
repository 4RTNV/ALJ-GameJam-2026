using System.Collections.Generic;
using _Project.Services.PlayerProgress;
using _Project.UI.ViewModels;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.Services.Factory
{
    public interface IGameFactory : IProgressUpdater
    {
        List<ISavedProgressReader> ProgressReaders { get; } 
        List<IProgressUpdater> ProgressWriters { get; }
        UIDocument CreatePlayerUI(GameStateViewModel gameVM);
        UIDocument CreateTooltipUI(TooltipViewModel tooltipVM);
        GameObject CreatePlayer();
    }
}