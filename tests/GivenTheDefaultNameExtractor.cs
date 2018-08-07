using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace EmbeddedResources.Tests
{
    [TestClass]
    public class GivenTheDefaultNameExtractor
    {
        private readonly Func<string, Assembly, string> NameExtractor = AssemblyResourceLocator.DefaultNameExtractor;

        [TestMethod]
        public void WhenTheManifestResourceNameContainsAFullyQualifiedPath()
        {
            string it = NameExtractor("SomeNamespace.SomeAssembly.filename.ext", null);

            it.ShouldEqual("filename.ext");
        }

        [TestMethod]
        public void WhenTheManifestResourceNameContainsJustAFilename()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                NameExtractor("filename.ext", null);
            });
        }
    }
}