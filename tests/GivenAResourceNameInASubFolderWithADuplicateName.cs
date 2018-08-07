using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace EmbeddedResources.Tests
{
    [TestClass]
    public class GivenAResourceNameInASubFolderWithADuplicateName
    {
        private readonly Assembly _asm;
        private readonly string _resourceName;

        public GivenAResourceNameInASubFolderWithADuplicateName()
        {
            _asm = GetType().Assembly;
            _resourceName = "BadGuy.txt";
        }

        [TestMethod]
        public void WhenILocateTheResource()
        {
            var it = new AssemblyResourceLocator(_asm)
                .Locate(_resourceName);

            it.FullName.ShouldEqual("EmbeddedResources.Tests.Resources.BadGuy.txt");
        }
    }
}
