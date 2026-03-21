using _Project.Infrastructure;
using _Project.Services.AssetManagement;
using _Project.Services.SceneLoader;
using _Project.UI.Services.Windows;

namespace _Project.Services.States
{
    public class LoadHubState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LoadHubState(GameStateMachine gameStateMachine, IWindowContainer windowContainer, ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Exit()
        {
        }

        private void OnHubSceneLoaded()
        {
            _gameStateMachine.Enter<LoadLevelState>();
        }

        public void Enter()
        {
            SingletonCoroutineRunner.Instance.StartCoroutine(
                _sceneLoader.LoadScene(SceneNames.LevelSceneName, onLoaded: OnHubSceneLoaded));
        }
    }
}