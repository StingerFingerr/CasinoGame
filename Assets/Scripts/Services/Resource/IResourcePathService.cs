using System;

namespace Services.Resource
{
    public interface IResourcePathService: IService
    {
        string GetResourcePath(Type type);
    }
}