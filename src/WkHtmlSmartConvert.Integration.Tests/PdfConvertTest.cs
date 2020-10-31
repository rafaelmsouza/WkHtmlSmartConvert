using FluentAssertions;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WkHtmlSmartConvert.Integration.Tests.Resources;
using WkHtmlSmartConvert.Integration.Tests.Utils;
using Xunit;

namespace WkHtmlSmartConvert.Integration.Tests
{
    public class PdfConvertTest
    {
        [Fact]
        public async void Convert_StaticHtml()
        {
            // Arrange
            PdfConvertUtils.DeleteTempDirectory();
            var pdfConvert = PdfConvertUtils.CreateWithAddEmbedded();
            var html = HtmlExemples.Short;

            // Act
            var buffer = await pdfConvert.ConvertAsync(html);

            // Assert
            buffer.Length.Should().BeInRange(14600, 14700);
        }

        [Fact]
        public async void Convert_StaticHtml_WithOptions()
        {
            // Arrange
            var pdfConvert = PdfConvertUtils.CreateWithAddEmbedded();
            var html = HtmlExemples.Short;
            var options = new PdfOptions
            {
                PageOrientation = PageOrientation.Landscape,
                IsGrayScale = true,
                Copies = 2,
                PageSize = PageSize.A0
            };

            // Act
            var buffer = await pdfConvert.ConvertAsync(html, options);

            // Assert
            buffer.Length.Should().BeInRange(15600, 15700);
        }

        [Fact]
        public async void Convert_StaticHtml_ImageEmbedded()
        {
            // Arrange
            var pdfConvert = PdfConvertUtils.CreateWithAddEmbedded();
            var html = HtmlExemples.WithImage;
            var options = new PdfOptions
            {
                PageOrientation = PageOrientation.Landscape,
            };

            // Act
            var buffer = await pdfConvert.ConvertAsync(html, options);
            
            // Assert
            buffer.Length.Should().BeInRange(31200, 31300);
        }

        [Fact]
        public async void Convert_StaticHtml_DefaultOPtions()
        {
            // Arrange
            var pdfConvert = PdfConvertUtils.CreateWithAddEmbedded(options => {
                options.PageOrientation = PageOrientation.Landscape;
                options.IsGrayScale = true;
                options.PageSize = PageSize.A2;
            });
            var html = HtmlExemples.WithImage;

            // Act
            var buffer = await pdfConvert.ConvertAsync(html);

            // Assert
            buffer.Length.Should().BeInRange(26600, 26700);
        }

        [Fact]
        public async void Convert_ThrowCancellationRequested()
        {
            // Arrange
            var cancellationToken = new CancellationToken(true);
            var pdfConvert = PdfConvertUtils.CreateWithAddEmbedded();

            // Act
            Task act() => pdfConvert.ConvertAsync("", cancellationToken);

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(act);
        }

        [Fact]
        public async void Convert_Stream()
        {
            // Arrange
            var pdfConvert = PdfConvertUtils.CreateWithAddEmbedded();
            var html = HtmlExemples.Short;
            var memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(html));

            // Act
            var buffer = await pdfConvert.ConvertAsync(memoryStream);
            
            // Assert
            buffer.Length.Should().BeInRange(14600, 14700);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", null)]
        public async void Convert_ThrowArgumentNullException(string html, PdfOptions options)
        {
            // Arrange
            var pdfConvert = PdfConvertUtils.CreateWithAddEmbedded();

            // Act
            Task act() => pdfConvert.ConvertAsync(html, options, CancellationToken.None);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(act);
        }

        [Fact]
        public async void Convert_Stream_ThrowArgumentNullException()
        {
            // Arrange
            var pdfConvert = PdfConvertUtils.CreateWithAddEmbedded();
            Stream html = null;

            // Act
            Task act() => pdfConvert.ConvertAsync(html, null, CancellationToken.None);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(act);
        }

        [Fact]
        public async void Convert_StaticHtml_WithoutEmbedded()
        {
            // Arrange
            PdfConvertUtils.DeleteTempDirectory();
            var pdfConvert = PdfConvertUtils.Create();
            var html = HtmlExemples.Short;

            // Act
            var buffer = await pdfConvert.ConvertAsync(html);

            // Assert
            buffer.Length.Should().BeInRange(14600, 14700);
        }
    }
}
