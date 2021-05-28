using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

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
            var arguments = parameters.Get();
            _processInfo = new ProcessStartInfo(_dockerExecutable, arguments)
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

        public string Log()
        {
            ProcessStartInfo info = new ProcessStartInfo(_dockerExecutable, $"logs {_containerId}")
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            var process = Process.Start(info);
            while (!process?.HasExited ?? false)
            {
                Thread.Sleep(10);
            }
            
            StringBuilder output = new StringBuilder(process?.StandardOutput.ReadToEnd());
            output.Append(process?.StandardError.ReadToEnd());
            process?.WaitForExit();
            return output.ToString();
        }

        private string GetPath(string executableName) =>
            Environment.GetEnvironmentVariable("PATH")
                ?.Split(';')
                .Select(x => Path.Combine(x, executableName))
                .FirstOrDefault(File.Exists)
            ?? string.Empty;

        public void WaitForLog(string logValue, int times = 1, long timeout = 60000)
        {
            var totalSleep = 0;
            var attempRetrySleep = 100;
            while (!ContainsTimes(logValue, times) || totalSleep > timeout)
            {
                Thread.Sleep(attempRetrySleep);
                totalSleep += attempRetrySleep;
            }
        }

        private bool ContainsTimes(string logValue, int times) => 
            Log()
                .Split('\n')
                .Count(line => line.Contains(logValue)) == times;
    }
}