using WkHtmlSmartConvert.Internal;

namespace WkHtmlSmartConvert
{
    /// <summary>
    /// A definition to configure of page's margins
    /// </summary>
    public struct Margins
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Margins"/> class.
        /// Sets the page margins.
        /// </summary>
        /// <param name="top">Page top margin in mm.</param>
        /// <param name="right">Page right margin in mm.</param>
        /// <param name="bottom">Page bottom margin in mm.</param>
        /// <param name="left">Page left margin in mm.</param>
        public Margins(int top, int right, int bottom, int left)
        {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
        }

        /// <summary>
        /// Set the page bottom margin
        /// </summary>
        [CommandLineAttribute("-B")] 
        public int? Bottom;

        /// <summary>
        /// Set the page left margin (default 10mm)
        /// </summary>
        [CommandLineAttribute("-L")] 
        public int? Left;

        /// <summary>
        /// Set the page right margin (default 10mm)
        /// </summary>
        [CommandLineAttribute("-R")] 
        public int? Right;

        /// <summary>
        /// Set the page top margin
        /// </summary>
        [CommandLineAttribute("-T")] 
        public int? Top;
    }
}
