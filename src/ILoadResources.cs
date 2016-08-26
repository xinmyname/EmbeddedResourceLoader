using System.IO;

namespace EmbeddedResources
{
    public interface ILoadResources
    {
        string LoadText(string name);
        byte[] LoadBytes(string name);
        Stream OpenStream(string name);
    }
}