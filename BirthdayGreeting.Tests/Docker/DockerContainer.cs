using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace BirthdayGreetings.Tests.Docker
{
    public class DockerContainer
    {
        public DockerRunParams Parameters { get; }
        private readonly ProcessStartInfo _processInfo;
        private readonly string _dockerExecutable;
        private string _containerId;

        public DockerContainer(DockerRunParams parameters)
        {
            Parameters = parameters;
            _containerId = string.Empty;
            _dockerExecutable = GetPath("docker.exe");
            _processInfo = new ProcessStartInfo(_dockerExecutable, parameters.Get())
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
        }

        public void Run()
        {
            var process = Process.Start(_processInfo);
            process?.WaitForExit();
            _containerId = process?.StandardOutput.ReadLine() ?? string.Empty;
        }

        public void Stop()
        {
            ProcessStartInfo info = new ProcessStartInfo(_dockerExecutable, $"rm -f {_containerId}")
            {
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(info)?.WaitForExit();
        }

        private string GetPath(string executableName) =>
            Environment.GetEnvironmentVariable("PATH")
                ?.Split(';')
                .Select(x => Path.Combine(x, executableName))
                .FirstOrDefault(File.Exists)
            ?? string.Empty;
    }
}