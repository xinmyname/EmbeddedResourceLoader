using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmbeddedResources.Tests
{
    public static class ShouldExtensions
    {
        public static void ShouldThrow<T>(this object it, Action code) where T : Exception
        {
            Assert.ThrowsException<T>(code);
        }

        public static void ShouldEqual(this object it, object that)
        {
            Assert.AreEqual(it, that);
        }

        public static void ShouldBeNull(this object it)
        {
            Assert.IsNull(it);
        }

        public static void ShouldNotBeEmpty<T>(this IEnumerable<T> it)
        {
            Assert.IsTrue(it.Any());
        }

        public static void ShouldBeType<T>(this object it)
        {
            Assert.IsTrue(it.GetType() == typeof(T));
        }
    }
}
