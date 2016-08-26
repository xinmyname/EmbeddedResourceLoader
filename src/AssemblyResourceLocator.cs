using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EmbeddedResources
{
    public class AssemblyResourceLocator : ILocateResources
    {
        private readonly IDictionary<string, Assembly> _resNames;

        public Func<string, string, bool> MatchingStrategy;

        public AssemblyResourceLocator(params Assembly[] assemblies)
        {
            _resNames = new Dictionary<string, Assembly>();

            foreach (Assembly assembly in assemblies)
            {
                foreach (string name in assembly.GetManifestResourceNames())
                    _resNames[name] = assembly;
            }

            MatchingStrategy = DefaultMatchingStrategy;
        }

        public ResourceReference Locate(string name)
        {
            string key = _resNames.Keys
                .FirstOrDefault(k => MatchingStrategy(k, name));

            if (key == null)
                return null;

            return new ResourceReference(_resNames[key], key);
        }

        public IEnumerable<ResourceEntry> EnumerateResourceEntries()
        {
            foreach (KeyValuePair<string, Assembly> pair in _resNames)
            {
                Assembly asm = pair.Value;
                AssemblyName asmName = asm.GetName();
                string asmResourcePrefix = asmName.Name + ".Resources.";

                yield return new ResourceEntry
                {
                    ManifestResourceName = pair.Key,
                    Assembly = asm,
                    Name = pair.Key.Substring(asmResourcePrefix.Length)
                };
            }
        }

        public static bool DefaultMatchingStrategy(string key, string name)
        {
            return key.Contains(name);
        }
    }
}
