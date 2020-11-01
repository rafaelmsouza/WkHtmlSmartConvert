using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace WkHtmlSmartConvert.Tests.Embedded
{
    public class RuntimeFolderExecutablePathTest
    {
        private readonly IExecutablePath _executablePath;

        public RuntimeFolderExecutablePathTest()
        {
            var collection = new ServiceCollection();
            collection.AddWkHtmlSmartConvert().AddEmbedded();
            _executablePath = collection.BuildServiceProvider().GetService<IExecutablePath>();
        }

        [Fact]
        public void AddEmbedded_AddsNeededServices()
        {
            // Act
            var path = _executablePath.Path;

            // Assert
            path.Should().Contain("runtimes");
        }
    }
}
