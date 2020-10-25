using FluentAssertions;
using Xunit;

namespace WkHtmlSmartConvert.Tests
{
    public class PdfOptionsTest
    {
        //private readonly Mock<IServiceProvider> _provider;
        //private readonly Mock<IProcessService> _processService;

        public PdfOptionsTest()
        {
            //_provider = new Mock<IServiceProvider>();
            //_processService = new Mock<IProcessService>();

            //_provider.Setup(p => p.GetService(typeof(IProcessService))).Returns(new BaseProcess());
        }

        [Fact]
        public void PdfOptions_ToString_DefaultValues()
        {
            // Arrange
            var pdfOptions = new PdfOptions();

            // Act
            var result = pdfOptions.ToString();

            // Assert
            result.Should().Be("--dpi 96 --image-dpi 600 --image-quality 94 --copies 1");
        }
    }
}
