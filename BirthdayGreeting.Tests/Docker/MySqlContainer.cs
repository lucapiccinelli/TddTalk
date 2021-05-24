using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;

namespace BirthdayGreetings.Tests.Docker
{
    class MySqlContainer
    {
        private readonly string _currentDirectory;
        private int _externalPort;
        private DockerContainer _container;

        public MySqlContainer()
        {
            _currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "./";
            var logFilename = $"mySql.log";
            _externalPort = 3306;

            string version = "0.0.21-SNAPSHOT";
            DockerRunParams parameters = new DockerRunParams()
                .AddParam($"-p {_externalPort}:3306")
                .AddParam($"--env MYSQL_ROOT_PASSWORD=sa")
                .AddParam("-d")
                .AddParam($"mysql");
            _container = new DockerContainer(parameters);
        }

        public void Start()
        {
            _container.Run();
            Thread.Sleep(30000);
        }

        public void Stop()
        {
            _container.Stop();
        }
    }
}
