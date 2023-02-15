namespace Services.Service_locator
{
    public interface IServiceLocator
    {
        void SetService<TService>(IService service) where TService: class, IService;
        TService GetService<TService>() where TService : class, IService;
    }
}