using Game_state_machine;
using Game_state_machine.States;
using GamePlay;
using UI;
using UnityEngine;

namespace Services.UI
{
    public class UIManager: MonoBehaviour, IUIManager
    {
        public GameObject menuWindow;
        public GameObject wheelGameWindow;
        public Wallet wallet;

        public CasinoWheel Wheel => wheel;
        public CasinoWheel wheel;

        private IGameStateMachine _gameStateMachine;

        public void Initialize(IGameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        public void OpenMenu()
        {
            wheelGameWindow.SetActive(false);
            menuWindow.SetActive(true);
        }
        public void OpenWheelGame()
        {
            menuWindow.SetActive(false);
            wheelGameWindow.SetActive(true);
        }

        public void UpdateCoins(Progress.Progress progress) => 
            wallet.UpdateCoins(progress);

        public void PlayGame() => 
            _gameStateMachine.Enter<WheelGameState>();

        public void BackToMainMenu() => 
            _gameStateMachine.Enter<MainMenuState>();
    }
}