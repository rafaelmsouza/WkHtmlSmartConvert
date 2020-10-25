using WkHtmlSmartConvert.Internal;
using System;

namespace WkHtmlSmartConvert
{
    public sealed class PdfOptions : ICommandLineParameter
    {
        /// <summary>
        ///  Change the dpi explicitly (this has no effect on X11 based systems) (default 96)
        /// </summary>
        [CommandLine("--dpi")]
        public int Dpi { get; set; } = 96;

        /// <summary>
        /// PDF will be generated in grayscale
        /// </summary>
        [CommandLine("--grayscale")]
        public bool IsGrayScale { get; set; }

        /// <summary>
        /// When embedding images scale them down to this dpi(default 600)
        /// </summary>
        [CommandLine("--image-dpi")]
        public int ImageDpi { get; set; } = 600;

        /// <summary>
        /// When embedding images scale them down to this dpi(default 600)
        /// </summary>
        [CommandLine("--image-quality")]
        public int ImageQuality { get; set; } = 94;

        /// <summary>
        /// Set log level to: none, error, warn or info (default info)
        /// </summary>
        [CommandLine("--log-level")]
        public LogLevel LogLevel { get; set; } = LogLevel.Info;

        /// <summary>
        /// Indicates whether the PDF should be generated in lower quality.
        /// </summary>
        [CommandLine("--lowquality")]
        public bool IsLowQuality { get; set; }

        /// <summary>
        /// Sets the page width in mm.
        /// </summary>
        /// <remarks>Has priority over <see cref="PageSize"/> but <see cref="Height"/> has to be also specified.</remarks>
        [CommandLine("--no-pdf-compression")]
        public bool IsNoCompression { get; set; }

        /// <summary>
        /// Number of copies to print into the pdf file (default 1)
        /// </summary>
        [CommandLine("--copies")]
        public int Copies { get; set; } = 1;

        /// <summary>
        /// Set paper size to: A4, Letter, etc. (default A4)
        /// </summary>
        [CommandLine("--page-size")]
        public PageSize PageSize { get; set; } = PageSize.A4;

        /// <summary>
        /// Set orientation to Landscape or Portrait (default Portrait)
        /// </summary>
        [CommandLine("--orientation")]
        public PageOrientation PageOrientation { get; set; } = PageOrientation.Portrait;

        /// <summary>
        /// Sets the page height in mm.
        /// </summary>
        /// <remarks>Has priority over <see cref="PageSize"/> but <see cref="Width"/> has to be also specified.</remarks>
        [CommandLine("--page-height")]
        public double? Height { get; set; }

        /// <summary>
        /// Sets the page width in mm.
        /// </summary>
        /// <remarks>Has priority over <see cref="PageSize"/> but <see cref="Height"/> has to be also specified.</remarks>
        [CommandLine("--page-width")]
        public double? Width { get; set; }

        /// <summary>
        /// Sets the page margins.
        /// </summary>
        public Margins Margins { get; set; }

        public override string ToString()
        {
            return this.ToCommandLineParameters();
        }
    }
}
