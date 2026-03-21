using System.Collections.Generic;
using _Project.Data;
using _Project.Infrastructure;
using _Project.Player;
using _Project.Services.AssetManagement;
using _Project.Services.PlayerProgress;
using UnityEngine.UIElements;
using _Project.UI.ViewModels;
using Unity.Cinemachine;
using UnityEditor.UIElements;
using UnityEngine;

namespace _Project.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;
        private readonly IPersistentProgress _progress;
        private readonly ICameraProvider _cameraProvider;

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

        public GameObject CreatePlayer()
        {
            GameObject playerInstance = _assets.Instantiate(Constants.PlayerPrefabPath);
            GameObject cameraParent = _assets.Instantiate(Constants.CinemachinePrefabPath);
            CinemachineCamera cinemachine = cameraParent.GetComponentInChildren<CinemachineCamera>();
            cinemachine.Follow = playerInstance.transform;

            Camera camera = cameraParent.GetComponentInChildren<Camera>();
            Debug.Log($"Camera found: {camera.gameObject.name}");
            _cameraProvider.SetCamera(camera);
            
            playerInstance.GetComponent<PlayerInteractor>().Construct(camera);
            playerInstance.GetComponent<PlayerMovement>().Construct(camera);
            return playerInstance;
        }

        public GameFactory(IAssetProvider assets, IPersistentProgress progress, ICameraProvider cameraProvider)
        {
            _assets = assets;
            _progress = progress;
            _cameraProvider = cameraProvider;
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
