using UnityEngine;
using System.Collections.Generic;
using _Project.Data;
using _Project.Services.AssetManagement;
using _Project.Services.PlayerProgress;
using UnityEngine.UIElements;
using _Project.Infrastructure.GameTime;
using _Project.MVVM;

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


        public void CreatePlayerUI(GameStateViewModel gameVM)
        {
            
            var ui = _assets.Instantiate<UIDocument>("Prefabs/UI/PlayerUI").rootVisualElement;
            ui.dataSource = gameVM;
            gameVM.Start();
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
