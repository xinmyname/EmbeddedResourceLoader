using System.Reflection;
using NUnit.Framework;
using Should;

namespace EmbeddedResourceLoader.Tests
{
    [TestFixture]
    public class GivenAResourceNameInTheRootFolder
    {
        private readonly Assembly _asm;
        private readonly string _resourceName;

        public GivenAResourceNameInTheRootFolder()
        {
            _asm = GetType().Assembly;
            _resourceName = "NotADJ.txt";
        }

        [Test]
        public void WhenILocateTheResource()
        {
            var it = new AssemblyResourceLocator(_asm)
                .Locate(_resourceName);

            it.ShouldBeType<ResourceReference>();
        }

        [Test]
        public void WhenILoadTheTextForTheResource()
        {
            var it = new EmbeddedResourceLoader(new AssemblyResourceLocator(_asm))
                .LoadText(_resourceName);

            it.ShouldEqual("Wyld Style");
        }
    }
}
