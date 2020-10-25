using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace WkHtmlSmartConvert
{
    /// <summary>
    /// A Convert abstraction for a PDF.
    /// </summary>
    public interface IPdfConvert
    {
        /// <summary>
        /// Convert HTML to PDF
        /// </summary>
        /// <param name="html">Html to be converted</param>
        /// <returns>The <see cref="Task"/> that represents the asynchronous operation, containing a buffer of <paramref cref="byte"/> from pdf converted.</returns>
        Task<byte[]> ConvertAsync(string html);

        /// <summary>
        /// Convert HTML to PDF
        /// </summary>
        /// <param name="html">Html to be converted</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Task"/> that represents the asynchronous operation, containing a buffer of <paramref cref="byte"/> from pdf converted.</returns>
        Task<byte[]> ConvertAsync(string html, CancellationToken cancellationToken);

        /// <summary>
        /// Convert HTML to PDF by setting <see name="options"/>
        /// </summary>
        /// <param name="html">Html to be converted</param>
        /// <param name="options">The <see cref="PdfOptions"/> to configure PDF convertion</param>
        /// <returns>The <see cref="Task"/> that represents the asynchronous operation, containing a buffer of <paramref cref="byte"/> from pdf converted.</returns>
        Task<byte[]> ConvertAsync(string html, PdfOptions options);

        /// <summary>
        /// Convert HTML to PDF by setting <see name="options"/>
        /// </summary>
        /// <param name="html">Html to be converted</param>
        /// <param name="options">The <see cref="PdfOptions"/> to configure PDF convertion</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Task"/> that represents the asynchronous operation, containing a buffer of <paramref cref="byte"/> from pdf converted.</returns>
        Task<byte[]> ConvertAsync(string html, PdfOptions options, CancellationToken cancellationToken);

        /// <summary>
        /// Convert HTML to PDF by setting <see name="options"/>
        /// </summary>
        /// <param name="html"><see cref="Stream"/> of HTML to be converted</param>
        /// <param name="options">The <see cref="PdfOptions"/> to configure PDF convertion</param>
        /// <returns>The <see cref="Task"/> that represents the asynchronous operation, containing a buffer of <paramref cref="byte"/> from pdf converted.</returns>
        Task<byte[]> ConvertAsync(Stream html, PdfOptions options);

        /// <summary>
        /// Convert HTML to PDF by setting <see name="options"/>
        /// </summary>
        /// <param name="html"><see cref="Stream"/> of HTML to be converted</param>
        /// <param name="options">The <see cref="PdfOptions"/> to configure PDF convertion</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Task"/> that represents the asynchronous operation, containing a buffer of <paramref cref="byte"/> from pdf converted.</returns>
        Task<byte[]> ConvertAsync(Stream html, PdfOptions options, CancellationToken cancellationToken);
    }
}
