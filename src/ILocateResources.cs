using System.Collections.Generic;

namespace EmbeddedResources
{
    public interface ILocateResources
    {
        ResourceReference Locate(string name);
        IEnumerable<ResourceEntry> EnumerateResourceEntries();
    }
}