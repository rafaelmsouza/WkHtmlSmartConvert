using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using Xunit;

namespace WkHtmlSmartConvert.Tests
{
    public class HtmlToPdfConvertTest
    {
        //private readonly Mock<IServiceProvider> _provider;
        //private readonly Mock<IProcessService> _processService;

        //public HtmlToPdfConvertTest()
        //{
        //    _provider = new Mock<IServiceProvider>();
        //    _processService = new Mock<IProcessService>();

        //    //_provider.Setup(p => p.GetService(typeof(IProcessService))).Returns(new BaseProcess());
        //}

        //[Fact]
        //public async void Test1()
        //{
        //    // Arrange
        //    var html = "<html><body><strong>Name: </strong> Teste</body></html>";
        //    var htmlToPdfConvert = new PdfConvert(null);

        //    // Act
        //    var result = await htmlToPdfConvert.ConvertAsync(html);

        //    // Assert
        //    result.Should().NotBeNull();
        //    result.Length.Should().BeGreaterThan(0);
        //}
    }
}
