

namespace Igp.Api.Base.Common
{
    public class ResourceManagerIGP : IResourceManagerIGP
    {
        public string GetResourceValue(string name)
        {
            return Resource.IGPResources.ResourceManager.GetString(name);
        }
    }
}
