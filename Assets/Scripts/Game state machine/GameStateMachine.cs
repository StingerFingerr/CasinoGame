using System;
using System.Collections.Generic;
using Game_state_machine.States;
using Services.Service_locator;

namespace Game_state_machine
{
    public class GameStateMachine: IGameStateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _currentState;
        
        public GameStateMachine(IServiceLocator serviceLocator)
        {
            _states = new()
            {
                {typeof(InitServicesState), new InitServicesState(serviceLocator, this)},
                {typeof(LoadProgressState), new LoadProgressState(serviceLocator, this)},
                {typeof(MainMenuState), new MainMenuState(serviceLocator)},
                {typeof(WheelGameState), new WheelGameState(serviceLocator)}
            };
        }
        
        
        public void Enter<TState>() where TState : class, IState
        {
            _currentState?.Exit();

            _currentState = GetState<TState>();
            
            _currentState.Enter();
        }

        private IState GetState<TState>() where TState: class, IState => 
            _states[typeof(TState)];
    }
}