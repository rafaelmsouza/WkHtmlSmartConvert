using System;
using System.Runtime.InteropServices;

namespace WkHtmlSmartConvert.Embedded.Internal
{
    internal class RuntimeFolderExecutablePath : IExecutablePath
    {
        public string Path => GetExecutablePath();

        private string GetExecutablePath() =>
            System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "runtimes", GetExecutableByOSPlatform(), "native");

        private string GetExecutableByOSPlatform()
        {
            if (!Environment.Is64BitOperatingSystem) throw new NotSupportedException("Operation System x86 not suported");

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return "win-x64";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return "linux-x64";
            }
            throw new NotSupportedException("Operation System not suported");
        }
    }
}
