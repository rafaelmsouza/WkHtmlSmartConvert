using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using Xunit;

namespace WkHtmlSmartConvert.Tests.Core
{
    public class PdfConvertDependencyInjectionExtensionsTest
    {
        private readonly Mock<IWkHtmlSmartConvertBuilder> _wkHtmlSmartConvertBuilder;

        public PdfConvertDependencyInjectionExtensionsTest()
        {
            var collection = new ServiceCollection();
            _wkHtmlSmartConvertBuilder = new Mock<IWkHtmlSmartConvertBuilder>();
            _wkHtmlSmartConvertBuilder.Setup(p => p.Services).Returns(collection);
        }

        [Fact]
        public void AddPdf_AddsNeededServices()
        {
            // Act
            var builder = PdfConvertDependencyInjectionExtensions.AddPdf(_wkHtmlSmartConvertBuilder.Object);

            // Assert
            builder.Services.Should().NotBeEmpty();
            builder.Services.Should().ContainSingle(p=> p.ServiceType == typeof(IPdfConvert));
        }

        [Fact]
        public void AddPdf_ThrowArgumentNullException()
        {
            // Act
            IWkHtmlSmartConvertBuilder act() => PdfConvertDependencyInjectionExtensions
                .AddPdf(_wkHtmlSmartConvertBuilder.Object, null);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }
    }
}
