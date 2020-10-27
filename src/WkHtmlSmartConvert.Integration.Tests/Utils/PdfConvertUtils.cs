using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace WkHtmlSmartConvert.Integration.Tests.Utils
{
    internal static class PdfConvertUtils
    {
        public static IPdfConvert Create()
        {
            var services = new ServiceCollection();
            services.AddWkHtmlSmartConvert().AddPdf();
            return services.BuildServiceProvider().GetService<IPdfConvert>();
        }

        public static IPdfConvert Create(Action<PdfOptions> options)
        {
            var services = new ServiceCollection();
            services.AddWkHtmlSmartConvert().AddPdf(options);
            services.AddLogging(options =>
            {
                options.AddDebug();
                options.AddConsole();
            });
            return services.BuildServiceProvider().GetService<IPdfConvert>();
        }

        public static void DeleteTempDirectory()
        {
            var path = Path.Combine(Path.GetTempPath(), "WkhtmlToPdf");
            if (Directory.Exists(path)) Directory.Delete(path, true);
        }
    }
}
