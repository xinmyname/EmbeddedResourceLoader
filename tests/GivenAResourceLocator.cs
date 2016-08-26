using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Should;

namespace EmbeddedResources.Tests
{
    [TestFixture]
    public class GivenAResourceLocator
    {
        private readonly ILocateResources _resLocator;

        public GivenAResourceLocator()
        {
            _resLocator = new AssemblyResourceLocator(GetType().Assembly);
        }

        [Test]
        public void WhenResourcesAreEnumerated()
        {
            IList<ResourceEntry> it = _resLocator
                .EnumerateResourceEntries()
                .ToList();

            it.ShouldNotBeEmpty();
        }
    }
}