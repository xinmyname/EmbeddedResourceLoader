using System.Reflection;
using NUnit.Framework;
using Should;

namespace EmbeddedResources.Tests
{
    [TestFixture]
    public class GivenAResourceNameInASubFolderWithADuplicateName
    {
        private readonly Assembly _asm;
        private readonly string _resourceName;

        public GivenAResourceNameInASubFolderWithADuplicateName()
        {
            _asm = GetType().Assembly;
            _resourceName = "BadGuy.txt";
        }

        [Test]
        public void WhenILocateTheResource()
        {
            var it = new AssemblyResourceLocator(_asm)
                .Locate(_resourceName);

            it.FullName.ShouldEqual("EmbeddedResources.Tests.Resources.BadGuy.txt");
        }
    }
}
