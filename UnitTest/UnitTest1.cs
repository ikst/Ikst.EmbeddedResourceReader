using System;
using Xunit;
using Ikst.EmbeddedResourceReader;
using System.Reflection;
using System.Drawing;
using System.IO;

namespace UnitTest
{
    public class UnitTest1
    {
        Assembly targetAssembly = Assembly.GetExecutingAssembly();

        [Fact]
        public void ArgumentError()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var result = targetAssembly.GetEmbeddedResourceString("error");
            });
        }

        [Fact]
        public void GetEmbeddedResourceString()
        {
            var result = targetAssembly.GetEmbeddedResourceString("TestResource.TextFile1.txt");
            Assert.Equal("OK", result);
        }

        [Fact]
        public void GetEmbeddedResourceBinary()
        {
            var result = targetAssembly.GetEmbeddedResourceBinary("TestResource.ImageFile.png");
            Assert.Equal(67070, result.Length);

            using (var ms = new MemoryStream(result))
            using (var bmp = new Bitmap(ms))
            {
                Assert.Equal(200, bmp.Width);
                Assert.Equal(150, bmp.Height);
            }
        }

    }
}
