using _Project.Services.Factory;
using _Project.Services.CurrentLevelProgress;
using _Project.Services.PlayerProgress;
using _Project.StaticData;
using _Project.UI.Services.Factory;
using _Project.Infrastructure.GameTime;
using _Project.MVVM;

namespace _Project.Services.States
{
    public class LoadLevelState : IState
    {
        private readonly IPersistentProgress _progress;
        private readonly IUIFactory _uiFactory;
        private readonly GameStateMachine _gameStateMachine;
        private readonly IStaticData _staticData;
        private readonly IGameFactory _gameFactory;
        private readonly ILevelProgress _levelProgress;

        private readonly GameStateViewModel _gameVM; //i'm not sure if it should be stored here

        public LoadLevelState(GameStateMachine gameStateMachine,
            IGameFactory gameFactory, IPersistentProgress progress,
            IStaticData staticData, IUIFactory uiFactory,
            ILevelProgress levelProgress, GameStateViewModel gameVM)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _progress = progress;
            _staticData = staticData;
            _uiFactory = uiFactory;
            _levelProgress = levelProgress;
            _gameVM = gameVM;
        }

        public void Enter()
        {
            _gameFactory.CreatePlayerUI(_gameVM);
        }

        public void Exit()
        {
        }
    }
}