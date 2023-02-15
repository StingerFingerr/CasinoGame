using Services.Progress;
using Services.Service_locator;
using Services.UI;

namespace Game_state_machine.States
{
    public class WheelGameState: IState
    {
        private IServiceLocator _serviceLocator;
        
        private IUIManager _uiManager;
        private IProgressService _progressService;

        private bool _wheelIsSpinning;

        public WheelGameState (IServiceLocator serviceLocator) => 
            _serviceLocator = serviceLocator;

        public void Enter()
        {
            _uiManager ??= _serviceLocator.GetService<IUIManager>();
            _progressService ??= _serviceLocator.GetService<IProgressService>();
                
            _uiManager.OpenWheelGame();
            _uiManager.UpdateCoins(_progressService.Progress);
            
            _uiManager.Wheel.launchButton.onClick.AddListener(LaunchWheel);
        }

        private void LaunchWheel()
        {
            if(_wheelIsSpinning)
                return;
            
            _wheelIsSpinning = true;
            _uiManager.Wheel.LaunchWheel(GetReward);
        }

        private void GetReward(int reward, CoinType type)
        {
            _wheelIsSpinning = false;
            
            _progressService.Progress.UpdateProgress(reward, type);
            
            _uiManager.UpdateCoins(_progressService.Progress);
        }

        public void Exit() => 
            _uiManager.Wheel.launchButton.onClick.RemoveListener(LaunchWheel);
    }
}