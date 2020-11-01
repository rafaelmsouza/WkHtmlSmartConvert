using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace WkHtmlSmartConvert.Tests.Embedded
{
    public class EmbeddedDependencyInjectionExtensionsTest
    {
        private readonly Mock<IWkHtmlSmartConvertBuilder> _wkHtmlSmartConvertBuilder;

        public EmbeddedDependencyInjectionExtensionsTest()
        {
            var collection = new ServiceCollection();
            _wkHtmlSmartConvertBuilder = new Mock<IWkHtmlSmartConvertBuilder>();
            _wkHtmlSmartConvertBuilder.Setup(p => p.Services).Returns(collection);
        }

        [Fact]
        public void AddEmbedded_AddsNeededServices()
        {
            // Act
            var builder = EmbeddedDependencyInjectionExtensions.AddEmbedded(_wkHtmlSmartConvertBuilder.Object);

            // Assert
            builder.Services.Should().NotBeEmpty();
            builder.Services.Should().ContainSingle(p=> p.ServiceType == typeof(IExecutablePath));
        }
    }
}
