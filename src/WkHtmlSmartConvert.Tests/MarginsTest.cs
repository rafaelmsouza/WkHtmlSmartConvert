using FluentAssertions;
using Xunit;

namespace WkHtmlSmartConvert.Tests
{
    public class MarginsTest
    {
        [Fact]
        public void ToString_Empty()
        {
            // Arrange
            var margins = new Margins();

            // Act
            var result = margins.ToString();

            // Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public void ToString_SettedParameter()
        {
            // Arrange
            var margins = new Margins(10, 20, 30, 40);

            // Act
            var result = margins.ToString();

            // Assert
            result.Should().Be("-T 10 -R 20 -B 30 -L 40");
        }
    }
}
