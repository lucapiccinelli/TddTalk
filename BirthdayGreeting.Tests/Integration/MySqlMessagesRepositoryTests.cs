using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BirthdayGreetings.Domain.Doors;
using BirthdayGreetings.Domain.Model;
using BirthdayGreetings.Doors.Repositories.Entity;
using BirthdayGreetings.Doors.Repositories.Entity.Entities;
using BirthdayGreetings.Tests.Docker;
using BirthdayGreetings.Tests.Helpers;
using Xunit;

namespace BirthdayGreetings.Tests.Integration
{
    public class MySqlMessagesRepositoryTestsFixture : IDisposable
    {
        private readonly MySqlContainer _mySql;

        public MySqlMessagesRepositoryTestsFixture()
        {
            _mySql = new MySqlContainer();
            _mySql.Start();
        }

        public void Dispose()
        {
            _mySql.Stop();
        }
    }

    public class MySqlMessagesRepositoryTests : IClassFixture<MySqlMessagesRepositoryTestsFixture>
    {
        [Fact]
        void CanReadMessagesFromDb()
        {
            PopulateDb(() =>
            {
                EfBirthdayMessagesRepository repository = new EfBirthdayMessagesRepository();

                List<BirthdayMessage> expectedBirthdayMessages = new List<BirthdayMessage>
                {
                    new BirthdayMessage(TestEmployees.John.Name),
                    new BirthdayMessage(TestEmployees.Mary.Name)
                };

                List<BirthdayMessage> actualBirthdayMessages = repository.ReadAll();
                Assert.Equal(expectedBirthdayMessages, actualBirthdayMessages);
            });
        }
        
        [Fact]
        void CanSaveMessagesInDb()
        {
            EfBirthdayMessagesRepository repository = new EfBirthdayMessagesRepository();
            var expectedMessage = new BirthdayMessage(new Name("Foo", "Bar"));
            repository.New(expectedMessage);

            var newMessage = repository.ReadAll().First();

            Assert.Equal(expectedMessage, newMessage);
        }

        private static void PopulateDb(Action test)
        {
            BirthdayDbContext _dbContext = new BirthdayDbContext();
            _dbContext.Migrate();
            _dbContext.Add(new BirthdayMessageEntity
            {
                Firstname = TestEmployees.John.Name.Firstname,
                Lastname = TestEmployees.John.Name.Lastname,
            });
            _dbContext.Add(new BirthdayMessageEntity
            {
                Firstname = TestEmployees.Mary.Name.Firstname,
                Lastname = TestEmployees.Mary.Name.Lastname,
            });
            _dbContext.SaveChanges();

            test();

            var allMessages = _dbContext.BirthdayMessages
                .Select(entity => entity).ToList();
            _dbContext.RemoveRange(allMessages);
            _dbContext.SaveChanges();
        }
    }
}
