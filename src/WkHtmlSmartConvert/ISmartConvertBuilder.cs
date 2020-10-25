using Microsoft.Extensions.DependencyInjection;

namespace WkHtmlSmartConvert
{
    /// <summary>
    /// A builder abstraction for configuring WkHtmlSmartConvert.
    /// </summary>
    public interface IWkHtmlSmartConvertBuilder
    {
        /// <summary>
        /// Gets the builder service collection.
        /// </summary>
        IServiceCollection Services { get; }
    }
}
