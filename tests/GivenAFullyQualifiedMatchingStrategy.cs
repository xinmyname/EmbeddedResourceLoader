using System;
using System.Reflection;
using NUnit.Framework;
using Should;

namespace EmbeddedResources.Tests
{
    [TestFixture]
    public class GivenAFullyQualifiedMatchingStrategy
    {
        private readonly Assembly _asm;
        private readonly Func<string, string, bool> _fullyQualifiedMatchingStrategy;

        public GivenAFullyQualifiedMatchingStrategy()
        {
            _asm = GetType().Assembly;
            _fullyQualifiedMatchingStrategy = (key, name) => key.Equals(name);
        }

        [Test]
        public void WhenILoadAResourceWithAShortName()
        {
            var locator = new AssemblyResourceLocator(_asm)
            {
                MatchingStrategy = _fullyQualifiedMatchingStrategy
            };

            var it = new EmbeddedResourceLoader(locator);

            it.ShouldThrow<ArgumentException>(() => it.LoadText("BadGuy.txt"));
        }

        [Test]
        public void WhenILoadAResourceWithAFullyQualifiedName()
        {
            var locator = new AssemblyResourceLocator(_asm)
            {
                MatchingStrategy = _fullyQualifiedMatchingStrategy
            };

            string it = new EmbeddedResourceLoader(locator)
                .LoadText("EmbeddedResources.Tests.Resources.Sub.Sub_Sub.BadGuy.txt");

            it.ShouldEqual("Bad Cop");
        }
    }
}