using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace WkHtmlSmartConvert.Internal
{
    internal abstract class ExternalProcess
    {
        private readonly string _executableName;

        public ExternalProcess(string executableName)
        {
            _executableName = executableName;
        }

        protected async Task StartAsync(string arguments, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                var path = GetExecutablePath();
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo(path, arguments)
                    {
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    }
                };

                process.Start();
                process.WaitForExit();
            }, cancellationToken);
        }

        protected async Task SaveFileInTempFolderAsync(Stream inputStream, string pathFile)
        {
            var fileInfo = new FileInfo(pathFile);
            if (!fileInfo.Directory.Exists) fileInfo.Directory.Create();

            using var fileStream = new FileStream(pathFile, FileMode.CreateNew);
            await inputStream.CopyToAsync(fileStream);
        }

        private string GetExecutablePath() =>
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "runtimes", GetExecutableByOSPlatform());

        private string GetExecutableByOSPlatform()
        {
            if (!Environment.Is64BitOperatingSystem) throw new NotSupportedException("Operation System x86 not suported");

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Path.Combine("win-x64", "native",  $"{_executableName}.exe");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return Path.Combine("linux-x64", "native", _executableName);
            }
            throw new NotSupportedException("Operation System not suported");
        }
    }
}