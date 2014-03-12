using System;
using System.IO;

namespace EmbeddedResourceLoader
{
    public class EmbeddedResourceLoader : ILoadResources
    {
        private readonly ILocateResources _resourceLocator;

        public EmbeddedResourceLoader(ILocateResources resourceLocator)
        {
            _resourceLocator = resourceLocator;
        }

        public string LoadText(string name)
        {
            ResourceReference resourceReference = _resourceLocator.Locate(name);

            if (resourceReference == null)
                throw new ArgumentException(String.Format("Resource \"{0}\" not found.", name));

            string text;

            using (var stream = resourceReference.Assembly.GetManifestResourceStream(resourceReference.FullName))
            {
                if (stream == null)
                    throw new ArgumentException(String.Format("Resource \"{0}\" not found.", name));

                var reader = new StreamReader(stream);
                text = reader.ReadToEnd();
            }

            return text;
        }
    }
}
