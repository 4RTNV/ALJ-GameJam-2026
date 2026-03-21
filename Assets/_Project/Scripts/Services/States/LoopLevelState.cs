using _Project.Infrastructure.InGameTime;
using _Project.Infrastructure.SaveLoad;
using _Project.Services.CurrentLevelProgress;
using _Project.Services.PlayerProgress;

namespace _Project.Services.States
{
    public class LoopLevelState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IInGameTimeService _timeService;
        private bool _isWaveOngoing;

        public LoopLevelState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            _timeService.RestoreTimePassage();
        }
    }
}