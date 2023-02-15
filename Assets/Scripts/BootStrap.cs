using Game_state_machine;
using Game_state_machine.States;
using Services.Progress;
using Services.Service_locator;
using UnityEngine;

public class BootStrap : MonoBehaviour
{
    private IServiceLocator _serviceLocator;
    private IGameStateMachine _gameStateMachine;
    
    private void Awake()
    {
        _serviceLocator = new ServiceLocator();
        _gameStateMachine = new GameStateMachine(_serviceLocator);
    }

    private void Start() => 
        _gameStateMachine.Enter<InitServicesState>();

    private void OnApplicationQuit() => 
        _serviceLocator.GetService<IProgressService>().SaveProgress();
}
