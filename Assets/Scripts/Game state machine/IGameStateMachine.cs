using Game_state_machine.States;

namespace Game_state_machine
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState: class, IState;
    }
}