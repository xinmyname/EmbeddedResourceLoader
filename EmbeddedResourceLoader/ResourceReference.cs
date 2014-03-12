using System.Reflection;

namespace EmbeddedResourceLoader
{
    public class ResourceReference
    {
        public Assembly Assembly { get; private set; }
        public string FullName { get; private set; }

        public ResourceReference(Assembly assembly, string fullName)
        {
            Assembly = assembly;
            FullName = fullName;
        }
    }
}
