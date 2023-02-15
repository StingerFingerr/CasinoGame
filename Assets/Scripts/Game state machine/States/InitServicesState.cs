using Services.Progress;
using Services.Resource;
using Services.Service_locator;
using Services.UI;

namespace Game_state_machine.States
{
    public class InitServicesState: IState
    {
        private IServiceLocator _serviceLocator;
        private IGameStateMachine _gameStateMachine;

        public InitServicesState (IServiceLocator serviceLocator, IGameStateMachine gameStateMachine)
        {
            _serviceLocator = serviceLocator;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            BindResourcesServices();
            BindUiManagerService();
            BindProgressService();

            _gameStateMachine.Enter<LoadProgressState>();
        }

        private void BindProgressService() => 
            _serviceLocator.SetService<IProgressService>(new PlayerPrefsProgressService());

        private void BindResourcesServices()
        {
            var pathService = new ResourcePathService();
            _serviceLocator.SetService<IResourcePathService>(pathService);
            _serviceLocator.SetService<IResourcesService>(new ResourcesService(pathService));
        }

        private void BindUiManagerService()
        {
            var resourcesService = _serviceLocator.GetService<IResourcesService>();
            var uiManager = resourcesService.LoadResource(typeof(IUIManager)) as IUIManager;
            uiManager.Initialize(_gameStateMachine);
            
            _serviceLocator.SetService<IUIManager>(uiManager);
        }

        public void Exit()
        {
            
        }
    }
}