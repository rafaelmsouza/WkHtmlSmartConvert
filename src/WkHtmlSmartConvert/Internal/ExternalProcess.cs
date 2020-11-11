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
        private readonly IExecutablePath _executablePath;
        private readonly string _executableName;

        protected ExternalProcess(IExecutablePath executablePath, string executableName)
        {
            _executablePath = executablePath;
            _executableName = executableName;
        }

        protected async Task StartAsync(string arguments, CancellationToken cancellationToken)
        {
            await Task.Run(async () =>
            {
                var path = Path.Combine(_executablePath.Path, $"{_executableName}{GetExtetionFileByOSPlatform()}");
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo(path, arguments)
                    {
                        CreateNoWindow = true,
                        RedirectStandardError = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    }
                };

                process.Start();
                var standardError = await process.StandardError.ReadToEndAsync();
                process.WaitForExit();
                if (process.ExitCode != 0) throw new InvalidOperationException(standardError);
            }, cancellationToken);
        }

        protected async Task SaveFileInTempFolderAsync(Stream inputStream, string pathFile)
        {
            var fileInfo = new FileInfo(pathFile);
            if (!fileInfo.Directory.Exists) fileInfo.Directory.Create();

            using var fileStream = new FileStream(pathFile, FileMode.CreateNew);
            await inputStream.CopyToAsync(fileStream);
        }

        private string GetExtetionFileByOSPlatform()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? ".exe" : "";
        }
    }
}