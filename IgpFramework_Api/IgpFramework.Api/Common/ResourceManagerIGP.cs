

namespace IgpFramework.Api.Common
{
    public class ResourceManagerIGP : IResourceManagerIGP
    {
        public string GetResourceValue(string name)
        {
            return Resource.IGPResources.ResourceManager.GetString(name);
        }
    }
}
