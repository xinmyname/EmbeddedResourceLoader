using System;
using System.IO;

namespace EmbeddedResources
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
            string text = String.Empty;

            using (var stream = this.OpenStream(name))
            {
                if (stream == null)
                    throw new ArgumentException($"Resource \"{name}\" not found.", nameof(name));

                var reader = new StreamReader(stream);
                text = reader.ReadToEnd();
            }

            return text;
        }

        public byte[] LoadBytes(string name)
        {
            var memStream = new MemoryStream();

            using (var resStream = this.OpenStream(name))
            {
                if (resStream == null)
                    throw new ArgumentException($"Resource \"{name}\" not found.", nameof(name));

                resStream.CopyTo(memStream);
            }

            return memStream.ToArray();
        }

        public Stream OpenStream(string name)
        {
            ResourceReference resourceReference = _resourceLocator.Locate(name);

            if (resourceReference == null)
                throw new ArgumentException($"Resource \"{name}\" not found.", nameof(name));

            var stream = resourceReference.Assembly.GetManifestResourceStream(resourceReference.FullName);

            if (stream == null)
                throw new ArgumentException($"Resource \"{name}\" not found.", nameof(name));

            return stream;
        }
    }
}
