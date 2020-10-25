using WkHtmlSmartConvert;
using WkHtmlSmartConvert.Internal;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

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
        /// <param name="WkHtmlSmartConvertBuilder">The <see cref="IWkHtmlSmartConvertBuilder"/>.</param>
        /// <param name="configure">A callback to configure the options.</param>
        /// <returns>The same instance of the <see cref="IWkHtmlSmartConvertBuilder"/> for chaining.</returns>
        public static IWkHtmlSmartConvertBuilder AddPdf(this IWkHtmlSmartConvertBuilder WkHtmlSmartConvertBuilder, Action<object> configure)
        {
            if (configure == null) throw new ArgumentNullException(nameof(configure));

            WkHtmlSmartConvertBuilder.Services.Configure(configure);
            WkHtmlSmartConvertBuilder.Services.TryAddSingleton<IPdfConvert, DefaultPdfConvert>();
            return WkHtmlSmartConvertBuilder;
        }
    }
}
