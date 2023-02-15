using Services.Progress;
using Services.Service_locator;

namespace Game_state_machine.States
{
    public class LoadProgressState: IState
    {
        private IServiceLocator _serviceLocator;
        private IGameStateMachine _gameStateMachine;

        public LoadProgressState (IServiceLocator serviceLocator, IGameStateMachine gameStateMachine)
        {
            _serviceLocator = serviceLocator;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            var progressService = _serviceLocator.GetService<IProgressService>();

            progressService.LoadProgress();

            _gameStateMachine.Enter<MainMenuState>();
        }

        public void Exit()
        {
            
        }
    }
}