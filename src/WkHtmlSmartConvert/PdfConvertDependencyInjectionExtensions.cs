using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using WkHtmlSmartConvert;
using WkHtmlSmartConvert.Internal;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for <see cref="IWkHtmlSmartConvertBuilder"/>.
    /// </summary>
    public static class PdfConvertDependencyInjectionExtensions
    {
        /// <summary>
        /// Adds PDF Convert to a <see cref="IWkHtmlSmartConvertBuilder"/>.
        /// </summary>
        /// <param name="WkHtmlSmartConvertBuilder">The <see cref="IWkHtmlSmartConvertBuilder"/>.</param>
        /// <returns>The same instance of the <see cref="IWkHtmlSmartConvertBuilder"/> for chaining.</returns>
        public static IWkHtmlSmartConvertBuilder AddPdf(this IWkHtmlSmartConvertBuilder WkHtmlSmartConvertBuilder)
        {
            return AddPdf(WkHtmlSmartConvertBuilder, o => { });
        }

        /// <summary>
        /// Adds PDF Convert to a <see cref="IWkHtmlSmartConvertBuilder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IWkHtmlSmartConvertBuilder"/>.</param>
        /// <param name="configure">A callback to configure the options when is not pass to convert method.</param>
        /// <returns>The same instance of the <see cref="IWkHtmlSmartConvertBuilder"/> for chaining.</returns>
        public static IWkHtmlSmartConvertBuilder AddPdf(this IWkHtmlSmartConvertBuilder builder, Action<PdfOptions> configure)
        {
            if (configure == null) throw new ArgumentNullException(nameof(configure));

            builder.Services.Configure(configure);
            builder.Services.TryAddSingleton<IPdfConvert, DefaultPdfConvert>();
            return builder;
        }
    }
}
