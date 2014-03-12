using System;
using System.Reflection;
using NUnit.Framework;
using Should;

namespace EmbeddedResourceLoader.Tests
{
    [TestFixture]
    public class GivenAResourceNameInASubFolderWithADuplicateName
    {
        private readonly Assembly _asm;
        private readonly string _resourceName;
        private readonly Func<string, string, bool> _fullyQualifiedMatchingStrategy; 

        public GivenAResourceNameInASubFolderWithADuplicateName()
        {
            _asm = GetType().Assembly;
            _resourceName = "BadGuy.txt";
            _fullyQualifiedMatchingStrategy = (key, name) => key.Equals(name);
        }

        [Test]
        public void WhenILocateTheResource()
        {
            var it = new AssemblyResourceLocator(_asm)
                .Locate(_resourceName);

            it.FullName.ShouldEqual("EmbeddedResourceLoader.Tests.Resources.BadGuy.txt");
        }

        [Test]
        public void WhenIUseAFullyQualifiedMatchingStrategy()
        {
            bool itThrowsAnArgumentException = false;

            try
            {
                var locator = new AssemblyResourceLocator(_asm)
                {
                    MatchingStrategy = _fullyQualifiedMatchingStrategy
                };

                new EmbeddedResourceLoader(locator)
                    .LoadText(_resourceName);
            }
            catch (ArgumentException)
            {
                itThrowsAnArgumentException = true;
            }

            itThrowsAnArgumentException.ShouldBeTrue();
        }
    }
}
