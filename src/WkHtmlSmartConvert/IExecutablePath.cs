namespace WkHtmlSmartConvert
{
    /// <summary>
    /// A abstraction for an executable path of WkHtmlToPdf.
    /// </summary>
    public interface IExecutablePath
    {
        /// <summary>
        /// Path of executable
        /// </summary>
        /// <returns>The path</returns>
        string Path { get; }
    }
}
