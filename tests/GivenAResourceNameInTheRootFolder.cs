using System.CodeDom;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace EmbeddedResources.Tests
{
    [TestClass]
    public class GivenAResourceNameInTheRootFolder
    {
        private readonly Assembly _asm;
        private readonly string _resourceName;

        public GivenAResourceNameInTheRootFolder()
        {
            _asm = GetType().Assembly;
            _resourceName = "NotADJ.txt";
        }

        [TestMethod]
        public void WhenILocateTheResource()
        {
            var it = new AssemblyResourceLocator(_asm)
                .Locate(_resourceName);

            it.ShouldBeType<ResourceReference>();
        }

        [TestMethod]
        public void WhenILoadTheTextForTheResource()
        {
            var it = new EmbeddedResourceLoader(new AssemblyResourceLocator(_asm))
                .LoadText(_resourceName);

            it.ShouldEqual("Wyld Style");
        }
    }
}
