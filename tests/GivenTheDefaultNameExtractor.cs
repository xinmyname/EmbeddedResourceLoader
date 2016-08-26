using System;
using System.Reflection;
using NUnit.Framework;
using Should;

namespace EmbeddedResources.Tests
{
    [TestFixture]
    public class GivenTheDefaultNameExtractor
    {
        private readonly Func<string, Assembly, string> NameExtractor = AssemblyResourceLocator.DefaultNameExtractor;

        [Test]
        public void WhenTheManifestResourceNameContainsAFullyQualifiedPath()
        {
            string it = NameExtractor("SomeNamespace.SomeAssembly.filename.ext", null);

            it.ShouldEqual("filename.ext");
        }

        [Test]
        public void WhenTheManifestResourceNameContainsJustAFilename()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                NameExtractor("filename.ext", null);
            });
        }
    }
}