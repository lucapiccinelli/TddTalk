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
        private readonly DockerContainer _container;
        private const string MySqlStartedString = "/usr/sbin/mysqld: ready for connections";

        public MySqlContainer()
        {
            var externalPort = 3306;

            DockerRunParams parameters = new DockerRunParams()
                .AddParam($"-p {externalPort}:3306")
                .AddParam($"--env MYSQL_ROOT_PASSWORD=sa")
                .AddParam($"--env MYSQL_DATABASE=Test")
                .AddParam("-d")
                .AddParam($"mysql");
            _container = new DockerContainer(parameters);
        }

        public void Start()
        {
            _container.Run();
            _container.WaitForLog(MySqlStartedString, times: 2);
        }

        public void Stop()
        {
            _container.Stop();
        }
    }
}
