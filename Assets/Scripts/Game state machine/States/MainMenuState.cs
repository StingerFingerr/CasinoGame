using Services.Progress;
using Services.Service_locator;
using Services.UI;

namespace Game_state_machine.States
{
    public class MainMenuState: IState
    {
        private IServiceLocator _serviceLocator;

        public MainMenuState (IServiceLocator serviceLocator) => 
            _serviceLocator = serviceLocator;

        public void Enter()
        {
            var uiManager = _serviceLocator.GetService<IUIManager>();
            var progressService = _serviceLocator.GetService<IProgressService>();
                
            uiManager.OpenMenu();
            uiManager.UpdateCoins(progressService.Progress);
        }

        public void Exit()
        {
            
        }
    }
}