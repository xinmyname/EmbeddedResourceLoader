using System;
using NUnit.Framework;

namespace EmbeddedResourceLoader.Tests
{
    public static class ShouldExtensions
    {
        public static void ShouldThrow<T>(this object it, TestDelegate code) where T : Exception
        {
            Assert.Throws<T>(code);
        }
    }
}
