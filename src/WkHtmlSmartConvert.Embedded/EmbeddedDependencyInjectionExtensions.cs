using WkHtmlSmartConvert;
using WkHtmlSmartConvert.Embedded.Internal;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for <see cref="IWkHtmlSmartConvertBuilder"/>.
    /// </summary>
    public static class EmbeddedDependencyInjectionExtensions
    {
        /// <summary>
        /// Adds wkhtmltopdf dependencies to a <see cref="IWkHtmlSmartConvertBuilder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IWkHtmlSmartConvertBuilder"/>.</param>
        /// <returns>The same instance of the <see cref="IWkHtmlSmartConvertBuilder"/> for chaining.</returns>
        public static IWkHtmlSmartConvertBuilder AddEmbedded(this IWkHtmlSmartConvertBuilder builder)
        {
            builder.Services.AddSingleton<IExecutablePath, RuntimeFolderExecutablePath>();
            return builder;
        }
    }
}
