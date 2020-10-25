using Microsoft.Extensions.DependencyInjection;

namespace WkHtmlSmartConvert.Internal
{
    internal class DefaultWkHtmlSmartConvertBuilder : IWkHtmlSmartConvertBuilder
    {
        public DefaultWkHtmlSmartConvertBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}
