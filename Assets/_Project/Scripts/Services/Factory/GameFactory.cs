using System.Collections.Generic;
using _Project.Data;
using _Project.Services.AssetManagement;
using _Project.Services.PlayerProgress;
using UnityEngine.UIElements;
using _Project.UI.ViewModels;
using UnityEditor.UIElements;

namespace _Project.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;
        private readonly IPersistentProgress _progress;

        public List<ISavedProgressReader> ProgressReaders { get; } = new();
        public List<IProgressUpdater> ProgressWriters { get; } = new()
        {
            Capacity = 0
        };


        public UIDocument CreatePlayerUI(GameStateViewModel gameVM)
        {
            var ui = _assets.Instantiate<UIDocument>(Constants.PlayerUIPrefabPath);
            ui.rootVisualElement.dataSource = gameVM;
            return ui;
        }

        public UIDocument CreateTooltipUI(TooltipViewModel tooltipVM)
        {
            var ui = _assets.Instantiate<UIDocument>(Constants.TooltipUIPrefabPath);
            ui.rootVisualElement.dataSource = tooltipVM;
            return ui;
        }

        public GameFactory(IAssetProvider assets, IPersistentProgress progress)
        {
            _assets = assets;
            _progress = progress;
        }

        public void LoadProgress(CurrentPlayerProgress progress)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateProgress(CurrentPlayerProgress progress)
        {
            throw new System.NotImplementedException();
        }
    }
}
