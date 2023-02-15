using Game_state_machine;
using GamePlay;

namespace Services.UI
{
    public interface IUIManager: IService
    {
        CasinoWheel Wheel { get; }
        public void Initialize(IGameStateMachine gameStateMachine);
        void OpenMenu();
        void OpenWheelGame();
        void UpdateCoins(Progress.Progress progress);
    }
}