using Microsoft.Extensions.DependencyInjection.Extensions;
using WkHtmlSmartConvert;
using WkHtmlSmartConvert.Internal;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class WkHtmlSmartConvertDependencyInjectionExtensions
    {
        /// <summary>
        /// Adds the minimum essential WkHtmlSmartConvert services to the specified <see cref="IServiceCollection" />. Additional services
        /// must be added separately using the <see cref="IWkHtmlSmartConvertBuilder"/> returned from this method.
        /// </summary>
        /// <remarks>
        /// By default environment variable PATH is use to find executable wkhtmltopdf
        /// </remarks>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <returns>An <see cref="IWkHtmlSmartConvertBuilder"/> that can be used to further configure the additional components.</returns>
        public static IWkHtmlSmartConvertBuilder AddWkHtmlSmartConvert(this IServiceCollection services)
        {
            var builder = new DefaultWkHtmlSmartConvertBuilder(services);
            builder.Services.TryAddSingleton<IExecutablePath, EmptyExecutablePath>();
            return builder;
        }
    }
}
