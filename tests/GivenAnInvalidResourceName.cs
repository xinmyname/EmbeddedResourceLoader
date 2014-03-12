﻿using System;
using System.Reflection;
using NUnit.Framework;
using Should;

namespace EmbeddedResourceLoader.Tests
{
    [TestFixture]
    public class GivenAnInvalidResourceName
    {
        private readonly Assembly _asm;
        private readonly string _resourceName;

        public GivenAnInvalidResourceName()
        {
            _asm = GetType().Assembly;
            _resourceName = "SirNotAppearingInThisAssembly.txt";
        }

        [Test]
        public void WhenILocateTheResource()
        {
            var it = new AssemblyResourceLocator(_asm)
                .Locate(_resourceName);

            it.ShouldBeNull();
        }

        [Test]
        public void WhenILoadTheResourceText()
        {
            bool itThrowsAnArgumentException = false;

            try
            {
                new EmbeddedResourceLoader(new AssemblyResourceLocator(_asm))
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