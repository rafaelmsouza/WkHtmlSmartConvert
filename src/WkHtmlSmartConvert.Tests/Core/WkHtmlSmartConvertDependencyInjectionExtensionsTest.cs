using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace WkHtmlSmartConvert.Tests.Core
{
    public class WkHtmlSmartConvertDependencyInjectionExtensionsTest
    {
        [Fact]
        public void AddWkHtmlSmartConvert_AddsNeededServices()
        {
            // Arrange
            var collection = new ServiceCollection();

            // Act
            WkHtmlSmartConvertDependencyInjectionExtensions.AddWkHtmlSmartConvert(collection);

            // Assert
            collection.Should().NotBeEmpty();
            collection.Should().ContainSingle(p => p.ServiceType == typeof(IExecutablePath));
        }
    }
}
