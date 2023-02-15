using System;
using System.Collections.Generic;
using Services.UI;

namespace Services.Resource
{
    public class ResourcePathService: IResourcePathService
    {
        private Dictionary<Type, string> _paths;

        public ResourcePathService ()
        {
            _paths = new()
            {
                {typeof(IUIManager), "UIManager"},
            };
        }
        
        public string GetResourcePath(Type type) => 
            _paths[type];
    }
}