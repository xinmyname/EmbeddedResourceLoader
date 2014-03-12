namespace EmbeddedResourceLoader
{
    public interface ILocateResources
    {
        ResourceReference Locate(string name);
    }
}