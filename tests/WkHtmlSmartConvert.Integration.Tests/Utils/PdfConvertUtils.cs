using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace WkHtmlSmartConvert.Integration.Tests.Utils
{
    internal static class PdfConvertUtils
    {
        public static IPdfConvert CreateWithAddEmbedded()
        {
            var services = new ServiceCollection();
            services.AddWkHtmlSmartConvert().AddPdf().AddEmbedded();
            return services.BuildServiceProvider().GetService<IPdfConvert>();
        }

        public static IPdfConvert CreateWithAddEmbedded(Action<PdfOptions> options)
        {
            var services = new ServiceCollection();
            services.AddWkHtmlSmartConvert().AddEmbedded().AddPdf(options);
            return services.BuildServiceProvider().GetService<IPdfConvert>();
        }

        public static IPdfConvert Create()
        {
            var services = new ServiceCollection();
            services.AddWkHtmlSmartConvert().AddPdf();
            return services.BuildServiceProvider().GetService<IPdfConvert>();
        }

        public static void DeleteTempDirectory()
        {
            var path = Path.Combine(Path.GetTempPath(), "WkhtmlToPdf");
            if (Directory.Exists(path)) Directory.Delete(path, true);
        }
    }
}
