using System.Reflection;

namespace EmbeddedResources
{
    public class ResourceEntry
    {
        public Assembly Assembly { get; set; }
        public string ManifestResourceName { get; set; }
        public string Name { get; set; }
    }
}