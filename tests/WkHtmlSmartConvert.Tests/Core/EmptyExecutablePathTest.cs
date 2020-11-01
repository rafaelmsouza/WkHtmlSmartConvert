using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace WkHtmlSmartConvert.Tests.Core
{
    public class EmptyExecutablePathTest
    {
        private readonly IExecutablePath _executablePath;

        public EmptyExecutablePathTest()
        {
            var collection = new ServiceCollection();
            collection.AddWkHtmlSmartConvert();
            _executablePath = collection.BuildServiceProvider().GetService<IExecutablePath>();
        }

        [Fact]
        public void AddEmbedded_AddsNeededServices()
        {
            // Act
            var path = _executablePath.Path;

            // Assert
            path.Should().BeEmpty();
        }
    }
}
