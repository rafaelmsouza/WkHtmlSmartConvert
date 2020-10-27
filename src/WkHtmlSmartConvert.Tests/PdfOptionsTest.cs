using FluentAssertions;
using System.Text;
using Xunit;

namespace WkHtmlSmartConvert.Tests
{
    public class PdfOptionsTest
    {
        [Fact]
        public void PdfOptions_ToString_DefaultValues()
        {
            // Arrange
            var pdfOptions = new PdfOptions();

            // Act
            var result = pdfOptions.ToString();

            // Assert
            result.Should().Be("--dpi 96 --image-dpi 600 --image-quality 94 --copies 1 --page-size a4 --orientation portrait");
        }

        [Fact]
        public void PdfOptions_ToString_SettedManyProperties()
        {
            // Arrange
            var pdfOptions = new PdfOptions {
                Dpi = 10,
                Copies = 2,
                Encoding = Encoding.ASCII,
                Height = 100,
                Width = 200,
                ImageDpi = 300,
                ImageQuality = 20,
                IsGrayScale = true,
                IsLowQuality = true,
                IsNoCompression = true,
                PageOrientation = PageOrientation.Landscape,
                PageSize = PageSize.Tabloid,
                Margins = new Margins { 
                    Bottom = 10,
                    Left = 20,
                    Top = 30,
                    Right = 40,
                }
            };

            // Act
            var result = pdfOptions.ToString();

            // Assert
            result.Should().Be("--dpi 10 --grayscale --encoding us-ascii --image-dpi 300 --image-quality 20 --lowquality --no-pdf-compression --copies 2 --page-size tabloid --orientation landscape --page-height 100 --page-width 200 -T 30 -R 40 -B 10 -L 20");
        }
    }
}
