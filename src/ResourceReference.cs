using System.Reflection;

namespace EmbeddedResources
{
    public class ResourceReference
    {
        public Assembly Assembly { get; }
        public string FullName { get; }

        public ResourceReference(Assembly assembly, string fullName)
        {
            Assembly = assembly;
            FullName = fullName;
        }
    }
}
