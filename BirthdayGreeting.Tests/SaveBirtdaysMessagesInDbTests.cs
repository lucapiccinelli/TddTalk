using System;
using System.Collections.Generic;
using BirthdayGreetings.Domain.Doors;
using BirthdayGreetings.Domain.Model;
using BirthdayGreetings.Domain.Usecases;
using BirthdayGreetings.Doors.Repositories;
using BirthdayGreetings.Tests.Helpers;
using Moq;
using Xunit;

namespace BirthdayGreetings.Tests
{
    public class SaveBirtdaysMessagesInDbTests
    {
        private readonly Mock<IRepository<Employee>> _employeesRepository = new Mock<IRepository<Employee>>();

        public SaveBirtdaysMessagesInDbTests()
        {
            _employeesRepository
                .Setup(repository => repository.ReadAll())
                .Returns(TestEmployees.TestList);
        }

        [Fact]
        public void GIVEN_AListOfEmployees_FromACsvFile_ItSavesBirthdaysMessages()
        {
            var service = new BirthdayStoreService(_employeesRepository.Object, new InMemoryBirthdayMessagesRepository());
            service.SaveMessages(TestEmployees.John.DateOfBirth);

            List<BirthdayMessage> expectedMessages = new List<BirthdayMessage>
            {
                new BirthdayMessage(TestEmployees.John.Name)
            };

            List<BirthdayMessage> actualMessages = service.FetchSavedMessages();
            Assert.Equal(expectedMessages, actualMessages);
        }

        [Fact]
        public void SavingAMessageASecondTime_Preserves_TheFirst()
        {
            var service = new BirthdayStoreService(_employeesRepository.Object, new InMemoryBirthdayMessagesRepository());
            service.SaveMessages(TestEmployees.John.DateOfBirth);
            service.SaveMessages(new DateTime(2021, 5, 24));

            List<BirthdayMessage> expectedMessages = new List<BirthdayMessage>
            {
                new BirthdayMessage(TestEmployees.John.Name)
            };

            List<BirthdayMessage> actualMessages = service.FetchSavedMessages();
            Assert.Equal(expectedMessages, actualMessages);
        }

    }
}
