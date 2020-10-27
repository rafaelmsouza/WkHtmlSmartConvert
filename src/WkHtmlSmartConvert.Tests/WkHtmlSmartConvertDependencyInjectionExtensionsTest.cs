using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace WkHtmlSmartConvert.Tests
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
            collection.Should().NotContain(p => p.ServiceType == typeof(IPdfConvert));
        }
    }
}
