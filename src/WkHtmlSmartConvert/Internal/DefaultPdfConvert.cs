using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WkHtmlSmartConvert.Internal
{
    internal class DefaultPdfConvert : ExternalProcess, IPdfConvert
    {
        private readonly PdfOptions _defaultOptions;

        public DefaultPdfConvert(IExecutablePath executablePath, IOptions<PdfOptions> options) 
            : base(executablePath, "wkhtmltopdf")
        {
            _defaultOptions = options.Value;
        }

        public async Task<byte[]> ConvertAsync(string html)
        {
            return await ConvertAsync(html, CancellationToken.None);
        }

        public async Task<byte[]> ConvertAsync(string html, CancellationToken cancellationToken)
        {
            return await ConvertAsync(html, _defaultOptions, cancellationToken);
        }

        public async Task<byte[]> ConvertAsync(string html, PdfOptions options)
        {
            return await ConvertAsync(html, options, CancellationToken.None);
        }

        public async Task<byte[]> ConvertAsync(string html, PdfOptions options, CancellationToken cancellationToken)
        {
            if (html == null) throw new ArgumentNullException(nameof(html));

            using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(html));
            return await ConvertAsync(memoryStream, options, cancellationToken);
        }

        public async Task<byte[]> ConvertAsync(Stream html)
        {
            return await ConvertAsync(html, _defaultOptions);
        }

        public async Task<byte[]> ConvertAsync(Stream html, PdfOptions options)
        {
            return await ConvertAsync(html, options, CancellationToken.None);
        }

        public async Task<byte[]> ConvertAsync(Stream html, PdfOptions options, CancellationToken cancellationToken)
        {
            if (html == null) throw new ArgumentNullException(nameof(html));
            if (options == null) throw new ArgumentNullException(nameof(options));

            cancellationToken.ThrowIfCancellationRequested();

            var baseFileName = Path.Combine(Path.GetTempPath(), "WkhtmlToPdf", Guid.NewGuid().ToString());
            var htmlFileName = $"{baseFileName}.html";
            var pdfFileName = $"{baseFileName}.pdf";
            var arguments = $"{options} {htmlFileName} {pdfFileName}";

            await SaveFileInTempFolderAsync(html, htmlFileName);
            await StartAsync(arguments, cancellationToken);

            var resultBuffer = await File.ReadAllBytesAsync(pdfFileName, cancellationToken);

            File.Delete(htmlFileName);
            File.Delete(pdfFileName);

            return resultBuffer;
        }
    }
}
