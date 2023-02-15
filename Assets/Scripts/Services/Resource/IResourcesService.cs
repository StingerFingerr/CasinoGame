using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.Resource
{
    public interface IResourcesService: IService
    {
        Object LoadResource(Type type);
    }
}