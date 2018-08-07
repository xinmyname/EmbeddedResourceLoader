using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace EmbeddedResources.Tests
{
    [TestClass]
    public class GivenAResourceLocator
    {
        private readonly ILocateResources _resLocator;

        public GivenAResourceLocator()
        {
            _resLocator = new AssemblyResourceLocator(GetType().Assembly);
        }

        [TestMethod]
        public void WhenResourcesAreEnumerated()
        {
            IList<ResourceEntry> it = _resLocator
                .EnumerateResourceEntries()
                .ToList();

            it.ShouldNotBeEmpty();
        }
    }
}