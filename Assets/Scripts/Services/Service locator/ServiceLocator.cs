using System;
using System.Collections.Generic;

namespace Services.Service_locator
{
    public class ServiceLocator: IServiceLocator
    {
        private Dictionary<Type, IService> _services = new();

        public void SetService<TService>(IService service) where TService : class, IService => 
            _services.Add(typeof(TService), service);

        public TService GetService<TService>() where TService : class, IService => 
            _services[typeof(TService)] as TService;
    }
}