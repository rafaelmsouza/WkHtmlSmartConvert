using WkHtmlSmartConvert.Internal;

namespace WkHtmlSmartConvert
{
    /// <summary>
    /// A definition to configure of page's margins
    /// </summary>
    public struct Margins : ICommandLineParameter
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
        /// Set the page top margin
        /// </summary>
        [CommandLine("-T")]
        public int? Top { get; set; }

        /// <summary>
        /// Set the page right margin (default 10mm)
        /// </summary>
        [CommandLine("-R")]
        public int? Right { get; set; }

        /// <summary>
        /// Set the page bottom margin
        /// </summary>
        [CommandLine("-B")]
        public int? Bottom { get; set; }

        /// <summary>
        /// Set the page left margin (default 10mm)
        /// </summary>
        [CommandLine("-L")]
        public int? Left { get; set; }

        public override string ToString()
        {
            return this.ToCommandLineParameters();
        }
    }
}
