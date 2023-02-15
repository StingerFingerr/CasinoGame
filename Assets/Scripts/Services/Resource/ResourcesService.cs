using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.Resource
{
    public class ResourcesService: IResourcesService
    {
        private IResourcePathService _resourcePathService;

        public ResourcesService (IResourcePathService resourcePathService) => 
            _resourcePathService = resourcePathService;

        public Object LoadResource(Type type)
        {
            var obj = Object.Instantiate(Resources.Load(GetPath(type), type));

            if (obj is null)
                throw new Exception($"Resource of type {type} no found");

            return obj;
        }

        private string GetPath(Type type) => 
            _resourcePathService.GetResourcePath(type);
    }
}